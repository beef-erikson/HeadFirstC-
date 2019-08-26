using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlashyThing
{
    public partial class Form1 : Form
    {
        int color;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            while (Visible)
            {
                for (color = 0; color <= 254 && Visible; color++)
                {
                    ChangeColor();
                }
                for (color = 254; color >= 0 && Visible; color--)
                {
                    ChangeColor();
                }
            }
        }

        private void ChangeColor()
        {
            this.BackColor = Color.FromArgb(color, 255 - color, 255 - color);
            Application.DoEvents();
            System.Threading.Thread.Sleep(3);
        }
    }
}
