namespace Polygons.Forms
{
    partial class PopulationGeneratorForm
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
            System.Windows.Forms.GroupBox populationGroupBox;
            System.Windows.Forms.Label polygonVerticesLabel;
            System.Windows.Forms.Label popSizeLabel;
            System.Windows.Forms.GroupBox imagesGroupBox;
            System.Windows.Forms.Label picturesSizeLabel;
            System.Windows.Forms.GroupBox importExportGroupbox;
            this.toolsLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.verticesUpdown = new System.Windows.Forms.NumericUpDown();
            this.clearPopulationbutton = new System.Windows.Forms.Button();
            this.createPopulationButton = new System.Windows.Forms.Button();
            this.popSizeUpdown = new System.Windows.Forms.NumericUpDown();
            this.resetColorButton = new System.Windows.Forms.Button();
            this.picturesSizeBar = new System.Windows.Forms.TrackBar();
            this.picturesBackColorButton = new System.Windows.Forms.Button();
            this.sortPopulationCheckbox = new System.Windows.Forms.CheckBox();
            this.deleteSelectedButton = new System.Windows.Forms.Button();
            this.importShapesButton = new System.Windows.Forms.Button();
            this.saveSelectionButton = new System.Windows.Forms.Button();
            this.createShapesButton = new System.Windows.Forms.Button();
            this.picturesLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.picturesBackgroundColorDialog = new System.Windows.Forms.ColorDialog();
            this.labeledImageContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeShapeFromPopulationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deselectAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openShapesDialog = new System.Windows.Forms.OpenFileDialog();
            this.savedShapesNotification = new System.Windows.Forms.NotifyIcon(this.components);
            splitContainer = new System.Windows.Forms.SplitContainer();
            populationGroupBox = new System.Windows.Forms.GroupBox();
            polygonVerticesLabel = new System.Windows.Forms.Label();
            popSizeLabel = new System.Windows.Forms.Label();
            imagesGroupBox = new System.Windows.Forms.GroupBox();
            picturesSizeLabel = new System.Windows.Forms.Label();
            importExportGroupbox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(splitContainer)).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            this.toolsLayoutPanel.SuspendLayout();
            populationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.verticesUpdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popSizeUpdown)).BeginInit();
            imagesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturesSizeBar)).BeginInit();
            importExportGroupbox.SuspendLayout();
            this.labeledImageContextMenu.SuspendLayout();
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
            splitContainer.Panel2.Controls.Add(this.picturesLayoutPanel);
            splitContainer.Size = new System.Drawing.Size(826, 565);
            splitContainer.SplitterDistance = 100;
            splitContainer.TabIndex = 0;
            // 
            // toolsLayoutPanel
            // 
            this.toolsLayoutPanel.Controls.Add(populationGroupBox);
            this.toolsLayoutPanel.Controls.Add(imagesGroupBox);
            this.toolsLayoutPanel.Controls.Add(importExportGroupbox);
            this.toolsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolsLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.toolsLayoutPanel.Name = "toolsLayoutPanel";
            this.toolsLayoutPanel.Size = new System.Drawing.Size(100, 565);
            this.toolsLayoutPanel.TabIndex = 0;
            // 
            // populationGroupBox
            // 
            populationGroupBox.Controls.Add(this.verticesUpdown);
            populationGroupBox.Controls.Add(polygonVerticesLabel);
            populationGroupBox.Controls.Add(this.clearPopulationbutton);
            populationGroupBox.Controls.Add(this.createPopulationButton);
            populationGroupBox.Controls.Add(this.popSizeUpdown);
            populationGroupBox.Controls.Add(popSizeLabel);
            populationGroupBox.Location = new System.Drawing.Point(3, 3);
            populationGroupBox.Name = "populationGroupBox";
            populationGroupBox.Size = new System.Drawing.Size(94, 174);
            populationGroupBox.TabIndex = 3;
            populationGroupBox.TabStop = false;
            populationGroupBox.Text = "Population";
            // 
            // verticesUpdown
            // 
            this.verticesUpdown.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.verticesUpdown.Location = new System.Drawing.Point(46, 111);
            this.verticesUpdown.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.verticesUpdown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.verticesUpdown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.verticesUpdown.Name = "verticesUpdown";
            this.verticesUpdown.Size = new System.Drawing.Size(42, 20);
            this.verticesUpdown.TabIndex = 4;
            this.verticesUpdown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.verticesUpdown.ValueChanged += new System.EventHandler(this.verticesUpdown_ValueChanged);
            // 
            // polygonVerticesLabel
            // 
            polygonVerticesLabel.AutoSize = true;
            polygonVerticesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            polygonVerticesLabel.Location = new System.Drawing.Point(5, 95);
            polygonVerticesLabel.Name = "polygonVerticesLabel";
            polygonVerticesLabel.Size = new System.Drawing.Size(48, 13);
            polygonVerticesLabel.TabIndex = 5;
            polygonVerticesLabel.Text = "Vertices:";
            // 
            // clearPopulationbutton
            // 
            this.clearPopulationbutton.Location = new System.Drawing.Point(5, 137);
            this.clearPopulationbutton.Name = "clearPopulationbutton";
            this.clearPopulationbutton.Size = new System.Drawing.Size(83, 32);
            this.clearPopulationbutton.TabIndex = 3;
            this.clearPopulationbutton.Text = "Clear Population";
            this.clearPopulationbutton.UseVisualStyleBackColor = true;
            this.clearPopulationbutton.Click += new System.EventHandler(this.clearPopulationbutton_Click);
            // 
            // createPopulationButton
            // 
            this.createPopulationButton.Location = new System.Drawing.Point(5, 19);
            this.createPopulationButton.Name = "createPopulationButton";
            this.createPopulationButton.Size = new System.Drawing.Size(83, 32);
            this.createPopulationButton.TabIndex = 2;
            this.createPopulationButton.Text = "Create population";
            this.createPopulationButton.UseVisualStyleBackColor = true;
            this.createPopulationButton.Click += new System.EventHandler(this.createPopulationButton_Click);
            // 
            // popSizeUpdown
            // 
            this.popSizeUpdown.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.popSizeUpdown.Location = new System.Drawing.Point(44, 70);
            this.popSizeUpdown.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.popSizeUpdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.popSizeUpdown.Name = "popSizeUpdown";
            this.popSizeUpdown.Size = new System.Drawing.Size(42, 20);
            this.popSizeUpdown.TabIndex = 0;
            this.popSizeUpdown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // popSizeLabel
            // 
            popSizeLabel.AutoSize = true;
            popSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            popSizeLabel.Location = new System.Drawing.Point(3, 54);
            popSizeLabel.Name = "popSizeLabel";
            popSizeLabel.Size = new System.Drawing.Size(83, 13);
            popSizeLabel.TabIndex = 1;
            popSizeLabel.Text = "Population Size:";
            // 
            // imagesGroupBox
            // 
            imagesGroupBox.Controls.Add(this.resetColorButton);
            imagesGroupBox.Controls.Add(picturesSizeLabel);
            imagesGroupBox.Controls.Add(this.picturesSizeBar);
            imagesGroupBox.Controls.Add(this.picturesBackColorButton);
            imagesGroupBox.Controls.Add(this.sortPopulationCheckbox);
            imagesGroupBox.Location = new System.Drawing.Point(3, 183);
            imagesGroupBox.Name = "imagesGroupBox";
            imagesGroupBox.Size = new System.Drawing.Size(94, 202);
            imagesGroupBox.TabIndex = 4;
            imagesGroupBox.TabStop = false;
            imagesGroupBox.Text = "Images";
            // 
            // resetColorButton
            // 
            this.resetColorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetColorButton.Location = new System.Drawing.Point(5, 93);
            this.resetColorButton.Name = "resetColorButton";
            this.resetColorButton.Size = new System.Drawing.Size(83, 23);
            this.resetColorButton.TabIndex = 5;
            this.resetColorButton.Text = "Reset Color";
            this.resetColorButton.UseVisualStyleBackColor = true;
            this.resetColorButton.Click += new System.EventHandler(this.resetColorButton_Click);
            // 
            // picturesSizeLabel
            // 
            picturesSizeLabel.AutoSize = true;
            picturesSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            picturesSizeLabel.Location = new System.Drawing.Point(6, 130);
            picturesSizeLabel.Name = "picturesSizeLabel";
            picturesSizeLabel.Size = new System.Drawing.Size(34, 15);
            picturesSizeLabel.TabIndex = 3;
            picturesSizeLabel.Text = "Size:";
            // 
            // picturesSizeBar
            // 
            this.picturesSizeBar.Location = new System.Drawing.Point(3, 148);
            this.picturesSizeBar.Maximum = 7;
            this.picturesSizeBar.Minimum = 3;
            this.picturesSizeBar.Name = "picturesSizeBar";
            this.picturesSizeBar.Size = new System.Drawing.Size(85, 45);
            this.picturesSizeBar.TabIndex = 2;
            this.picturesSizeBar.Value = 5;
            this.picturesSizeBar.ValueChanged += new System.EventHandler(this.picturesSizeBar_ValueChanged);
            // 
            // picturesBackColorButton
            // 
            this.picturesBackColorButton.Location = new System.Drawing.Point(5, 55);
            this.picturesBackColorButton.Name = "picturesBackColorButton";
            this.picturesBackColorButton.Size = new System.Drawing.Size(83, 32);
            this.picturesBackColorButton.TabIndex = 1;
            this.picturesBackColorButton.Text = "Background Color";
            this.picturesBackColorButton.UseVisualStyleBackColor = true;
            this.picturesBackColorButton.Click += new System.EventHandler(this.picturesBackColorButton_Click);
            // 
            // sortPopulationCheckbox
            // 
            this.sortPopulationCheckbox.Location = new System.Drawing.Point(5, 19);
            this.sortPopulationCheckbox.Name = "sortPopulationCheckbox";
            this.sortPopulationCheckbox.Size = new System.Drawing.Size(85, 30);
            this.sortPopulationCheckbox.TabIndex = 0;
            this.sortPopulationCheckbox.Text = "Sort by Fitness";
            this.sortPopulationCheckbox.UseVisualStyleBackColor = true;
            this.sortPopulationCheckbox.CheckedChanged += new System.EventHandler(this.sortPopulationCheckbox_CheckedChanged);
            // 
            // importExportGroupbox
            // 
            importExportGroupbox.Controls.Add(this.deleteSelectedButton);
            importExportGroupbox.Controls.Add(this.importShapesButton);
            importExportGroupbox.Controls.Add(this.saveSelectionButton);
            importExportGroupbox.Controls.Add(this.createShapesButton);
            importExportGroupbox.Location = new System.Drawing.Point(3, 391);
            importExportGroupbox.Name = "importExportGroupbox";
            importExportGroupbox.Size = new System.Drawing.Size(94, 170);
            importExportGroupbox.TabIndex = 5;
            importExportGroupbox.TabStop = false;
            importExportGroupbox.Text = "Import/export";
            // 
            // deleteSelectedButton
            // 
            this.deleteSelectedButton.Location = new System.Drawing.Point(5, 56);
            this.deleteSelectedButton.Name = "deleteSelectedButton";
            this.deleteSelectedButton.Size = new System.Drawing.Size(83, 32);
            this.deleteSelectedButton.TabIndex = 3;
            this.deleteSelectedButton.Text = "Delete selected";
            this.deleteSelectedButton.UseVisualStyleBackColor = true;
            this.deleteSelectedButton.Click += new System.EventHandler(this.deleteSelectedButton_Click);
            // 
            // importShapesButton
            // 
            this.importShapesButton.Location = new System.Drawing.Point(5, 94);
            this.importShapesButton.Name = "importShapesButton";
            this.importShapesButton.Size = new System.Drawing.Size(83, 32);
            this.importShapesButton.TabIndex = 2;
            this.importShapesButton.Text = "Import shapes";
            this.importShapesButton.UseVisualStyleBackColor = true;
            this.importShapesButton.Click += new System.EventHandler(this.importShapesButton_Click);
            // 
            // saveSelectionButton
            // 
            this.saveSelectionButton.Location = new System.Drawing.Point(5, 18);
            this.saveSelectionButton.Name = "saveSelectionButton";
            this.saveSelectionButton.Size = new System.Drawing.Size(83, 32);
            this.saveSelectionButton.TabIndex = 1;
            this.saveSelectionButton.Text = "Save selected";
            this.saveSelectionButton.UseVisualStyleBackColor = true;
            this.saveSelectionButton.Click += new System.EventHandler(this.saveSelectionButton_Click);
            // 
            // createShapesButton
            // 
            this.createShapesButton.Location = new System.Drawing.Point(5, 132);
            this.createShapesButton.Name = "createShapesButton";
            this.createShapesButton.Size = new System.Drawing.Size(83, 32);
            this.createShapesButton.TabIndex = 0;
            this.createShapesButton.Text = "Create shapes";
            this.createShapesButton.UseVisualStyleBackColor = true;
            this.createShapesButton.Click += new System.EventHandler(this.createShapesButton_Click);
            // 
            // picturesLayoutPanel
            // 
            this.picturesLayoutPanel.AutoScroll = true;
            this.picturesLayoutPanel.AutoSize = true;
            this.picturesLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.picturesLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picturesLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.picturesLayoutPanel.Name = "picturesLayoutPanel";
            this.picturesLayoutPanel.Size = new System.Drawing.Size(722, 565);
            this.picturesLayoutPanel.TabIndex = 0;
            this.picturesLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.picturesLayoutPanel_Paint);
            this.picturesLayoutPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picturesLayoutPanel_MouseDown);
            this.picturesLayoutPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picturesLayoutPanel_MouseUp);
            // 
            // picturesBackgroundColorDialog
            // 
            this.picturesBackgroundColorDialog.Color = System.Drawing.Color.DarkCyan;
            // 
            // labeledImageContextMenu
            // 
            this.labeledImageContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveShapeMenuItem,
            this.removeShapeFromPopulationMenuItem,
            this.replaceShapeMenuItem,
            this.toolStripSeparator1,
            this.selectAllMenuItem,
            this.deselectAllMenuItem});
            this.labeledImageContextMenu.Name = "labeledImageContextMenu";
            this.labeledImageContextMenu.Size = new System.Drawing.Size(151, 120);
            // 
            // saveShapeMenuItem
            // 
            this.saveShapeMenuItem.Name = "saveShapeMenuItem";
            this.saveShapeMenuItem.Size = new System.Drawing.Size(150, 22);
            this.saveShapeMenuItem.Text = "Save shape";
            this.saveShapeMenuItem.Click += new System.EventHandler(this.saveShapeMenuItem_Click);
            // 
            // removeShapeFromPopulationMenuItem
            // 
            this.removeShapeFromPopulationMenuItem.Name = "removeShapeFromPopulationMenuItem";
            this.removeShapeFromPopulationMenuItem.Size = new System.Drawing.Size(150, 22);
            this.removeShapeFromPopulationMenuItem.Text = "Remove";
            this.removeShapeFromPopulationMenuItem.Click += new System.EventHandler(this.removeShapeFromPopulationMenuItem_Click);
            // 
            // replaceShapeMenuItem
            // 
            this.replaceShapeMenuItem.Name = "replaceShapeMenuItem";
            this.replaceShapeMenuItem.Size = new System.Drawing.Size(150, 22);
            this.replaceShapeMenuItem.Text = "Replace with...";
            this.replaceShapeMenuItem.Click += new System.EventHandler(this.replaceShapeMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(147, 6);
            // 
            // selectAllMenuItem
            // 
            this.selectAllMenuItem.Name = "selectAllMenuItem";
            this.selectAllMenuItem.Size = new System.Drawing.Size(150, 22);
            this.selectAllMenuItem.Text = "Select All";
            this.selectAllMenuItem.Click += new System.EventHandler(this.selectAllMenuItem_Click);
            // 
            // deselectAllMenuItem
            // 
            this.deselectAllMenuItem.Name = "deselectAllMenuItem";
            this.deselectAllMenuItem.Size = new System.Drawing.Size(150, 22);
            this.deselectAllMenuItem.Text = "Deselect All";
            this.deselectAllMenuItem.Click += new System.EventHandler(this.deselectAllMenuItem_Click);
            // 
            // openShapesDialog
            // 
            this.openShapesDialog.DefaultExt = "xml";
            this.openShapesDialog.FileName = "openFileDialog1";
            this.openShapesDialog.Multiselect = true;
            this.openShapesDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openShapesDialog_FileOk);
            // 
            // savedShapesNotification
            // 
            this.savedShapesNotification.BalloonTipText = "Selected shapes successfully saved to default saves folder";
            this.savedShapesNotification.BalloonTipTitle = "Saved";
            this.savedShapesNotification.Text = "notifyIcon1";
            this.savedShapesNotification.Visible = true;
            // 
            // PopulationGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 565);
            this.Controls.Add(splitContainer);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(580, 600);
            this.Name = "PopulationGeneratorForm";
            this.Text = "Population generator";
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(splitContainer)).EndInit();
            splitContainer.ResumeLayout(false);
            this.toolsLayoutPanel.ResumeLayout(false);
            populationGroupBox.ResumeLayout(false);
            populationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.verticesUpdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popSizeUpdown)).EndInit();
            imagesGroupBox.ResumeLayout(false);
            imagesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturesSizeBar)).EndInit();
            importExportGroupbox.ResumeLayout(false);
            this.labeledImageContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel toolsLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel picturesLayoutPanel;
        private System.Windows.Forms.NumericUpDown popSizeUpdown;
        private System.Windows.Forms.Button createPopulationButton;
        private System.Windows.Forms.Button clearPopulationbutton;
        private System.Windows.Forms.Button picturesBackColorButton;
        private System.Windows.Forms.CheckBox sortPopulationCheckbox;
        private System.Windows.Forms.ColorDialog picturesBackgroundColorDialog;
        private System.Windows.Forms.TrackBar picturesSizeBar;
        private System.Windows.Forms.Button resetColorButton;
        private System.Windows.Forms.NumericUpDown verticesUpdown;
        private System.Windows.Forms.Button createShapesButton;
        private System.Windows.Forms.Button saveSelectionButton;
        private System.Windows.Forms.ContextMenuStrip labeledImageContextMenu;
        private System.Windows.Forms.ToolStripMenuItem saveShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeShapeFromPopulationMenuItem;
        private System.Windows.Forms.Button importShapesButton;
        private System.Windows.Forms.ToolStripMenuItem replaceShapeMenuItem;
        private System.Windows.Forms.OpenFileDialog openShapesDialog;
        private System.Windows.Forms.NotifyIcon savedShapesNotification;
        private System.Windows.Forms.Button deleteSelectedButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem selectAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deselectAllMenuItem;
    }
}