using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Polygons.Forms.DialogForms;
using CustomExtensions.Graphics;
using Polygons.Utils;

namespace Polygons.Forms
{
    /// <summary>
    /// Form allowing user to specify and modify a custom shape
    /// </summary>
    /// <remarks>
    /// Provides following features (among others):
    /// <list type="bullet">
    ///     <item><description>Define the shape of a polygon</description></item>
    ///     <item><description>Rename created shapes</description></item>
    ///     <item><description>Change color of a shape</description></item>
    ///     <item><description>Limited file management of shapes</description></item>
    /// </list>
    /// </remarks>
    public partial class PolygonCreationForm : Form
    {
        #region Main
        private List<Point> userInput = new List<Point>();
        private Polygon DefinedPolygon => new Polygon(userInput, PolygonColor, ShapeName);
        private Color PolygonColor { get; set; }

        /// <summary>
        /// Form allowing user to specify and modify a custom shape
        /// </summary>
        public PolygonCreationForm()
        {
            InitializeComponent();

            saveSuccessfulNotification.Icon = SystemIcons.Information;
            deleteSuccessfulNotification.Icon = SystemIcons.Information;
            genericIcon.Icon = SystemIcons.Information;
            genericIcon.ShowBalloonTip(5000);
           
            PolygonColor = Color.Black;
            polygonBox.Paint += polygonBox_Paint;

            loadShapeDialog.InitialDirectory = PolygonPaths.PolygonSavedShapesFolderNoBacklash;
            deleteShapeDialog.InitialDirectory = PolygonPaths.PolygonSavedShapesFolderNoBacklash;
            TryCreateSavesFolder();
        }

        private void PolygonCreationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var control in this.Controls)
            {
                if (control is NotifyIcon)
                {
                    NotifyIcon notification = control as NotifyIcon;
                    notification.Icon = null;
                    notification.Dispose();
                }
            }
        }

        /// <summary>
        /// Safely close form on ESC press
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void polygonBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            polygonBox.BackColor = inversionCheckbox.Checked 
                ? PolygonColor.Invert() 
                : DefaultBackground;

            if (useGridCheckBox.Checked)
            { PaintGrid(polygonBox, g); }

            if (closeShapeCheckbox.Checked)
            { DefinedPolygon.Draw(g); }
            else
            { DefinedPolygon.DrawIncomplete(g); }

            if (showCentroidCheckBox.Checked)
            { DefinedPolygon.DrawCentroid(g); }
        }
        #endregion

        #region Grid
        private int GridCellSize => (int)cellSizeUpDown.Value;

        private void PaintGrid(PictureBox box, Graphics g)
        {
            using (Pen gridPen = new Pen(Color.Gray))
            {
                for (int i = 0; i <= box.Width; i += GridCellSize)
                {
                    Point upperPoint = new Point(i, 0);
                    Point lowerPoint = new Point(i, box.Height);
                    g.DrawLine(gridPen, upperPoint, lowerPoint);
                }
                for (int i = 0; i < box.Height; i += GridCellSize)
                {
                    Point leftPoint = new Point(0, i);
                    Point rightPoint = new Point(box.Width, i);
                    g.DrawLine(gridPen, leftPoint, rightPoint);
                }                
            }
            using (Brush cellBrush = new SolidBrush(Color.LightGray))
            {
                if (CurrentGridCell != null)
                {
                    g.FillRectangle(cellBrush, CurrentGridCell);
                }
            }
        }

        private void cellSizeUpDown_ValueChanged(object sender, EventArgs e)
        {
            polygonBox.Invalidate();
        }

        private Rectangle CurrentGridCell { get; set; }
        private void UpdateCurrentGridCell(Point location)
        {
            int cellsLeft = location.X / GridCellSize;
            int cellsUp = location.Y / GridCellSize;
            Point rectangleUpperLeft = new Point(cellsLeft * GridCellSize, cellsUp * GridCellSize);
            CurrentGridCell = new Rectangle(rectangleUpperLeft, new Size(GridCellSize, GridCellSize));
        }
        #endregion Grid

        #region User-painting
        private void polygonBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button != MouseButtons.Left)
            { return; }

            Point inputCoordinates;
            if (useGridCheckBox.Checked)
            {
                inputCoordinates = new Point(
                    CurrentGridCell.Left + CurrentGridCell.Width / 2,
                    CurrentGridCell.Top + CurrentGridCell.Height / 2);
            }
            else
            { inputCoordinates = me.Location; }

            userInput.Add(inputCoordinates);
            UpdateDescriptors();
            polygonBox.Invalidate();
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            if (polygonColorDialog.ShowDialog() == DialogResult.OK)
            {
                PolygonColor = polygonColorDialog.Color;
                polygonBox.Invalidate();
                UpdateDescriptors();
            }
        }

        private void UpdateDescriptors()
        {
            verticesCountTextBox.Text = "N vertices: " + userInput.Count.ToString();
            colorLabel.Text = PolygonColor.ToString();
        }

        private void deleteLastButton_Click(object sender, EventArgs e)
        {
            if (userInput.Count > 0)
            {
                userInput.RemoveAt(userInput.Count - 1);
                polygonBox.Invalidate();
                UpdateDescriptors();
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            userInput.Clear();
            PolygonColor = Color.Black;
            polygonBox.Invalidate();
            UpdateDescriptors();
        }

        private void AnyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            polygonBox.Invalidate();
        }
        #endregion

        #region File Manipulation
        /// <summary>
        /// Name of the shape being currently edited
        /// </summary>
        public string ShapeName { get; set; } = string.Empty;
        private bool ValidFolderSelected { get; set; }

        private static void TryCreateSavesFolder()
        {
            System.IO.Directory.CreateDirectory(PolygonPaths.PolygonSavedShapesFolder);
        }

        private void saveShapeButton_Click(object sender, EventArgs e)
        {
            using (var nameChooser = new ShapeNameChooserPrompt(this))
            {
                nameChooser.ShowDialog(); 
            }

            if (ShapeName == "" || ShapeName == string.Empty) //make sure a proper name can be constructed
            { return; }

            if (System.IO.File.Exists(PolygonPaths.SaveXmlPath(ShapeName)))
            {
                using (var overwriteForm = new ShapeOverwritePromptForm(ShapeName))
                {
                    if (overwriteForm.ShowDialog() == DialogResult.Cancel)
                    {
                        //not ok to overwrite
                        return;
                    }
                }
            }

            //nothing is being overwritten or ok to overwrite
            DefinedPolygon.SaveToDefaultFolder();
            saveSuccessfulNotification.ShowBalloonTip(2000, "Save successful", ShapeName + " has been successfully saved.", ToolTipIcon.Info);
        }

        private void loadShapeButton_Click(object sender, EventArgs e)
        {
            if (loadShapeDialog.ShowDialog() != DialogResult.OK)
            { return; }

            if (ValidFolderSelected)
            {
                Polygon loadedPolygon;
                try
                {
                    loadedPolygon = PolygonXmlHandler.Load(loadShapeDialog.FileName);
                    loadedPolygon.ShiftUpperLeftCorner(new Point(0, 0));
                }
                catch (Exception ex)
                {
                    //loaded file isn't in proper state, prompt to delete
                    if (!DeleteFileConfirmation.Confirm(loadShapeDialog.FileName, true))
                    { return; }

                    System.IO.File.Delete(loadShapeDialog.FileName);
                    { deleteSuccessfulNotification.ShowBalloonTip(2000, "Deletion successful", "Faulty file has been deleted.", ToolTipIcon.Info); }
                    return;
                }

                loadedPolygon.ShiftCenter(new Point((int)(polygonBox.Width / 2), (int)(polygonBox.Height / 2)));
                userInput = loadedPolygon.Vertices;
                ShapeName = loadedPolygon.Name;
                PolygonColor = loadedPolygon.OutlineColor;

                UpdateDescriptors();
                polygonBox.Invalidate();
            }
            else
            {
                loadShapeDialog.ShowDialog();
            }
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            //check if user left the predefined directory
            if (loadShapeDialog.FileName.Contains(loadShapeDialog.InitialDirectory))
            {
                ValidFolderSelected = true;
            }
            else
            {
                MessageBox.Show("You have left the pre-set directory. Invalid action.");
                ValidFolderSelected = false;
            }
        }

        private void deleteFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            //check if user left the predefined directory
            if (deleteShapeDialog.FileName.Contains(deleteShapeDialog.InitialDirectory))
            {
                ValidFolderSelected = true;
            }
            else
            {
                MessageBox.Show("You have left the pre-set directory. Invalid action.");
                ValidFolderSelected = false;
            }
        }

        private void deleteShapeButton_Click(object sender, EventArgs e)
        {
            if (deleteShapeDialog.ShowDialog() == DialogResult.OK)
            {
                if (ValidFolderSelected)
                {
                    bool okToDelete;

                    if (deleteShapeDialog.FileNames.Length == 1)
                    {
                        okToDelete = DeleteFileConfirmation.Confirm(deleteShapeDialog.FileName);
                        if (okToDelete)
                        { deleteSuccessfulNotification.ShowBalloonTip(2000, "Deletion successful", "1 file has been deleted.", ToolTipIcon.Info); }
                    }
                    else
                    {
                        okToDelete = DeleteFileConfirmation.Confirm(deleteShapeDialog.FileNames.Length.ToString());
                        if (okToDelete)
                        { deleteSuccessfulNotification.ShowBalloonTip(2000, "Deletion successful",
                                                                      $"{deleteShapeDialog.FileNames.Length} files have been deleted.", ToolTipIcon.Info); }
                    }
                    
                    if (okToDelete)
                    {
                        foreach (var fileName in deleteShapeDialog.FileNames)
                        {
                            new System.IO.FileInfo(fileName).Attributes = System.IO.FileAttributes.Normal;
                            System.IO.File.Delete(fileName);
                        }
                    }
                }
            }
        }
        #endregion

        #region Mouse, shape movement
        private Point MouseDownLocation { get; set; }

        private void polygonBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void polygonBox_MouseMove(object sender, MouseEventArgs e)
        {
            UpdateCurrentGridCell(e.Location);
            if (e.Button == MouseButtons.Right)
            {
                int dX = e.X - MouseDownLocation.X;
                int dY = e.Y - MouseDownLocation.Y;
                MouseDownLocation = e.Location;

                userInput = Polygon.ShiftedVertices(userInput, dX, dY);
            }
            polygonBox.Invalidate();
        }
        #endregion

        #region Background
        private static readonly Color DefaultBackground = Color.White;

        private void inversionCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            polygonBox.Invalidate();
        }

        private void useGridCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            cellSizeLabel.Visible = useGridCheckBox.Checked;
            cellSizeUpDown.Visible = useGridCheckBox.Checked;
            polygonBox.Invalidate();
        }
        #endregion
    }
}
