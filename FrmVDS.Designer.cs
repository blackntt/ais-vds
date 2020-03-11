namespace VirusDetectionSystem
{
    partial class FrmVDS
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVDS));
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.lbTestStatus = new System.Windows.Forms.Label();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.lbRateFileTesting = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lbBenignCount_TestModel = new System.Windows.Forms.Label();
            this.lbVirusCount_TestModel = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.lbWrongTestCount = new System.Windows.Forms.Label();
            this.lbCorrectTestCount = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dGVTestingResult = new System.Windows.Forms.DataGridView();
            this.gBTestInformation = new System.Windows.Forms.GroupBox();
            this.rdFolderTesting = new System.Windows.Forms.RadioButton();
            this.rdDangerLevelFileTesting = new System.Windows.Forms.RadioButton();
            this.btnDLFolder = new System.Windows.Forms.Button();
            this.txtTestingFolder = new System.Windows.Forms.TextBox();
            this.btnTestModel = new System.Windows.Forms.Button();
            this.txtTestFile = new System.Windows.Forms.TextBox();
            this.btnDLFile = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lbDangerLevelAndClassificationStatus = new System.Windows.Forms.Label();
            this.gBClassification = new System.Windows.Forms.GroupBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCreateModel = new System.Windows.Forms.Button();
            this.nUDGuassKernelPara = new System.Windows.Forms.NumericUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.btnViewClassificationInput = new System.Windows.Forms.Button();
            this.btnClassification = new System.Windows.Forms.Button();
            this.gBDangerLevel = new System.Windows.Forms.GroupBox();
            this.btnComputingLD = new System.Windows.Forms.Button();
            this.txtSourceLD = new System.Windows.Forms.TextBox();
            this.btnComputingDLDefault = new System.Windows.Forms.Button();
            this.txtDestinationLD = new System.Windows.Forms.TextBox();
            this.rdBenign = new System.Windows.Forms.RadioButton();
            this.btnSourceLD = new System.Windows.Forms.Button();
            this.rdVirus = new System.Windows.Forms.RadioButton();
            this.btnDestinationLD = new System.Windows.Forms.Button();
            this.Details = new System.Windows.Forms.GroupBox();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.dGVDangerOfLevel = new System.Windows.Forms.DataGridView();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.dGVClassificationInput = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbTimeElapsed = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbClusteringResultMessage = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnLoadClusteringResult = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dGVClusteredVirusGeneSet = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dGVClusteredBenignGeneSet = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lbCleaningResultMessage = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.btnLoadCleaningResult = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dGVCleaningVirusGeneSet = new System.Windows.Forms.DataGridView();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.dGVCleaningBenignGeneSet = new System.Windows.Forms.DataGridView();
            this.label19 = new System.Windows.Forms.Label();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.lbFirstDetectorResult = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.btnLoadFirstDetectorsResult = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.dGVDetector_NSA = new System.Windows.Forms.DataGridView();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.dGVVirusGeneSet_Detector = new System.Windows.Forms.DataGridView();
            this.label21 = new System.Windows.Forms.Label();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.lbaiNetResult = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.btnLoadaiNetResult = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.dGVaiNetDetector_aiNet = new System.Windows.Forms.DataGridView();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.dGVFirstDetectors_aiNet = new System.Windows.Forms.DataGridView();
            this.label23 = new System.Windows.Forms.Label();
            this.gBStates = new System.Windows.Forms.GroupBox();
            this.rTBStates = new System.Windows.Forms.RichTextBox();
            this.gBDirectory = new System.Windows.Forms.GroupBox();
            this.btnRootDirectoryBrowser = new System.Windows.Forms.Button();
            this.txtMainDirectory = new System.Windows.Forms.TextBox();
            this.gBAiNet = new System.Windows.Forms.GroupBox();
            this.nUDMatchingThresholdAiNet = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.nUDSelectedClonesNum = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nUDNewRandomDetectors = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownGeneration = new System.Windows.Forms.NumericUpDown();
            this.btnaiNet = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nUDClonesNum_APattern = new System.Windows.Forms.NumericUpDown();
            this.nUDSupThreshold = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.gBGenerateFirstDetectors = new System.Windows.Forms.GroupBox();
            this.nUDMaxErrors = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.nUDNSADetectorCount = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.btnCleanVirusGeneSet = new System.Windows.Forms.Button();
            this.btnClustering = new System.Windows.Forms.Button();
            this.btnOnlyNSA = new System.Windows.Forms.Button();
            this.nUDLimitCountforDBSCAN = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.nUDMatchingThreshold = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRunNSA = new System.Windows.Forms.Button();
            this.nUDClusteringThreshold = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.elapsedTimer = new System.Windows.Forms.Timer(this.components);
            this.elapsedTimer2 = new System.Windows.Forms.Timer(this.components);
            this.elapsedTimer3 = new System.Windows.Forms.Timer(this.components);
            this.tabPage6.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVTestingResult)).BeginInit();
            this.gBTestInformation.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.gBClassification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDGuassKernelPara)).BeginInit();
            this.gBDangerLevel.SuspendLayout();
            this.Details.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDangerOfLevel)).BeginInit();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVClassificationInput)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVClusteredVirusGeneSet)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVClusteredBenignGeneSet)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVCleaningVirusGeneSet)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVCleaningBenignGeneSet)).BeginInit();
            this.tabPage8.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDetector_NSA)).BeginInit();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVVirusGeneSet_Detector)).BeginInit();
            this.tabPage9.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVaiNetDetector_aiNet)).BeginInit();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVFirstDetectors_aiNet)).BeginInit();
            this.gBStates.SuspendLayout();
            this.gBDirectory.SuspendLayout();
            this.gBAiNet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMatchingThresholdAiNet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDSelectedClonesNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDNewRandomDetectors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGeneration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDClonesNum_APattern)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDSupThreshold)).BeginInit();
            this.gBGenerateFirstDetectors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMaxErrors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDNSADetectorCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLimitCountforDBSCAN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMatchingThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDClusteringThreshold)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.lbTestStatus);
            this.tabPage6.Controls.Add(this.groupBox19);
            this.tabPage6.Controls.Add(this.groupBox18);
            this.tabPage6.Controls.Add(this.gBTestInformation);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(980, 657);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Test";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // lbTestStatus
            // 
            this.lbTestStatus.AutoSize = true;
            this.lbTestStatus.Location = new System.Drawing.Point(8, 639);
            this.lbTestStatus.Name = "lbTestStatus";
            this.lbTestStatus.Size = new System.Drawing.Size(130, 13);
            this.lbTestStatus.TabIndex = 35;
            this.lbTestStatus.Text = "Elapsed time: 00.00:00:00";
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.lbRateFileTesting);
            this.groupBox19.Controls.Add(this.label5);
            this.groupBox19.Controls.Add(this.label26);
            this.groupBox19.Controls.Add(this.label25);
            this.groupBox19.Controls.Add(this.lbBenignCount_TestModel);
            this.groupBox19.Controls.Add(this.lbVirusCount_TestModel);
            this.groupBox19.Controls.Add(this.label27);
            this.groupBox19.Controls.Add(this.label28);
            this.groupBox19.Controls.Add(this.lbWrongTestCount);
            this.groupBox19.Controls.Add(this.lbCorrectTestCount);
            this.groupBox19.Controls.Add(this.label24);
            this.groupBox19.Controls.Add(this.label12);
            this.groupBox19.Location = new System.Drawing.Point(8, 134);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(288, 116);
            this.groupBox19.TabIndex = 33;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Statistic";
            // 
            // lbRateFileTesting
            // 
            this.lbRateFileTesting.AutoSize = true;
            this.lbRateFileTesting.Location = new System.Drawing.Point(84, 91);
            this.lbRateFileTesting.Name = "lbRateFileTesting";
            this.lbRateFileTesting.Size = new System.Drawing.Size(16, 13);
            this.lbRateFileTesting.TabIndex = 11;
            this.lbRateFileTesting.Text = "---";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Rate";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(188, 16);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(71, 13);
            this.label26.TabIndex = 9;
            this.label26.Text = "FolderTesting";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(48, 16);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(78, 13);
            this.label25.TabIndex = 8;
            this.label25.Text = "DL File Testing";
            // 
            // lbBenignCount_TestModel
            // 
            this.lbBenignCount_TestModel.AutoSize = true;
            this.lbBenignCount_TestModel.Location = new System.Drawing.Point(241, 62);
            this.lbBenignCount_TestModel.Name = "lbBenignCount_TestModel";
            this.lbBenignCount_TestModel.Size = new System.Drawing.Size(16, 13);
            this.lbBenignCount_TestModel.TabIndex = 7;
            this.lbBenignCount_TestModel.Text = "---";
            // 
            // lbVirusCount_TestModel
            // 
            this.lbVirusCount_TestModel.AutoSize = true;
            this.lbVirusCount_TestModel.Location = new System.Drawing.Point(241, 35);
            this.lbVirusCount_TestModel.Name = "lbVirusCount_TestModel";
            this.lbVirusCount_TestModel.Size = new System.Drawing.Size(16, 13);
            this.lbVirusCount_TestModel.TabIndex = 6;
            this.lbVirusCount_TestModel.Text = "---";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(172, 62);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(40, 13);
            this.label27.TabIndex = 5;
            this.label27.Text = "Benign";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(172, 35);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(30, 13);
            this.label28.TabIndex = 4;
            this.label28.Text = "Virus";
            // 
            // lbWrongTestCount
            // 
            this.lbWrongTestCount.AutoSize = true;
            this.lbWrongTestCount.Location = new System.Drawing.Point(84, 62);
            this.lbWrongTestCount.Name = "lbWrongTestCount";
            this.lbWrongTestCount.Size = new System.Drawing.Size(16, 13);
            this.lbWrongTestCount.TabIndex = 3;
            this.lbWrongTestCount.Text = "---";
            // 
            // lbCorrectTestCount
            // 
            this.lbCorrectTestCount.AutoSize = true;
            this.lbCorrectTestCount.Location = new System.Drawing.Point(84, 35);
            this.lbCorrectTestCount.Name = "lbCorrectTestCount";
            this.lbCorrectTestCount.Size = new System.Drawing.Size(16, 13);
            this.lbCorrectTestCount.TabIndex = 2;
            this.lbCorrectTestCount.Text = "---";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(15, 62);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(39, 13);
            this.label24.TabIndex = 1;
            this.label24.Text = "Wrong";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Correct";
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.tabControl4);
            this.groupBox18.Location = new System.Drawing.Point(304, 5);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(670, 644);
            this.groupBox18.TabIndex = 32;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Details";
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage5);
            this.tabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl4.Location = new System.Drawing.Point(3, 16);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(664, 625);
            this.tabControl4.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dGVTestingResult);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(656, 599);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Results of Testing";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dGVTestingResult
            // 
            this.dGVTestingResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVTestingResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVTestingResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVTestingResult.Location = new System.Drawing.Point(3, 3);
            this.dGVTestingResult.Name = "dGVTestingResult";
            this.dGVTestingResult.ReadOnly = true;
            this.dGVTestingResult.Size = new System.Drawing.Size(650, 593);
            this.dGVTestingResult.TabIndex = 0;
            this.dGVTestingResult.Paint += new System.Windows.Forms.PaintEventHandler(this.dGVTestingResult_Paint_FileTesting);
            // 
            // gBTestInformation
            // 
            this.gBTestInformation.Controls.Add(this.rdFolderTesting);
            this.gBTestInformation.Controls.Add(this.rdDangerLevelFileTesting);
            this.gBTestInformation.Controls.Add(this.btnDLFolder);
            this.gBTestInformation.Controls.Add(this.txtTestingFolder);
            this.gBTestInformation.Controls.Add(this.btnTestModel);
            this.gBTestInformation.Controls.Add(this.txtTestFile);
            this.gBTestInformation.Controls.Add(this.btnDLFile);
            this.gBTestInformation.Location = new System.Drawing.Point(8, 6);
            this.gBTestInformation.Name = "gBTestInformation";
            this.gBTestInformation.Size = new System.Drawing.Size(288, 127);
            this.gBTestInformation.TabIndex = 18;
            this.gBTestInformation.TabStop = false;
            this.gBTestInformation.Text = "Test Information";
            // 
            // rdFolderTesting
            // 
            this.rdFolderTesting.AutoSize = true;
            this.rdFolderTesting.Location = new System.Drawing.Point(6, 99);
            this.rdFolderTesting.Name = "rdFolderTesting";
            this.rdFolderTesting.Size = new System.Drawing.Size(92, 17);
            this.rdFolderTesting.TabIndex = 21;
            this.rdFolderTesting.Text = "Folder Testing";
            this.rdFolderTesting.UseVisualStyleBackColor = true;
            // 
            // rdDangerLevelFileTesting
            // 
            this.rdDangerLevelFileTesting.AutoSize = true;
            this.rdDangerLevelFileTesting.Checked = true;
            this.rdDangerLevelFileTesting.Location = new System.Drawing.Point(6, 76);
            this.rdDangerLevelFileTesting.Name = "rdDangerLevelFileTesting";
            this.rdDangerLevelFileTesting.Size = new System.Drawing.Size(149, 17);
            this.rdDangerLevelFileTesting.TabIndex = 20;
            this.rdDangerLevelFileTesting.TabStop = true;
            this.rdDangerLevelFileTesting.Text = "Danger Level File Testing ";
            this.rdDangerLevelFileTesting.UseVisualStyleBackColor = true;
            // 
            // btnDLFolder
            // 
            this.btnDLFolder.Location = new System.Drawing.Point(6, 47);
            this.btnDLFolder.Name = "btnDLFolder";
            this.btnDLFolder.Size = new System.Drawing.Size(75, 23);
            this.btnDLFolder.TabIndex = 19;
            this.btnDLFolder.Text = "Folder";
            this.btnDLFolder.UseVisualStyleBackColor = true;
            this.btnDLFolder.Click += new System.EventHandler(this.btnDLFolder_Click);
            // 
            // txtTestingFolder
            // 
            this.txtTestingFolder.Location = new System.Drawing.Point(87, 45);
            this.txtTestingFolder.Name = "txtTestingFolder";
            this.txtTestingFolder.Size = new System.Drawing.Size(195, 20);
            this.txtTestingFolder.TabIndex = 18;
            // 
            // btnTestModel
            // 
            this.btnTestModel.Location = new System.Drawing.Point(161, 76);
            this.btnTestModel.Name = "btnTestModel";
            this.btnTestModel.Size = new System.Drawing.Size(121, 40);
            this.btnTestModel.TabIndex = 11;
            this.btnTestModel.Text = "Scan";
            this.btnTestModel.UseVisualStyleBackColor = true;
            this.btnTestModel.Click += new System.EventHandler(this.btnTestModel_Click);
            // 
            // txtTestFile
            // 
            this.txtTestFile.Location = new System.Drawing.Point(87, 18);
            this.txtTestFile.Name = "txtTestFile";
            this.txtTestFile.Size = new System.Drawing.Size(195, 20);
            this.txtTestFile.TabIndex = 15;
            // 
            // btnDLFile
            // 
            this.btnDLFile.Location = new System.Drawing.Point(6, 18);
            this.btnDLFile.Name = "btnDLFile";
            this.btnDLFile.Size = new System.Drawing.Size(75, 23);
            this.btnDLFile.TabIndex = 17;
            this.btnDLFile.Text = "DL File";
            this.btnDLFile.UseVisualStyleBackColor = true;
            this.btnDLFile.Click += new System.EventHandler(this.btnDLFile_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lbDangerLevelAndClassificationStatus);
            this.tabPage4.Controls.Add(this.gBClassification);
            this.tabPage4.Controls.Add(this.gBDangerLevel);
            this.tabPage4.Controls.Add(this.Details);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(980, 657);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Danger Level and Classificaiton";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lbDangerLevelAndClassificationStatus
            // 
            this.lbDangerLevelAndClassificationStatus.AutoSize = true;
            this.lbDangerLevelAndClassificationStatus.Location = new System.Drawing.Point(8, 639);
            this.lbDangerLevelAndClassificationStatus.Name = "lbDangerLevelAndClassificationStatus";
            this.lbDangerLevelAndClassificationStatus.Size = new System.Drawing.Size(130, 13);
            this.lbDangerLevelAndClassificationStatus.TabIndex = 34;
            this.lbDangerLevelAndClassificationStatus.Text = "Elapsed time: 00.00:00:00";
            // 
            // gBClassification
            // 
            this.gBClassification.Controls.Add(this.label35);
            this.gBClassification.Controls.Add(this.label34);
            this.gBClassification.Controls.Add(this.label30);
            this.gBClassification.Controls.Add(this.label14);
            this.gBClassification.Controls.Add(this.btnCreateModel);
            this.gBClassification.Controls.Add(this.nUDGuassKernelPara);
            this.gBClassification.Controls.Add(this.label29);
            this.gBClassification.Controls.Add(this.btnViewClassificationInput);
            this.gBClassification.Controls.Add(this.btnClassification);
            this.gBClassification.Location = new System.Drawing.Point(8, 164);
            this.gBClassification.Name = "gBClassification";
            this.gBClassification.Size = new System.Drawing.Size(288, 211);
            this.gBClassification.TabIndex = 33;
            this.gBClassification.TabStop = false;
            this.gBClassification.Text = "Classification";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(104, 69);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(162, 13);
            this.label35.TabIndex = 42;
            this.label35.Text = "Classification\\Training\\Model.md";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(104, 42);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(159, 13);
            this.label34.TabIndex = 41;
            this.label34.Text = "Classification\\Training\\Model.txt";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(33, 42);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(68, 13);
            this.label30.TabIndex = 40;
            this.label30.Text = "DL of Model:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 13);
            this.label14.TabIndex = 39;
            this.label14.Text = "Classified Model:";
            // 
            // btnCreateModel
            // 
            this.btnCreateModel.Location = new System.Drawing.Point(107, 123);
            this.btnCreateModel.Name = "btnCreateModel";
            this.btnCreateModel.Size = new System.Drawing.Size(121, 23);
            this.btnCreateModel.TabIndex = 37;
            this.btnCreateModel.Text = "Create DL of Model";
            this.btnCreateModel.UseVisualStyleBackColor = true;
            this.btnCreateModel.Click += new System.EventHandler(this.btnCreateModel_Click);
            // 
            // nUDGuassKernelPara
            // 
            this.nUDGuassKernelPara.DecimalPlaces = 10;
            this.nUDGuassKernelPara.Location = new System.Drawing.Point(106, 95);
            this.nUDGuassKernelPara.Name = "nUDGuassKernelPara";
            this.nUDGuassKernelPara.Size = new System.Drawing.Size(122, 20);
            this.nUDGuassKernelPara.TabIndex = 36;
            this.nUDGuassKernelPara.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(7, 99);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(93, 13);
            this.label29.TabIndex = 35;
            this.label29.Text = "RBF Kernel Sigma";
            // 
            // btnViewClassificationInput
            // 
            this.btnViewClassificationInput.Location = new System.Drawing.Point(107, 151);
            this.btnViewClassificationInput.Name = "btnViewClassificationInput";
            this.btnViewClassificationInput.Size = new System.Drawing.Size(121, 23);
            this.btnViewClassificationInput.TabIndex = 34;
            this.btnViewClassificationInput.Text = "View DL of Model";
            this.btnViewClassificationInput.UseVisualStyleBackColor = true;
            this.btnViewClassificationInput.Click += new System.EventHandler(this.btnViewClassificationInput_Click);
            // 
            // btnClassification
            // 
            this.btnClassification.Location = new System.Drawing.Point(107, 178);
            this.btnClassification.Name = "btnClassification";
            this.btnClassification.Size = new System.Drawing.Size(121, 23);
            this.btnClassification.TabIndex = 15;
            this.btnClassification.Text = "Classification";
            this.btnClassification.UseVisualStyleBackColor = true;
            this.btnClassification.Click += new System.EventHandler(this.btnClassification_Click);
            // 
            // gBDangerLevel
            // 
            this.gBDangerLevel.Controls.Add(this.btnComputingLD);
            this.gBDangerLevel.Controls.Add(this.txtSourceLD);
            this.gBDangerLevel.Controls.Add(this.btnComputingDLDefault);
            this.gBDangerLevel.Controls.Add(this.txtDestinationLD);
            this.gBDangerLevel.Controls.Add(this.rdBenign);
            this.gBDangerLevel.Controls.Add(this.btnSourceLD);
            this.gBDangerLevel.Controls.Add(this.rdVirus);
            this.gBDangerLevel.Controls.Add(this.btnDestinationLD);
            this.gBDangerLevel.Location = new System.Drawing.Point(8, 6);
            this.gBDangerLevel.Name = "gBDangerLevel";
            this.gBDangerLevel.Size = new System.Drawing.Size(288, 152);
            this.gBDangerLevel.TabIndex = 32;
            this.gBDangerLevel.TabStop = false;
            this.gBDangerLevel.Text = "Danger Levels";
            // 
            // btnComputingLD
            // 
            this.btnComputingLD.Location = new System.Drawing.Point(107, 86);
            this.btnComputingLD.Name = "btnComputingLD";
            this.btnComputingLD.Size = new System.Drawing.Size(121, 23);
            this.btnComputingLD.TabIndex = 5;
            this.btnComputingLD.Text = "Computing";
            this.btnComputingLD.UseVisualStyleBackColor = true;
            this.btnComputingLD.Click += new System.EventHandler(this.btnComputingLD_Click);
            // 
            // txtSourceLD
            // 
            this.txtSourceLD.Location = new System.Drawing.Point(91, 27);
            this.txtSourceLD.Name = "txtSourceLD";
            this.txtSourceLD.Size = new System.Drawing.Size(191, 20);
            this.txtSourceLD.TabIndex = 4;
            // 
            // btnComputingDLDefault
            // 
            this.btnComputingDLDefault.Location = new System.Drawing.Point(107, 115);
            this.btnComputingDLDefault.Name = "btnComputingDLDefault";
            this.btnComputingDLDefault.Size = new System.Drawing.Size(121, 23);
            this.btnComputingDLDefault.TabIndex = 30;
            this.btnComputingDLDefault.Text = "Default Computing";
            this.btnComputingDLDefault.UseVisualStyleBackColor = true;
            this.btnComputingDLDefault.Click += new System.EventHandler(this.btnComputingDLDefault_Click);
            // 
            // txtDestinationLD
            // 
            this.txtDestinationLD.Location = new System.Drawing.Point(91, 54);
            this.txtDestinationLD.Name = "txtDestinationLD";
            this.txtDestinationLD.Size = new System.Drawing.Size(191, 20);
            this.txtDestinationLD.TabIndex = 6;
            // 
            // rdBenign
            // 
            this.rdBenign.AutoSize = true;
            this.rdBenign.Location = new System.Drawing.Point(10, 115);
            this.rdBenign.Name = "rdBenign";
            this.rdBenign.Size = new System.Drawing.Size(58, 17);
            this.rdBenign.TabIndex = 10;
            this.rdBenign.Text = "Benign";
            this.rdBenign.UseVisualStyleBackColor = true;
            // 
            // btnSourceLD
            // 
            this.btnSourceLD.Location = new System.Drawing.Point(10, 25);
            this.btnSourceLD.Name = "btnSourceLD";
            this.btnSourceLD.Size = new System.Drawing.Size(75, 23);
            this.btnSourceLD.TabIndex = 7;
            this.btnSourceLD.Text = "DL Source";
            this.btnSourceLD.UseVisualStyleBackColor = true;
            this.btnSourceLD.Click += new System.EventHandler(this.btnSourceLD_Click);
            // 
            // rdVirus
            // 
            this.rdVirus.AutoSize = true;
            this.rdVirus.Checked = true;
            this.rdVirus.Location = new System.Drawing.Point(10, 86);
            this.rdVirus.Name = "rdVirus";
            this.rdVirus.Size = new System.Drawing.Size(48, 17);
            this.rdVirus.TabIndex = 9;
            this.rdVirus.TabStop = true;
            this.rdVirus.Text = "Virus";
            this.rdVirus.UseVisualStyleBackColor = true;
            // 
            // btnDestinationLD
            // 
            this.btnDestinationLD.Location = new System.Drawing.Point(10, 54);
            this.btnDestinationLD.Name = "btnDestinationLD";
            this.btnDestinationLD.Size = new System.Drawing.Size(75, 23);
            this.btnDestinationLD.TabIndex = 8;
            this.btnDestinationLD.Text = "DL Des";
            this.btnDestinationLD.UseVisualStyleBackColor = true;
            this.btnDestinationLD.Click += new System.EventHandler(this.btnDestinationLD_Click);
            // 
            // Details
            // 
            this.Details.Controls.Add(this.tabControl3);
            this.Details.Location = new System.Drawing.Point(302, 3);
            this.Details.Name = "Details";
            this.Details.Size = new System.Drawing.Size(670, 644);
            this.Details.TabIndex = 31;
            this.Details.TabStop = false;
            this.Details.Text = "Details";
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage7);
            this.tabControl3.Controls.Add(this.tabPage10);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(3, 16);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(664, 625);
            this.tabControl3.TabIndex = 1;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.dGVDangerOfLevel);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(656, 599);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "Results of Danger Levels";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // dGVDangerOfLevel
            // 
            this.dGVDangerOfLevel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVDangerOfLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVDangerOfLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVDangerOfLevel.Location = new System.Drawing.Point(3, 3);
            this.dGVDangerOfLevel.Name = "dGVDangerOfLevel";
            this.dGVDangerOfLevel.ReadOnly = true;
            this.dGVDangerOfLevel.Size = new System.Drawing.Size(650, 593);
            this.dGVDangerOfLevel.TabIndex = 0;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.dGVClassificationInput);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(656, 599);
            this.tabPage10.TabIndex = 1;
            this.tabPage10.Text = "Classification Info";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // dGVClassificationInput
            // 
            this.dGVClassificationInput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVClassificationInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVClassificationInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVClassificationInput.Location = new System.Drawing.Point(3, 3);
            this.dGVClassificationInput.Name = "dGVClassificationInput";
            this.dGVClassificationInput.ReadOnly = true;
            this.dGVClassificationInput.Size = new System.Drawing.Size(650, 593);
            this.dGVClassificationInput.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbTimeElapsed);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.gBStates);
            this.tabPage1.Controls.Add(this.gBDirectory);
            this.tabPage1.Controls.Add(this.gBAiNet);
            this.tabPage1.Controls.Add(this.gBGenerateFirstDetectors);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(980, 657);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Training and Generating Detectors";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbTimeElapsed
            // 
            this.lbTimeElapsed.AutoSize = true;
            this.lbTimeElapsed.Location = new System.Drawing.Point(8, 639);
            this.lbTimeElapsed.Name = "lbTimeElapsed";
            this.lbTimeElapsed.Size = new System.Drawing.Size(130, 13);
            this.lbTimeElapsed.TabIndex = 33;
            this.lbTimeElapsed.Text = "Elapsed time: 00.00:00:00";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tabControl2);
            this.groupBox5.Location = new System.Drawing.Point(300, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(671, 549);
            this.groupBox5.TabIndex = 32;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Details";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Controls.Add(this.tabPage9);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 16);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(665, 530);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbClusteringResultMessage);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.btnLoadClusteringResult);
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(657, 504);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Clustering";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbClusteringResultMessage
            // 
            this.lbClusteringResultMessage.AutoSize = true;
            this.lbClusteringResultMessage.Location = new System.Drawing.Point(65, 483);
            this.lbClusteringResultMessage.Name = "lbClusteringResultMessage";
            this.lbClusteringResultMessage.Size = new System.Drawing.Size(0, 13);
            this.lbClusteringResultMessage.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 483);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Message:";
            // 
            // btnLoadClusteringResult
            // 
            this.btnLoadClusteringResult.Location = new System.Drawing.Point(573, 478);
            this.btnLoadClusteringResult.Name = "btnLoadClusteringResult";
            this.btnLoadClusteringResult.Size = new System.Drawing.Size(75, 23);
            this.btnLoadClusteringResult.TabIndex = 2;
            this.btnLoadClusteringResult.Text = "Load";
            this.btnLoadClusteringResult.UseVisualStyleBackColor = true;
            this.btnLoadClusteringResult.Click += new System.EventHandler(this.btnLoadClusteringResult_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dGVClusteredVirusGeneSet);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Location = new System.Drawing.Point(332, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(321, 477);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            // 
            // dGVClusteredVirusGeneSet
            // 
            this.dGVClusteredVirusGeneSet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVClusteredVirusGeneSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVClusteredVirusGeneSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVClusteredVirusGeneSet.Location = new System.Drawing.Point(3, 39);
            this.dGVClusteredVirusGeneSet.Name = "dGVClusteredVirusGeneSet";
            this.dGVClusteredVirusGeneSet.ReadOnly = true;
            this.dGVClusteredVirusGeneSet.Size = new System.Drawing.Size(315, 435);
            this.dGVClusteredVirusGeneSet.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label13.Location = new System.Drawing.Point(3, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(315, 23);
            this.label13.TabIndex = 2;
            this.label13.Text = "Virus gene set";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dGVClusteredBenignGeneSet);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(321, 477);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            // 
            // dGVClusteredBenignGeneSet
            // 
            this.dGVClusteredBenignGeneSet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVClusteredBenignGeneSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVClusteredBenignGeneSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVClusteredBenignGeneSet.Location = new System.Drawing.Point(3, 39);
            this.dGVClusteredBenignGeneSet.Name = "dGVClusteredBenignGeneSet";
            this.dGVClusteredBenignGeneSet.ReadOnly = true;
            this.dGVClusteredBenignGeneSet.Size = new System.Drawing.Size(315, 435);
            this.dGVClusteredBenignGeneSet.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label9.Location = new System.Drawing.Point(3, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(315, 23);
            this.label9.TabIndex = 1;
            this.label9.Text = "Benign gene set";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lbCleaningResultMessage);
            this.tabPage3.Controls.Add(this.label31);
            this.tabPage3.Controls.Add(this.btnLoadCleaningResult);
            this.tabPage3.Controls.Add(this.groupBox8);
            this.tabPage3.Controls.Add(this.groupBox9);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(657, 504);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Cleaning";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lbCleaningResultMessage
            // 
            this.lbCleaningResultMessage.AutoSize = true;
            this.lbCleaningResultMessage.Location = new System.Drawing.Point(68, 483);
            this.lbCleaningResultMessage.Name = "lbCleaningResultMessage";
            this.lbCleaningResultMessage.Size = new System.Drawing.Size(0, 13);
            this.lbCleaningResultMessage.TabIndex = 7;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(9, 483);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(53, 13);
            this.label31.TabIndex = 6;
            this.label31.Text = "Message:";
            // 
            // btnLoadCleaningResult
            // 
            this.btnLoadCleaningResult.Location = new System.Drawing.Point(576, 478);
            this.btnLoadCleaningResult.Name = "btnLoadCleaningResult";
            this.btnLoadCleaningResult.Size = new System.Drawing.Size(75, 23);
            this.btnLoadCleaningResult.TabIndex = 5;
            this.btnLoadCleaningResult.Text = "Load";
            this.btnLoadCleaningResult.UseVisualStyleBackColor = true;
            this.btnLoadCleaningResult.Click += new System.EventHandler(this.btnLoadCleaningResult_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.dGVCleaningVirusGeneSet);
            this.groupBox8.Controls.Add(this.label18);
            this.groupBox8.Location = new System.Drawing.Point(332, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(321, 477);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            // 
            // dGVCleaningVirusGeneSet
            // 
            this.dGVCleaningVirusGeneSet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVCleaningVirusGeneSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVCleaningVirusGeneSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVCleaningVirusGeneSet.Location = new System.Drawing.Point(3, 39);
            this.dGVCleaningVirusGeneSet.Name = "dGVCleaningVirusGeneSet";
            this.dGVCleaningVirusGeneSet.ReadOnly = true;
            this.dGVCleaningVirusGeneSet.Size = new System.Drawing.Size(315, 435);
            this.dGVCleaningVirusGeneSet.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label18.Location = new System.Drawing.Point(3, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(315, 23);
            this.label18.TabIndex = 2;
            this.label18.Text = "Virus gene set";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.dGVCleaningBenignGeneSet);
            this.groupBox9.Controls.Add(this.label19);
            this.groupBox9.Location = new System.Drawing.Point(3, 3);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(321, 477);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            // 
            // dGVCleaningBenignGeneSet
            // 
            this.dGVCleaningBenignGeneSet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVCleaningBenignGeneSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVCleaningBenignGeneSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVCleaningBenignGeneSet.Location = new System.Drawing.Point(3, 39);
            this.dGVCleaningBenignGeneSet.Name = "dGVCleaningBenignGeneSet";
            this.dGVCleaningBenignGeneSet.ReadOnly = true;
            this.dGVCleaningBenignGeneSet.Size = new System.Drawing.Size(315, 435);
            this.dGVCleaningBenignGeneSet.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.Dock = System.Windows.Forms.DockStyle.Top;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label19.Location = new System.Drawing.Point(3, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(315, 23);
            this.label19.TabIndex = 1;
            this.label19.Text = "Benign gene set";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.lbFirstDetectorResult);
            this.tabPage8.Controls.Add(this.label32);
            this.tabPage8.Controls.Add(this.btnLoadFirstDetectorsResult);
            this.tabPage8.Controls.Add(this.groupBox10);
            this.tabPage8.Controls.Add(this.groupBox11);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(657, 504);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "First Detectors";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // lbFirstDetectorResult
            // 
            this.lbFirstDetectorResult.AutoSize = true;
            this.lbFirstDetectorResult.Location = new System.Drawing.Point(67, 483);
            this.lbFirstDetectorResult.Name = "lbFirstDetectorResult";
            this.lbFirstDetectorResult.Size = new System.Drawing.Size(0, 13);
            this.lbFirstDetectorResult.TabIndex = 10;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(8, 483);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(53, 13);
            this.label32.TabIndex = 9;
            this.label32.Text = "Message:";
            // 
            // btnLoadFirstDetectorsResult
            // 
            this.btnLoadFirstDetectorsResult.Location = new System.Drawing.Point(575, 478);
            this.btnLoadFirstDetectorsResult.Name = "btnLoadFirstDetectorsResult";
            this.btnLoadFirstDetectorsResult.Size = new System.Drawing.Size(75, 23);
            this.btnLoadFirstDetectorsResult.TabIndex = 8;
            this.btnLoadFirstDetectorsResult.Text = "Load";
            this.btnLoadFirstDetectorsResult.UseVisualStyleBackColor = true;
            this.btnLoadFirstDetectorsResult.Click += new System.EventHandler(this.btnLoadFirstDetectorsResult_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.dGVDetector_NSA);
            this.groupBox10.Controls.Add(this.label20);
            this.groupBox10.Location = new System.Drawing.Point(332, 3);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(321, 477);
            this.groupBox10.TabIndex = 5;
            this.groupBox10.TabStop = false;
            // 
            // dGVDetector_NSA
            // 
            this.dGVDetector_NSA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVDetector_NSA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVDetector_NSA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVDetector_NSA.Location = new System.Drawing.Point(3, 39);
            this.dGVDetector_NSA.Name = "dGVDetector_NSA";
            this.dGVDetector_NSA.ReadOnly = true;
            this.dGVDetector_NSA.Size = new System.Drawing.Size(315, 435);
            this.dGVDetector_NSA.TabIndex = 3;
            // 
            // label20
            // 
            this.label20.Dock = System.Windows.Forms.DockStyle.Top;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label20.Location = new System.Drawing.Point(3, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(315, 23);
            this.label20.TabIndex = 2;
            this.label20.Text = "Detector set";
            this.label20.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.dGVVirusGeneSet_Detector);
            this.groupBox11.Controls.Add(this.label21);
            this.groupBox11.Location = new System.Drawing.Point(3, 3);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(321, 477);
            this.groupBox11.TabIndex = 4;
            this.groupBox11.TabStop = false;
            // 
            // dGVVirusGeneSet_Detector
            // 
            this.dGVVirusGeneSet_Detector.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVVirusGeneSet_Detector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVVirusGeneSet_Detector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVVirusGeneSet_Detector.Location = new System.Drawing.Point(3, 39);
            this.dGVVirusGeneSet_Detector.Name = "dGVVirusGeneSet_Detector";
            this.dGVVirusGeneSet_Detector.ReadOnly = true;
            this.dGVVirusGeneSet_Detector.Size = new System.Drawing.Size(315, 435);
            this.dGVVirusGeneSet_Detector.TabIndex = 0;
            // 
            // label21
            // 
            this.label21.Dock = System.Windows.Forms.DockStyle.Top;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label21.Location = new System.Drawing.Point(3, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(315, 23);
            this.label21.TabIndex = 1;
            this.label21.Text = "Virus gene set";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.lbaiNetResult);
            this.tabPage9.Controls.Add(this.label33);
            this.tabPage9.Controls.Add(this.btnLoadaiNetResult);
            this.tabPage9.Controls.Add(this.groupBox12);
            this.tabPage9.Controls.Add(this.groupBox13);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(657, 504);
            this.tabPage9.TabIndex = 3;
            this.tabPage9.Text = "aiNet";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // lbaiNetResult
            // 
            this.lbaiNetResult.AutoSize = true;
            this.lbaiNetResult.Location = new System.Drawing.Point(67, 483);
            this.lbaiNetResult.Name = "lbaiNetResult";
            this.lbaiNetResult.Size = new System.Drawing.Size(0, 13);
            this.lbaiNetResult.TabIndex = 13;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(8, 483);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(53, 13);
            this.label33.TabIndex = 12;
            this.label33.Text = "Message:";
            // 
            // btnLoadaiNetResult
            // 
            this.btnLoadaiNetResult.Location = new System.Drawing.Point(575, 478);
            this.btnLoadaiNetResult.Name = "btnLoadaiNetResult";
            this.btnLoadaiNetResult.Size = new System.Drawing.Size(75, 23);
            this.btnLoadaiNetResult.TabIndex = 11;
            this.btnLoadaiNetResult.Text = "Load";
            this.btnLoadaiNetResult.UseVisualStyleBackColor = true;
            this.btnLoadaiNetResult.Click += new System.EventHandler(this.btnLoadaiNetResult_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.dGVaiNetDetector_aiNet);
            this.groupBox12.Controls.Add(this.label22);
            this.groupBox12.Location = new System.Drawing.Point(332, 3);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(321, 477);
            this.groupBox12.TabIndex = 7;
            this.groupBox12.TabStop = false;
            // 
            // dGVaiNetDetector_aiNet
            // 
            this.dGVaiNetDetector_aiNet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVaiNetDetector_aiNet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVaiNetDetector_aiNet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVaiNetDetector_aiNet.Location = new System.Drawing.Point(3, 39);
            this.dGVaiNetDetector_aiNet.Name = "dGVaiNetDetector_aiNet";
            this.dGVaiNetDetector_aiNet.ReadOnly = true;
            this.dGVaiNetDetector_aiNet.Size = new System.Drawing.Size(315, 435);
            this.dGVaiNetDetector_aiNet.TabIndex = 3;
            // 
            // label22
            // 
            this.label22.Dock = System.Windows.Forms.DockStyle.Top;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label22.Location = new System.Drawing.Point(3, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(315, 23);
            this.label22.TabIndex = 2;
            this.label22.Text = "aiNet Detectors";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.dGVFirstDetectors_aiNet);
            this.groupBox13.Controls.Add(this.label23);
            this.groupBox13.Location = new System.Drawing.Point(3, 3);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(321, 477);
            this.groupBox13.TabIndex = 6;
            this.groupBox13.TabStop = false;
            // 
            // dGVFirstDetectors_aiNet
            // 
            this.dGVFirstDetectors_aiNet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVFirstDetectors_aiNet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVFirstDetectors_aiNet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVFirstDetectors_aiNet.Location = new System.Drawing.Point(3, 39);
            this.dGVFirstDetectors_aiNet.Name = "dGVFirstDetectors_aiNet";
            this.dGVFirstDetectors_aiNet.ReadOnly = true;
            this.dGVFirstDetectors_aiNet.Size = new System.Drawing.Size(315, 435);
            this.dGVFirstDetectors_aiNet.TabIndex = 0;
            // 
            // label23
            // 
            this.label23.Dock = System.Windows.Forms.DockStyle.Top;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label23.Location = new System.Drawing.Point(3, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(315, 23);
            this.label23.TabIndex = 1;
            this.label23.Text = "First detectors";
            this.label23.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gBStates
            // 
            this.gBStates.Controls.Add(this.rTBStates);
            this.gBStates.Location = new System.Drawing.Point(8, 553);
            this.gBStates.Name = "gBStates";
            this.gBStates.Size = new System.Drawing.Size(963, 87);
            this.gBStates.TabIndex = 31;
            this.gBStates.TabStop = false;
            this.gBStates.Text = "States";
            // 
            // rTBStates
            // 
            this.rTBStates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTBStates.Location = new System.Drawing.Point(3, 16);
            this.rTBStates.Name = "rTBStates";
            this.rTBStates.Size = new System.Drawing.Size(957, 68);
            this.rTBStates.TabIndex = 30;
            this.rTBStates.Text = "";
            // 
            // gBDirectory
            // 
            this.gBDirectory.Controls.Add(this.btnRootDirectoryBrowser);
            this.gBDirectory.Controls.Add(this.txtMainDirectory);
            this.gBDirectory.Location = new System.Drawing.Point(6, 6);
            this.gBDirectory.Name = "gBDirectory";
            this.gBDirectory.Size = new System.Drawing.Size(288, 51);
            this.gBDirectory.TabIndex = 28;
            this.gBDirectory.TabStop = false;
            this.gBDirectory.Text = "Root Directory";
            // 
            // btnRootDirectoryBrowser
            // 
            this.btnRootDirectoryBrowser.Location = new System.Drawing.Point(7, 20);
            this.btnRootDirectoryBrowser.Name = "btnRootDirectoryBrowser";
            this.btnRootDirectoryBrowser.Size = new System.Drawing.Size(86, 23);
            this.btnRootDirectoryBrowser.TabIndex = 6;
            this.btnRootDirectoryBrowser.Text = "Browser";
            this.btnRootDirectoryBrowser.UseVisualStyleBackColor = true;
            this.btnRootDirectoryBrowser.Click += new System.EventHandler(this.btnRootDirectoryBrowser_Click);
            // 
            // txtMainDirectory
            // 
            this.txtMainDirectory.Location = new System.Drawing.Point(97, 22);
            this.txtMainDirectory.Name = "txtMainDirectory";
            this.txtMainDirectory.Size = new System.Drawing.Size(171, 20);
            this.txtMainDirectory.TabIndex = 5;
            // 
            // gBAiNet
            // 
            this.gBAiNet.Controls.Add(this.nUDMatchingThresholdAiNet);
            this.gBAiNet.Controls.Add(this.label17);
            this.gBAiNet.Controls.Add(this.nUDSelectedClonesNum);
            this.gBAiNet.Controls.Add(this.label8);
            this.gBAiNet.Controls.Add(this.nUDNewRandomDetectors);
            this.gBAiNet.Controls.Add(this.label1);
            this.gBAiNet.Controls.Add(this.numericUpDownGeneration);
            this.gBAiNet.Controls.Add(this.btnaiNet);
            this.gBAiNet.Controls.Add(this.label6);
            this.gBAiNet.Controls.Add(this.label3);
            this.gBAiNet.Controls.Add(this.nUDClonesNum_APattern);
            this.gBAiNet.Controls.Add(this.nUDSupThreshold);
            this.gBAiNet.Controls.Add(this.label4);
            this.gBAiNet.Location = new System.Drawing.Point(7, 305);
            this.gBAiNet.Name = "gBAiNet";
            this.gBAiNet.Size = new System.Drawing.Size(287, 247);
            this.gBAiNet.TabIndex = 27;
            this.gBAiNet.TabStop = false;
            this.gBAiNet.Text = "AiNet Paramaters";
            // 
            // nUDMatchingThresholdAiNet
            // 
            this.nUDMatchingThresholdAiNet.DecimalPlaces = 7;
            this.nUDMatchingThresholdAiNet.Location = new System.Drawing.Point(197, 41);
            this.nUDMatchingThresholdAiNet.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDMatchingThresholdAiNet.Name = "nUDMatchingThresholdAiNet";
            this.nUDMatchingThresholdAiNet.Size = new System.Drawing.Size(75, 20);
            this.nUDMatchingThresholdAiNet.TabIndex = 32;
            this.nUDMatchingThresholdAiNet.Value = new decimal(new int[] {
            84375,
            0,
            0,
            327680});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(42, 44);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(150, 13);
            this.label17.TabIndex = 31;
            this.label17.Text = "Matching Threshold AiNet (sk)";
            // 
            // nUDSelectedClonesNum
            // 
            this.nUDSelectedClonesNum.Location = new System.Drawing.Point(197, 97);
            this.nUDSelectedClonesNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDSelectedClonesNum.Name = "nUDSelectedClonesNum";
            this.nUDSelectedClonesNum.Size = new System.Drawing.Size(75, 20);
            this.nUDSelectedClonesNum.TabIndex = 24;
            this.nUDSelectedClonesNum.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Number of Selected Clones (m)";
            // 
            // nUDNewRandomDetectors
            // 
            this.nUDNewRandomDetectors.Location = new System.Drawing.Point(197, 156);
            this.nUDNewRandomDetectors.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDNewRandomDetectors.Name = "nUDNewRandomDetectors";
            this.nUDNewRandomDetectors.Size = new System.Drawing.Size(75, 20);
            this.nUDNewRandomDetectors.TabIndex = 23;
            this.nUDNewRandomDetectors.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Number of New Random Detectors (k)";
            // 
            // numericUpDownGeneration
            // 
            this.numericUpDownGeneration.Location = new System.Drawing.Point(197, 15);
            this.numericUpDownGeneration.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownGeneration.Name = "numericUpDownGeneration";
            this.numericUpDownGeneration.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownGeneration.TabIndex = 12;
            this.numericUpDownGeneration.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnaiNet
            // 
            this.btnaiNet.Location = new System.Drawing.Point(160, 193);
            this.btnaiNet.Name = "btnaiNet";
            this.btnaiNet.Size = new System.Drawing.Size(121, 23);
            this.btnaiNet.TabIndex = 6;
            this.btnaiNet.Text = "aiNet";
            this.btnaiNet.UseVisualStyleBackColor = true;
            this.btnaiNet.Click += new System.EventHandler(this.btnaiNet_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Number of Clones for A Pattern";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Generations (n)";
            // 
            // nUDClonesNum_APattern
            // 
            this.nUDClonesNum_APattern.Location = new System.Drawing.Point(197, 127);
            this.nUDClonesNum_APattern.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDClonesNum_APattern.Name = "nUDClonesNum_APattern";
            this.nUDClonesNum_APattern.Size = new System.Drawing.Size(75, 20);
            this.nUDClonesNum_APattern.TabIndex = 20;
            this.nUDClonesNum_APattern.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nUDSupThreshold
            // 
            this.nUDSupThreshold.DecimalPlaces = 7;
            this.nUDSupThreshold.Location = new System.Drawing.Point(197, 69);
            this.nUDSupThreshold.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDSupThreshold.Name = "nUDSupThreshold";
            this.nUDSupThreshold.Size = new System.Drawing.Size(75, 20);
            this.nUDSupThreshold.TabIndex = 15;
            this.nUDSupThreshold.Value = new decimal(new int[] {
            90625,
            0,
            0,
            327680});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "SuppressionThreshold (sp)";
            // 
            // gBGenerateFirstDetectors
            // 
            this.gBGenerateFirstDetectors.Controls.Add(this.nUDMaxErrors);
            this.gBGenerateFirstDetectors.Controls.Add(this.label16);
            this.gBGenerateFirstDetectors.Controls.Add(this.nUDNSADetectorCount);
            this.gBGenerateFirstDetectors.Controls.Add(this.label15);
            this.gBGenerateFirstDetectors.Controls.Add(this.btnCleanVirusGeneSet);
            this.gBGenerateFirstDetectors.Controls.Add(this.btnClustering);
            this.gBGenerateFirstDetectors.Controls.Add(this.btnOnlyNSA);
            this.gBGenerateFirstDetectors.Controls.Add(this.nUDLimitCountforDBSCAN);
            this.gBGenerateFirstDetectors.Controls.Add(this.label10);
            this.gBGenerateFirstDetectors.Controls.Add(this.nUDMatchingThreshold);
            this.gBGenerateFirstDetectors.Controls.Add(this.label7);
            this.gBGenerateFirstDetectors.Controls.Add(this.btnRunNSA);
            this.gBGenerateFirstDetectors.Controls.Add(this.nUDClusteringThreshold);
            this.gBGenerateFirstDetectors.Controls.Add(this.label2);
            this.gBGenerateFirstDetectors.Location = new System.Drawing.Point(8, 63);
            this.gBGenerateFirstDetectors.Name = "gBGenerateFirstDetectors";
            this.gBGenerateFirstDetectors.Size = new System.Drawing.Size(286, 236);
            this.gBGenerateFirstDetectors.TabIndex = 26;
            this.gBGenerateFirstDetectors.TabStop = false;
            this.gBGenerateFirstDetectors.Text = "Generate First Detectors";
            // 
            // nUDMaxErrors
            // 
            this.nUDMaxErrors.Location = new System.Drawing.Point(198, 133);
            this.nUDMaxErrors.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDMaxErrors.Name = "nUDMaxErrors";
            this.nUDMaxErrors.Size = new System.Drawing.Size(74, 20);
            this.nUDMaxErrors.TabIndex = 36;
            this.nUDMaxErrors.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(132, 133);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 37;
            this.label16.Text = "Error Count";
            // 
            // nUDNSADetectorCount
            // 
            this.nUDNSADetectorCount.Location = new System.Drawing.Point(198, 105);
            this.nUDNSADetectorCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDNSADetectorCount.Name = "nUDNSADetectorCount";
            this.nUDNSADetectorCount.Size = new System.Drawing.Size(74, 20);
            this.nUDNSADetectorCount.TabIndex = 34;
            this.nUDNSADetectorCount.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(89, 106);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(103, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "Number of detectors";
            // 
            // btnCleanVirusGeneSet
            // 
            this.btnCleanVirusGeneSet.Location = new System.Drawing.Point(159, 170);
            this.btnCleanVirusGeneSet.Name = "btnCleanVirusGeneSet";
            this.btnCleanVirusGeneSet.Size = new System.Drawing.Size(121, 23);
            this.btnCleanVirusGeneSet.TabIndex = 31;
            this.btnCleanVirusGeneSet.Text = "Clean Virus Gene Set";
            this.btnCleanVirusGeneSet.UseVisualStyleBackColor = true;
            this.btnCleanVirusGeneSet.Click += new System.EventHandler(this.btnCleanVirusGeneSet_Click);
            // 
            // btnClustering
            // 
            this.btnClustering.Location = new System.Drawing.Point(28, 170);
            this.btnClustering.Name = "btnClustering";
            this.btnClustering.Size = new System.Drawing.Size(120, 23);
            this.btnClustering.TabIndex = 30;
            this.btnClustering.Text = "Clustering";
            this.btnClustering.UseVisualStyleBackColor = true;
            this.btnClustering.Click += new System.EventHandler(this.btnClustering_Click);
            // 
            // btnOnlyNSA
            // 
            this.btnOnlyNSA.Location = new System.Drawing.Point(28, 197);
            this.btnOnlyNSA.Name = "btnOnlyNSA";
            this.btnOnlyNSA.Size = new System.Drawing.Size(120, 23);
            this.btnOnlyNSA.TabIndex = 7;
            this.btnOnlyNSA.Text = "Generate Detector";
            this.btnOnlyNSA.UseVisualStyleBackColor = true;
            this.btnOnlyNSA.Click += new System.EventHandler(this.btnOnlyNSA_Click);
            // 
            // nUDLimitCountforDBSCAN
            // 
            this.nUDLimitCountforDBSCAN.Location = new System.Drawing.Point(197, 76);
            this.nUDLimitCountforDBSCAN.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDLimitCountforDBSCAN.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nUDLimitCountforDBSCAN.Name = "nUDLimitCountforDBSCAN";
            this.nUDLimitCountforDBSCAN.Size = new System.Drawing.Size(75, 20);
            this.nUDLimitCountforDBSCAN.TabIndex = 29;
            this.nUDLimitCountforDBSCAN.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(71, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Limit Count for DBSCAN";
            // 
            // nUDMatchingThreshold
            // 
            this.nUDMatchingThreshold.DecimalPlaces = 7;
            this.nUDMatchingThreshold.Location = new System.Drawing.Point(197, 48);
            this.nUDMatchingThreshold.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDMatchingThreshold.Name = "nUDMatchingThreshold";
            this.nUDMatchingThreshold.Size = new System.Drawing.Size(75, 20);
            this.nUDMatchingThreshold.TabIndex = 24;
            this.nUDMatchingThreshold.Value = new decimal(new int[] {
            84375,
            0,
            0,
            327680});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(74, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "MatchingThreshold (sk)";
            // 
            // btnRunNSA
            // 
            this.btnRunNSA.Location = new System.Drawing.Point(159, 197);
            this.btnRunNSA.Name = "btnRunNSA";
            this.btnRunNSA.Size = new System.Drawing.Size(121, 23);
            this.btnRunNSA.TabIndex = 5;
            this.btnRunNSA.Text = "Run All First Steps";
            this.btnRunNSA.UseVisualStyleBackColor = true;
            this.btnRunNSA.Click += new System.EventHandler(this.btnRunNSA_Click);
            // 
            // nUDClusteringThreshold
            // 
            this.nUDClusteringThreshold.DecimalPlaces = 7;
            this.nUDClusteringThreshold.Location = new System.Drawing.Point(197, 21);
            this.nUDClusteringThreshold.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDClusteringThreshold.Name = "nUDClusteringThreshold";
            this.nUDClusteringThreshold.Size = new System.Drawing.Size(75, 20);
            this.nUDClusteringThreshold.TabIndex = 22;
            this.nUDClusteringThreshold.Value = new decimal(new int[] {
            9375,
            0,
            0,
            262144});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "ClusteringThreshold (gc)";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(988, 683);
            this.tabControl1.TabIndex = 5;
            // 
            // elapsedTimer
            // 
            this.elapsedTimer.Interval = 1000;
            this.elapsedTimer.Tick += new System.EventHandler(this.elapsedTimer_Tick);
            // 
            // elapsedTimer2
            // 
            this.elapsedTimer2.Interval = 1000;
            this.elapsedTimer2.Tick += new System.EventHandler(this.elapsedtimer2_Tick);
            // 
            // elapsedTimer3
            // 
            this.elapsedTimer3.Interval = 1000;
            this.elapsedTimer3.Tick += new System.EventHandler(this.elapsedTimer3_Tick);
            // 
            // FrmVDS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 683);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmVDS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "-Virus Dectection System-";
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.tabControl4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVTestingResult)).EndInit();
            this.gBTestInformation.ResumeLayout(false);
            this.gBTestInformation.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.gBClassification.ResumeLayout(false);
            this.gBClassification.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDGuassKernelPara)).EndInit();
            this.gBDangerLevel.ResumeLayout(false);
            this.gBDangerLevel.PerformLayout();
            this.Details.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVDangerOfLevel)).EndInit();
            this.tabPage10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVClassificationInput)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVClusteredVirusGeneSet)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVClusteredBenignGeneSet)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVCleaningVirusGeneSet)).EndInit();
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVCleaningBenignGeneSet)).EndInit();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVDetector_NSA)).EndInit();
            this.groupBox11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVVirusGeneSet_Detector)).EndInit();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVaiNetDetector_aiNet)).EndInit();
            this.groupBox13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVFirstDetectors_aiNet)).EndInit();
            this.gBStates.ResumeLayout(false);
            this.gBDirectory.ResumeLayout(false);
            this.gBDirectory.PerformLayout();
            this.gBAiNet.ResumeLayout(false);
            this.gBAiNet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMatchingThresholdAiNet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDSelectedClonesNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDNewRandomDetectors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGeneration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDClonesNum_APattern)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDSupThreshold)).EndInit();
            this.gBGenerateFirstDetectors.ResumeLayout(false);
            this.gBGenerateFirstDetectors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMaxErrors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDNSADetectorCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLimitCountforDBSCAN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMatchingThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDClusteringThreshold)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btnDLFile;
        private System.Windows.Forms.TextBox txtTestFile;
        private System.Windows.Forms.Button btnTestModel;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnComputingDLDefault;
        private System.Windows.Forms.RadioButton rdBenign;
        private System.Windows.Forms.RadioButton rdVirus;
        private System.Windows.Forms.Button btnDestinationLD;
        private System.Windows.Forms.Button btnSourceLD;
        private System.Windows.Forms.TextBox txtDestinationLD;
        private System.Windows.Forms.TextBox txtSourceLD;
        private System.Windows.Forms.Button btnComputingLD;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridView dGVClusteredVirusGeneSet;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dGVClusteredBenignGeneSet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGridView dGVCleaningVirusGeneSet;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.DataGridView dGVCleaningBenignGeneSet;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.DataGridView dGVDetector_NSA;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.DataGridView dGVVirusGeneSet_Detector;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.DataGridView dGVaiNetDetector_aiNet;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.DataGridView dGVFirstDetectors_aiNet;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox gBStates;
        private System.Windows.Forms.RichTextBox rTBStates;
        private System.Windows.Forms.GroupBox gBDirectory;
        private System.Windows.Forms.GroupBox gBAiNet;
        private System.Windows.Forms.NumericUpDown nUDMatchingThresholdAiNet;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown nUDSelectedClonesNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nUDNewRandomDetectors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownGeneration;
        private System.Windows.Forms.Button btnaiNet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nUDClonesNum_APattern;
        private System.Windows.Forms.NumericUpDown nUDSupThreshold;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gBGenerateFirstDetectors;
        private System.Windows.Forms.NumericUpDown nUDMaxErrors;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown nUDNSADetectorCount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnCleanVirusGeneSet;
        private System.Windows.Forms.Button btnClustering;
        private System.Windows.Forms.Button btnOnlyNSA;
        private System.Windows.Forms.NumericUpDown nUDLimitCountforDBSCAN;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nUDMatchingThreshold;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRunNSA;
        private System.Windows.Forms.NumericUpDown nUDClusteringThreshold;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox Details;
        private System.Windows.Forms.DataGridView dGVDangerOfLevel;
        private System.Windows.Forms.GroupBox gBClassification;
        private System.Windows.Forms.Button btnClassification;
        private System.Windows.Forms.GroupBox gBDangerLevel;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.DataGridView dGVClassificationInput;
        private System.Windows.Forms.Button btnViewClassificationInput;
        private System.Windows.Forms.GroupBox gBTestInformation;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dGVTestingResult;
        private System.Windows.Forms.Button btnDLFolder;
        private System.Windows.Forms.TextBox txtTestingFolder;
        private System.Windows.Forms.RadioButton rdFolderTesting;
        private System.Windows.Forms.RadioButton rdDangerLevelFileTesting;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.Label lbWrongTestCount;
        private System.Windows.Forms.Label lbCorrectTestCount;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbBenignCount_TestModel;
        private System.Windows.Forms.Label lbVirusCount_TestModel;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown nUDGuassKernelPara;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btnCreateModel;
        private System.Windows.Forms.Label lbRateFileTesting;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLoadClusteringResult;
        private System.Windows.Forms.Label lbClusteringResultMessage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbCleaningResultMessage;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Button btnLoadCleaningResult;
        private System.Windows.Forms.Label lbFirstDetectorResult;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button btnLoadFirstDetectorsResult;
        private System.Windows.Forms.Label lbaiNetResult;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button btnLoadaiNetResult;
        private System.Windows.Forms.Label lbDangerLevelAndClassificationStatus;
        private System.Windows.Forms.Label lbTestStatus;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txtMainDirectory;
        private System.Windows.Forms.Button btnRootDirectoryBrowser;
        private System.Windows.Forms.Timer elapsedTimer;
        private System.Windows.Forms.Label lbTimeElapsed;
        private System.Windows.Forms.Timer elapsedTimer2;
        private System.Windows.Forms.Timer elapsedTimer3;
    }
}

