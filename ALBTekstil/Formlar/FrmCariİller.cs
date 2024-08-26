using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ALBTekstil.Formlar
{
    public partial class FrmCariİller : Form
    {
        public FrmCariİller()
        {
            InitializeComponent();
        }
        DB_ALBER_TEKSTİLEntities dB = new DB_ALBER_TEKSTİLEntities();
        SqlConnection connect = new SqlConnection(@"Data Source=localhost\SQL2017;Initial Catalog=DB_ALBER_TEKSTİL;Integrated Security=True;");

        private void FrmCariİller_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource =dB.ALB_MUSTERILER
                .OrderBy(x=> x.Musteri_Il)
                .GroupBy(y => y.Musteri_Il)
                .Select(z => new
                {
                    İL =z.Key,
                    TOPLAM = z.Count()
                }).ToList();

            connect.Open();
            SqlCommand cmd = new SqlCommand("select Musteri_Il,Count(*) from ALB_MUSTERILER group by Musteri_Il",connect);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]),int.Parse( dr[1].ToString()));

            }
            connect.Close();
        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
