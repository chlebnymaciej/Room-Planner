using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Configuration;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Globalization;
using System.Threading;
using System.Resources;
//using ChlebnyWindowsFormsPWSG.Resources;

namespace ChlebnyWindowsFormsPWSG
{

    public partial class RoomPlanner : Form
    {
        private Bitmap bitmap;
        private Bitmap spareBitmap;
        private int selected = 0;
        private Image source;
        private Button reset;
        public static Pen wallPen = new Pen(Brushes.Black, 10);
        private static Pen transPen = new Pen(Color.FromArgb(128, Color.Black), 10);
        private RoomItem WallInDraw = null;
        private BindingList<RoomItem> items = new BindingList<RoomItem>();
        private RoomItem select = null;
        private Point lastPosition;
        private (string name, Image source)[] sourcelist;
        private GraphicsPath spareGP = new GraphicsPath();
        public RoomPlanner()
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("pl-PL");
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            InitializeComponent();
            bitmap = DrawFilledRectangle(imagePanel.Width, imagePanel.Height);
            pictureBox1.Image = bitmap;
            pictureBox1.MouseWheel += MouseWheelEventHandler;
            // smooth connections
            wallPen.MiterLimit = 1.0f;
            transPen.MiterLimit = 1.0f;
            items.AllowNew = true;
            items.AllowEdit = true;
            items.AllowRemove = true;
            items.RaiseListChangedEvents = true;
            ListOfItems.DataSource = items;
            ResourceManager m = new ResourceManager(typeof(RoomPlanner));

            sourcelist = new (string name, Image source)[]
            {
                (m.GetString("chairs1"),chairsB.BackgroundImage),
                (m.GetString("dbed1"),dbedB.BackgroundImage),
                (m.GetString("sofa1"),sofaB.BackgroundImage),
                (m.GetString("table1"),tableB.BackgroundImage),
                (m.GetString("wall1"), wallB.BackgroundImage)
            };
        }

        private void ChangeLanguage(string lang = "en")
        {
            Controls.Clear();
            select = null;
            selected = 0;
            CultureInfo culture = CultureInfo.GetCultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            InitializeComponent();
            bitmap = DrawFilledRectangle(imagePanel.Width, imagePanel.Height);
            pictureBox1.Image = bitmap;
            pictureBox1.MouseWheel += MouseWheelEventHandler;
            wallPen.MiterLimit = 1.0f;
            transPen.MiterLimit = 1.0f;
            ResourceManager m = new ResourceManager(typeof(RoomPlanner));
            sourcelist = new (string name, Image source)[]
            {
                (m.GetString("chairs1"),chairsB.BackgroundImage),
                (m.GetString("dbed1"),dbedB.BackgroundImage),
                (m.GetString("sofa1"),sofaB.BackgroundImage),
                (m.GetString("table1"),tableB.BackgroundImage),
                (m.GetString("wall1"), wallB.BackgroundImage)
            };
            foreach (RoomItem item in items)
            {
                item.updateNames(sourcelist);

            }
            ListOfItems.DataSource = items;
        }

        /// <summary>
        /// New Blueprint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newBlueprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bitmap = DrawFilledRectangle(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmap;
            items.Clear();
            WallInDraw = null;
        }

        //https://stackoverflow.com/questions/12502365/how-to-create-1024x1024-rgb-bitmap-image-of-white
        private Bitmap DrawFilledRectangle(int x, int y)
        {
            Bitmap bmp = new Bitmap(x, y);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(0, 0, x, y);
                graph.FillRectangle(Brushes.White, ImageSize);
            }
            return bmp;
        }

        // resize event
        private void RoomPlanner_Resize(object sender, EventArgs e)
        {
            if (this.bitmap == null) return;

            int width = this.bitmap.Width;
            int height = this.bitmap.Height;

            if (this.imagePanel.Width > this.bitmap.Width)
                width = this.imagePanel.Width;
            if (this.imagePanel.Height > this.bitmap.Height)
                height = this.imagePanel.Height;

            if (height > this.bitmap.Height ||
                width > this.bitmap.Width)
            {
                Bitmap b = DrawFilledRectangle(height, width);
                Graphics g = Graphics.FromImage(b);
                g.DrawImage(bitmap, 0, 0);

                bitmap = b;
                pictureBox1.Image = bitmap;
            }


        }

        


        // ===========================================================
        // Picture Box Events
        // ===========================================================
        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {
            ImageClickWithoutButtonSelected(sender, e);

            if (selected == 5 && e.Button == MouseButtons.Right)
            {
                reset.BackColor = Button.DefaultBackColor;
                source = null;
                selected = 0;
                pictureBox1.Image = bitmap;
                pictureBox1.MouseMove -= MouseMoveDrawWall;
                WallInDraw = null;
                pictureBox1.Refresh();

                return;
            }
            if (selected == 5 && this.WallInDraw != null)
            {
                // poprawić walle
                this.WallInDraw.wall.AddLine( this.WallInDraw.points.Last(),Minus( e.Location, this.WallInDraw.Center));
                this.WallInDraw.points.Add( Minus(e.Location,WallInDraw.Center) );
        
                pictureBox1.Refresh();
                return;
            }


            bool isWall = false;
            StringBuilder sb = new StringBuilder();
            switch (selected)
            {
                case 1:
                    sb.Append("Chairs");
                    break;
                case 2:
                    sb.Append("Double Bed");
                    break;
                case 3:
                    sb.Append("Sofa");
                    break;
                case 4:
                    sb.Append("Table");
                    break;
                case 5:
                    sb.Append("Wall");
                    isWall = true;
                    spareBitmap = (Bitmap)bitmap.Clone();
                    pictureBox1.MouseMove += MouseMoveDrawWall;
                    break;
                default:
                    return;
            }
            if (bitmap == null)
            {
                MessageBox.Show("Cannot draw without Blueprint, please create one.",
                    "Drawing without canvas",
                    MessageBoxButtons.OK);
                return;
            }

            RoomItem Item = new RoomItem( selected-1, sourcelist[selected-1].name, e.Location, source, isWall);
            sb.Append(e.Location.ToString());

            items.Add(Item);
            if (selected != 0 && selected != 5)
            {
                reset.BackColor = Button.DefaultBackColor;
                selected = 0;

                Graphics g = Graphics.FromImage(bitmap);
                int correct_x = e.X - source.Width / 2;
                int correct_y = e.Y - source.Height / 2;

                g.DrawImage(source, correct_x, correct_y);
                pictureBox1.Refresh();
            }

            if (isWall)
            {
                this.WallInDraw = Item;
            }


        }


        // https://stackoverflow.com/questions/13116684/how-to-make-the-scrollbar-note-scroll-when-the-mouse-wheel-event-happens-in-c-sh
        void MouseWheelEventHandler(object sender, MouseEventArgs e)
        {
            if (select != null)
            {

                select.Angle += e.Delta * 0.01f;
                pictureBox1.Refresh();
            }

            ((HandledMouseEventArgs)e).Handled = true;
        }



        // temporary wall while drawing
        private void MouseMoveDrawWall(object s, MouseEventArgs e1)
        {
            spareBitmap = (Bitmap)bitmap.Clone();

            using (Graphics g = Graphics.FromImage(spareBitmap))
            {
                spareGP = (GraphicsPath)WallInDraw.wall.Clone();
                // tu poprawic
                spareGP.AddLine(this.WallInDraw.points.Last(), Minus(e1.Location,this.WallInDraw.Center));
                pictureBox1.Refresh();
            }
        }

        // finding closest center
        private RoomItem Closest(Point p)
        {
            RoomItem tmp = null;
            int dist = int.MaxValue;
            foreach (RoomItem item in items)
            {
                if (item.IsWall) continue;

                if (item.IsInItem(p) < dist)
                {
                    dist = item.IsInItem(p);
                    tmp = item;
                }
            }
            if (tmp != null)
                return tmp;

            RoomItem s = items.Where(x => x.IsWall
                                    && x.IsInWall(p))
                                    .LastOrDefault();
            return s;
        }


        // it is just normal image paint
        private void DrawImage(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            foreach (RoomItem ri in items)
            {
                if (ri == WallInDraw) continue;

                g.TranslateTransform(ri.Center.X, ri.Center.Y);
                g.RotateTransform(ri.Angle);

                if (select == ri && ri.IsWall)
                {
                    g.DrawPath(transPen, ri.wall);

                    g.RotateTransform(-ri.Angle);
                    g.TranslateTransform(-ri.Center.X, -ri.Center.Y);
                    continue;
                }

                if (ri.IsWall)
                {
                    g.DrawPath(wallPen, ri.wall);

                    g.RotateTransform(-ri.Angle);
                    g.TranslateTransform(-ri.Center.X, -ri.Center.Y);
                    continue;
                }


                if (select == ri)
                {
                    using (Image im = BitmapExtensions.SetOpacity(select.Source, 0.5f))
                    {
                        g.DrawImage(im, new Point(-im.Width / 2, -im.Height / 2));
                        g.RotateTransform(-ri.Angle);
                        g.TranslateTransform(-ri.Center.X, -ri.Center.Y);
                    }
                    continue;
                }
                g.DrawImage(ri.Source, new Point(-ri.Source.Width / 2, -ri.Source.Height / 2));

                g.RotateTransform(-ri.Angle);
                g.TranslateTransform(-ri.Center.X, -ri.Center.Y);

            }
            if (WallInDraw != null)
            {
                g.TranslateTransform(WallInDraw.Center.X, WallInDraw.Center.Y);
                g.RotateTransform(WallInDraw.Angle);
                g.DrawPath(wallPen, spareGP);

                g.RotateTransform(WallInDraw.Angle);
                g.TranslateTransform(-WallInDraw.Center.X, -WallInDraw.Center.Y);
            }


        }

        private void ImageClickWithoutButtonSelected(object s, MouseEventArgs e)
        {
            if (selected == 0)
            {
                RoomItem item = this.Closest(e.Location);
                select = item;
                if (select == null)
                {
                    pictureBox1.Refresh();
                    return;
                }
                ListOfItems.SelectedIndex = ListOfItems.Items.IndexOf(select);
                pictureBox1.Refresh();
                return;
            }
        }
        private void ImageMove(object sender, MouseEventArgs e)
        {
            if (select != null && e.Button == MouseButtons.Left)
            {
                Point t = new Point(e.X - lastPosition.X,
                                    e.Y - lastPosition.Y);
                select.Center = new Point(select.Center.X + t.X, select.Center.Y + t.Y);

                items.ResetBindings();
                pictureBox1.Refresh();
            }

            lastPosition = e.Location;
        }

        private void ListOfItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            select = (RoomItem)ListOfItems.SelectedItem;
            pictureBox1.Refresh();
        }

        private void RoomPlanner_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && select != null)
            {
                items.Remove(select);
                select = null;
                pictureBox1.Refresh();
            }
        }
        // serialization
        private void saveBlueprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog s = new SaveFileDialog())
            {
                Stream file;
                s.Filter = "super schema (*.ss)|*.ss";
                if (s.ShowDialog() == DialogResult.OK)
                {
                    if ((file = s.OpenFile()) != null)
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        foreach (RoomItem item in items)
                        {
                            item.bitmapSize = bitmap.Size;
                        }
                        binaryFormatter.Serialize(file, items);
                        file.Close();
                    }
                }

            }

        }

        private void openBlueprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog s = new OpenFileDialog())
            {
                Stream file;
                s.Filter = "super schema (*.ss)|*.ss";
                if (s.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if ((file = s.OpenFile()) != null)
                        {
                            BinaryFormatter binaryFormatter = new BinaryFormatter();
                            items = (BindingList<RoomItem>)binaryFormatter.Deserialize(file);
                            file.Close();

                            foreach (RoomItem ri in items)
                            {
                                ri.updateNames(sourcelist);
                                ri.Source = sourcelist
                                      .Where(x => x.name == ri.Name)
                                      .FirstOrDefault()
                                      .source;
                                ri.DeSerialize();
                            }
                        }
                        if (items.First() != null)
                        {
                            bitmap = DrawFilledRectangle(items.First().bitmapSize.Width, items.First().bitmapSize.Height);
                            pictureBox1.Image = bitmap;
                        }
                        pictureBox1.Refresh();
                        ListOfItems.DataSource = items;
                    } catch (Exception error)
                    {
                        MessageBox.Show(error.Message + "\n" + error.StackTrace);
                    }
                }

            }
        }

        public static Point Plus(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point Minus(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }

        private void polskiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("pl-PL");
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("en");
        }

        private void RoomPlanner_Load(object sender, EventArgs e)
        {

        }
    }
}
