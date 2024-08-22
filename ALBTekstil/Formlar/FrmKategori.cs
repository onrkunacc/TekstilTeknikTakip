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
    }
}
