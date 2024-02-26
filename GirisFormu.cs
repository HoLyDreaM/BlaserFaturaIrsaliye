using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Blaser_ÖTV_Fatura_Irsaliye
{
    public partial class GirisFormu : DevExpress.XtraEditors.XtraForm
    {
        public GirisFormu()
        {
            InitializeComponent();
        }
        Ayarlar.LookUpServers lookUpServers;
        Ayarlar.LookUpSirketler lookUpSirketler;
        Ayarlar.lookUpKullanicilar lookupKullanicilar;
        Anaform frmAnaForm;
       
        iniOku.iniOku iniOku = new iniOku.iniOku(Application.StartupPath + "\\LoginSettings.ini");

        string aSirket;

        private void GirisFormu_Load(object sender, EventArgs e)
        {
            try
            {
                txtServer.Text = iniOku.IniOku("Ayar", "Server");
                txtSirket.Text = iniOku.IniOku("Ayar", "Sirket");
                aSirket = iniOku.IniOku("Ayar", "aSirket");     
            }
            catch
            {
                lblDurum.Text = "Hata : Bağlantı sağlanamadı...";
            }
        }

        private void btnBaglan_Click(object sender, EventArgs e)
        {
            try
            {
                conCs.Close();
                conCs.ConnectionString = "Data Source=" + txtServer.Text + ";Persist Security Info=True;Initial Catalog=YNS" + txtSirket.Text + ";User ID=YNS" + txtSirket.Text + ";Password=PSW" + txtSirket.Text;
                Properties.Settings.Default["Cs"] = conCs.ConnectionString.ToString();
                conCs.Open();

                #region Şirket Seçimi İptal Edildi 
                //conMaster.Close();
                //conMaster.ConnectionString = "Data Source=" + txtServer.Text + ";Initial Catalog=YN" + aSirket + ";Integrated Security=True";
                //Properties.Settings.Default["CsMaster"] = conCs.ConnectionString.ToString();
                //conMaster.Open();
                #endregion

                conBlaser.Close();
                conBlaser.ConnectionString = "Data Source=" + txtServer.Text + ";Initial Catalog=Blaser;Persist Security Info=True;User ID=sa;Password=1";
                Properties.Settings.Default["CsBlaser"] = conBlaser.ConnectionString.ToString();
                conBlaser.Open();

                this.tblKullanicilarTableAdapter1.kullaniciKontrol(dataSet11.tblKullanicilar,txtKullanici.Text,txtSifre.Text);
                if (dataSet11.tblKullanicilar.Rows.Count>0)
                {
                    iniOku.IniYaz("Ayar", "Server", txtServer.Text);
                    iniOku.IniYaz("Ayar", "Sirket", txtSirket.Text);
 
                    frmAnaForm = new Anaform();
                    Program.ac.MainForm = frmAnaForm;
                    frmAnaForm.ID = dataSet11.tblKullanicilar.Rows[0]["ID"].ToString();
                    frmAnaForm.lblSirket.Text = "Şirket : " + txtSirket.Text;
                    frmAnaForm.lblKullanici.Text = "Kullanıcı : " + txtKullanici.Text;
                    frmAnaForm.IGuncelleme = (Boolean)dataSet11.tblKullanicilar.Rows[0]["Guncelleme"];
                    frmAnaForm.Versiyon = iniOku.IniOku("Ayar", "version");
                    frmAnaForm.Show();
                    this.Close();
                }
                else
                {
                    lblDurum.Text = "Hatalı Kullanıcı Girişi!";
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txtKullanici_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                conBlaser.Close();
                conBlaser.ConnectionString = "Data Source=" + txtServer.Text + ";Initial Catalog=Blaser;Persist Security Info=True;User ID=sa;Password=1";
                Properties.Settings.Default["CsBlaser"] = conBlaser.ConnectionString.ToString();

                if (conBlaser.State == ConnectionState.Closed)
                    conBlaser.Open();

                Ayarlar.lookUpKullanicilar lookupKullanicilar = new Ayarlar.lookUpKullanicilar();
                lookupKullanicilar.frmGiris = this;
                lookupKullanicilar.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanici Properties Hata Verdi");
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txtServer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtSirket.Focus();
        }

        private void txtSirket_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtKullanici.Focus();
        }

        private void txtKullanici_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtSifre.Focus();
        }

        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBaglan.Focus();
        }


    }
}