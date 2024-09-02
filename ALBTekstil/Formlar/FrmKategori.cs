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
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
        DB_ALBER_TEKSTİLEntities db = new DB_ALBER_TEKSTİLEntities();
        private void FrmKategori_Load(object sender, EventArgs e)
        {
            var deger = from k in db.ALB_KATEGORILER
                                       select new
                                       {
                                         k.Kategori_ID,
                                         k.KategoriAdi,
                                         k.Aciklama
                                       };
            gridControl1.DataSource = deger.ToList();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            ALB_KATEGORILER k = new ALB_KATEGORILER();
            k.KategoriAdi = TxtAd.Text;
            k.Aciklama = TxtAciklama.Text;
            db.ALB_KATEGORILER.Add(k);
            db.SaveChanges();
            MessageBox.Show("Yeni kategori başarıyla kaydedildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var deger = from k in db.ALB_KATEGORILER
                        select new
                        {
                            k.Kategori_ID,
                            k.KategoriAdi,
                            k.Aciklama
                        };
            gridControl1.DataSource = deger.ToList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtId.Text = gridView1.GetFocusedRowCellValue("Kategori_ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("KategoriAdi").ToString();
            TxtAciklama.Text = gridView1.GetFocusedRowCellValue("Aciklama").ToString();
            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.ALB_KATEGORILER.Find(id);
            db.ALB_KATEGORILER.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Kategori başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.ALB_KATEGORILER.Find(id);
            deger.KategoriAdi = TxtAd.Text;
            deger.Aciklama = TxtAciklama.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori bilgileri başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
