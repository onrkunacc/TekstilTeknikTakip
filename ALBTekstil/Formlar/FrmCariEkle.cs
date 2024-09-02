using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALBTekstil.Formlar
{
    public partial class FrmCariEkle : Form
    {
        public FrmCariEkle()
        {
            InitializeComponent();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DB_ALBER_TEKSTİLEntities db = new DB_ALBER_TEKSTİLEntities();
            ALB_MUSTERILER cari = new ALB_MUSTERILER();
            cari.Musteri_Adi = TxtCariAdi.Text;
            cari.Musteri_Soyad = TxtSoyad.Text;
            cari.Musteri_Tel_No = TxtTelNo.Text;
            cari.Musteri_Sirket = TxtSirket.Text;
            cari.Musteri_Adres = TxtAdres.Text;
            cari.Musteri_Il = TxtIl.Text;
            cari.Musteri_Ilce = TxtIlce.Text;   
            
            db.ALB_MUSTERILER.Add(cari);    
            db.SaveChanges();

            MessageBox.Show("Cari başarıyla eklendi ! ","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
