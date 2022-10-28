using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3._2
{
    public partial class Form1 : Form
    {
        int _x;
        int _y;
        bool _mouseClicked = false;
        Color SelectedColor
        {
            get { return colorDialog1.Color; }
        }
        int SelectedSize
        {
             get { return trackBar1.Value; }
        }
        Brush _selecredBrush;
        Color DefaultColor
        {
            get { return Color.White; }
        }
        void CreateBlank (int width, int height)
        {
            var OldImage = pictureBox1.Image;
            var bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j<height;j++ )
                {
                    bmp.SetPixel(i, j, DefaultColor);
                }
            }
            pictureBox1.Image = bmp;
            if (OldImage!=null)
            {
                OldImage.Dispose();
            }
        }
       
        public Form1()
        {
            InitializeComponent();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _selecredBrush = new QuadBrush(SelectedColor, SelectedSize);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (_selecredBrush == null)
            {
                return;
            }
            _selecredBrush.Draw(pictureBox1.Image as Bitmap, _x, _y);
            pictureBox1.Refresh();
            _mouseClicked = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseClicked = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            _x = e.X > 0 ? e.X : 0;
            _y = e.Y > 0 ? e.Y : 0;
            if (_mouseClicked)
            {
                _selecredBrush.Draw(pictureBox1.Image as Bitmap, _x, _y);
                pictureBox1.Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _selecredBrush = new Circle(SelectedColor, SelectedSize);
        }
        class ImageSizeForm
        {

        }
        
        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            if (form.Canceled==false)
            {
                CreateBlank(form.W, form.H);
            }
            
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image=null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog()==DialogResult.OK)
            {
                button5.BackColor = colorDialog1.Color;
            }
        }
    }
}
