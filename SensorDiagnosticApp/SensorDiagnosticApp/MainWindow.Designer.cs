namespace SensorDiagnosticApp
{
    partial class SensorDiagnostics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SensorDiagnostics));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSensorNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGetSensorStatus = new System.Windows.Forms.Button();
            this.txtSensorStatus = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtPingStart = new System.Windows.Forms.TextBox();
            this.txtPingEnd = new System.Windows.Forms.TextBox();
            this.listSensors = new System.Windows.Forms.ListBox();
            this.btnPingSensors = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnGetRawData = new System.Windows.Forms.Button();
            this.txtQueueTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSamples = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtChangeStatus = new System.Windows.Forms.TextBox();
            this.btnChangeSensorID = new System.Windows.Forms.Button();
            this.txtNewSensorID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOldSensorID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnGetVoltage = new System.Windows.Forms.Button();
            this.txtSensorVoltage = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnGetThresholds = new System.Windows.Forms.Button();
            this.txtMaxRate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRstddr = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStddr = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnBatchUpdate = new System.Windows.Forms.Button();
            this.txtBatchUpdateEnd = new System.Windows.Forms.TextBox();
            this.txtBatchUpdateStart = new System.Windows.Forms.TextBox();
            this.btnSetThresholds = new System.Windows.Forms.Button();
            this.txtSetMaxRate = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSetRstddr = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSetStddr = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.btnOpenLogs = new System.Windows.Forms.Button();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.btnExportLogs = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnStopService = new System.Windows.Forms.Button();
            this.btnStartService = new System.Windows.Forms.Button();
            this.btnReboot = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtFirmwareEnd = new System.Windows.Forms.TextBox();
            this.txtFirmwareStart = new System.Windows.Forms.TextBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.txtChangeIP = new System.Windows.Forms.TextBox();
            this.btnChangeIP = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSensorNumber);
            this.groupBox2.Controls.Add(this.label3);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // txtSensorNumber
            // 
            resources.ApplyResources(this.txtSensorNumber, "txtSensorNumber");
            this.txtSensorNumber.Name = "txtSensorNumber";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnGetSensorStatus);
            this.groupBox3.Controls.Add(this.txtSensorStatus);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // btnGetSensorStatus
            // 
            resources.ApplyResources(this.btnGetSensorStatus, "btnGetSensorStatus");
            this.btnGetSensorStatus.Name = "btnGetSensorStatus";
            this.btnGetSensorStatus.UseVisualStyleBackColor = true;
            this.btnGetSensorStatus.Click += new System.EventHandler(this.btnGetSensorStatus_Click);
            // 
            // txtSensorStatus
            // 
            resources.ApplyResources(this.txtSensorStatus, "txtSensorStatus");
            this.txtSensorStatus.Name = "txtSensorStatus";
            this.txtSensorStatus.ReadOnly = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtPingStart);
            this.groupBox4.Controls.Add(this.txtPingEnd);
            this.groupBox4.Controls.Add(this.listSensors);
            this.groupBox4.Controls.Add(this.btnPingSensors);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // txtPingStart
            // 
            this.txtPingStart.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            resources.ApplyResources(this.txtPingStart, "txtPingStart");
            this.txtPingStart.Name = "txtPingStart";
            this.txtPingStart.Enter += new System.EventHandler(this.TxtPingStart_Enter);
            this.txtPingStart.Leave += new System.EventHandler(this.TxtPingStart_Leave);
            // 
            // txtPingEnd
            // 
            resources.ApplyResources(this.txtPingEnd, "txtPingEnd");
            this.txtPingEnd.Name = "txtPingEnd";
            this.txtPingEnd.Enter += new System.EventHandler(this.txtPingRange_Enter);
            this.txtPingEnd.Leave += new System.EventHandler(this.txtPingRange_Leave);
            // 
            // listSensors
            // 
            resources.ApplyResources(this.listSensors, "listSensors");
            this.listSensors.FormattingEnabled = true;
            this.listSensors.Name = "listSensors";
            this.listSensors.SelectedIndexChanged += new System.EventHandler(this.listSensors_SelectedIndexChanged);
            // 
            // btnPingSensors
            // 
            resources.ApplyResources(this.btnPingSensors, "btnPingSensors");
            this.btnPingSensors.Name = "btnPingSensors";
            this.btnPingSensors.UseVisualStyleBackColor = true;
            this.btnPingSensors.Click += new System.EventHandler(this.btnPingSensors_Click);
            // 
            // txtIP
            // 
            resources.ApplyResources(this.txtIP, "txtIP");
            this.txtIP.Name = "txtIP";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnGetRawData);
            this.groupBox5.Controls.Add(this.txtQueueTime);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.txtSamples);
            this.groupBox5.Controls.Add(this.label4);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // btnGetRawData
            // 
            resources.ApplyResources(this.btnGetRawData, "btnGetRawData");
            this.btnGetRawData.Name = "btnGetRawData";
            this.btnGetRawData.UseVisualStyleBackColor = true;
            this.btnGetRawData.Click += new System.EventHandler(this.btnGetRawData_Click);
            // 
            // txtQueueTime
            // 
            resources.ApplyResources(this.txtQueueTime, "txtQueueTime");
            this.txtQueueTime.Name = "txtQueueTime";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtSamples
            // 
            resources.ApplyResources(this.txtSamples, "txtSamples");
            this.txtSamples.Name = "txtSamples";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtChangeStatus);
            this.groupBox6.Controls.Add(this.btnChangeSensorID);
            this.groupBox6.Controls.Add(this.txtNewSensorID);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.txtOldSensorID);
            this.groupBox6.Controls.Add(this.label7);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // txtChangeStatus
            // 
            resources.ApplyResources(this.txtChangeStatus, "txtChangeStatus");
            this.txtChangeStatus.Name = "txtChangeStatus";
            this.txtChangeStatus.ReadOnly = true;
            // 
            // btnChangeSensorID
            // 
            resources.ApplyResources(this.btnChangeSensorID, "btnChangeSensorID");
            this.btnChangeSensorID.Name = "btnChangeSensorID";
            this.btnChangeSensorID.UseVisualStyleBackColor = true;
            this.btnChangeSensorID.Click += new System.EventHandler(this.BtnChangeSensorID_Click);
            // 
            // txtNewSensorID
            // 
            resources.ApplyResources(this.txtNewSensorID, "txtNewSensorID");
            this.txtNewSensorID.Name = "txtNewSensorID";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtOldSensorID
            // 
            resources.ApplyResources(this.txtOldSensorID, "txtOldSensorID");
            this.txtOldSensorID.Name = "txtOldSensorID";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnGetVoltage);
            this.groupBox7.Controls.Add(this.txtSensorVoltage);
            resources.ApplyResources(this.groupBox7, "groupBox7");
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.TabStop = false;
            // 
            // btnGetVoltage
            // 
            resources.ApplyResources(this.btnGetVoltage, "btnGetVoltage");
            this.btnGetVoltage.Name = "btnGetVoltage";
            this.btnGetVoltage.UseVisualStyleBackColor = true;
            this.btnGetVoltage.Click += new System.EventHandler(this.btnGetVoltage_Click);
            // 
            // txtSensorVoltage
            // 
            resources.ApplyResources(this.txtSensorVoltage, "txtSensorVoltage");
            this.txtSensorVoltage.Name = "txtSensorVoltage";
            this.txtSensorVoltage.ReadOnly = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnGetThresholds);
            this.groupBox8.Controls.Add(this.txtMaxRate);
            this.groupBox8.Controls.Add(this.label10);
            this.groupBox8.Controls.Add(this.txtRstddr);
            this.groupBox8.Controls.Add(this.label8);
            this.groupBox8.Controls.Add(this.txtStddr);
            this.groupBox8.Controls.Add(this.label9);
            resources.ApplyResources(this.groupBox8, "groupBox8");
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.TabStop = false;
            // 
            // btnGetThresholds
            // 
            resources.ApplyResources(this.btnGetThresholds, "btnGetThresholds");
            this.btnGetThresholds.Name = "btnGetThresholds";
            this.btnGetThresholds.UseVisualStyleBackColor = true;
            this.btnGetThresholds.Click += new System.EventHandler(this.btnGetThresholds_Click);
            // 
            // txtMaxRate
            // 
            resources.ApplyResources(this.txtMaxRate, "txtMaxRate");
            this.txtMaxRate.Name = "txtMaxRate";
            this.txtMaxRate.ReadOnly = true;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // txtRstddr
            // 
            resources.ApplyResources(this.txtRstddr, "txtRstddr");
            this.txtRstddr.Name = "txtRstddr";
            this.txtRstddr.ReadOnly = true;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txtStddr
            // 
            resources.ApplyResources(this.txtStddr, "txtStddr");
            this.txtStddr.Name = "txtStddr";
            this.txtStddr.ReadOnly = true;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnBatchUpdate);
            this.groupBox9.Controls.Add(this.txtBatchUpdateEnd);
            this.groupBox9.Controls.Add(this.txtBatchUpdateStart);
            this.groupBox9.Controls.Add(this.btnSetThresholds);
            this.groupBox9.Controls.Add(this.txtSetMaxRate);
            this.groupBox9.Controls.Add(this.label11);
            this.groupBox9.Controls.Add(this.txtSetRstddr);
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.txtSetStddr);
            this.groupBox9.Controls.Add(this.label13);
            resources.ApplyResources(this.groupBox9, "groupBox9");
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.TabStop = false;
            // 
            // btnBatchUpdate
            // 
            resources.ApplyResources(this.btnBatchUpdate, "btnBatchUpdate");
            this.btnBatchUpdate.Name = "btnBatchUpdate";
            this.btnBatchUpdate.UseVisualStyleBackColor = true;
            this.btnBatchUpdate.Click += new System.EventHandler(this.BtnBatchUpdate_Click);
            // 
            // txtBatchUpdateEnd
            // 
            resources.ApplyResources(this.txtBatchUpdateEnd, "txtBatchUpdateEnd");
            this.txtBatchUpdateEnd.Name = "txtBatchUpdateEnd";
            this.txtBatchUpdateEnd.Enter += new System.EventHandler(this.TxtBatchUpdateEnd_Enter);
            this.txtBatchUpdateEnd.Leave += new System.EventHandler(this.TxtBatchUpdateEnd_Leave);
            // 
            // txtBatchUpdateStart
            // 
            this.txtBatchUpdateStart.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            resources.ApplyResources(this.txtBatchUpdateStart, "txtBatchUpdateStart");
            this.txtBatchUpdateStart.Name = "txtBatchUpdateStart";
            this.txtBatchUpdateStart.Enter += new System.EventHandler(this.TxtBatchUpdateStart_Enter);
            this.txtBatchUpdateStart.Leave += new System.EventHandler(this.TxtBatchUpdateStart_Leave);
            // 
            // btnSetThresholds
            // 
            resources.ApplyResources(this.btnSetThresholds, "btnSetThresholds");
            this.btnSetThresholds.Name = "btnSetThresholds";
            this.btnSetThresholds.UseVisualStyleBackColor = true;
            this.btnSetThresholds.Click += new System.EventHandler(this.btnSetThresholds_Click);
            // 
            // txtSetMaxRate
            // 
            resources.ApplyResources(this.txtSetMaxRate, "txtSetMaxRate");
            this.txtSetMaxRate.Name = "txtSetMaxRate";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // txtSetRstddr
            // 
            resources.ApplyResources(this.txtSetRstddr, "txtSetRstddr");
            this.txtSetRstddr.Name = "txtSetRstddr";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // txtSetStddr
            // 
            resources.ApplyResources(this.txtSetStddr, "txtSetStddr");
            this.txtSetStddr.Name = "txtSetStddr";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.btnOpenLogs);
            this.groupBox10.Controls.Add(this.btnClearLogs);
            this.groupBox10.Controls.Add(this.btnExportLogs);
            this.groupBox10.Controls.Add(this.txtLog);
            resources.ApplyResources(this.groupBox10, "groupBox10");
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.TabStop = false;
            // 
            // btnOpenLogs
            // 
            resources.ApplyResources(this.btnOpenLogs, "btnOpenLogs");
            this.btnOpenLogs.Name = "btnOpenLogs";
            this.btnOpenLogs.UseVisualStyleBackColor = true;
            this.btnOpenLogs.Click += new System.EventHandler(this.btnOpenLogs_Click);
            // 
            // btnClearLogs
            // 
            resources.ApplyResources(this.btnClearLogs, "btnClearLogs");
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.UseVisualStyleBackColor = true;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // btnExportLogs
            // 
            resources.ApplyResources(this.btnExportLogs, "btnExportLogs");
            this.btnExportLogs.Name = "btnExportLogs";
            this.btnExportLogs.UseVisualStyleBackColor = true;
            this.btnExportLogs.Click += new System.EventHandler(this.btnExportLogs_Click);
            // 
            // txtLog
            // 
            resources.ApplyResources(this.txtLog, "txtLog");
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            // 
            // btnStopService
            // 
            resources.ApplyResources(this.btnStopService, "btnStopService");
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.UseVisualStyleBackColor = true;
            this.btnStopService.Click += new System.EventHandler(this.BtnStopService_Click);
            // 
            // btnStartService
            // 
            resources.ApplyResources(this.btnStartService, "btnStartService");
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.BtnStartService_Click);
            // 
            // btnReboot
            // 
            resources.ApplyResources(this.btnReboot, "btnReboot");
            this.btnReboot.Name = "btnReboot";
            this.btnReboot.UseVisualStyleBackColor = true;
            this.btnReboot.Click += new System.EventHandler(this.BtnReboot_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFileName);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnUpload);
            this.groupBox1.Controls.Add(this.txtFirmwareEnd);
            this.groupBox1.Controls.Add(this.txtFirmwareStart);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // txtFileName
            // 
            this.txtFileName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            resources.ApplyResources(this.txtFileName, "txtFileName");
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            // 
            // btnBrowse
            // 
            resources.ApplyResources(this.btnBrowse, "btnBrowse");
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // btnUpload
            // 
            resources.ApplyResources(this.btnUpload, "btnUpload");
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // txtFirmwareEnd
            // 
            resources.ApplyResources(this.txtFirmwareEnd, "txtFirmwareEnd");
            this.txtFirmwareEnd.Name = "txtFirmwareEnd";
            this.txtFirmwareEnd.Enter += new System.EventHandler(this.TxtFirmwareEnd_Enter);
            this.txtFirmwareEnd.Leave += new System.EventHandler(this.TxtFirmwareEnd_Leave);
            // 
            // txtFirmwareStart
            // 
            this.txtFirmwareStart.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            resources.ApplyResources(this.txtFirmwareStart, "txtFirmwareStart");
            this.txtFirmwareStart.Name = "txtFirmwareStart";
            this.txtFirmwareStart.Enter += new System.EventHandler(this.TxtFirmwareStart_Enter);
            this.txtFirmwareStart.Leave += new System.EventHandler(this.TxtFirmwareStart_Leave);
            // 
            // pictureBoxLogo
            // 
            resources.ApplyResources(this.pictureBoxLogo, "pictureBoxLogo");
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.TabStop = false;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.txtChangeIP);
            this.groupBox11.Controls.Add(this.btnChangeIP);
            resources.ApplyResources(this.groupBox11, "groupBox11");
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.TabStop = false;
            // 
            // txtChangeIP
            // 
            this.txtChangeIP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            resources.ApplyResources(this.txtChangeIP, "txtChangeIP");
            this.txtChangeIP.Name = "txtChangeIP";
            // 
            // btnChangeIP
            // 
            resources.ApplyResources(this.btnChangeIP, "btnChangeIP");
            this.btnChangeIP.Name = "btnChangeIP";
            this.btnChangeIP.UseVisualStyleBackColor = true;
            this.btnChangeIP.Click += new System.EventHandler(this.BtnChangeIP_Click);
            // 
            // SensorDiagnostics
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.btnReboot);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btnStartService);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnStopService);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SensorDiagnostics";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSensorNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnGetSensorStatus;
        private System.Windows.Forms.TextBox txtSensorStatus;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listSensors;
        private System.Windows.Forms.Button btnPingSensors;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtQueueTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSamples;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGetRawData;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnChangeSensorID;
        private System.Windows.Forms.TextBox txtNewSensorID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOldSensorID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnGetVoltage;
        private System.Windows.Forms.TextBox txtSensorVoltage;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtRstddr;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtStddr;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaxRate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btnGetThresholds;
        private System.Windows.Forms.Button btnSetThresholds;
        private System.Windows.Forms.TextBox txtSetMaxRate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSetRstddr;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSetStddr;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.Button btnExportLogs;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnOpenLogs;
        private System.Windows.Forms.TextBox txtPingEnd;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPingStart;
        private System.Windows.Forms.TextBox txtChangeStatus;
        private System.Windows.Forms.Button btnStopService;
        private System.Windows.Forms.Button btnStartService;
        private System.Windows.Forms.Button btnReboot;
        private System.Windows.Forms.TextBox txtBatchUpdateEnd;
        private System.Windows.Forms.TextBox txtBatchUpdateStart;
        private System.Windows.Forms.Button btnBatchUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox txtFirmwareEnd;
        private System.Windows.Forms.TextBox txtFirmwareStart;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox txtChangeIP;
        private System.Windows.Forms.Button btnChangeIP;
    }
}

