using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Akıllı_Tahta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            grfik = panel1.CreateGraphics();
   
            kalem.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
            kalembeyaz.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
        }
        ColorDialog renkdialog;Graphics grfik;
        Pen kalem = new Pen(Color.Black,5);
        int x;int y;int genislik;
        Pen kalembeyaz = new Pen(Color.White, 5);
        Boolean secim;

        private void button1_Click(object sender, EventArgs e)
        {
            renkdialog = new ColorDialog();
            renkdialog.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            try
            {
               grfik.Clear(panel1.BackColor);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "EBS Securty");
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Point nokta1 = new Point(x, y);
            Point nokta2 = new Point(e.X, e.Y);
            if (e.Button == MouseButtons.Left) //EBS Coding...
            {
                #region Yazıyı yazar
                if (renkdialog != null)
                {
                    kalem = new Pen(renkdialog.Color, 3);
                }
                if (secim == true)
                {
                    grfik.DrawLine(kalem, nokta1, nokta2);
                    x = e.X;
                    y = e.Y;
                }
                #endregion

            }
            else if (e.Button == MouseButtons.Right)
            {
                #region Yazıyı Siler
                grfik.DrawLine(kalembeyaz, nokta1, nokta2);
                #endregion
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            secim = true;
            x = e.X;
            y = e.Y;

            if (radioButton1.Checked) //EBS Coding...
            {
                genislik = 1;
            }
            else if (radioButton2.Checked)
            {
                genislik = 5;
            }
            else if (radioButton3.Checked)
            {
                genislik = 10;
            }
            else if (radioButton4.Checked)
            {
                genislik = 15;
            }
            else if (radioButton5.Checked)
            {
                genislik = 30;
            }
            kalem.Width = genislik;
            kalembeyaz.Width = genislik;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            secim = false;
        }

    }
}
