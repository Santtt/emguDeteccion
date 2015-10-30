using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.CvEnum;
using System.IO;
using System.Runtime.InteropServices;

namespace pruebaEmgu
{
    public partial class Form1 : Form
    {
        private Capture capturar;
        HaarCascade haarCascade1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            capturar = new Capture(0);
            haarCascade1 = new HaarCascade("haarcascade_frontalface_default.xml");
            timer1.Interval = 40;
            timer1.Enabled=true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            using(Image<Bgr, byte> imagen = capturar.QueryFrame())
            {
               if (imagen !=  null)
               {
                   Image<Gray, byte> gris = imagen.Convert<Gray, byte>();
                   var faces = gris.DetectHaarCascade(haarCascade1)[0];
                   foreach (var face in faces)
                   {
                       imagen.Draw(face.rect, new Bgr(0, 255, 0), 3);
                   }

                   pictureBox1.Image = imagen.ToBitmap();
               }
            }
        }

       
    }
}
