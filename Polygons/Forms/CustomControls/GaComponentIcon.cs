using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Polygons.Forms.CustomControls
{
    internal partial class GaComponentIcon : UserControl
    {
        private Graphics g;

        public delegate void GaIconClickedEventHandler(object sender, EventArgs e);
        public event GaIconClickedEventHandler OnGaIconClicked;

        public GaComponentIcon()
        {
            InitializeComponent();

            iconPictureBox.Click += OnClickedAnywhere;
            componentNameLabel.Click += OnClickedAnywhere;
        }

        private void OnClickedAnywhere(object sender, EventArgs e)
        {
            OnGaIconClicked?.Invoke(this, e);
        }


        public override string Text
        {
            get { return componentNameLabel.Text; }
            set { componentNameLabel.Text = value; Invalidate(); }
        }

        public void AssignIconPicture(string iconFilePath)
        {
            if (!System.IO.File.Exists(iconFilePath))
            { return; }
            iconPictureBox.Image = new Bitmap(iconFilePath);
            iconPictureBox.Image = ThinkerExtensions.Graphics.GdiExtensions.Resize(iconPictureBox.Image, iconPictureBox.Width, iconPictureBox.Height);
            g = Graphics.FromImage(iconPictureBox.Image);
        }

        public void AssignIconPicture(Bitmap picture)
        {
            iconPictureBox.Image = ThinkerExtensions.Graphics.GdiExtensions.Resize(picture, iconPictureBox.Width, iconPictureBox.Height);
            g = Graphics.FromImage(iconPictureBox.Image);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (iconPictureBox.Image != null)
            { iconPictureBox.Image = ThinkerExtensions.Graphics.GdiExtensions.Resize(iconPictureBox.Image, iconPictureBox.Width, iconPictureBox.Height); }
        }

        private void componentNameLabel_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush lgBrush = new LinearGradientBrush(
                componentNameLabel.ClientRectangle,
                Color.DarkCyan, Color.White,
                LinearGradientMode.Vertical))
            { g.FillRectangle(lgBrush, componentNameLabel.ClientRectangle); }

            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            g.DrawString(Text, componentNameLabel.Font, Brushes.Black, componentNameLabel.ClientRectangle, sf);
        }
    }
}