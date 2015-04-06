using System.Data.SqlClient;

namespace DM6To5Migrator
{
    public class Settings
    {
        public string SrcSqlHost;
        public string SrcSqlUser;
        public string SrcSqlPassword;
        public string SrcSqlDbName;

        public string SrcLibRootFolder;

        public string DestSqlHost;
        public string DestSqlUser;
        public string DestSqlPassword;
        public string DestSqlDbName;

        public string DestLibName;
        public string DestLibUser;
        public string DestLibPass;
        public string DestLibDefaultProfile;

        public string GetSrcSqlConnectionString()
        {
            return new SqlConnectionStringBuilder
            {
                ApplicationName = "DM6To5Migrator",
                DataSource = SrcSqlHost,
                InitialCatalog = SrcSqlDbName,
                UserID = SrcSqlUser,
                Password = SrcSqlPassword
            }.ConnectionString;
        }

        public string GetDestSqlConnectionString()
        {
            return new SqlConnectionStringBuilder
            {
                ApplicationName = "DM6To5Migrator",
                DataSource = DestSqlHost,
                InitialCatalog = DestSqlDbName,
                UserID = DestSqlUser,
                Password = DestSqlPassword
            }.ConnectionString;
        }
    }
}