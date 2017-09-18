using Polygons.Forms.CustomControls;

namespace Polygons.Forms
{
    partial class CrossroadForm
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
            System.Windows.Forms.SplitContainer splitContainer1;
            System.Windows.Forms.SplitContainer splitContainer2;
            this.geneticAlgorithmIcon = new Forms.CustomControls.GaComponentIcon();
            this.populationGenerationIcon = new Forms.CustomControls.GaComponentIcon();
            this.shapeCreationIcon = new Forms.CustomControls.GaComponentIcon();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(splitContainer1)).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(splitContainer2)).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(this.geneticAlgorithmIcon);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new System.Drawing.Size(454, 431);
            splitContainer1.SplitterDistance = 218;
            splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer2.IsSplitterFixed = true;
            splitContainer2.Location = new System.Drawing.Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(this.populationGenerationIcon);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(this.shapeCreationIcon);
            splitContainer2.Size = new System.Drawing.Size(454, 209);
            splitContainer2.SplitterDistance = 221;
            splitContainer2.TabIndex = 0;
            // 
            // geneticAlgorithmIcon
            // 
            this.geneticAlgorithmIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.geneticAlgorithmIcon.Location = new System.Drawing.Point(12, 12);
            this.geneticAlgorithmIcon.Name = "geneticAlgorithmIcon";
            this.geneticAlgorithmIcon.Size = new System.Drawing.Size(430, 194);
            this.geneticAlgorithmIcon.TabIndex = 0;
            this.geneticAlgorithmIcon.Click += new System.EventHandler(this.geneticAlgorithmIcon_Click);
            // 
            // populationGenerationIcon
            // 
            this.populationGenerationIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.populationGenerationIcon.Location = new System.Drawing.Point(12, 3);
            this.populationGenerationIcon.Name = "populationGenerationIcon";
            this.populationGenerationIcon.Size = new System.Drawing.Size(197, 194);
            this.populationGenerationIcon.TabIndex = 0;
            this.populationGenerationIcon.Click += new System.EventHandler(this.populationGenerationIcon_Click);
            // 
            // shapeCreationIcon
            // 
            this.shapeCreationIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shapeCreationIcon.Location = new System.Drawing.Point(18, 3);
            this.shapeCreationIcon.Name = "shapeCreationIcon";
            this.shapeCreationIcon.Size = new System.Drawing.Size(199, 194);
            this.shapeCreationIcon.TabIndex = 0;
            this.shapeCreationIcon.Click += new System.EventHandler(this.shapeCreationIcon_Click);
            // 
            // CrossroadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(454, 431);
            this.Controls.Add(splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CrossroadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Genetic Algorithm Crossroad";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splitContainer1)).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splitContainer2)).EndInit();
            splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GaComponentIcon geneticAlgorithmIcon;
        private GaComponentIcon populationGenerationIcon;
        private GaComponentIcon shapeCreationIcon;
    }
}