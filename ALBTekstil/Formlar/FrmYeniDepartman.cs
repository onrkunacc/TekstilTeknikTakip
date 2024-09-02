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
    public partial class FrmYeniDepartman : Form
    {
        public FrmYeniDepartman()
        {
            InitializeComponent();
        }

        private void textEdit9_EditValueChanged(object sender, EventArgs e)
        {

        }

        DB_ALBER_TEKSTİLEntities db = new DB_ALBER_TEKSTİLEntities();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            ALB_DEPARTMAN k = new ALB_DEPARTMAN();
            k.Departman_Adi = TxtAd.Text;
            k.Aciklama = TxtAciklama.Text;
            db.ALB_DEPARTMAN.Add(k);
            db.SaveChanges();
            MessageBox.Show("Departman başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {

        }
    }
}
