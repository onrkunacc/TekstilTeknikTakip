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
            labelControl27.Text = db.ALB_BOYAHANETAKIP.Sum( a => a.Gonderilen_Miktar ).ToString();
            labelControl25.Text = db.ALB_BOYAHANETAKIP.Sum(a => a.Gelen_Miktar).ToString();
        }
    }
}
