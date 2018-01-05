namespace Polygons.Forms
{
    /// <summary>
    /// Form allowing user to specify and modify a custom shape
    /// </summary>
    partial class PolygonCreationForm
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
            this.cellSizeLabel = new System.Windows.Forms.Label();
            this.polygonColorDialog = new System.Windows.Forms.ColorDialog();
            this.toolsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.verticesCountTextBox = new System.Windows.Forms.TextBox();
            this.colorLabel = new System.Windows.Forms.TextBox();
            this.ColorButton = new System.Windows.Forms.Button();
            this.inversionCheckbox = new System.Windows.Forms.CheckBox();
            this.useGridCheckBox = new System.Windows.Forms.CheckBox();
            this.cellSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.showCentroidCheckBox = new System.Windows.Forms.CheckBox();
            this.closeShapeCheckbox = new System.Windows.Forms.CheckBox();
            this.deleteLastButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.fileHandlingPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.saveShapeButton = new System.Windows.Forms.Button();
            this.loadShapeButton = new System.Windows.Forms.Button();
            this.deleteShapeButton = new System.Windows.Forms.Button();
            this.polygonBox = new System.Windows.Forms.PictureBox();
            this.paintGroupBox = new System.Windows.Forms.GroupBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.toolBox = new System.Windows.Forms.GroupBox();
            this.saveSuccessfulNotification = new System.Windows.Forms.NotifyIcon(this.components);
            this.loadShapeDialog = new System.Windows.Forms.OpenFileDialog();
            this.deleteShapeDialog = new System.Windows.Forms.OpenFileDialog();
            this.deleteSuccessfulNotification = new System.Windows.Forms.NotifyIcon(this.components);
            this.genericIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.creationTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.toolsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cellSizeUpDown)).BeginInit();
            this.fileHandlingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.polygonBox)).BeginInit();
            this.paintGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.toolBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cellSizeLabel
            // 
            this.cellSizeLabel.AutoSize = true;
            this.cellSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cellSizeLabel.Location = new System.Drawing.Point(3, 140);
            this.cellSizeLabel.Name = "cellSizeLabel";
            this.cellSizeLabel.Size = new System.Drawing.Size(49, 13);
            this.cellSizeLabel.TabIndex = 10;
            this.cellSizeLabel.Text = "Grid Size";
            // 
            // polygonColorDialog
            // 
            this.polygonColorDialog.AnyColor = true;
            // 
            // toolsPanel
            // 
            this.toolsPanel.Controls.Add(this.verticesCountTextBox);
            this.toolsPanel.Controls.Add(this.colorLabel);
            this.toolsPanel.Controls.Add(this.ColorButton);
            this.toolsPanel.Controls.Add(this.inversionCheckbox);
            this.toolsPanel.Controls.Add(this.useGridCheckBox);
            this.toolsPanel.Controls.Add(this.cellSizeLabel);
            this.toolsPanel.Controls.Add(this.cellSizeUpDown);
            this.toolsPanel.Controls.Add(this.showCentroidCheckBox);
            this.toolsPanel.Controls.Add(this.closeShapeCheckbox);
            this.toolsPanel.Controls.Add(this.deleteLastButton);
            this.toolsPanel.Controls.Add(this.resetButton);
            this.toolsPanel.Location = new System.Drawing.Point(6, 19);
            this.toolsPanel.Name = "toolsPanel";
            this.toolsPanel.Size = new System.Drawing.Size(99, 414);
            this.toolsPanel.TabIndex = 6;
            // 
            // verticesCountTextBox
            // 
            this.verticesCountTextBox.BackColor = System.Drawing.Color.DarkCyan;
            this.verticesCountTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.verticesCountTextBox.Location = new System.Drawing.Point(3, 3);
            this.verticesCountTextBox.Name = "verticesCountTextBox";
            this.verticesCountTextBox.ReadOnly = true;
            this.verticesCountTextBox.Size = new System.Drawing.Size(93, 13);
            this.verticesCountTextBox.TabIndex = 4;
            this.verticesCountTextBox.Text = "N vertices:";
            // 
            // colorLabel
            // 
            this.colorLabel.BackColor = System.Drawing.Color.DarkCyan;
            this.colorLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.colorLabel.Location = new System.Drawing.Point(3, 22);
            this.colorLabel.Multiline = true;
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.ReadOnly = true;
            this.colorLabel.Size = new System.Drawing.Size(90, 40);
            this.colorLabel.TabIndex = 7;
            this.colorLabel.Text = "Color:";
            // 
            // ColorButton
            // 
            this.ColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ColorButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ColorButton.Location = new System.Drawing.Point(3, 68);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(90, 23);
            this.ColorButton.TabIndex = 3;
            this.ColorButton.Text = "Choose color";
            this.creationTooltip.SetToolTip(this.ColorButton, "Change the outline color of the displayed polygon");
            this.ColorButton.UseVisualStyleBackColor = false;
            this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // inversionCheckbox
            // 
            this.inversionCheckbox.AutoSize = true;
            this.inversionCheckbox.BackColor = System.Drawing.Color.DarkCyan;
            this.inversionCheckbox.Location = new System.Drawing.Point(3, 97);
            this.inversionCheckbox.Name = "inversionCheckbox";
            this.inversionCheckbox.Size = new System.Drawing.Size(89, 17);
            this.inversionCheckbox.TabIndex = 8;
            this.inversionCheckbox.Text = "Invert BackG";
            this.creationTooltip.SetToolTip(this.inversionCheckbox, "Make the background color become the inverse color\r\nof the polygon\'s outline");
            this.inversionCheckbox.UseVisualStyleBackColor = false;
            this.inversionCheckbox.CheckedChanged += new System.EventHandler(this.inversionCheckbox_CheckedChanged);
            // 
            // useGridCheckBox
            // 
            this.useGridCheckBox.AutoSize = true;
            this.useGridCheckBox.Checked = true;
            this.useGridCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useGridCheckBox.Location = new System.Drawing.Point(3, 120);
            this.useGridCheckBox.Name = "useGridCheckBox";
            this.useGridCheckBox.Size = new System.Drawing.Size(67, 17);
            this.useGridCheckBox.TabIndex = 11;
            this.useGridCheckBox.Text = "Use Grid";
            this.creationTooltip.SetToolTip(this.useGridCheckBox, "Draw a square grid in the background,\r\nallowing for more precise placement of nod" +
        "es.");
            this.useGridCheckBox.UseVisualStyleBackColor = true;
            this.useGridCheckBox.CheckedChanged += new System.EventHandler(this.useGridCheckBox_CheckedChanged);
            // 
            // cellSizeUpDown
            // 
            this.cellSizeUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.cellSizeUpDown.Location = new System.Drawing.Point(58, 143);
            this.cellSizeUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.cellSizeUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.cellSizeUpDown.Name = "cellSizeUpDown";
            this.cellSizeUpDown.Size = new System.Drawing.Size(34, 20);
            this.cellSizeUpDown.TabIndex = 9;
            this.creationTooltip.SetToolTip(this.cellSizeUpDown, "Change the size of the squares in the grid");
            this.cellSizeUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.cellSizeUpDown.ValueChanged += new System.EventHandler(this.cellSizeUpDown_ValueChanged);
            // 
            // showCentroidCheckBox
            // 
            this.showCentroidCheckBox.AutoSize = true;
            this.showCentroidCheckBox.Location = new System.Drawing.Point(3, 169);
            this.showCentroidCheckBox.Name = "showCentroidCheckBox";
            this.showCentroidCheckBox.Size = new System.Drawing.Size(95, 17);
            this.showCentroidCheckBox.TabIndex = 13;
            this.showCentroidCheckBox.Text = "Show Centroid";
            this.creationTooltip.SetToolTip(this.showCentroidCheckBox, "Display the calculated centroid of the polygon.\r\nCentroid is the arithmetic mean " +
        "of all the vertices.");
            this.showCentroidCheckBox.UseVisualStyleBackColor = true;
            this.showCentroidCheckBox.CheckedChanged += new System.EventHandler(this.AnyCheckBox_CheckedChanged);
            // 
            // closeShapeCheckbox
            // 
            this.closeShapeCheckbox.AutoSize = true;
            this.closeShapeCheckbox.Location = new System.Drawing.Point(3, 192);
            this.closeShapeCheckbox.Name = "closeShapeCheckbox";
            this.closeShapeCheckbox.Size = new System.Drawing.Size(86, 17);
            this.closeShapeCheckbox.TabIndex = 12;
            this.closeShapeCheckbox.Text = "Close Shape";
            this.creationTooltip.SetToolTip(this.closeShapeCheckbox, "Choose whether a connection between the first and last vertex of the polygon shou" +
        "ld be drawn.\r\n(no effect on the actual properties of the polygon, merely a graph" +
        "ical option)");
            this.closeShapeCheckbox.UseVisualStyleBackColor = true;
            this.closeShapeCheckbox.CheckedChanged += new System.EventHandler(this.AnyCheckBox_CheckedChanged);
            // 
            // deleteLastButton
            // 
            this.deleteLastButton.BackColor = System.Drawing.Color.SkyBlue;
            this.deleteLastButton.Location = new System.Drawing.Point(3, 215);
            this.deleteLastButton.Name = "deleteLastButton";
            this.deleteLastButton.Size = new System.Drawing.Size(93, 33);
            this.deleteLastButton.TabIndex = 5;
            this.deleteLastButton.Text = "Remove last";
            this.creationTooltip.SetToolTip(this.deleteLastButton, "Delete last added node of the polygon.");
            this.deleteLastButton.UseVisualStyleBackColor = false;
            this.deleteLastButton.Click += new System.EventHandler(this.deleteLastButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.resetButton.BackColor = System.Drawing.Color.SkyBlue;
            this.resetButton.Location = new System.Drawing.Point(3, 254);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(93, 33);
            this.resetButton.TabIndex = 6;
            this.resetButton.Text = "Reset";
            this.creationTooltip.SetToolTip(this.resetButton, "Completely remove all drawn vertices and restore color to default.");
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // fileHandlingPanel
            // 
            this.fileHandlingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fileHandlingPanel.Controls.Add(this.saveShapeButton);
            this.fileHandlingPanel.Controls.Add(this.loadShapeButton);
            this.fileHandlingPanel.Controls.Add(this.deleteShapeButton);
            this.fileHandlingPanel.Location = new System.Drawing.Point(6, 439);
            this.fileHandlingPanel.Name = "fileHandlingPanel";
            this.fileHandlingPanel.Size = new System.Drawing.Size(96, 130);
            this.fileHandlingPanel.TabIndex = 7;
            this.fileHandlingPanel.Tag = "File Manipulation";
            // 
            // saveShapeButton
            // 
            this.saveShapeButton.BackColor = System.Drawing.Color.SkyBlue;
            this.saveShapeButton.Location = new System.Drawing.Point(3, 3);
            this.saveShapeButton.Name = "saveShapeButton";
            this.saveShapeButton.Size = new System.Drawing.Size(90, 37);
            this.saveShapeButton.TabIndex = 0;
            this.saveShapeButton.Text = "Save shape";
            this.saveShapeButton.UseVisualStyleBackColor = false;
            this.saveShapeButton.Click += new System.EventHandler(this.saveShapeButton_Click);
            // 
            // loadShapeButton
            // 
            this.loadShapeButton.BackColor = System.Drawing.Color.SkyBlue;
            this.loadShapeButton.Location = new System.Drawing.Point(3, 46);
            this.loadShapeButton.Name = "loadShapeButton";
            this.loadShapeButton.Size = new System.Drawing.Size(90, 37);
            this.loadShapeButton.TabIndex = 1;
            this.loadShapeButton.Text = "Load Shape";
            this.loadShapeButton.UseVisualStyleBackColor = false;
            this.loadShapeButton.Click += new System.EventHandler(this.loadShapeButton_Click);
            // 
            // deleteShapeButton
            // 
            this.deleteShapeButton.BackColor = System.Drawing.Color.SkyBlue;
            this.deleteShapeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteShapeButton.Location = new System.Drawing.Point(3, 89);
            this.deleteShapeButton.Name = "deleteShapeButton";
            this.deleteShapeButton.Size = new System.Drawing.Size(90, 37);
            this.deleteShapeButton.TabIndex = 2;
            this.deleteShapeButton.Text = "Delete Shape(s)";
            this.deleteShapeButton.UseVisualStyleBackColor = false;
            this.deleteShapeButton.Click += new System.EventHandler(this.deleteShapeButton_Click);
            // 
            // polygonBox
            // 
            this.polygonBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.polygonBox.Location = new System.Drawing.Point(3, 16);
            this.polygonBox.Name = "polygonBox";
            this.polygonBox.Size = new System.Drawing.Size(588, 566);
            this.polygonBox.TabIndex = 2;
            this.polygonBox.TabStop = false;
            this.polygonBox.Click += new System.EventHandler(this.polygonBox_Click);
            this.polygonBox.Paint += new System.Windows.Forms.PaintEventHandler(this.polygonBox_Paint);
            this.polygonBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.polygonBox_MouseDown);
            this.polygonBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.polygonBox_MouseMove);
            // 
            // paintGroupBox
            // 
            this.paintGroupBox.Controls.Add(this.polygonBox);
            this.paintGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paintGroupBox.Location = new System.Drawing.Point(0, 0);
            this.paintGroupBox.Name = "paintGroupBox";
            this.paintGroupBox.Size = new System.Drawing.Size(594, 585);
            this.paintGroupBox.TabIndex = 5;
            this.paintGroupBox.TabStop = false;
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.splitContainer.Panel1.Controls.Add(this.toolBox);
            this.splitContainer.Panel1.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.Color.Azure;
            this.splitContainer.Panel2.Controls.Add(this.paintGroupBox);
            this.splitContainer.Panel2MinSize = 100;
            this.splitContainer.Size = new System.Drawing.Size(721, 587);
            this.splitContainer.SplitterDistance = 121;
            this.splitContainer.TabIndex = 10;
            // 
            // toolBox
            // 
            this.toolBox.BackColor = System.Drawing.Color.Transparent;
            this.toolBox.Controls.Add(this.fileHandlingPanel);
            this.toolBox.Controls.Add(this.toolsPanel);
            this.toolBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolBox.Location = new System.Drawing.Point(5, 5);
            this.toolBox.Name = "toolBox";
            this.toolBox.Size = new System.Drawing.Size(109, 575);
            this.toolBox.TabIndex = 0;
            this.toolBox.TabStop = false;
            this.toolBox.Text = "Tools";
            // 
            // saveSuccessfulNotification
            // 
            this.saveSuccessfulNotification.BalloonTipTitle = "Save successful";
            this.saveSuccessfulNotification.Text = "Successfully saved";
            this.saveSuccessfulNotification.Visible = true;
            // 
            // loadShapeDialog
            // 
            this.loadShapeDialog.DefaultExt = "xml";
            this.loadShapeDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // deleteShapeDialog
            // 
            this.deleteShapeDialog.DefaultExt = "xml";
            this.deleteShapeDialog.Multiselect = true;
            this.deleteShapeDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.deleteFileDialog_FileOk);
            // 
            // deleteSuccessfulNotification
            // 
            this.deleteSuccessfulNotification.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.deleteSuccessfulNotification.BalloonTipTitle = "Deletion successful";
            this.deleteSuccessfulNotification.Text = "Successfully saved";
            this.deleteSuccessfulNotification.Visible = true;
            // 
            // genericIcon
            // 
            this.genericIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.genericIcon.BalloonTipText = "...you can drag with right mouse button to move your shapes.";
            this.genericIcon.BalloonTipTitle = "Did you know?";
            this.genericIcon.Text = "Info Icon";
            this.genericIcon.Visible = true;
            // 
            // creationTooltip
            // 
            this.creationTooltip.AutomaticDelay = 2000;
            this.creationTooltip.AutoPopDelay = 18000;
            this.creationTooltip.InitialDelay = 2000;
            this.creationTooltip.IsBalloon = true;
            this.creationTooltip.ReshowDelay = 18000;
            this.creationTooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.creationTooltip.ToolTipTitle = "Creation tooltip";
            // 
            // PolygonCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 587);
            this.Controls.Add(this.splitContainer);
            this.MinimumSize = new System.Drawing.Size(140, 210);
            this.Name = "PolygonCreationForm";
            this.ShowIcon = false;
            this.Text = "Create polygons";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PolygonCreationForm_FormClosing);
            this.toolsPanel.ResumeLayout(false);
            this.toolsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cellSizeUpDown)).EndInit();
            this.fileHandlingPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.polygonBox)).EndInit();
            this.paintGroupBox.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.toolBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog polygonColorDialog;
        private System.Windows.Forms.Button ColorButton;
        private System.Windows.Forms.FlowLayoutPanel toolsPanel;
        private System.Windows.Forms.TextBox verticesCountTextBox;
        private System.Windows.Forms.Button deleteLastButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.FlowLayoutPanel fileHandlingPanel;
        private System.Windows.Forms.Button saveShapeButton;
        private System.Windows.Forms.GroupBox paintGroupBox;
        private System.Windows.Forms.PictureBox polygonBox;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox toolBox;
        private System.Windows.Forms.NotifyIcon saveSuccessfulNotification;
        private System.Windows.Forms.Button loadShapeButton;
        private System.Windows.Forms.OpenFileDialog loadShapeDialog;
        private System.Windows.Forms.TextBox colorLabel;
        private System.Windows.Forms.Button deleteShapeButton;
        private System.Windows.Forms.OpenFileDialog deleteShapeDialog;
        private System.Windows.Forms.NotifyIcon deleteSuccessfulNotification;
        private System.Windows.Forms.CheckBox inversionCheckbox;
        private System.Windows.Forms.NotifyIcon genericIcon;
        private System.Windows.Forms.NumericUpDown cellSizeUpDown;
        private System.Windows.Forms.CheckBox useGridCheckBox;
        private System.Windows.Forms.CheckBox closeShapeCheckbox;
        private System.Windows.Forms.CheckBox showCentroidCheckBox;
        private System.Windows.Forms.Label cellSizeLabel;
        private System.Windows.Forms.ToolTip creationTooltip;
    }
}