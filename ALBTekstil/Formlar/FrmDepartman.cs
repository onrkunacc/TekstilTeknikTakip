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
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }
        DB_ALBER_TEKSTİLEntities db = new DB_ALBER_TEKSTİLEntities();
        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            var degerler = from departman in db.ALB_DEPARTMAN
                           select new
                           {
                               departman.Departman_ID,
                               departman.Departman_Adi,
                               departman.Aciklama
                           };
            gridControl1.DataSource = degerler.ToList();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            ALB_DEPARTMAN t = new ALB_DEPARTMAN();
            if (TxtAd.Text.Length <= 50 && TxtAd.Text != "" )
            {
                t.Departman_Adi = TxtAd.Text;
                t.Aciklama = TxtAciklama.Text;
                db.ALB_DEPARTMAN.Add(t);
                db.SaveChanges();
                MessageBox.Show("Departman Kaydedildi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Kayıt Edilemedi !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.ALB_DEPARTMAN.Find(id);
            db.ALB_DEPARTMAN.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Departman Başarıyla Silindi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.ALB_DEPARTMAN.Find(id);
            deger.Departman_Adi = TxtAd.Text;
            deger.Aciklama = TxtAciklama.Text;
            db.SaveChanges();
            MessageBox.Show("Departman Başarıyla Güncellendi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from u in db.ALB_DEPARTMAN
                           select new
                           {
                               u.Departman_ID,
                               u.Departman_Adi,
                               u.Aciklama

                           };
            gridControl1.DataSource = degerler.ToList();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtId.Text = gridView1.GetFocusedRowCellValue("Departman_ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("Departman_Adi").ToString();
            TxtAciklama.Text = gridView1.GetFocusedRowCellValue("Aciklama").ToString();
        }
    }
}
