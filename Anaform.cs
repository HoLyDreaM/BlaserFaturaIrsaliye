using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;

namespace Blaser_ÖTV_Fatura_Irsaliye
{
    public partial class Anaform : DevExpress.XtraEditors.XtraForm
    {
        public Anaform()
        {
            InitializeComponent();
        }

        public string ID { get; set; }

        iniOku.iniOku iniOku = new iniOku.iniOku(Application.StartupPath + "\\LoginSettings.ini");
        iniOku.iniOku uzakIni;

        private Thread tRemoteVersiyonCek;
        private Thread tRemoteClietVersiyon;

        Boolean _IGuncelleme;
        public Boolean IGuncelleme
        {
            get { return _IGuncelleme; }
            set
            {
                _IGuncelleme = value;
            }
        }

        #region "Form Tanımları"

        Arkaplan frmArkaPlan;
        OtvliSatisFaturasi frmOtvliSatisFaturasi;
        Ayarlar.frmKullanicilar frmKullanicilar;
        Ayarlar.frmEvrakNumaralari frmEvrakNumaralari;
        OtvliSatisIrsaliyesi frmOtvliSatisIrsaliyesi;
        Ayarlar.frmGuncelleme frmGuncelleme;
        OtvliAlimIrsaliyesi frmOtvliAlimIrsaliyesi;
        OtvliSatistanIadeFaturasi frmOtvliSatistaniadeFatura;
        Ayarlar.frmEvrakTasarimi frmEvrakTasarimi;
        FiyatListesi.FiyatListelerimiz frmFiyatListesi;
        FiyatListesi.IskontoListemiz frmIskontoListesi;

        public void frmEvrakTasarimiAc()
        {
            if (frmEvrakTasarimi == null || frmEvrakTasarimi.IsDisposed)
            {
                frmEvrakTasarimi = new Ayarlar.frmEvrakTasarimi();
                frmEvrakTasarimi.MdiParent = this;
                frmEvrakTasarimi.Show();
            }
            else
                frmEvrakTasarimi.Activate();
        }

        public void frmArkaPlanAc()
        {
            if (frmArkaPlan == null || frmArkaPlan.IsDisposed)
            {
                frmArkaPlan = new Arkaplan();
                frmArkaPlan.MdiParent = this;
                frmArkaPlan.Show();
            }
            else
                frmOtvliSatisFaturasi.Activate();
        }

        public void frmOtvliSatisFaturasiAc()
        {
            if (frmOtvliSatisFaturasi == null || frmOtvliSatisFaturasi.IsDisposed)
            {
                frmOtvliSatisFaturasi = new OtvliSatisFaturasi();
                frmOtvliSatisFaturasi.ID = ID;
                frmOtvliSatisFaturasi.MdiParent = this;
                frmOtvliSatisFaturasi.Show();
            }
            else
                frmOtvliSatisFaturasi.Activate();

        }

        public void frmKullanicilarAc()
        {
            if (frmKullanicilar == null || frmKullanicilar.IsDisposed)
            {
                frmKullanicilar = new Ayarlar.frmKullanicilar();
                frmKullanicilar.MdiParent = this;
                frmKullanicilar.Show();
            }
            else
                frmKullanicilar.Activate();
        }

        public void frmEvrakNumaralariAc()
        {
            if (frmEvrakNumaralari == null || frmEvrakNumaralari.IsDisposed)
            {
                frmEvrakNumaralari = new Ayarlar.frmEvrakNumaralari();
                frmEvrakNumaralari.MdiParent = this;
                frmEvrakNumaralari.Show();
            }
            else
                frmEvrakNumaralari.Activate();
        }

        public void frmFiyatListesiAc()
        {
            if (frmFiyatListesi == null || frmFiyatListesi.IsDisposed)
            {
                frmFiyatListesi = new FiyatListesi.FiyatListelerimiz();
                frmFiyatListesi.ID = ID;
                frmFiyatListesi.MdiParent = this;
                frmFiyatListesi.Show();
            }
            else
            {
                frmFiyatListesi.Activate();
            }
        }

        public void frmIskontoListesiAc()
        {
            if (frmIskontoListesi == null || frmIskontoListesi.IsDisposed)
            {
                frmIskontoListesi = new FiyatListesi.IskontoListemiz();
                frmIskontoListesi.ID = ID;
                frmIskontoListesi.MdiParent = this;
                frmIskontoListesi.Show();
            }
            else
            {
                frmIskontoListesi.Activate();
            }
        }

        public void frmOtvliSatisIrsaliyesiAc()
        {
            if (frmOtvliSatisIrsaliyesi == null || frmOtvliSatisIrsaliyesi.IsDisposed)
            {
                frmOtvliSatisIrsaliyesi = new OtvliSatisIrsaliyesi();
                frmOtvliSatisIrsaliyesi.ID = ID;
                frmOtvliSatisIrsaliyesi.MdiParent = this;
                frmOtvliSatisIrsaliyesi.Show();
            }
            else
            {
                frmOtvliSatisIrsaliyesi.Activate();
            }
        }

        private void frmGuncelleAC()
        {
            if (frmGuncelleme == null || frmGuncelleme.IsDisposed)
            {
                frmGuncelleme = new Ayarlar.frmGuncelleme();
                frmGuncelleme.Owner = this;
                frmGuncelleme.MdiParent = this;
                //frmGuncelleme.anafrm = this;
                frmGuncelleme.Show();
            }
            else
            {
                frmGuncelleme.Activate();
            }
        }

        public void frmOtvliAlimIrsaliyesiAc()
        {
            if (frmOtvliAlimIrsaliyesi == null || frmOtvliAlimIrsaliyesi.IsDisposed)
            {
                frmOtvliAlimIrsaliyesi = new OtvliAlimIrsaliyesi();
                frmOtvliAlimIrsaliyesi.ID = ID;
                frmOtvliAlimIrsaliyesi.MdiParent = this;
                frmOtvliAlimIrsaliyesi.Show();
            }
            else
            {
                frmOtvliAlimIrsaliyesi.Activate();
            }
        }

        public void frmOtvliSatistanIadeFaturaAc()
        {
            if (frmOtvliSatistaniadeFatura == null || frmOtvliSatistaniadeFatura.IsDisposed)
            {
                frmOtvliSatistaniadeFatura = new OtvliSatistanIadeFaturasi();
                frmOtvliSatistaniadeFatura.ID = ID;
                frmOtvliSatistaniadeFatura.MdiParent = this;
                frmOtvliSatistaniadeFatura.Show();
            }
            else
            {
                frmOtvliSatistaniadeFatura.Activate();
            }
        }

        #endregion

        #region Versiyon İşlemleri Classı

        private string _versiyon;
        public string Versiyon
        {
            get { return _versiyon; }
            set { _versiyon = value; }
        }

        private string _gelenVersion;
        public string GelenVersion
        {
            get { return _gelenVersion; }
            set { _gelenVersion = value; }
        }

        private string _aciklama;
        public string Aciklama
        {
            get { return _aciklama; }
            set { _aciklama = value; }
        }

        private string _dosyalar;
        public string Dosyalar
        {
            get { return _dosyalar; }
            set { _dosyalar = value; }
        }

        #endregion

        #region Form Load İşlemleri

        private void Anaform_Load(object sender, EventArgs e)
        {
            frmArkaPlanAc();

            if (_IGuncelleme)
            {
                try
                {
                    if (iniOku.IniOku("Ayar", "GuncellemeTuru") == "0")
                    {
                        ps_threadremoteVersiyonCek();
                    }
                    else
                    {
                        ps_clientVersiyonCek();// ps_threadtUzakVersiyon();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        #endregion

        #region Timer Tick

        private void timerSaat_Tick(object sender, EventArgs e)
        {
            lblSaat.Text = DateTime.Now.ToString();
        }

        #endregion

        #region Ötvli Fatura Formu

        private void btnOtvliSatisFaturasi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmOtvliSatisFaturasiAc();
        }

        #endregion

        #region Ötvli Irsaliye Formu

        private void btnOtvliSatisIrsaliyesi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmOtvliSatisIrsaliyesiAc();
        }

        #endregion

        #region Kullanıcılar ve Evrak Numaraları

        private void btnKullanicilar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmKullanicilarAc();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmEvrakNumaralariAc();
        }

        #endregion

        #region Güncelleme Kontrolü

        delegate void dlg_alert(string mesaj);
        private void ps_alert(string mesaj)
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new dlg_alert(ps_alert), mesaj);
            }
            else
            {
                DevExpress.XtraBars.Alerter.AlertInfo ai = new DevExpress.XtraBars.Alerter.AlertInfo("Yeni Güncelleme!", mesaj);
                alertControl1.Show(this, ai);

            }
        }

        DataSet ds;
        private void ps_remoteVersiyonCek()
        {
            try
            {
                ds = new DataSet("guncelleme");
                ds.ReadXml("http://editorgroup.net/Programlar/Blaser/FaturaIrsaliye/version.xml");

                GelenVersion = ds.Tables[0].Rows[0]["Versiyon"].ToString();
                Aciklama = ds.Tables[0].Rows[0]["Aciklama"].ToString();
                Dosyalar = ds.Tables[0].Rows[0]["Dosya"].ToString();

                if (Versiyon != GelenVersion)
                {
                    ps_alert(Aciklama);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme kontrolü hatası:" + ex.Message.ToString());
            }
        }
       
        private void ps_threadremoteVersiyonCek()
        {
            tRemoteVersiyonCek = new Thread(new ThreadStart(ps_remoteVersiyonCek));
            tRemoteVersiyonCek.Start();
        }

        private void ps_clientVersiyonCek()
        {
            try
            {
                uzakIni = new global::iniOku.iniOku(iniOku.IniOku("Ayar", "InıYolu") + @"\Ayar.ini");

                GelenVersion = uzakIni.IniOku("Ayar", "version");
                Aciklama = GelenVersion.ToString() + " Versiyonu Bulundu!";
                Dosyalar = "BlaserOtvliFaturaIrsaliye.exe";


                if (Versiyon != GelenVersion && !string.IsNullOrEmpty(GelenVersion))
                {
                    ps_alert(Aciklama);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme kontrolü hatası:" + ex.Message.ToString());
            }
        }
        
        private void ps_threadtUzakVersiyon()
        {
            tRemoteClietVersiyon = new Thread(new ThreadStart(ps_threadtUzakVersiyon));
            tRemoteClietVersiyon.Start();
        }

        #endregion

        #region Güncelleme Butonu

        private void btnGuncelle_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmGuncelleAC();
        }

        #endregion

        #region Alım Irsaliyesini Açıyoruz

        private void btnotvliAlimIrsaliyesi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmOtvliAlimIrsaliyesiAc();
        }

        #endregion

        private void btnOtvliSatistaniadeFatura_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmOtvliSatistanIadeFaturaAc();
        }

        private void btnEvrakTasarimi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmEvrakTasarimiAc();
        }

        private void btnEvrakNumaralari_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmEvrakNumaralariAc();
        }

        private void btnFiyatListesi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmFiyatListesiAc();
        }

        private void btniskontoListesi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmIskontoListesiAc();
        }

    }
}