using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ScreenSaver
{
    public partial class Form1 : Form
    {
        private List<Image> BGImages = new List<Image>();
        private List<BritPic> britPics = new List<BritPic>();
        private Random rand = new Random();

        class BritPic
        {
            public int picNum;
            public float x;
            public float y;
            public float speed;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void frmScreenSaver_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        private void frmScreenSaver_Load(object sender, EventArgs e)
        {
            string[] images = System.IO.Directory.GetFiles("pics");

            foreach (string image in images)
            {
                BGImages.Add(new Bitmap(image));
            }

            for (int i = 0; i < 50; i++)
            {
                BritPic mp = new BritPic();
                mp.picNum = i % BGImages.Count;
                mp.x = rand.Next(0, Width);
                mp.y = rand.Next(0, Height);

                britPics.Add(mp);
            }
        }

        private void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (BritPic bp in britPics)
            {
                e.Graphics.DrawImage(BGImages[bp.picNum], bp.x, bp.y);
                bp.x -= 2;

                if (bp.x < -250)
                {
                    bp.x = Width + rand.Next(20, 100);
                }
            }
        }
    }
}