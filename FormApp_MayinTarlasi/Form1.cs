using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApp_MayinTarlasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int puan = 0;
        private void btnBasla_Click(object sender, EventArgs e){
            MayinDoldur(10,10);
        }

        void MayinDoldur(int mayin,int boyut){
            flowLayoutPanel1.Width = boyut * 30;
            flowLayoutPanel1.Height = boyut * 30;
            flowLayoutPanel1.Controls.Clear();
            int[] mayinlar = new int[mayin];
            Random rnd = new Random();
                for (int i = 0; i < mayin; i++){
                    int secilen = rnd.Next(0, boyut * boyut);
                    if (mayinlar.Contains(secilen)){
                        i--;
                        continue;
                    }
                     mayinlar[i] = secilen;
                }

              for (int i = 0; i < boyut*boyut; i++){
                Button btn = new Button();
                btn.Width = 30;
                btn.Height = 30;
                btn.Margin = new Padding(0);
                btn.Tag = mayinlar.Contains(i);
                btn.Click += btn_Click;
                flowLayoutPanel1.Controls.Add(btn);
            }
        }
        void btn_Click(object sender, EventArgs e){
            Button tiklanan = (Button) sender;
            bool durum = (bool)tiklanan.Tag;
            if (durum == true){
                tiklanan.BackColor = Color.Red;
                OyunBitir();
            }else{
                tiklanan.BackColor = Color.Green;
                puan++;
                textBox1.Text=puan.ToString();
            }
        }

        void OyunBitir()
        {
            puan = 0;
            foreach (Button item in flowLayoutPanel1.Controls)
            {
                bool durum = (bool)item.Tag;
                if (durum)
                {
                    item.BackColor = Color.Red;
                }
                else
                {
                    item.BackColor = Color.Green;
                }
            }
            DialogResult sonuc = MessageBox.Show("Oyun Bitti Yeniden Oynamak İster Misin ?","Yeniden Başlat!",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(sonuc == DialogResult.Yes){
                MayinDoldur(10,10);
            }
        }
        
    }
}
