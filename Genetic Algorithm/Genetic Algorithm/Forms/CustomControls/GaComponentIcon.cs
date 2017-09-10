using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomExtensions.Graphics;
using System.Drawing.Drawing2D;

namespace Genetic_Algorithm.Forms
{
    internal partial class GaComponentIcon : UserControl
    {
        Graphics g;

        public delegate void GaIconClickedEventHandler(object sender, EventArgs e);
        public event GaIconClickedEventHandler OnGaIconClicked;

        public GaComponentIcon()
        {
            InitializeComponent();

            iconPictureBox.Click += new EventHandler(OnClickedAnywhere);
            componentNameLabel.Click += new EventHandler(OnClickedAnywhere);
        }

        private void OnClickedAnywhere(object sender, EventArgs e)
        {
            if (OnGaIconClicked != null)
            { OnGaIconClicked(this, e); }
        }


        public override string Text
        {
            get { return componentNameLabel.Text; }
            set { componentNameLabel.Text = value; Invalidate(); }
        }

        public void AssignIconPicture(string iconFilePath)
        {
            if (System.IO.File.Exists(iconFilePath))
            {
                iconPictureBox.Image = new Bitmap(iconFilePath);
                iconPictureBox.Image = GraphicalExtensions.Resize(iconPictureBox.Image, iconPictureBox.Width, iconPictureBox.Height);
                g = Graphics.FromImage(iconPictureBox.Image);
            }
        }

        public void AssignIconPicture(Bitmap picture)
        {
            iconPictureBox.Image = GraphicalExtensions.Resize(picture, iconPictureBox.Width, iconPictureBox.Height);
            g = Graphics.FromImage(iconPictureBox.Image);
        }

        public void AssignIconPicture(System.IO.Stream pictureStream)
        {
            try
            {
                iconPictureBox.Image = new Bitmap(pictureStream);
                iconPictureBox.Image = GraphicalExtensions.Resize(iconPictureBox.Image, iconPictureBox.Width, iconPictureBox.Height);
                g = Graphics.FromImage(iconPictureBox.Image);
            }
            catch { MessageBox.Show("Failed to load resource image"); }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (iconPictureBox.Image != null)
            { iconPictureBox.Image = GraphicalExtensions.Resize(iconPictureBox.Image, iconPictureBox.Width, iconPictureBox.Height); }
        }

        private void componentNameLabel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            using (LinearGradientBrush lgBrush = new LinearGradientBrush(
                componentNameLabel.ClientRectangle,
                Color.DarkCyan, Color.White,
                LinearGradientMode.Vertical))
            { g.FillRectangle(lgBrush, componentNameLabel.ClientRectangle); }

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            g.DrawString(Text, componentNameLabel.Font, Brushes.Black, componentNameLabel.ClientRectangle, sf);
        }
    }
}