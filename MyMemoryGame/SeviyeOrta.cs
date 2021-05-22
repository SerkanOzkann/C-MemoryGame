using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMemoryGame
{
    public partial class SeviyeOrta : Form
    {
        public SeviyeOrta()
        {
            InitializeComponent();
        }

        byte islem = 0;
       PictureBox oncekiResim;
        byte kalan = 8;
        byte time = 59;

        void resimSifirla()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    (x as PictureBox).Image = Properties.Resources.block;
                }
            }
        }

        void tagSifirla()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    (x as PictureBox).Tag = "block";
                }
            }
        }

        void tagDagit()
        {
            int[] sayilar = new int[16];
            Random rnd = new Random();
            byte i = 0;
            while (i<16)
            {
                int rastgele = rnd.Next(1, 17);
                if (Array.IndexOf(sayilar, rastgele) == -1)
                {
                    sayilar[i] = rastgele;
                    i++;
                }
            }

            for (byte j = 0; j < 16; j++)
            {
                if (sayilar[j] > 8) sayilar[j] -= 8;
            }

            byte b = 0;
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    x.Tag = sayilar[b].ToString();
                    b++;
                }
            }
        }

        void karsilastirma(PictureBox onceki, PictureBox sonraki)
        {
            if (onceki.Tag.ToString() == sonraki.Tag.ToString())
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
                onceki.Visible = false;
                sonraki.Visible = false;
                kalan--;
                if (kalan == 0)
                {
                    lbl_bilgi.Text = "Tebrikler";
                    timer1.Enabled = false;
                }
                else
               
                lbl_bilgi.Text = ":" + kalan;
               
            }
            else
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
                onceki.Image= Image.FromFile("block.png");
                sonraki.Image= Image.FromFile("block.png");
            }
        }

        private void SeviyeOrta_Load(object sender, EventArgs e)
        {
            
            resimSifirla();
            tagSifirla();
            tagDagit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox simdikiResim = (sender as PictureBox);


            simdikiResim.Image = Image.FromFile((sender as PictureBox).Tag.ToString() + ".png");

            if (islem == 0)
            {
                oncekiResim = simdikiResim;
                islem++;
            }
            else
            {
                if (oncekiResim == simdikiResim)
                {
                    MessageBox.Show("Aynı Resim");
                    islem = 0;
                    oncekiResim.Image= Image.FromFile("block.png");
                }

                else
                {
                    karsilastirma(oncekiResim, simdikiResim);
                    islem = 0;
                }

            }

        }

        void goster()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    (x as PictureBox).Image = Image.FromFile(x.Tag.ToString() + ".png");
                }
            }
        }

        void gizle()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    (x as PictureBox).Image = Image.FromFile("block.png");
                }
            }
        }
        private void btn_goster_Click(object sender, EventArgs e)
        {
            
            goster();
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);
            gizle();
            islem = 0;
        }

        void VisibleAc()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    (x as PictureBox).Visible = true;
                }
            }
        }
        private void btn_yenioyun_Click(object sender, EventArgs e)
        {
            resimSifirla();
            tagSifirla();
            tagDagit();
            VisibleAc();
            kalan = 8;
            islem = 0;
            time = 60;
            timer1.Enabled = true;
            lbl_bilgi.Text = ":" + kalan;

        }

        private void lbl_bilgi_Click(object sender, EventArgs e)
        {

        }

        private void btn_cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void dur()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    (x as PictureBox).Enabled = false;
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            time -= 1;
            lbl_time.Text = ":" + time;
            if (time == 0)
            {
                lbl_bilgi.Text = "Süre Doldu";
                lbl_time.Text = "0";
                dur();
                timer1.Enabled = false;


            }
        }
    }
}
