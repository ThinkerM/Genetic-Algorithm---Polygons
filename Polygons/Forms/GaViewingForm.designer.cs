namespace Polygons.Forms
{
    partial class GaViewerForm
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
            System.Windows.Forms.SplitContainer splitContainer;
            System.Windows.Forms.GroupBox gaSettingsBox;
            System.Windows.Forms.Label saveFrequencyLabel;
            System.Windows.Forms.Label stopFrequencyLabel2;
            System.Windows.Forms.Label stopFrequencyLabel1;
            System.Windows.Forms.GroupBox selectionGroupBox;
            System.Windows.Forms.Label maximumDistanceMutationLabel;
            System.Windows.Forms.Label crossoverChanceLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GaViewerForm));
            System.Windows.Forms.Label mutationChanceLabel;
            System.Windows.Forms.Label maximumDegreesMutationLabel;
            System.Windows.Forms.Label horizontalSeparator1;
            System.Windows.Forms.Label horizontalSeparator2;
            System.Windows.Forms.Label picturesSizeLabel;
            this.toolsLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.GaInitTab = new System.Windows.Forms.TabPage();
            this.savedGenerationsCombobox = new System.Windows.Forms.ComboBox();
            this.saveFrequencyUpdown = new System.Windows.Forms.NumericUpDown();
            this.terminationConditionsGroupBox = new System.Windows.Forms.GroupBox();
            this.improvementRatioUpdown = new System.Windows.Forms.NumericUpDown();
            this.terminationGenerationUpdown = new System.Windows.Forms.NumericUpDown();
            this.useFitnessCheckbox = new System.Windows.Forms.CheckBox();
            this.useGenerationNumberCheckbox = new System.Windows.Forms.CheckBox();
            this.radioButtonsPanel = new System.Windows.Forms.Panel();
            this.andRadioButton = new System.Windows.Forms.RadioButton();
            this.orRadioButton = new System.Windows.Forms.RadioButton();
            this.fitnessFunctionComboBox = new System.Windows.Forms.ComboBox();
            this.pauseFrequencyUpdown = new System.Windows.Forms.NumericUpDown();
            this.startStopGaButton = new System.Windows.Forms.Button();
            this.importInitialPopulationButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.fitnessfunctionLabel = new System.Windows.Forms.Label();
            this.gaSettingsTab = new System.Windows.Forms.TabPage();
            this.populationSizeUpdown = new System.Windows.Forms.NumericUpDown();
            this.populationSizeLabel = new System.Windows.Forms.Label();
            this.resetSettingsButton = new System.Windows.Forms.Button();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.elitismCheckbox = new System.Windows.Forms.CheckBox();
            this.verticesCountUpdown = new System.Windows.Forms.NumericUpDown();
            this.rouletteRadioButton = new System.Windows.Forms.RadioButton();
            this.steadyStateRadioButton = new System.Windows.Forms.RadioButton();
            this.verticesCountLabel = new System.Windows.Forms.Label();
            this.crossoverUpdown = new System.Windows.Forms.NumericUpDown();
            this.steadyStateRateUpdown = new System.Windows.Forms.NumericUpDown();
            this.maxDistanceMutationUpdown = new System.Windows.Forms.NumericUpDown();
            this.maxAngleMutationUpdown = new System.Windows.Forms.NumericUpDown();
            this.mutationUpdown = new System.Windows.Forms.NumericUpDown();
            this.steadyStateLabel = new System.Windows.Forms.Label();
            this.imagesTab = new System.Windows.Forms.TabPage();
            this.clearPopulationButton = new System.Windows.Forms.Button();
            this.picturesSizeBar = new System.Windows.Forms.TrackBar();
            this.sortPopulationCheckbox = new System.Windows.Forms.CheckBox();
            this.resetColorButton = new System.Windows.Forms.Button();
            this.picturesBackColorButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.picturesLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.logBox = new System.Windows.Forms.ListBox();
            this.picturesBackgroundColorDialog = new System.Windows.Forms.ColorDialog();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gaBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.importPopulationDialog = new System.Windows.Forms.OpenFileDialog();
            splitContainer = new System.Windows.Forms.SplitContainer();
            gaSettingsBox = new System.Windows.Forms.GroupBox();
            saveFrequencyLabel = new System.Windows.Forms.Label();
            stopFrequencyLabel2 = new System.Windows.Forms.Label();
            stopFrequencyLabel1 = new System.Windows.Forms.Label();
            selectionGroupBox = new System.Windows.Forms.GroupBox();
            maximumDistanceMutationLabel = new System.Windows.Forms.Label();
            crossoverChanceLabel = new System.Windows.Forms.Label();
            mutationChanceLabel = new System.Windows.Forms.Label();
            maximumDegreesMutationLabel = new System.Windows.Forms.Label();
            horizontalSeparator1 = new System.Windows.Forms.Label();
            horizontalSeparator2 = new System.Windows.Forms.Label();
            picturesSizeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(splitContainer)).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            this.toolsLayoutPanel.SuspendLayout();
            gaSettingsBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.GaInitTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saveFrequencyUpdown)).BeginInit();
            this.terminationConditionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.improvementRatioUpdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.terminationGenerationUpdown)).BeginInit();
            this.radioButtonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pauseFrequencyUpdown)).BeginInit();
            this.gaSettingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.populationSizeUpdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verticesCountUpdown)).BeginInit();
            selectionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crossoverUpdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.steadyStateRateUpdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxDistanceMutationUpdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxAngleMutationUpdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationUpdown)).BeginInit();
            this.imagesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturesSizeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            splitContainer.IsSplitterFixed = true;
            splitContainer.Location = new System.Drawing.Point(0, 0);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.BackColor = System.Drawing.Color.DarkCyan;
            splitContainer.Panel1.Controls.Add(this.toolsLayoutPanel);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(this.splitContainer1);
            splitContainer.Size = new System.Drawing.Size(826, 565);
            splitContainer.SplitterDistance = 137;
            splitContainer.TabIndex = 0;
            // 
            // toolsLayoutPanel
            // 
            this.toolsLayoutPanel.Controls.Add(gaSettingsBox);
            this.toolsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolsLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.toolsLayoutPanel.Name = "toolsLayoutPanel";
            this.toolsLayoutPanel.Size = new System.Drawing.Size(137, 565);
            this.toolsLayoutPanel.TabIndex = 0;
            // 
            // gaSettingsBox
            // 
            gaSettingsBox.Controls.Add(this.tabControl1);
            gaSettingsBox.Location = new System.Drawing.Point(3, 3);
            gaSettingsBox.Name = "gaSettingsBox";
            gaSettingsBox.Size = new System.Drawing.Size(131, 501);
            gaSettingsBox.TabIndex = 5;
            gaSettingsBox.TabStop = false;
            gaSettingsBox.Text = "Options";
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.GaInitTab);
            this.tabControl1.Controls.Add(this.gaSettingsTab);
            this.tabControl1.Controls.Add(this.imagesTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(125, 482);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 2;
            // 
            // GaInitTab
            // 
            this.GaInitTab.BackColor = System.Drawing.Color.Teal;
            this.GaInitTab.Controls.Add(this.savedGenerationsCombobox);
            this.GaInitTab.Controls.Add(this.saveFrequencyUpdown);
            this.GaInitTab.Controls.Add(saveFrequencyLabel);
            this.GaInitTab.Controls.Add(this.terminationConditionsGroupBox);
            this.GaInitTab.Controls.Add(this.fitnessFunctionComboBox);
            this.GaInitTab.Controls.Add(stopFrequencyLabel2);
            this.GaInitTab.Controls.Add(stopFrequencyLabel1);
            this.GaInitTab.Controls.Add(this.pauseFrequencyUpdown);
            this.GaInitTab.Controls.Add(this.startStopGaButton);
            this.GaInitTab.Controls.Add(this.importInitialPopulationButton);
            this.GaInitTab.Controls.Add(this.continueButton);
            this.GaInitTab.Controls.Add(this.fitnessfunctionLabel);
            this.GaInitTab.Location = new System.Drawing.Point(23, 4);
            this.GaInitTab.Name = "GaInitTab";
            this.GaInitTab.Padding = new System.Windows.Forms.Padding(3);
            this.GaInitTab.Size = new System.Drawing.Size(98, 474);
            this.GaInitTab.TabIndex = 0;
            this.GaInitTab.Text = "Genetic Algorithm";
            // 
            // savedGenerationsCombobox
            // 
            this.savedGenerationsCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.savedGenerationsCombobox.FormattingEnabled = true;
            this.savedGenerationsCombobox.Location = new System.Drawing.Point(3, 23);
            this.savedGenerationsCombobox.Name = "savedGenerationsCombobox";
            this.savedGenerationsCombobox.Size = new System.Drawing.Size(92, 21);
            this.savedGenerationsCombobox.TabIndex = 11;
            this.savedGenerationsCombobox.Visible = false;
            this.savedGenerationsCombobox.SelectedIndexChanged += new System.EventHandler(this.savedGenerationsCombobox_SelectedItemChanged);
            // 
            // saveFrequencyUpdown
            // 
            this.saveFrequencyUpdown.Location = new System.Drawing.Point(26, 429);
            this.saveFrequencyUpdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.saveFrequencyUpdown.Name = "saveFrequencyUpdown";
            this.saveFrequencyUpdown.Size = new System.Drawing.Size(52, 20);
            this.saveFrequencyUpdown.TabIndex = 10;
            this.toolTip.SetToolTip(this.saveFrequencyUpdown, "Every n-th generation will be saved for later viewing");
            this.saveFrequencyUpdown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // saveFrequencyLabel
            // 
            saveFrequencyLabel.Location = new System.Drawing.Point(3, 410);
            saveFrequencyLabel.Name = "saveFrequencyLabel";
            saveFrequencyLabel.Size = new System.Drawing.Size(72, 16);
            saveFrequencyLabel.TabIndex = 9;
            saveFrequencyLabel.Text = "Save every";
            // 
            // terminationConditionsGroupBox
            // 
            this.terminationConditionsGroupBox.Controls.Add(this.improvementRatioUpdown);
            this.terminationConditionsGroupBox.Controls.Add(this.terminationGenerationUpdown);
            this.terminationConditionsGroupBox.Controls.Add(this.useFitnessCheckbox);
            this.terminationConditionsGroupBox.Controls.Add(this.useGenerationNumberCheckbox);
            this.terminationConditionsGroupBox.Controls.Add(this.radioButtonsPanel);
            this.terminationConditionsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.terminationConditionsGroupBox.Location = new System.Drawing.Point(0, 65);
            this.terminationConditionsGroupBox.Name = "terminationConditionsGroupBox";
            this.terminationConditionsGroupBox.Size = new System.Drawing.Size(105, 198);
            this.terminationConditionsGroupBox.TabIndex = 7;
            this.terminationConditionsGroupBox.TabStop = false;
            this.terminationConditionsGroupBox.Text = "Termination conditions";
            // 
            // improvementRatioUpdown
            // 
            this.improvementRatioUpdown.DecimalPlaces = 2;
            this.improvementRatioUpdown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.improvementRatioUpdown.Location = new System.Drawing.Point(23, 166);
            this.improvementRatioUpdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.improvementRatioUpdown.Name = "improvementRatioUpdown";
            this.improvementRatioUpdown.Size = new System.Drawing.Size(69, 20);
            this.improvementRatioUpdown.TabIndex = 4;
            this.improvementRatioUpdown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // terminationGenerationUpdown
            // 
            this.terminationGenerationUpdown.Location = new System.Drawing.Point(20, 61);
            this.terminationGenerationUpdown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.terminationGenerationUpdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.terminationGenerationUpdown.Name = "terminationGenerationUpdown";
            this.terminationGenerationUpdown.Size = new System.Drawing.Size(72, 20);
            this.terminationGenerationUpdown.TabIndex = 3;
            this.terminationGenerationUpdown.ThousandsSeparator = true;
            this.terminationGenerationUpdown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // useFitnessCheckbox
            // 
            this.useFitnessCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useFitnessCheckbox.Location = new System.Drawing.Point(4, 120);
            this.useFitnessCheckbox.Name = "useFitnessCheckbox";
            this.useFitnessCheckbox.Size = new System.Drawing.Size(95, 43);
            this.useFitnessCheckbox.TabIndex = 1;
            this.useFitnessCheckbox.Text = "Top fitness improvement over initial";
            this.toolTip.SetToolTip(this.useFitnessCheckbox, "Consider improvement relative to initial best fitness as termination");
            this.useFitnessCheckbox.UseVisualStyleBackColor = true;
            // 
            // useGenerationNumberCheckbox
            // 
            this.useGenerationNumberCheckbox.Checked = true;
            this.useGenerationNumberCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useGenerationNumberCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useGenerationNumberCheckbox.Location = new System.Drawing.Point(6, 29);
            this.useGenerationNumberCheckbox.Name = "useGenerationNumberCheckbox";
            this.useGenerationNumberCheckbox.Size = new System.Drawing.Size(92, 30);
            this.useGenerationNumberCheckbox.TabIndex = 0;
            this.useGenerationNumberCheckbox.Text = "Generation N reached:";
            this.toolTip.SetToolTip(this.useGenerationNumberCheckbox, "Consider the generation number while terminating");
            this.useGenerationNumberCheckbox.UseVisualStyleBackColor = true;
            // 
            // radioButtonsPanel
            // 
            this.radioButtonsPanel.Controls.Add(this.andRadioButton);
            this.radioButtonsPanel.Controls.Add(this.orRadioButton);
            this.radioButtonsPanel.Location = new System.Drawing.Point(0, 88);
            this.radioButtonsPanel.Name = "radioButtonsPanel";
            this.radioButtonsPanel.Size = new System.Drawing.Size(98, 27);
            this.radioButtonsPanel.TabIndex = 2;
            // 
            // andRadioButton
            // 
            this.andRadioButton.AutoSize = true;
            this.andRadioButton.Location = new System.Drawing.Point(48, 7);
            this.andRadioButton.Name = "andRadioButton";
            this.andRadioButton.Size = new System.Drawing.Size(51, 17);
            this.andRadioButton.TabIndex = 1;
            this.andRadioButton.Text = "AND";
            this.andRadioButton.UseVisualStyleBackColor = true;
            // 
            // orRadioButton
            // 
            this.orRadioButton.AutoSize = true;
            this.orRadioButton.Checked = true;
            this.orRadioButton.Location = new System.Drawing.Point(6, 7);
            this.orRadioButton.Name = "orRadioButton";
            this.orRadioButton.Size = new System.Drawing.Size(43, 17);
            this.orRadioButton.TabIndex = 0;
            this.orRadioButton.TabStop = true;
            this.orRadioButton.Text = "OR";
            this.orRadioButton.UseVisualStyleBackColor = true;
            // 
            // fitnessFunctionComboBox
            // 
            this.fitnessFunctionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fitnessFunctionComboBox.FormattingEnabled = true;
            this.fitnessFunctionComboBox.Location = new System.Drawing.Point(3, 290);
            this.fitnessFunctionComboBox.Name = "fitnessFunctionComboBox";
            this.fitnessFunctionComboBox.Size = new System.Drawing.Size(92, 21);
            this.fitnessFunctionComboBox.TabIndex = 5;
            this.toolTip.SetToolTip(this.fitnessFunctionComboBox, "Select which fitness function should be used for evaluation");
            this.fitnessFunctionComboBox.DropDown += new System.EventHandler(this.fitnessFunctionComboBox_DropDown);
            this.fitnessFunctionComboBox.DropDownClosed += new System.EventHandler(this.fitnessFunctionComboBox_DropDownClosed);
            this.fitnessFunctionComboBox.SelectedValueChanged += new System.EventHandler(this.fitnessFunctionComboBox_SelectedValueChanged);
            // 
            // stopFrequencyLabel2
            // 
            stopFrequencyLabel2.AutoSize = true;
            stopFrequencyLabel2.Location = new System.Drawing.Point(30, 453);
            stopFrequencyLabel2.Name = "stopFrequencyLabel2";
            stopFrequencyLabel2.Size = new System.Drawing.Size(62, 13);
            stopFrequencyLabel2.TabIndex = 4;
            stopFrequencyLabel2.Text = "generations";
            // 
            // stopFrequencyLabel1
            // 
            stopFrequencyLabel1.Location = new System.Drawing.Point(3, 368);
            stopFrequencyLabel1.Name = "stopFrequencyLabel1";
            stopFrequencyLabel1.Size = new System.Drawing.Size(72, 16);
            stopFrequencyLabel1.TabIndex = 3;
            stopFrequencyLabel1.Text = "Pause every";
            // 
            // pauseFrequencyUpdown
            // 
            this.pauseFrequencyUpdown.Location = new System.Drawing.Point(26, 387);
            this.pauseFrequencyUpdown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.pauseFrequencyUpdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pauseFrequencyUpdown.Name = "pauseFrequencyUpdown";
            this.pauseFrequencyUpdown.Size = new System.Drawing.Size(52, 20);
            this.pauseFrequencyUpdown.TabIndex = 2;
            this.toolTip.SetToolTip(this.pauseFrequencyUpdown, "Every n-th generation will pause and be shown");
            this.pauseFrequencyUpdown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // startStopGaButton
            // 
            this.startStopGaButton.Location = new System.Drawing.Point(6, 329);
            this.startStopGaButton.Name = "startStopGaButton";
            this.startStopGaButton.Size = new System.Drawing.Size(86, 36);
            this.startStopGaButton.TabIndex = 1;
            this.startStopGaButton.Text = "Start GA!";
            this.startStopGaButton.UseVisualStyleBackColor = true;
            this.startStopGaButton.Click += new System.EventHandler(this.startStopGaButton_Click);
            // 
            // importInitialPopulationButton
            // 
            this.importInitialPopulationButton.Location = new System.Drawing.Point(6, 14);
            this.importInitialPopulationButton.Name = "importInitialPopulationButton";
            this.importInitialPopulationButton.Size = new System.Drawing.Size(86, 36);
            this.importInitialPopulationButton.TabIndex = 0;
            this.importInitialPopulationButton.Text = "Import Initial Population";
            this.toolTip.SetToolTip(this.importInitialPopulationButton, "Choose individuals who should be included in the first generation.\r\nNumber of ver" +
        "tices in settings will be adjusted to match your choice (so that all individuals" +
        " have the same number of vertices).\r\n");
            this.importInitialPopulationButton.UseVisualStyleBackColor = true;
            this.importInitialPopulationButton.Click += new System.EventHandler(this.importInitialPopulationButton_Click);
            // 
            // continueButton
            // 
            this.continueButton.Location = new System.Drawing.Point(6, 275);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(86, 36);
            this.continueButton.TabIndex = 6;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Visible = false;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // fitnessfunctionLabel
            // 
            this.fitnessfunctionLabel.AutoSize = true;
            this.fitnessfunctionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitnessfunctionLabel.Location = new System.Drawing.Point(1, 274);
            this.fitnessfunctionLabel.Name = "fitnessfunctionLabel";
            this.fitnessfunctionLabel.Size = new System.Drawing.Size(101, 13);
            this.fitnessfunctionLabel.TabIndex = 6;
            this.fitnessfunctionLabel.Text = "Fitness function:";
            // 
            // gaSettingsTab
            // 
            this.gaSettingsTab.BackColor = System.Drawing.Color.DarkCyan;
            this.gaSettingsTab.Controls.Add(this.populationSizeUpdown);
            this.gaSettingsTab.Controls.Add(this.populationSizeLabel);
            this.gaSettingsTab.Controls.Add(this.resetSettingsButton);
            this.gaSettingsTab.Controls.Add(this.saveSettingsButton);
            this.gaSettingsTab.Controls.Add(this.elitismCheckbox);
            this.gaSettingsTab.Controls.Add(this.verticesCountUpdown);
            this.gaSettingsTab.Controls.Add(selectionGroupBox);
            this.gaSettingsTab.Controls.Add(this.verticesCountLabel);
            this.gaSettingsTab.Controls.Add(maximumDistanceMutationLabel);
            this.gaSettingsTab.Controls.Add(crossoverChanceLabel);
            this.gaSettingsTab.Controls.Add(mutationChanceLabel);
            this.gaSettingsTab.Controls.Add(this.crossoverUpdown);
            this.gaSettingsTab.Controls.Add(this.steadyStateRateUpdown);
            this.gaSettingsTab.Controls.Add(this.maxDistanceMutationUpdown);
            this.gaSettingsTab.Controls.Add(this.maxAngleMutationUpdown);
            this.gaSettingsTab.Controls.Add(this.mutationUpdown);
            this.gaSettingsTab.Controls.Add(maximumDegreesMutationLabel);
            this.gaSettingsTab.Controls.Add(this.steadyStateLabel);
            this.gaSettingsTab.Location = new System.Drawing.Point(23, 4);
            this.gaSettingsTab.Name = "gaSettingsTab";
            this.gaSettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.gaSettingsTab.Size = new System.Drawing.Size(98, 474);
            this.gaSettingsTab.TabIndex = 1;
            this.gaSettingsTab.Text = "GA Parameters";
            // 
            // populationSizeUpdown
            // 
            this.helpProvider.SetHelpKeyword(this.populationSizeUpdown, "");
            this.helpProvider.SetHelpString(this.populationSizeUpdown, "");
            this.populationSizeUpdown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.populationSizeUpdown.Location = new System.Drawing.Point(40, 20);
            this.populationSizeUpdown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.populationSizeUpdown.Name = "populationSizeUpdown";
            this.helpProvider.SetShowHelp(this.populationSizeUpdown, true);
            this.populationSizeUpdown.Size = new System.Drawing.Size(51, 20);
            this.populationSizeUpdown.TabIndex = 21;
            this.populationSizeUpdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.populationSizeUpdown, "Indicates how likely a mutation is to occur on each gene. \r\nLower values (0.05-0." +
        "15) recommended.");
            this.populationSizeUpdown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.populationSizeUpdown.ValueChanged += new System.EventHandler(this.populationSizeUpdown_ValueChanged);
            // 
            // populationSizeLabel
            // 
            this.populationSizeLabel.AutoSize = true;
            this.helpProvider.SetHelpKeyword(this.populationSizeLabel, "");
            this.helpProvider.SetHelpString(this.populationSizeLabel, "");
            this.populationSizeLabel.Location = new System.Drawing.Point(3, 3);
            this.populationSizeLabel.Name = "populationSizeLabel";
            this.helpProvider.SetShowHelp(this.populationSizeLabel, true);
            this.populationSizeLabel.Size = new System.Drawing.Size(80, 13);
            this.populationSizeLabel.TabIndex = 20;
            this.populationSizeLabel.Text = "Population Size";
            this.toolTip.SetToolTip(this.populationSizeLabel, "Sets the desired size of GA populations.\r\nIf you import a population set larger t" +
        "han this value, the value gets adjusted.");
            // 
            // resetSettingsButton
            // 
            this.helpProvider.SetHelpKeyword(this.resetSettingsButton, "");
            this.helpProvider.SetHelpString(this.resetSettingsButton, "");
            this.resetSettingsButton.Location = new System.Drawing.Point(50, 446);
            this.resetSettingsButton.Name = "resetSettingsButton";
            this.helpProvider.SetShowHelp(this.resetSettingsButton, true);
            this.resetSettingsButton.Size = new System.Drawing.Size(44, 23);
            this.resetSettingsButton.TabIndex = 19;
            this.resetSettingsButton.Text = "Reset";
            this.toolTip.SetToolTip(this.resetSettingsButton, "Reset all settings to pre-set defaults");
            this.resetSettingsButton.UseVisualStyleBackColor = true;
            this.resetSettingsButton.Click += new System.EventHandler(this.resetSettingsButton_Click);
            // 
            // saveSettingsButton
            // 
            this.helpProvider.SetHelpKeyword(this.saveSettingsButton, "");
            this.helpProvider.SetHelpString(this.saveSettingsButton, "");
            this.saveSettingsButton.Location = new System.Drawing.Point(3, 446);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.helpProvider.SetShowHelp(this.saveSettingsButton, true);
            this.saveSettingsButton.Size = new System.Drawing.Size(44, 23);
            this.saveSettingsButton.TabIndex = 18;
            this.saveSettingsButton.Text = "Save";
            this.toolTip.SetToolTip(this.saveSettingsButton, "Saving current settings will make every future GA instance load with these settin" +
        "gs.\r\nYou do not need to save for this window\'s GA to use them.\r\n");
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // elitismCheckbox
            // 
            this.elitismCheckbox.AutoSize = true;
            this.elitismCheckbox.Checked = true;
            this.elitismCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.helpProvider.SetHelpKeyword(this.elitismCheckbox, "");
            this.helpProvider.SetHelpString(this.elitismCheckbox, "");
            this.elitismCheckbox.Location = new System.Drawing.Point(5, 230);
            this.elitismCheckbox.Name = "elitismCheckbox";
            this.helpProvider.SetShowHelp(this.elitismCheckbox, true);
            this.elitismCheckbox.Size = new System.Drawing.Size(87, 17);
            this.elitismCheckbox.TabIndex = 14;
            this.elitismCheckbox.Text = "Elitism on/off";
            this.toolTip.SetToolTip(this.elitismCheckbox, "Individual with the best fitness score is guaranteed to continue into next genera" +
        "tion and be immune to mutations.\r\n Elitism ensures that top fitness of generatio" +
        "ns doesn\'t deteriorate.");
            this.elitismCheckbox.UseVisualStyleBackColor = true;
            this.elitismCheckbox.CheckedChanged += new System.EventHandler(this.elitismCheckbox_CheckedChanged);
            // 
            // verticesCountUpdown
            // 
            this.verticesCountUpdown.Location = new System.Drawing.Point(40, 414);
            this.verticesCountUpdown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.verticesCountUpdown.Name = "verticesCountUpdown";
            this.verticesCountUpdown.Size = new System.Drawing.Size(47, 20);
            this.verticesCountUpdown.TabIndex = 10;
            this.verticesCountUpdown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.verticesCountUpdown.ValueChanged += new System.EventHandler(this.verticesCountUpdown_ValueChanged);
            // 
            // selectionGroupBox
            // 
            selectionGroupBox.Controls.Add(this.rouletteRadioButton);
            selectionGroupBox.Controls.Add(this.steadyStateRadioButton);
            selectionGroupBox.Location = new System.Drawing.Point(6, 305);
            selectionGroupBox.Name = "selectionGroupBox";
            selectionGroupBox.Size = new System.Drawing.Size(87, 93);
            selectionGroupBox.TabIndex = 17;
            selectionGroupBox.TabStop = false;
            selectionGroupBox.Text = "Selection Type";
            // 
            // rouletteRadioButton
            // 
            this.rouletteRadioButton.AutoSize = true;
            this.rouletteRadioButton.Checked = true;
            this.helpProvider.SetHelpKeyword(this.rouletteRadioButton, "");
            this.helpProvider.SetHelpString(this.rouletteRadioButton, "");
            this.rouletteRadioButton.Location = new System.Drawing.Point(8, 34);
            this.rouletteRadioButton.Name = "rouletteRadioButton";
            this.helpProvider.SetShowHelp(this.rouletteRadioButton, true);
            this.rouletteRadioButton.Size = new System.Drawing.Size(65, 17);
            this.rouletteRadioButton.TabIndex = 15;
            this.rouletteRadioButton.TabStop = true;
            this.rouletteRadioButton.Text = "Roulette";
            this.toolTip.SetToolTip(this.rouletteRadioButton, "Candidates for breeding are selected with a weighted chance based on their fitnes" +
        "s values.");
            this.rouletteRadioButton.UseVisualStyleBackColor = true;
            this.rouletteRadioButton.CheckedChanged += new System.EventHandler(this.rouletteRadioButton_CheckedChanged);
            // 
            // steadyStateRadioButton
            // 
            this.helpProvider.SetHelpKeyword(this.steadyStateRadioButton, "");
            this.helpProvider.SetHelpString(this.steadyStateRadioButton, "");
            this.steadyStateRadioButton.Location = new System.Drawing.Point(8, 48);
            this.steadyStateRadioButton.Name = "steadyStateRadioButton";
            this.helpProvider.SetShowHelp(this.steadyStateRadioButton, true);
            this.steadyStateRadioButton.Size = new System.Drawing.Size(73, 39);
            this.steadyStateRadioButton.TabIndex = 16;
            this.steadyStateRadioButton.Text = "Steady State";
            this.toolTip.SetToolTip(this.steadyStateRadioButton, "Certain percentage of the population will continue without crossover, \r\nrest is f" +
        "illed by regular Roulette selection");
            this.steadyStateRadioButton.UseVisualStyleBackColor = true;
            this.steadyStateRadioButton.CheckedChanged += new System.EventHandler(this.steadyStateRadioButton_CheckedChanged);
            // 
            // verticesCountLabel
            // 
            this.verticesCountLabel.AutoSize = true;
            this.verticesCountLabel.Location = new System.Drawing.Point(4, 398);
            this.verticesCountLabel.Name = "verticesCountLabel";
            this.verticesCountLabel.Size = new System.Drawing.Size(88, 13);
            this.verticesCountLabel.TabIndex = 11;
            this.verticesCountLabel.Text = "Polygon vertices:";
            // 
            // maximumDistanceMutationLabel
            // 
            this.helpProvider.SetHelpKeyword(maximumDistanceMutationLabel, "");
            this.helpProvider.SetHelpString(maximumDistanceMutationLabel, "");
            maximumDistanceMutationLabel.Location = new System.Drawing.Point(1, 173);
            maximumDistanceMutationLabel.Name = "maximumDistanceMutationLabel";
            this.helpProvider.SetShowHelp(maximumDistanceMutationLabel, true);
            maximumDistanceMutationLabel.Size = new System.Drawing.Size(94, 30);
            maximumDistanceMutationLabel.TabIndex = 11;
            maximumDistanceMutationLabel.Text = "Maximum Distance Mutation";
            this.toolTip.SetToolTip(maximumDistanceMutationLabel, "Indicates how large a mutation can occur on every gene. \r\nThis is a ratio, i.e. v" +
        "ertices further apart from centroid are allowed to mutate more.\r\n");
            // 
            // crossoverChanceLabel
            // 
            crossoverChanceLabel.AutoSize = true;
            this.helpProvider.SetHelpKeyword(crossoverChanceLabel, "");
            this.helpProvider.SetHelpString(crossoverChanceLabel, "");
            crossoverChanceLabel.Location = new System.Drawing.Point(3, 82);
            crossoverChanceLabel.Name = "crossoverChanceLabel";
            this.helpProvider.SetShowHelp(crossoverChanceLabel, true);
            crossoverChanceLabel.Size = new System.Drawing.Size(94, 13);
            crossoverChanceLabel.TabIndex = 8;
            crossoverChanceLabel.Text = "Crossover Chance";
            this.toolTip.SetToolTip(crossoverChanceLabel, resources.GetString("crossoverChanceLabel.ToolTip"));
            // 
            // mutationChanceLabel
            // 
            mutationChanceLabel.AutoSize = true;
            this.helpProvider.SetHelpKeyword(mutationChanceLabel, "");
            this.helpProvider.SetHelpString(mutationChanceLabel, "");
            mutationChanceLabel.Location = new System.Drawing.Point(3, 43);
            mutationChanceLabel.Name = "mutationChanceLabel";
            this.helpProvider.SetShowHelp(mutationChanceLabel, true);
            mutationChanceLabel.Size = new System.Drawing.Size(88, 13);
            mutationChanceLabel.TabIndex = 7;
            mutationChanceLabel.Text = "Mutation Chance";
            this.toolTip.SetToolTip(mutationChanceLabel, "Indicates how likely a mutation is to occur on each gene. \r\nLower values (0.05-0." +
        "15) recommended.");
            // 
            // crossoverUpdown
            // 
            this.crossoverUpdown.DecimalPlaces = 2;
            this.helpProvider.SetHelpKeyword(this.crossoverUpdown, "");
            this.helpProvider.SetHelpString(this.crossoverUpdown, "");
            this.crossoverUpdown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.crossoverUpdown.Location = new System.Drawing.Point(40, 98);
            this.crossoverUpdown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.crossoverUpdown.Name = "crossoverUpdown";
            this.helpProvider.SetShowHelp(this.crossoverUpdown, true);
            this.crossoverUpdown.Size = new System.Drawing.Size(51, 20);
            this.crossoverUpdown.TabIndex = 5;
            this.crossoverUpdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.crossoverUpdown, resources.GetString("crossoverUpdown.ToolTip"));
            this.crossoverUpdown.Value = new decimal(new int[] {
            9,
            0,
            0,
            65536});
            this.crossoverUpdown.ValueChanged += new System.EventHandler(this.crossoverUpdown_ValueChanged);
            // 
            // steadyStateRateUpdown
            // 
            this.steadyStateRateUpdown.DecimalPlaces = 2;
            this.helpProvider.SetHelpKeyword(this.steadyStateRateUpdown, "Steady State Survival Rate");
            this.helpProvider.SetHelpString(this.steadyStateRateUpdown, "");
            this.steadyStateRateUpdown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.steadyStateRateUpdown.Location = new System.Drawing.Point(44, 282);
            this.steadyStateRateUpdown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.steadyStateRateUpdown.Name = "steadyStateRateUpdown";
            this.helpProvider.SetShowHelp(this.steadyStateRateUpdown, true);
            this.steadyStateRateUpdown.Size = new System.Drawing.Size(51, 20);
            this.steadyStateRateUpdown.TabIndex = 4;
            this.steadyStateRateUpdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.steadyStateRateUpdown, "Indicates the proportion of every generation that automatically passes into the n" +
        "ext generation");
            this.steadyStateRateUpdown.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.steadyStateRateUpdown.Visible = false;
            this.steadyStateRateUpdown.ValueChanged += new System.EventHandler(this.steadyStateRateUpdown_ValueChanged);
            // 
            // maxDistanceMutationUpdown
            // 
            this.maxDistanceMutationUpdown.DecimalPlaces = 2;
            this.helpProvider.SetHelpKeyword(this.maxDistanceMutationUpdown, "");
            this.helpProvider.SetHelpString(this.maxDistanceMutationUpdown, "");
            this.maxDistanceMutationUpdown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.maxDistanceMutationUpdown.Location = new System.Drawing.Point(41, 204);
            this.maxDistanceMutationUpdown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxDistanceMutationUpdown.Name = "maxDistanceMutationUpdown";
            this.helpProvider.SetShowHelp(this.maxDistanceMutationUpdown, true);
            this.maxDistanceMutationUpdown.Size = new System.Drawing.Size(51, 20);
            this.maxDistanceMutationUpdown.TabIndex = 3;
            this.maxDistanceMutationUpdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.maxDistanceMutationUpdown, "Indicates how large a mutation can occur on every gene. \r\nThis is a ratio, i.e. v" +
        "ertices further apart from centroid are allowed to mutate more.");
            this.maxDistanceMutationUpdown.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.maxDistanceMutationUpdown.ValueChanged += new System.EventHandler(this.maxDistanceMutationUpdown_ValueChanged);
            // 
            // maxAngleMutationUpdown
            // 
            this.helpProvider.SetHelpKeyword(this.maxAngleMutationUpdown, "");
            this.helpProvider.SetHelpString(this.maxAngleMutationUpdown, "");
            this.maxAngleMutationUpdown.Location = new System.Drawing.Point(40, 150);
            this.maxAngleMutationUpdown.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.maxAngleMutationUpdown.Name = "maxAngleMutationUpdown";
            this.helpProvider.SetShowHelp(this.maxAngleMutationUpdown, true);
            this.maxAngleMutationUpdown.Size = new System.Drawing.Size(51, 20);
            this.maxAngleMutationUpdown.TabIndex = 2;
            this.maxAngleMutationUpdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.maxAngleMutationUpdown, "Maximum variance (in degrees) that a gene/vertex can rotate relative to the centr" +
        "oid when mutating.");
            this.maxAngleMutationUpdown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.maxAngleMutationUpdown.ValueChanged += new System.EventHandler(this.maxAngleMutationUpdown_ValueChanged);
            // 
            // mutationUpdown
            // 
            this.mutationUpdown.DecimalPlaces = 2;
            this.helpProvider.SetHelpKeyword(this.mutationUpdown, "");
            this.helpProvider.SetHelpString(this.mutationUpdown, "");
            this.mutationUpdown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.mutationUpdown.Location = new System.Drawing.Point(40, 60);
            this.mutationUpdown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mutationUpdown.Name = "mutationUpdown";
            this.helpProvider.SetShowHelp(this.mutationUpdown, true);
            this.mutationUpdown.Size = new System.Drawing.Size(51, 20);
            this.mutationUpdown.TabIndex = 0;
            this.mutationUpdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.mutationUpdown, "Indicates how likely a mutation is to occur on each gene. \r\nLower values (0.05-0." +
        "15) recommended.");
            this.mutationUpdown.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.mutationUpdown.ValueChanged += new System.EventHandler(this.mutationUpdown_ValueChanged);
            // 
            // maximumDegreesMutationLabel
            // 
            this.helpProvider.SetHelpKeyword(maximumDegreesMutationLabel, "");
            this.helpProvider.SetHelpString(maximumDegreesMutationLabel, "");
            maximumDegreesMutationLabel.Location = new System.Drawing.Point(1, 121);
            maximumDegreesMutationLabel.Name = "maximumDegreesMutationLabel";
            this.helpProvider.SetShowHelp(maximumDegreesMutationLabel, true);
            maximumDegreesMutationLabel.Size = new System.Drawing.Size(94, 31);
            maximumDegreesMutationLabel.TabIndex = 13;
            maximumDegreesMutationLabel.Text = "Maximum Angle Mutation";
            this.toolTip.SetToolTip(maximumDegreesMutationLabel, "Maximum variance (in degrees) that a gene/vertex can rotate relative to the centr" +
        "oid when mutating.");
            // 
            // steadyStateLabel
            // 
            this.helpProvider.SetHelpKeyword(this.steadyStateLabel, "");
            this.helpProvider.SetHelpString(this.steadyStateLabel, "");
            this.steadyStateLabel.Location = new System.Drawing.Point(4, 250);
            this.steadyStateLabel.Name = "steadyStateLabel";
            this.helpProvider.SetShowHelp(this.steadyStateLabel, true);
            this.steadyStateLabel.Size = new System.Drawing.Size(88, 29);
            this.steadyStateLabel.TabIndex = 12;
            this.steadyStateLabel.Text = "Steady State Survival Rate";
            this.toolTip.SetToolTip(this.steadyStateLabel, "Indicates the proportion of every generation that automatically passes into the n" +
        "ext generation");
            this.steadyStateLabel.Visible = false;
            // 
            // imagesTab
            // 
            this.imagesTab.BackColor = System.Drawing.Color.Teal;
            this.imagesTab.Controls.Add(this.clearPopulationButton);
            this.imagesTab.Controls.Add(horizontalSeparator1);
            this.imagesTab.Controls.Add(horizontalSeparator2);
            this.imagesTab.Controls.Add(this.picturesSizeBar);
            this.imagesTab.Controls.Add(picturesSizeLabel);
            this.imagesTab.Controls.Add(this.sortPopulationCheckbox);
            this.imagesTab.Controls.Add(this.resetColorButton);
            this.imagesTab.Controls.Add(this.picturesBackColorButton);
            this.imagesTab.Location = new System.Drawing.Point(23, 4);
            this.imagesTab.Name = "imagesTab";
            this.imagesTab.Size = new System.Drawing.Size(98, 474);
            this.imagesTab.TabIndex = 2;
            this.imagesTab.Text = "Images";
            // 
            // clearPopulationButton
            // 
            this.clearPopulationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearPopulationButton.Location = new System.Drawing.Point(6, 333);
            this.clearPopulationButton.Name = "clearPopulationButton";
            this.clearPopulationButton.Size = new System.Drawing.Size(86, 36);
            this.clearPopulationButton.TabIndex = 11;
            this.clearPopulationButton.Text = "Clear All";
            this.clearPopulationButton.UseVisualStyleBackColor = true;
            this.clearPopulationButton.Click += new System.EventHandler(this.clearPopulationButton_Click);
            // 
            // horizontalSeparator1
            // 
            horizontalSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            horizontalSeparator1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            horizontalSeparator1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            horizontalSeparator1.Location = new System.Drawing.Point(9, 61);
            horizontalSeparator1.Name = "horizontalSeparator1";
            horizontalSeparator1.Size = new System.Drawing.Size(79, 2);
            horizontalSeparator1.TabIndex = 10;
            // 
            // horizontalSeparator2
            // 
            horizontalSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            horizontalSeparator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            horizontalSeparator2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            horizontalSeparator2.Location = new System.Drawing.Point(9, 238);
            horizontalSeparator2.Name = "horizontalSeparator2";
            horizontalSeparator2.Size = new System.Drawing.Size(79, 2);
            horizontalSeparator2.TabIndex = 9;
            // 
            // picturesSizeBar
            // 
            this.picturesSizeBar.BackColor = System.Drawing.Color.Teal;
            this.picturesSizeBar.Location = new System.Drawing.Point(47, 66);
            this.picturesSizeBar.Maximum = 7;
            this.picturesSizeBar.Minimum = 3;
            this.picturesSizeBar.Name = "picturesSizeBar";
            this.picturesSizeBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.picturesSizeBar.Size = new System.Drawing.Size(45, 165);
            this.picturesSizeBar.TabIndex = 2;
            this.picturesSizeBar.Value = 5;
            this.picturesSizeBar.ValueChanged += new System.EventHandler(this.picturesSizeBar_ValueChanged);
            // 
            // picturesSizeLabel
            // 
            picturesSizeLabel.AutoSize = true;
            picturesSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            picturesSizeLabel.Location = new System.Drawing.Point(7, 169);
            picturesSizeLabel.Name = "picturesSizeLabel";
            picturesSizeLabel.Size = new System.Drawing.Size(34, 15);
            picturesSizeLabel.TabIndex = 3;
            picturesSizeLabel.Text = "Size:";
            // 
            // sortPopulationCheckbox
            // 
            this.sortPopulationCheckbox.Checked = true;
            this.sortPopulationCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sortPopulationCheckbox.Location = new System.Drawing.Point(10, 15);
            this.sortPopulationCheckbox.Name = "sortPopulationCheckbox";
            this.sortPopulationCheckbox.Size = new System.Drawing.Size(74, 30);
            this.sortPopulationCheckbox.TabIndex = 0;
            this.sortPopulationCheckbox.Text = "Sort by Fitness";
            this.sortPopulationCheckbox.UseVisualStyleBackColor = true;
            this.sortPopulationCheckbox.CheckedChanged += new System.EventHandler(this.sortPopulationCheckbox_CheckedChanged);
            // 
            // resetColorButton
            // 
            this.resetColorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetColorButton.Location = new System.Drawing.Point(6, 291);
            this.resetColorButton.Name = "resetColorButton";
            this.resetColorButton.Size = new System.Drawing.Size(86, 36);
            this.resetColorButton.TabIndex = 5;
            this.resetColorButton.Text = "Reset Color";
            this.resetColorButton.UseVisualStyleBackColor = true;
            this.resetColorButton.Click += new System.EventHandler(this.resetColorButton_Click);
            // 
            // picturesBackColorButton
            // 
            this.picturesBackColorButton.Location = new System.Drawing.Point(6, 248);
            this.picturesBackColorButton.Name = "picturesBackColorButton";
            this.picturesBackColorButton.Size = new System.Drawing.Size(86, 36);
            this.picturesBackColorButton.TabIndex = 1;
            this.picturesBackColorButton.Text = "Background Color";
            this.picturesBackColorButton.UseVisualStyleBackColor = true;
            this.picturesBackColorButton.Click += new System.EventHandler(this.picturesBackColorButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.picturesLayoutPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.logBox);
            this.splitContainer1.Size = new System.Drawing.Size(685, 565);
            this.splitContainer1.SplitterDistance = 416;
            this.splitContainer1.TabIndex = 5;
            // 
            // picturesLayoutPanel
            // 
            this.picturesLayoutPanel.AutoScroll = true;
            this.picturesLayoutPanel.AutoSize = true;
            this.picturesLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.picturesLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picturesLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.picturesLayoutPanel.Name = "picturesLayoutPanel";
            this.picturesLayoutPanel.Size = new System.Drawing.Size(685, 416);
            this.picturesLayoutPanel.TabIndex = 0;
            this.picturesLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.picturesLayoutPanel_Paint);
            // 
            // logBox
            // 
            this.logBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logBox.FormattingEnabled = true;
            this.logBox.Location = new System.Drawing.Point(0, 0);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(685, 145);
            this.logBox.TabIndex = 0;
            // 
            // picturesBackgroundColorDialog
            // 
            this.picturesBackgroundColorDialog.Color = System.Drawing.Color.DarkCyan;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 8000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            // 
            // importPopulationDialog
            // 
            this.importPopulationDialog.DefaultExt = "xml";
            this.importPopulationDialog.FileName = "importPopulationFile";
            this.importPopulationDialog.Multiselect = true;
            this.importPopulationDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.importPopulationDialog_FileOk);
            // 
            // GaViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(826, 565);
            this.Controls.Add(splitContainer);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(580, 600);
            this.Name = "GaViewerForm";
            this.Text = "Genetic Algorithm Viewer";
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splitContainer)).EndInit();
            splitContainer.ResumeLayout(false);
            this.toolsLayoutPanel.ResumeLayout(false);
            gaSettingsBox.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.GaInitTab.ResumeLayout(false);
            this.GaInitTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saveFrequencyUpdown)).EndInit();
            this.terminationConditionsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.improvementRatioUpdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.terminationGenerationUpdown)).EndInit();
            this.radioButtonsPanel.ResumeLayout(false);
            this.radioButtonsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pauseFrequencyUpdown)).EndInit();
            this.gaSettingsTab.ResumeLayout(false);
            this.gaSettingsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.populationSizeUpdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verticesCountUpdown)).EndInit();
            selectionGroupBox.ResumeLayout(false);
            selectionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crossoverUpdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.steadyStateRateUpdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxDistanceMutationUpdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxAngleMutationUpdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationUpdown)).EndInit();
            this.imagesTab.ResumeLayout(false);
            this.imagesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturesSizeBar)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel toolsLayoutPanel;
        private System.Windows.Forms.Button picturesBackColorButton;
        private System.Windows.Forms.CheckBox sortPopulationCheckbox;
        private System.Windows.Forms.ColorDialog picturesBackgroundColorDialog;
        private System.Windows.Forms.TrackBar picturesSizeBar;
        private System.Windows.Forms.Button resetColorButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox logBox;
        private System.Windows.Forms.FlowLayoutPanel picturesLayoutPanel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage GaInitTab;
        private System.Windows.Forms.Button importInitialPopulationButton;
        private System.Windows.Forms.TabPage gaSettingsTab;
        private System.Windows.Forms.TabPage imagesTab;
        private System.Windows.Forms.CheckBox elitismCheckbox;
        private System.Windows.Forms.RadioButton rouletteRadioButton;
        private System.Windows.Forms.RadioButton steadyStateRadioButton;
        private System.Windows.Forms.NumericUpDown crossoverUpdown;
        private System.Windows.Forms.NumericUpDown steadyStateRateUpdown;
        private System.Windows.Forms.NumericUpDown maxDistanceMutationUpdown;
        private System.Windows.Forms.NumericUpDown maxAngleMutationUpdown;
        private System.Windows.Forms.NumericUpDown mutationUpdown;
        private System.Windows.Forms.Label steadyStateLabel;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.HelpProvider helpProvider;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox fitnessFunctionComboBox;
        private System.Windows.Forms.NumericUpDown pauseFrequencyUpdown;
        private System.Windows.Forms.Button startStopGaButton;
        private System.ComponentModel.BackgroundWorker gaBackgroundWorker;
        private System.Windows.Forms.GroupBox terminationConditionsGroupBox;
        private System.Windows.Forms.NumericUpDown improvementRatioUpdown;
        private System.Windows.Forms.NumericUpDown terminationGenerationUpdown;
        private System.Windows.Forms.CheckBox useFitnessCheckbox;
        private System.Windows.Forms.CheckBox useGenerationNumberCheckbox;
        private System.Windows.Forms.Panel radioButtonsPanel;
        private System.Windows.Forms.RadioButton andRadioButton;
        private System.Windows.Forms.RadioButton orRadioButton;
        private System.Windows.Forms.OpenFileDialog importPopulationDialog;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Label verticesCountLabel;
        private System.Windows.Forms.NumericUpDown verticesCountUpdown;
        private System.Windows.Forms.Button resetSettingsButton;
        private System.Windows.Forms.Button clearPopulationButton;
        private System.Windows.Forms.Label fitnessfunctionLabel;
        private System.Windows.Forms.NumericUpDown populationSizeUpdown;
        private System.Windows.Forms.Label populationSizeLabel;
        private System.Windows.Forms.NumericUpDown saveFrequencyUpdown;
        private System.Windows.Forms.ComboBox savedGenerationsCombobox;
    }
}