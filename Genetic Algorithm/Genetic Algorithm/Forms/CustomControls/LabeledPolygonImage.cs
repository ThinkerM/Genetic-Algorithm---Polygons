using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Polygons;

namespace Genetic_Algorithm.Forms
{
    /// <summary>
    /// Control containing a picture of a polygon, an optional description tag and a selection checkbox which appears when mouse-hovered over
    /// </summary>
    internal partial class LabeledPolygonImage : UserControl
    {
        /// <summary>
        /// Polygon assigned to the image
        /// </summary>
        public Polygon SavedPolygon { get; }

        public bool AllowSelectionCheckbox { get; set; }

        /// <summary>
        /// Control containing a picturebox for a polygon picture, a selection checkbox and a custom description label
        /// </summary>
        /// <param name="assignedPolygon">Polygon to draw in a picturebox</param>
        /// <param name="description">Optional description tag to inclue with the picture</param>
        /// <param name="enableSelectionCheckbox">Whether selection checkbox should become functional (and visible)</param>
        public LabeledPolygonImage(Polygon assignedPolygon, string description = "", bool enableSelectionCheckbox = true)
        {
            InitializeComponent();
            this.BackColor = Color.DarkCyan;
            this.SendToBack();
            SavedPolygon = assignedPolygon;
            AllowSelectionCheckbox = enableSelectionCheckbox;
        }

        /// <summary>
        /// Height of the image part of the control
        /// </summary>
        public int ImageHeight { get { return pictureBox.Height; } }
        /// <summary>
        /// Width of the image part of the control
        /// </summary>
        public int ImageWidth { get { return pictureBox.Width; } }
        /// <summary>
        /// Handle of the picturebox of the control
        /// </summary>
        public PictureBox PictureBox { get { return pictureBox; } }
        /// <summary>
        /// Indicates whether the control's selection box is checked
        /// </summary>
        public bool Selected { get { return selectionCheckbox.Checked; } }

        /// <summary>
        /// Change state of SelectionCheckbox to true
        /// </summary>
        public new void Select() => selectionCheckbox.Checked = true;

        /// <summary>
        /// Change state of SelectionCheckbox to false
        /// </summary>
        public void Deselect() => selectionCheckbox.Checked = false;

        private Point ImageCenter
        {
            get { return new Point(ImageWidth / 2, ImageHeight / 2); }
        }

        /// <summary>
        /// Optional description tag of the image
        /// </summary>
        public string Description
        {
            get { return descriptionLabel.Text; }
            set
            {
                descriptionLabel.Text = value;
                Invalidate();
            }
        }

        private void PaintSymmetryAxis(Polygon p, Graphics g)
        {
            Point upperPoint = new Point(p.Centroid.X, 0);
            Point lowerPoint = new Point(p.Centroid.X, Height - descriptionLabel.Height);
            g.DrawLine(Pens.Black, upperPoint, lowerPoint);
        }

        /// <summary>
        /// Redraw the control
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var drawablePolygon = 
                PolygonVisualizer.PolygonNormalizedToBox(
                    SavedPolygon, (int)(pictureBox.Width * 0.9), (int)(pictureBox.Height * 0.9));
            drawablePolygon.ShiftCenter(ImageCenter);

            PaintSymmetryAxis(drawablePolygon, e.Graphics);
            PolygonVisualizer.Draw(drawablePolygon, e.Graphics);   
        }

        /// <summary>
        /// Mouse right-click occured anywhere on the control
        /// </summary>
        public event MouseEventHandler LabeledImageMouseRightClicked;

        /// <summary>
        /// Right mouse-click occured
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnRightMouseClicked(MouseEventArgs e)
        {
            LabeledImageMouseRightClicked?.Invoke(this, e);
        }
        private void LabeledPolygonImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            { OnRightMouseClicked(e); }
        }

        private void LabeledPolygonImage_MouseMove(object sender, MouseEventArgs e)
        {
           if (selectionCheckbox.Bounds.Contains(e.Location) && !selectionCheckbox.Visible && AllowSelectionCheckbox)
            { selectionCheckbox.Show(); }
        }

        private void selectionCheckbox_MouseLeave(object sender, EventArgs e)
        {
            if (!selectionCheckbox.Checked)
            { selectionCheckbox.Hide(); }
        }

        private void selectionCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!AllowSelectionCheckbox)
            {
                //deny checkbox functionality
                selectionCheckbox.Checked = false;
                selectionCheckbox.Visible = false;
                return;
            }

            selectionCheckbox.Visible = selectionCheckbox.Checked;
        }

        private event MouseEventHandler _imageMouseDown;
        public event MouseEventHandler ImageMouseDown
        {
            add { _imageMouseDown += value; }
            remove { _imageMouseDown -= value; }
        }
        private void LabeledPolygonImage_MouseDown(object sender, MouseEventArgs e) => _imageMouseDown?.Invoke(sender, e);

        private event MouseEventHandler _imageMouseUp;
        public event MouseEventHandler ImageMouseUp
        {
            add { _imageMouseUp += value; }
            remove { _imageMouseUp -= value; }
        }
        private void LabeledPolygonImage_MouseUp(object sender, MouseEventArgs e) => _imageMouseUp?.Invoke(sender, e);
    }
}
