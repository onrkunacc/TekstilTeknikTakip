using DevExpress.XtraEditors;
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
    public partial class FrmCariListesi : Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }

        private void labelControl9_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        DB_ALBER_TEKSTİLEntities db = new DB_ALBER_TEKSTİLEntities();
        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.ALB_MUSTERILER.ToList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtId.Text = gridView1.GetFocusedRowCellValue("Musteri_ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("Musteri_Adi").ToString();
            TxtSoyad.Text = gridView1.GetFocusedRowCellValue("Musteri_Soyad").ToString();
            TxtSirket.Text = gridView1.GetFocusedRowCellValue("Musteri_Sirket").ToString();
            TxtTelNo.Text = gridView1.GetFocusedRowCellValue("Musteri_Tel_No").ToString();
            TxtMail.Text = gridView1.GetFocusedRowCellValue("Musteri_Mail").ToString();
            TxtAdres.Text = gridView1.GetFocusedRowCellValue("Musteri_Adres").ToString();
            TxtIl.Text = gridView1.GetFocusedRowCellValue("Musteri_Il").ToString();
            TxtIlce.Text = gridView1.GetFocusedRowCellValue("Musteri_Ilce").ToString();


        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            ALB_MUSTERILER m = new ALB_MUSTERILER();
            m.Musteri_Adi = TxtAd.Text;
            m.Musteri_Soyad = TxtSoyad.Text;
            m.Musteri_Sirket = TxtSirket.Text;
            m.Musteri_Tel_No = TxtTelNo.Text;
            m.Musteri_Mail = TxtMail.Text;
            m.Musteri_Adres = TxtAdres.Text;    
            m.Musteri_Il = TxtIl.Text;  
            m.Musteri_Ilce = TxtIlce.Text;

            db.ALB_MUSTERILER.Add(m);
            db.SaveChanges();
            MessageBox.Show("Yeni cari girişi yapıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var deger = from m in db.ALB_MUSTERILER
                        select new
                        {
                           m.Musteri_ID,
                           m.Musteri_Adi,
                           m.Musteri_Soyad,
                           m.Musteri_Sirket,
                           m.Musteri_Tel_No,
                           m.Musteri_Mail,
                           m.Musteri_Adres,
                           m.Musteri_Il,
                           m.Musteri_Ilce
                        };
            gridControl1.DataSource = deger.ToList();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.ALB_MUSTERILER.Find(id);
            db.ALB_MUSTERILER.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Cari başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.ALB_MUSTERILER.Find(id);
            deger.Musteri_Adi = TxtAd.Text;
            deger.Musteri_Soyad = TxtSoyad.Text;
            deger.Musteri_Sirket = TxtSirket.Text;
            deger.Musteri_Tel_No = TxtTelNo.Text;
            deger.Musteri_Mail =TxtMail.Text;
            deger.Musteri_Adres = TxtAdres.Text;
            deger.Musteri_Il = TxtIl.Text;
            deger.Musteri_Ilce = TxtIlce.Text;
            db.SaveChanges();
            MessageBox.Show("Cari bilgileri başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
