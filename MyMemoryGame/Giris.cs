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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/SerkanOzkann");
        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }

        private void btn_kolay_Click(object sender, EventArgs e)
        {
            SeviyeKolay f1 = new SeviyeKolay();

            if (tb_kadi.Text == "")
            {
                MessageBox.Show("Oyuncu adı boş bırakılamaz.");
            }
            else
            {
                f1.Show();
                this.Hide();
            }
        }

        private void btn_orta_Click(object sender, EventArgs e)
        {
            SeviyeOrta f2 = new SeviyeOrta();
            if (tb_kadi.Text == "")
            {
                MessageBox.Show("Oyuncu adı boş bırakılamaz.");
            }
            else
            {
                f2.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SeviyeZor f3 = new SeviyeZor();

            if (tb_kadi.Text == "")
            {
                MessageBox.Show("Oyuncu adı boş bırakılamaz.");
            }
            else
            {
                f3.Show();
                this.Hide();
            }
        }
    }
}
