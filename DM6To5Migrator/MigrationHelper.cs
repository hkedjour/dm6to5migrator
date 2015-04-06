using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Hummingbird.DM.Server.Interop.PCDClient;

namespace DM6To5Migrator
{
    public partial class MigrationHelper
    {
        private Settings _settings;

        public MigrationHelper(Settings settings)
        {
            _settings = settings;
        }

        public void RunAllTests()
        {
            Logger.WriteLine("Starting simulation...");
            TestSouceFilesAccess();
            CheckCustomFields();
            ConnectToDestLib();
            if (GetDefaultDocumentTypeId() == null)
                Logger.WriteLine("Impossible de trouver le type de document par défaut dans la destination");
        }

        /// <summary>
        /// Check the supplied credentials for the library
        /// </summary>
        private void ConnectToDestLib()
        {
            var login = new PCDLogin();

            login.AddLogin(0, _settings.DestLibName, _settings.DestLibUser, _settings.DestLibPass);
            login.Execute();

            if (login.ErrNumber != 0)
                Logger.WriteLine("Impossible de se connecter à la bibliothèque de destination  : " +
                                 login.ErrDescription);

        }

        /// <summary>
        /// Test if source files exist in the disk (ie:we provided the right path)
        /// </summary>
        private void TestSouceFilesAccess()
        {
            Logger.WriteLine("Testing access to source files");

            using (var cn = new SqlConnection(_settings.GetSrcSqlConnectionString()))
            {
                var cmd = new SqlCommand("select p.PATH + c.PATH as PATH, p.DOCNAME from DOCSADM.COMPONENTS c "
                                         + "inner join DOCSADM.PROFILE p on c.DOCNUMBER = p.DOCNUMBER", cn);

                cn.Open();

                var foundAll = true;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var path = (string)reader["PATH"];
                        var name = (string)reader["DOCNAME"];

                        var fullPath = _settings.SrcLibRootFolder + path;

                        //Logger.WriteLine("checking {0}", fullPath);

                        if (!File.Exists(fullPath))
                        {
                            foundAll = false;
                            Logger.WriteLine("File \"{0}\" not found", fullPath);
                        }
                    }
                }

                Logger.WriteLine(foundAll ? "All files are found" : "Not all files are found");
            }
        }

        /// <summary>
        /// Test if the target library contain all custom fields (ie:both source and target have the same database schema)
        /// </summary>
        private void CheckCustomFields()
        {
            Logger.WriteLine("Checking custom fields");

            var srcCustomFields = GetSrcLibCustomFields();
            var destFilds = GetProfileTableColumns(_settings.GetDestSqlConnectionString());

            srcCustomFields.Where(c => !destFilds.Contains(c, StringComparer.InvariantCultureIgnoreCase))
                .ToList()
                .ForEach(c => Logger.WriteLine("La champ \"{0}\" n'a pas été trouvé dans la destination", c));

        }

        /// <summary>
        /// Rerturns the custom fields added to the profile table
        /// </summary>
        /// <returns></returns>
        List<string> GetSrcLibCustomFields()
        {
            var cols = GetProfileTableColumns(_settings.GetSrcSqlConnectionString());
            return cols.Where(c => !defaultDM6ProfileColumns.Contains(c, StringComparer.InvariantCultureIgnoreCase))
                .ToList();
        }

        /// <summary>
        /// Return Profile table columns
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private List<string> GetProfileTableColumns(string connectionString)
        {
            var cols = new List<string>();
            using (var cn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("select COLUMN_NAME from information_schema.columns"
                                         + " where table_name='PROFILE' and table_schema='DOCSADM'", cn);

                cn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cols.Add((string) reader["COLUMN_NAME"]);
                    }
                }

                return cols;
            }
        }

        /// <summary>
        /// returns "DEFAULT" for english library and "PAR DEFAUT" for french one
        /// null for known language
        /// </summary>
        /// <returns></returns>
        private string GetDefaultDocumentTypeId()
        {
            var enSql = "select count(*) from [DOCSADM].[DOCUMENTTYPES] where TYPE_ID = 'DEFAULT'";
            var frSql = "select count(*) from [DOCSADM].[DOCUMENTTYPES] where TYPE_ID = 'PAR DÉFAUT'";

            using (var cn = new SqlConnection(_settings.GetDestSqlConnectionString()))
            {
                cn.Open();

                var cmd = new SqlCommand(enSql, cn);
                if (Convert.ToInt32(cmd.ExecuteScalar()) == 1)
                    return "DEFAULT";

                cmd.CommandText = frSql;
                if (Convert.ToInt32(cmd.ExecuteScalar()) == 1)
                    return "PAR DÉFAUT";

                return null;
            }
        }

        private List<string> _srcLibCustomFields;
        private static string _defaultDocType;

        public void StartMigration(object sender, DoWorkEventArgs e)
        {
            Logger.WriteLine("Démarrage de la migration (seul les érreurs seront affichées ici)");

            var migratinBgWorker = (BackgroundWorker) e.Argument;

            _srcLibCustomFields = GetSrcLibCustomFields();
            _defaultDocType = GetDefaultDocumentTypeId();

            var docIds = new List<int>();

            using (var cn = new SqlConnection(_settings.GetSrcSqlConnectionString()))
            {
                var cmd = new SqlCommand("select DOCNUMBER from [DOCSADM].PROFILE", cn);

                cn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        docIds.Add((int)reader[0]);
                    }
                }
            }

            for (var i = 0; i < docIds.Count; i++)
            {
                try
                {
                    MigrateProfile(docIds[i]);
                }
                catch (Exception exception)
                {
                    Logger.WriteLine("Error lors de la migratin du doc n°{0} - {1}", docIds[i], exception.Message);
                }

                migratinBgWorker.ReportProgress(i + 1);

                if (migratinBgWorker.CancellationPending)
                {
                    e.Cancel = true;
                    migratinBgWorker.ReportProgress(0);
                    return;
                }
            }
        }

        private void MigrateProfile(int docNumber)
        {
            var login = new PCDLogin();

            login.AddLogin(0, _settings.DestLibName, _settings.DestLibUser, _settings.DestLibPass);
            login.Execute();

            var dst = login.GetDST();

            // read profile from source
            var profile = new ProfileInfo();
            profile.ReadSourceProfile(_settings.GetSrcSqlConnectionString(), docNumber, _srcLibCustomFields);


            // Create new profile
            var objDoc = new PCDDocObject();
            objDoc.SetProperty("%TARGET_LIBRARY", _settings.DestLibName);
            objDoc.SetDST(dst);

            objDoc.SetObjectType(_settings.DestLibDefaultProfile);
            profile.SetDocProperties(objDoc);
            objDoc.Create();

            CheckError(objDoc);

            int newDocNbr = objDoc.GetReturnProperty("%OBJECT_IDENTIFIER");
            int newDocVersionId = objDoc.GetReturnProperty("%VERSION_ID");

            // loading files

            var pdfFilePath = GetPdfFilePath(docNumber);

            if (pdfFilePath != null && File.Exists(pdfFilePath))
            {
                UploadFileToLibrary(dst, newDocNbr.ToString(CultureInfo.InvariantCulture),
                    newDocVersionId.ToString(CultureInfo.InvariantCulture), pdfFilePath);
                
            }

            var txtFilePath = GetTxtFilePath(docNumber);

            if (txtFilePath != null && File.Exists(txtFilePath))
            {
                objDoc = new PCDDocObject();
                objDoc.SetDST(dst);
                objDoc.SetObjectType(_settings.DestLibDefaultProfile);
                objDoc.SetProperty("%TARGET_LIBRARY", _settings.DestLibName);
                objDoc.SetProperty("%OBJECT_IDENTIFIER", newDocNbr);
                objDoc.SetProperty("%VERSION_ID", newDocVersionId);

                objDoc.Fetch();

                if (objDoc.ErrNumber == 0)
                {
                    objDoc.SetProperty("%VERSION_DIRECTIVE", "%ADD_ATTACHMENT");
                    objDoc.SetProperty("%ATTACHMENT_ID", "TXT");
                    objDoc.SetProperty("%VERSION_COMMENT", "Ajouté par l'Outil d'Archivage Electronique");

                    objDoc.Update();
                    if (objDoc.ErrNumber == 0)
                    {
                        int vId = objDoc.GetReturnProperty("%VERSION_ID");

                        UploadFileToLibrary(dst, newDocNbr.ToString(CultureInfo.InvariantCulture),
                            vId.ToString(CultureInfo.InvariantCulture), txtFilePath);
                    }
                }
            }


            objDoc = new PCDDocObject();
            objDoc.SetDST(dst);
            objDoc.SetObjectType(_settings.DestLibDefaultProfile);
            objDoc.SetProperty("%TARGET_LIBRARY", _settings.DestLibName);
            objDoc.SetProperty("%OBJECT_IDENTIFIER", newDocNbr);
            objDoc.SetProperty("%VERSION_ID", newDocVersionId);
            objDoc.SetProperty("%STATUS", "%UNLOCK");

            objDoc.Update();

            CheckError(objDoc);
        }

        /// <summary>
        /// Convert COM error to exception
        /// </summary>
        /// <param name="pcdObject"></param>
        public void CheckError(dynamic pcdObject)
        {
            if (pcdObject.ErrNumber != 0)
                throw new Exception(pcdObject.ErrDescription);
        }

        void UploadFileToLibrary(string dst, string docNbr, string versionId, string filePath)
        {
            var objPutDoc = new PCDPutDoc();
            objPutDoc.SetDST(dst);
            objPutDoc.AddSearchCriteria("%TARGET_LIBRARY", _settings.DestLibName);
            objPutDoc.AddSearchCriteria("%DOCUMENT_NUMBER", docNbr);
            objPutDoc.AddSearchCriteria("%VERSION_ID", versionId);

            objPutDoc.Execute();

            CheckError(objPutDoc);

            objPutDoc.NextRow();

            PCDPutStream objPutStream = objPutDoc.GetPropertyValue("%CONTENT");

            var buffer = new byte[1024*1024]; // 1mb buffer

            using (var stream = File.OpenRead(filePath))
            {
                int read = 0;
                while ((read = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    int writenbytes;
                    objPutStream.Write(buffer, read, out writenbytes);
                }
            }

            CheckError(objPutStream);

            objPutStream.SetComplete();
            CheckError(objPutStream);
        }

        /// <summary>
        /// Extract the PDF file path from the original DB
        /// </summary>
        /// <param name="docNumber"></param>
        /// <returns></returns>
        public string GetPdfFilePath(int docNumber)
        {
            var cmdTxt = "select p.PATH + c.PATH as PATH  from DOCSADM.COMPONENTS c "
                         + "inner join DOCSADM.PROFILE p on c.DOCNUMBER = p.DOCNUMBER and c.DOCNUMBER = " + docNumber
                         + " inner join DOCSADM.VERSIONS v on c.VERSION_ID = v.VERSION_ID and VERSION_LABEL <> 'TXT'";

            using (var cn = new SqlConnection(_settings.GetSrcSqlConnectionString()))
            {
                var cmd = new SqlCommand(cmdTxt, cn);

                cn.Open();

                var path = (string) cmd.ExecuteScalar();
                return path == null ? null : _settings.SrcLibRootFolder + path;
            }
        }


        /// <summary>
        /// Extract the TXT file path from the library
        /// </summary>
        /// <param name="docNumber"></param>
        /// <returns></returns>
        public string GetTxtFilePath(int docNumber)
        {
            var cmdTxt = "select p.PATH + c.PATH as PATH  from DOCSADM.COMPONENTS c "
                         + "inner join DOCSADM.PROFILE p on c.DOCNUMBER = p.DOCNUMBER and c.DOCNUMBER = " + docNumber
                         + " inner join DOCSADM.VERSIONS v on c.VERSION_ID = v.VERSION_ID and VERSION_LABEL = 'TXT'";

            using (var cn = new SqlConnection(_settings.GetSrcSqlConnectionString()))
            {
                var cmd = new SqlCommand(cmdTxt, cn);

                cn.Open();

                var path = (string) cmd.ExecuteScalar();
                return path == null ? null : _settings.SrcLibRootFolder + path;
            }
        }

        class ProfileInfo
        {
            public Dictionary<string, object> Values { get; set; }

            public ProfileInfo()
            {
                Values = new Dictionary<string, object>();
            }

            public void ReadSourceProfile(string connectionString, int docNumber, List<string> customFields)
            {
                var cmdTxt = "select [DOCNAME],"
                             + "peo.[USER_ID] as TYPIST_ID,"
                             + "peo.[USER_ID] as AUTHOR_ID,"
                             + "dt.TYPE_ID as TYPE_ID,"
                             + "app.APPLICATION as APP_ID,"
                             + "[ABSTRACT],"
                             + "[PATH]"
                             + (customFields.Count == 0 ? "" : ", p." + string.Join(", p.", customFields))
                             + " from docsadm.profile p"
                             + "	inner join docsadm.PEOPLE peo on p.AUTHOR = peo.SYSTEM_ID"
                             + "	inner join docsadm.PEOPLE peot on p.AUTHOR = peot.SYSTEM_ID"
                             + "	inner join [DOCSADM].[DOCUMENTTYPES] dt on p.DOCUMENTTYPE = dt.SYSTEM_ID"
                             + "	inner join [DOCSADM].[APPS] app on p.APPLICATION = app.SYSTEM_ID"
                             + "	WHERE DOCNUMBER=" + docNumber;

                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand(cmdTxt, cn);

                    cn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        Values["DOCNAME"] = reader["DOCNAME"];
                        Values["TYPIST_ID"] = reader["TYPIST_ID"];
                        Values["AUTHOR_ID"] = reader["AUTHOR_ID"];
                        var docType = Convert.ToString(reader["TYPE_ID"]);
                        Values["TYPE_ID"] = docType == "DEFAULT" || docType == "PAR DÉFAUT" ? _defaultDocType : docType;
                        Values["APP_ID"] = reader["APP_ID"];
                        Values["ABSTRACT"] = reader["ABSTRACT"];
                        Values["PATH"] = reader["PATH"];
                        foreach (var field in customFields)
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal(field)))
                                Values[field] = reader[field];
                        }
                    }
                }
            }

            public void SetDocProperties(PCDDocObject objDoc)
            {
                foreach (var value in Values.Where(v => v.Value != null && v.Key != "PATH"))
                {
                    objDoc.SetProperty(value.Key, value.Value);
                }
            }
        }
    }
}