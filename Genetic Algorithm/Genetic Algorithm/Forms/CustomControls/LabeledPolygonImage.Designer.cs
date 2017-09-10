namespace Genetic_Algorithm.Forms
{
    partial class LabeledPolygonImage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.selectionCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(0, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(275, 264);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Visible = false;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.descriptionLabel.Location = new System.Drawing.Point(0, 287);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(0, 13);
            this.descriptionLabel.TabIndex = 1;
            // 
            // selectionCheckbox
            // 
            this.selectionCheckbox.AutoSize = true;
            this.selectionCheckbox.Location = new System.Drawing.Point(0, 0);
            this.selectionCheckbox.Name = "selectionCheckbox";
            this.selectionCheckbox.Size = new System.Drawing.Size(15, 14);
            this.selectionCheckbox.TabIndex = 2;
            this.selectionCheckbox.UseVisualStyleBackColor = true;
            this.selectionCheckbox.Visible = false;
            this.selectionCheckbox.CheckedChanged += new System.EventHandler(this.selectionCheckbox_CheckedChanged);
            this.selectionCheckbox.MouseLeave += new System.EventHandler(this.selectionCheckbox_MouseLeave);
            // 
            // LabeledPolygonImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectionCheckbox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.pictureBox);
            this.DoubleBuffered = true;
            this.Name = "LabeledPolygonImage";
            this.Size = new System.Drawing.Size(275, 300);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LabeledPolygonImage_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabeledPolygonImage_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LabeledPolygonImage_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LabeledPolygonImage_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.CheckBox selectionCheckbox;
    }
}
