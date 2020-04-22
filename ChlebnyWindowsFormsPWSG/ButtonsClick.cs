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
//using ChlebnyWindowsFormsPWSG.Resources;

namespace ChlebnyWindowsFormsPWSG
{
    public partial class RoomPlanner : Form
    {
        // =====================================================
        // Button Click events
        // =====================================================
        private void chairsB_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            select = null;
            pictureBox1.Refresh();
            if (selected == 1)
            {
                b.BackColor = Button.DefaultBackColor;
                source = null;
                selected = 0;
                return;
            }
            
            if (selected != 0)
                reset.BackColor = Button.DefaultBackColor;
            reset = b;
            b.BackColor = Color.Pink;
            source = b.BackgroundImage;
            selected = 1;
        }

        private void dbedB_Click(object sender, EventArgs e)
        {
            select = null;
            pictureBox1.Refresh();
            Button b = sender as Button;
            if (selected == 2)
            {
                b.BackColor = Button.DefaultBackColor;
                source = null;
                selected = 0;
                return;
            }

            if (selected != 0)
                reset.BackColor = Button.DefaultBackColor;
            reset = b;
            b.BackColor = Color.Pink;
            source = b.BackgroundImage;
            selected = 2;
        }

        private void sofaB_Click(object sender, EventArgs e)
        {
            select = null;
            pictureBox1.Refresh();
            Button b = sender as Button;
            if (selected == 3)
            {

                b.BackColor = Button.DefaultBackColor;
                source = null;
                selected = 0;
                return;
            }

            if (selected != 0)
                reset.BackColor = Button.DefaultBackColor;
            reset = b;
            b.BackColor = Color.Pink;
            source = b.BackgroundImage;
            selected = 3;

        }

        private void tableB_Click(object sender, EventArgs e)
        {
            select = null;
            pictureBox1.Refresh();
            Button b = sender as Button;
            if (selected == 4)
            {
                b.BackColor = Button.DefaultBackColor;
                source = null;
                selected = 0;
                return;
            }

            if (selected != 0)
                reset.BackColor = Button.DefaultBackColor;
            reset = b;

            b.BackColor = Color.Pink;
            source = b.BackgroundImage;
            selected = 4;
        }

        private void wallB_Click(object sender, EventArgs e)
        {
            select = null;
            pictureBox1.Refresh();
            Button b = sender as Button;
            if (selected == 5)
            {
                b.BackColor = Button.DefaultBackColor;
                source = null;
                selected = 0;
                pictureBox1.Image = bitmap;
                pictureBox1.Refresh();
                pictureBox1.MouseMove -= MouseMoveDrawWall;
                WallInDraw = null;
                return;
            }

            if (selected != 0)
                reset.BackColor = Button.DefaultBackColor;
            reset = b;

            b.BackColor = Color.Pink;
            source = b.BackgroundImage;
            selected = 5;
        }
    }
}
