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
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureEdit13_EditValueChanged(object sender, EventArgs e)
        {

        }
        DB_ALBER_TEKSTİLEntities db = new DB_ALBER_TEKSTİLEntities();
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            labelControl15.Text = db.ALB_URUNLER.Count().ToString();
            labelControl3.Text = db.ALB_KATEGORILER.Count().ToString();
            labelControl5.Text = db.ALB_URUNLER.Sum(x =>x.Stok_Miktari).ToString();
            labelControl27.Text = db.ALB_BOYAHANETAKIP.Sum( a => a.Gonderilen_Miktar ).ToString() + " Kg";
            labelControl25.Text = db.ALB_BOYAHANETAKIP.Sum(a => a.Gelen_Miktar).ToString() + " Kg";
            labelControl29.Text = (from x in  db.ALB_URUNLER 
                                   orderby x.Stok_Miktari descending
                                   select x.Urun_Adi).FirstOrDefault();
            labelControl21.Text = (from x in db.ALB_URUNLER
                                   orderby x.Stok_Miktari ascending
                                   select x.Urun_Adi).FirstOrDefault();
            labelControl7.Text = "10";
            labelControl9.Text = db.ALB_SIPARISLER.Count().ToString();  
            labelControl23.Text = db.ALB_URUNLER.Max(a => a.Satis_Fiyati).ToString();

            //X ÜRÜNÜN STOK SAYISI 
            // labelControl21.Text = db.ALB_URUNLER.Count(x => x.KategoriID == 4).ToString();

            //Toplam marka sayısı çekme tedarikçi sayısı çekme 
            //labelControl33.Text = (from x in db.ALB_URUNLER
            //                       select x.Tedarikci_ID).Distinct().Count().ToString();
        }

        private void labelControl29_Click(object sender, EventArgs e)
        {

        }
    }
}
