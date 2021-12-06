using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_21
{
    public partial class Form1 : Form
    {
        int x, y;
        int width, height;

        public Form1()
        {
            InitializeComponent();
            x = y = 0;
            width = height = 100;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            trackBar1.Maximum = Width - width;
            trackBar2.Maximum = Height - height;
            e.Graphics.FillRectangle(new SolidBrush(SystemColors.ControlDark), x, y, width, height);
            TransparencyKey = SystemColors.ControlDark;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            x = trackBar1.Value;
            Invalidate();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            y = trackBar2.Value;
            Invalidate();
        }

    }
}
