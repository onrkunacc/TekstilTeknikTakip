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
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }

        private void FrmYeniUrun_Load(object sender, EventArgs e)
        {

        }

        private void textEdit9_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnVazgeç_Click(object sender, EventArgs e)
        {
            FrmYeniUrun fr = new FrmYeniUrun();
            //fr.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DB_ALBER_TEKSTİLEntities db = new DB_ALBER_TEKSTİLEntities();
            ALB_URUNLER urun = new ALB_URUNLER();
            urun.Urun_Adi = TxtUrunAd.Text;
            urun.Urun_Barkod = TxtBarkod.Text;
            urun.Kategori_ID = int.Parse(TxtKategori.Text);
            urun.Alis_Fiyati = decimal.Parse(TxtAlisFiyati.Text);
            urun.Satis_Fiyati = decimal.Parse(TxtSatisFiyati.Text);
            urun.Olcu_Birimi = TxtBirim.Text;
            urun.Stok_Durumu = TxtStokDurum.Text;
            urun.Stok_Miktari = decimal.Parse(TxtStokMiktari.Text);
            db.ALB_URUNLER.Add(urun);   
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla eklendi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
        }
    }
}
