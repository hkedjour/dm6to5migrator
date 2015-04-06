namespace DM6To5Migrator
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSrcSqlDbName = new System.Windows.Forms.TextBox();
            this.txtSrcSqlPass = new System.Windows.Forms.TextBox();
            this.txtSrcSqlUser = new System.Windows.Forms.TextBox();
            this.txtSrcSqlHost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExtractSrcLibInfo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblSrcLibTotalProfiles = new System.Windows.Forms.Label();
            this.lblSrcLibRootFolder = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSrcLibDocsPath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDestSqlDbName = new System.Windows.Forms.TextBox();
            this.txtDestSqlPass = new System.Windows.Forms.TextBox();
            this.txtDesSqlUser = new System.Windows.Forms.TextBox();
            this.txtDestSqlHost = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtDestLibPass = new System.Windows.Forms.TextBox();
            this.txtDestLibUser = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDestLibName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnStartMigration = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.migrationProgress = new System.Windows.Forms.ProgressBar();
            this.migratinBgWorker = new System.ComponentModel.BackgroundWorker();
            this.btnStopMigration = new System.Windows.Forms.Button();
            this.txtDefaultProfileName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSrcSqlDbName);
            this.groupBox1.Controls.Add(this.txtSrcSqlPass);
            this.groupBox1.Controls.Add(this.txtSrcSqlUser);
            this.groupBox1.Controls.Add(this.txtSrcSqlHost);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnExtractSrcLibInfo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 155);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serveur SQL Source";
            // 
            // txtSrcSqlDbName
            // 
            this.txtSrcSqlDbName.Location = new System.Drawing.Point(124, 97);
            this.txtSrcSqlDbName.Name = "txtSrcSqlDbName";
            this.txtSrcSqlDbName.Size = new System.Drawing.Size(100, 20);
            this.txtSrcSqlDbName.TabIndex = 3;
            // 
            // txtSrcSqlPass
            // 
            this.txtSrcSqlPass.Location = new System.Drawing.Point(124, 71);
            this.txtSrcSqlPass.Name = "txtSrcSqlPass";
            this.txtSrcSqlPass.PasswordChar = '*';
            this.txtSrcSqlPass.Size = new System.Drawing.Size(100, 20);
            this.txtSrcSqlPass.TabIndex = 2;
            // 
            // txtSrcSqlUser
            // 
            this.txtSrcSqlUser.Location = new System.Drawing.Point(124, 45);
            this.txtSrcSqlUser.Name = "txtSrcSqlUser";
            this.txtSrcSqlUser.Size = new System.Drawing.Size(100, 20);
            this.txtSrcSqlUser.TabIndex = 1;
            // 
            // txtSrcSqlHost
            // 
            this.txtSrcSqlHost.Location = new System.Drawing.Point(124, 19);
            this.txtSrcSqlHost.Name = "txtSrcSqlHost";
            this.txtSrcSqlHost.Size = new System.Drawing.Size(100, 20);
            this.txtSrcSqlHost.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Library database name";
            // 
            // btnExtractSrcLibInfo
            // 
            this.btnExtractSrcLibInfo.Location = new System.Drawing.Point(9, 123);
            this.btnExtractSrcLibInfo.Name = "btnExtractSrcLibInfo";
            this.btnExtractSrcLibInfo.Size = new System.Drawing.Size(215, 23);
            this.btnExtractSrcLibInfo.TabIndex = 4;
            this.btnExtractSrcLibInfo.Text = "Extract library information";
            this.btnExtractSrcLibInfo.UseVisualStyleBackColor = true;
            this.btnExtractSrcLibInfo.Click += new System.EventHandler(this.btnExtractSrcLibInfo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "SQL Server password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "SQL Server user";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SQL Server host";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblSrcLibTotalProfiles);
            this.groupBox3.Controls.Add(this.lblSrcLibRootFolder);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtSrcLibDocsPath);
            this.groupBox3.Location = new System.Drawing.Point(255, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(506, 155);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Souce DM Library information";
            // 
            // lblSrcLibTotalProfiles
            // 
            this.lblSrcLibTotalProfiles.AutoSize = true;
            this.lblSrcLibTotalProfiles.Location = new System.Drawing.Point(109, 74);
            this.lblSrcLibTotalProfiles.Name = "lblSrcLibTotalProfiles";
            this.lblSrcLibTotalProfiles.Size = new System.Drawing.Size(0, 13);
            this.lblSrcLibTotalProfiles.TabIndex = 5;
            // 
            // lblSrcLibRootFolder
            // 
            this.lblSrcLibRootFolder.AutoSize = true;
            this.lblSrcLibRootFolder.Location = new System.Drawing.Point(106, 20);
            this.lblSrcLibRootFolder.Name = "lblSrcLibRootFolder";
            this.lblSrcLibRootFolder.Size = new System.Drawing.Size(0, 13);
            this.lblSrcLibRootFolder.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Original root folder";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Total profiles";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Actual root folder";
            // 
            // txtSrcLibDocsPath
            // 
            this.txtSrcLibDocsPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSrcLibDocsPath.Location = new System.Drawing.Point(106, 45);
            this.txtSrcLibDocsPath.Name = "txtSrcLibDocsPath";
            this.txtSrcLibDocsPath.Size = new System.Drawing.Size(394, 20);
            this.txtSrcLibDocsPath.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDestSqlDbName);
            this.groupBox2.Controls.Add(this.txtDestSqlPass);
            this.groupBox2.Controls.Add(this.txtDesSqlUser);
            this.groupBox2.Controls.Add(this.txtDestSqlHost);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(12, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 124);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Serveur SQL Destination";
            // 
            // txtDestSqlDbName
            // 
            this.txtDestSqlDbName.Location = new System.Drawing.Point(124, 97);
            this.txtDestSqlDbName.Name = "txtDestSqlDbName";
            this.txtDestSqlDbName.Size = new System.Drawing.Size(100, 20);
            this.txtDestSqlDbName.TabIndex = 3;
            // 
            // txtDestSqlPass
            // 
            this.txtDestSqlPass.Location = new System.Drawing.Point(124, 71);
            this.txtDestSqlPass.Name = "txtDestSqlPass";
            this.txtDestSqlPass.PasswordChar = '*';
            this.txtDestSqlPass.Size = new System.Drawing.Size(100, 20);
            this.txtDestSqlPass.TabIndex = 2;
            // 
            // txtDesSqlUser
            // 
            this.txtDesSqlUser.Location = new System.Drawing.Point(124, 45);
            this.txtDesSqlUser.Name = "txtDesSqlUser";
            this.txtDesSqlUser.Size = new System.Drawing.Size(100, 20);
            this.txtDesSqlUser.TabIndex = 1;
            // 
            // txtDestSqlHost
            // 
            this.txtDestSqlHost.Location = new System.Drawing.Point(124, 19);
            this.txtDestSqlHost.Name = "txtDestSqlHost";
            this.txtDestSqlHost.Size = new System.Drawing.Size(100, 20);
            this.txtDestSqlHost.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Library database name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "SQL Server password";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "SQL Server user";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "SQL Server host";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtDefaultProfileName);
            this.groupBox4.Controls.Add(this.txtDestLibPass);
            this.groupBox4.Controls.Add(this.txtDestLibUser);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.txtDestLibName);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Location = new System.Drawing.Point(254, 174);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(507, 124);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Destination DM Library information";
            // 
            // txtDestLibPass
            // 
            this.txtDestLibPass.Location = new System.Drawing.Point(107, 71);
            this.txtDestLibPass.Name = "txtDestLibPass";
            this.txtDestLibPass.PasswordChar = '*';
            this.txtDestLibPass.Size = new System.Drawing.Size(145, 20);
            this.txtDestLibPass.TabIndex = 2;
            // 
            // txtDestLibUser
            // 
            this.txtDestLibUser.Location = new System.Drawing.Point(107, 45);
            this.txtDestLibUser.Name = "txtDestLibUser";
            this.txtDestLibUser.Size = new System.Drawing.Size(145, 20);
            this.txtDestLibUser.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Library password";
            // 
            // txtDestLibName
            // 
            this.txtDestLibName.Location = new System.Drawing.Point(107, 19);
            this.txtDestLibName.Name = "txtDestLibName";
            this.txtDestLibName.Size = new System.Drawing.Size(145, 20);
            this.txtDestLibName.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Library user name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Library name";
            // 
            // btnTest
            // 
            this.btnTest.Enabled = false;
            this.btnTest.Location = new System.Drawing.Point(12, 304);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(208, 23);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "Lancer une simulation";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnStartMigration
            // 
            this.btnStartMigration.Enabled = false;
            this.btnStartMigration.Location = new System.Drawing.Point(227, 303);
            this.btnStartMigration.Name = "btnStartMigration";
            this.btnStartMigration.Size = new System.Drawing.Size(208, 23);
            this.btnStartMigration.TabIndex = 5;
            this.btnStartMigration.Text = "Start migration";
            this.btnStartMigration.UseVisualStyleBackColor = true;
            this.btnStartMigration.Click += new System.EventHandler(this.btnStartMigration_Click);
            // 
            // txtLog
            // 
            this.txtLog.AcceptsReturn = true;
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(13, 333);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(748, 111);
            this.txtLog.TabIndex = 6;
            this.txtLog.WordWrap = false;
            // 
            // migrationProgress
            // 
            this.migrationProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.migrationProgress.Location = new System.Drawing.Point(13, 450);
            this.migrationProgress.Name = "migrationProgress";
            this.migrationProgress.Size = new System.Drawing.Size(748, 23);
            this.migrationProgress.TabIndex = 7;
            // 
            // migratinBgWorker
            // 
            this.migratinBgWorker.WorkerReportsProgress = true;
            this.migratinBgWorker.WorkerSupportsCancellation = true;
            this.migratinBgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.migratinBgWorker_DoWork);
            this.migratinBgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.migratinBgWorker_ProgressChanged);
            this.migratinBgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.migratinBgWorker_RunWorkerCompleted);
            // 
            // btnStopMigration
            // 
            this.btnStopMigration.Enabled = false;
            this.btnStopMigration.Location = new System.Drawing.Point(441, 303);
            this.btnStopMigration.Name = "btnStopMigration";
            this.btnStopMigration.Size = new System.Drawing.Size(208, 23);
            this.btnStopMigration.TabIndex = 5;
            this.btnStopMigration.Text = "Stop migration";
            this.btnStopMigration.UseVisualStyleBackColor = true;
            this.btnStopMigration.Click += new System.EventHandler(this.btnStopMigration_Click);
            // 
            // txtDefaultProfileName
            // 
            this.txtDefaultProfileName.Location = new System.Drawing.Point(107, 97);
            this.txtDefaultProfileName.Name = "txtDefaultProfileName";
            this.txtDefaultProfileName.Size = new System.Drawing.Size(145, 20);
            this.txtDefaultProfileName.TabIndex = 3;
            this.txtDefaultProfileName.Text = "FRA_DEF_PROF";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 100);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Profile to use";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 485);
            this.Controls.Add(this.migrationProgress);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnStopMigration);
            this.Controls.Add(this.btnStartMigration);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "DM 6.x to 5.x migration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSrcSqlDbName;
        private System.Windows.Forms.TextBox txtSrcSqlPass;
        private System.Windows.Forms.TextBox txtSrcSqlUser;
        private System.Windows.Forms.TextBox txtSrcSqlHost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExtractSrcLibInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSrcLibDocsPath;
        private System.Windows.Forms.Label lblSrcLibTotalProfiles;
        private System.Windows.Forms.Label lblSrcLibRootFolder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDestSqlDbName;
        private System.Windows.Forms.TextBox txtDestSqlPass;
        private System.Windows.Forms.TextBox txtDesSqlUser;
        private System.Windows.Forms.TextBox txtDestSqlHost;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtDestLibPass;
        private System.Windows.Forms.TextBox txtDestLibUser;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDestLibName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnStartMigration;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ProgressBar migrationProgress;
        private System.ComponentModel.BackgroundWorker migratinBgWorker;
        private System.Windows.Forms.Button btnStopMigration;
        private System.Windows.Forms.TextBox txtDefaultProfileName;
        private System.Windows.Forms.Label label15;
    }
}

