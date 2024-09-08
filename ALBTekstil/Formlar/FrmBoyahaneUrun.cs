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
    public partial class FrmBoyahaneUrun : Form
    {
        public FrmBoyahaneUrun()
        {
            InitializeComponent();
        }

        private void textEdit9_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureEdit9_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            DB_ALBER_TEKSTİLEntities db = new DB_ALBER_TEKSTİLEntities();
            ALB_BOYAHANETAKIP takip = new ALB_BOYAHANETAKIP();
            takip.Urun_ID = int.Parse(TxtUrunAd.Text);
            takip.Urun_Barkod = TxtBarkod.Text;
            takip.Gonderilen_Miktar = int.Parse(TxtGonderilenMiktar.Text);
            takip.Gelen_Miktar = int.Parse(TxtGelenMiktar.Text);
            takip.Gonderim_Tarih = Convert.ToDateTime(TxtGonderimTarihi.Text);
            takip.Gelis_Tarih = Convert.ToDateTime(TxtGelisTarihi.Text);
            takip.Durum = TxtDurum.Text;

            db.ALB_BOYAHANETAKIP.Add(takip);
            db.SaveChanges();
            MessageBox.Show("Boyahaneye başarıyla gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void FrmBoyahaneUrun_Load(object sender, EventArgs e)
        {

        }
    }
}
