using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALBTekstil.Formlar
{
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        DB_ALBER_TEKSTİLEntities db = new DB_ALBER_TEKSTİLEntities();
        void Metot1()
        {
            var degerler = from urun in db.ALB_URUNLER
                           select new
                           {
                               urun.Urun_ID,
                               urun.Urun_Adi,
                               urun.Urun_Barkod,
                               urun.ALB_KATEGORILER.KategoriAdi,
                               urun.Alis_Fiyati,
                               urun.Satis_Fiyati,
                               urun.Olcu_Birimi,
                               urun.Stok_Durumu,
                               urun.Stok_Miktari
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            //Listeleme ToList Add Remove
            //var degerler = db.ALB_URUNLER.ToList();
            Metot1();           
            lookUpEdit1.Properties.DataSource = db.ALB_KATEGORILER.ToList();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl8_Click(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                ALB_URUNLER u = new ALB_URUNLER();
                u.Urun_Adi = TxtUrunAd.Text;
                u.Urun_Barkod = TxtBarkod.Text;
                u.Alis_Fiyati = decimal.Parse(TxtAlisFiyat.Text);
                u.Satis_Fiyati = decimal.Parse(TxtSatisFiyat.Text);
                u.Olcu_Birimi = TxtOlcuBirimi.Text;
                u.Stok_Durumu = TxtStokDurum.Text;
                u.Stok_Miktari = decimal.Parse(TxtStokMiktar.Text);
                u.Kategori_ID = int.Parse(lookUpEdit1.EditValue.ToString());
                db.ALB_URUNLER.Add(u);
                db.SaveChanges();
                MessageBox.Show("Ürün başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                MessageBox.Show("Kaydetme sırasında bir hata oluştu: " + ex.Message);
            }
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Metot1();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // URUNID alanını kontrol et
            var urunIdValue = gridView1.GetFocusedRowCellValue("Urun_ID");
            TxtId.Text = urunIdValue != null ? urunIdValue.ToString() : string.Empty;

            // AD alanını kontrol et
            var urunAdValue = gridView1.GetFocusedRowCellValue("Urun_Adi");
            TxtUrunAd.Text = urunAdValue != null ? urunAdValue.ToString() : string.Empty;

            // BARKOD alanını kontrol et
            var barkodValue = gridView1.GetFocusedRowCellValue("Urun_Barkod");
            TxtBarkod.Text = barkodValue != null ? barkodValue.ToString() : string.Empty;

            // ALISFIYAT alanını kontrol et
            var alisFiyatValue = gridView1.GetFocusedRowCellValue("Alis_Fiyati");
            TxtAlisFiyat.Text = alisFiyatValue != null ? alisFiyatValue.ToString() : string.Empty;

            // SATISFIYAT alanını kontrol et
            var satisFiyatValue = gridView1.GetFocusedRowCellValue("Satis_Fiyati");
            TxtSatisFiyat.Text = satisFiyatValue != null ? satisFiyatValue.ToString() : string.Empty;

            // OLCUBIRIMI alanını kontrol et
            var olcuBirimiValue = gridView1.GetFocusedRowCellValue("Olcu_Birimi");
            TxtOlcuBirimi.Text = olcuBirimiValue != null ? olcuBirimiValue.ToString() : string.Empty;

            // STOKDURUM alanını kontrol et
            var stokDurumValue = gridView1.GetFocusedRowCellValue("Stok_Durumu");
            TxtStokDurum.Text = stokDurumValue != null ? stokDurumValue.ToString() : string.Empty;

            // STOKMIKTAR alanını kontrol et
            var stokMiktarValue = gridView1.GetFocusedRowCellValue("Stok_Miktari");
            TxtStokMiktar.Text = stokMiktarValue != null ? stokMiktarValue.ToString() : string.Empty;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.ALB_URUNLER.Find(id);
            db.ALB_URUNLER.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla silindi!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Stop);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.ALB_URUNLER.Find(id);
            deger.Urun_Adi = TxtUrunAd.Text;
            deger.Urun_Barkod = TxtBarkod.Text;
            deger.Alis_Fiyati = decimal.Parse(TxtAlisFiyat.Text);
            deger.Satis_Fiyati = decimal.Parse(TxtSatisFiyat.Text);
            deger.Olcu_Birimi = TxtOlcuBirimi.Text;
            deger.Stok_Durumu = TxtStokDurum.Text;
            deger.Stok_Miktari = decimal.Parse(TxtStokMiktar.Text);
            deger.Kategori_ID = int.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ürün bilgileri başarıyla güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);



        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
