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
    public partial class FrmBoyahane : Form
    {
        public FrmBoyahane()
        {
            InitializeComponent();
        }

        DB_ALBER_TEKSTİLEntities db = new DB_ALBER_TEKSTİLEntities();
        private void FrmBoyahane_Load(object sender, EventArgs e)
        {
            var degerler = from u in db.ALB_BOYAHANETAKIP
                           select new
                           {
                               u.Boyahane_Takip_ID,
                               u.ALB_URUNLER.Urun_Adi,
                               u.Urun_Barkod,
                               u.Gonderilen_Miktar,
                               u.Gelen_Miktar,
                               u.Gonderim_Tarih,
                               u.Gelis_Tarih,
                               u.Durum
                           };
            gridControl1.DataSource = degerler.ToList();

        }

        private void labelControl9_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtId.Text = gridView1.GetFocusedRowCellValue("Boyahane_Takip_ID").ToString();
            //TxtUrun.Text = gridView1.GetFocusedRowCellValue("Urun_Adi").ToString();
            TxtBarkod.Text = gridView1.GetFocusedRowCellValue("Urun_Barkod").ToString();
            TxtGonderilenMiktar.Text = gridView1.GetFocusedRowCellValue("Gonderilen_Miktar").ToString();
            TxtGelenMiktar.Text = gridView1.GetFocusedRowCellValue("Gelen_Miktar").ToString();
            TxtGonderimTarihi.Text = gridView1.GetFocusedRowCellValue("Gonderim_Tarih").ToString();
            TxtGelisTarihi.Text = gridView1.GetFocusedRowCellValue("Gelis_Tarih").ToString();
            TxtDurum.Text = gridView1.GetFocusedRowCellValue("Durum").ToString();

        }
    }
}
