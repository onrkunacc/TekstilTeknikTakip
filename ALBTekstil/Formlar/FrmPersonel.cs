﻿using System;
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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        DB_ALBER_TEKSTİLEntities db = new DB_ALBER_TEKSTİLEntities();
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            var degerler = from u in db.ALB_PERSONEL
                           select new
                           {
                               u.Personel_ID,
                               u.Personel_Adi,
                               u.Personel_Soyadi,
                               u.Personel_TC,
                               u.Personel_Tel_No,
                               u.Personel_Mail,
                               u.Personel_Pozisyon,
                               u.ALB_DEPARTMAN.Departman_Adi
                           };
            gridControl1.DataSource = degerler.ToList();

            lookUpEdit1.Properties.DataSource = (from x in db.ALB_DEPARTMAN
                                                select new
                                                {
                                                    x.Departman_ID,
                                                    x.Departman_Adi
                                                }).ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            ALB_PERSONEL p = new ALB_PERSONEL();
            p.Personel_Adi = TxtAd.Text;
            p.Personel_Soyadi = TxtSoyad.Text;
            p.Personel_TC = TxtTC.Text;
            p.Personel_Tel_No = TxtTelNo.Text;
            p.Personel_Mail = TxtMail.Text;
            p.Personel_Pozisyon = TxtPozisyon.Text;
            p.Departman_ID = int.Parse(lookUpEdit1.EditValue.ToString());
            db.ALB_PERSONEL.Add(p);
            db.SaveChanges();   

            MessageBox.Show("Personel Başarıyla Eklendi.","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.ALB_PERSONEL.Find(id);
            db.ALB_PERSONEL.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Personel Başarıyla Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
