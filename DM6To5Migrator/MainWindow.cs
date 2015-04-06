using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hummingbird.DM.Server.Interop.PCDClient;

namespace DM6To5Migrator
{
    public partial class MainWindow : Form, ILogger
    {
        public MainWindow()
        {
            InitializeComponent();
            Logger.Instance = this;
        }

        private void btnExtractSrcLibInfo_Click(object sender, EventArgs e)
        {
            try
            {
                using (var cn = new SqlConnection(GetSettings().GetSrcSqlConnectionString()))
                {
                    var cmd = new SqlCommand("select LOCATION from DOCSADM.DOCSERVERS", cn);

                    cn.Open();

                    lblSrcLibRootFolder.Text = txtSrcLibDocsPath.Text = (string) cmd.ExecuteScalar();

                    cmd.CommandText = "select count(*) from DOCSADM.PROFILE";
                    lblSrcLibTotalProfiles.Text = cmd.ExecuteScalar().ToString();
                }

                btnTest.Enabled = btnStartMigration.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DM Migrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            new MigrationHelper(GetSettings()).RunAllTests();
        }

        public Settings GetSettings()
        {
            return new Settings
            {
                SrcSqlHost = txtSrcSqlHost.Text,
                SrcSqlUser = txtSrcSqlUser.Text,
                SrcSqlPassword = txtSrcSqlPass.Text,
                SrcSqlDbName = txtSrcSqlDbName.Text,

                SrcLibRootFolder = txtSrcLibDocsPath.Text,

                DestSqlHost = txtDestSqlHost.Text,
                DestSqlUser = txtDesSqlUser.Text,
                DestSqlPassword = txtDestSqlPass.Text,
                DestSqlDbName = txtDestSqlDbName.Text,

                DestLibName = txtDestLibName.Text,
                DestLibUser = txtDestLibUser.Text,
                DestLibPass = txtDestLibPass.Text,
                DestLibDefaultProfile = txtDefaultProfileName.Text
            };
        }

        #region ILogger implementation

        public ILogger WriteLine(string format, params object[] values)
        {
            Invoke(new Action(() =>
            {
                txtLog.Text += string.Format(format + "\r\n", values);
                txtLog.Select(txtLog.TextLength, 0);
                txtLog.ScrollToCaret();
            }));
            return this;
        }

        public ILogger Write(string format, params object[] values)
        {
            Invoke(new Action(() =>
            {
                txtLog.Text += string.Format(format, values);
                txtLog.Select(txtLog.TextLength, 0);
                txtLog.ScrollToCaret();
            }));
            return this;
        }

        #endregion

        private void migratinBgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            new MigrationHelper(GetSettings()).StartMigration(sender, e);
        }

        private void migratinBgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage <= migrationProgress.Value)
                migrationProgress.Value = e.ProgressPercentage;
        }

        private void migratinBgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnStopMigration.Enabled = false;
            btnTest.Enabled = btnStartMigration.Enabled = true;
            Logger.WriteLine(e.Cancelled ? "Opération annulée" : "Migratin terminée");
        }

        private void btnStartMigration_Click(object sender, EventArgs e)
        {
            migrationProgress.Value = 0;
            migrationProgress.Minimum = 0;
            migrationProgress.Maximum = int.Parse(lblSrcLibTotalProfiles.Text); // Very poor line!

            migratinBgWorker.RunWorkerAsync(migratinBgWorker);

            btnTest.Enabled = btnStartMigration.Enabled = false;
            btnStopMigration.Enabled = true;
        }

        private void btnStopMigration_Click(object sender, EventArgs e)
        {
            migratinBgWorker.CancelAsync();
        }
    }
}
