using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Blaser_ÖTV_Fatura_Irsaliye.Ayarlar
{
    public partial class LookUpStokveCariHareketiSatisdaniadeFatura : DevExpress.XtraEditors.XtraForm
    {
        public LookUpStokveCariHareketiSatisdaniadeFatura()
        {
            InitializeComponent();
        }

        public OtvliSatistanIadeFaturasi frmOtvliSatisFaturasi { get; set; }
        public string hangiKod;

        private void ps_parametreSecimi()
        {
            if (!string.IsNullOrEmpty(referansKoduTextBox.Text))
                switch (hangiKod)
                {
                    case "stokKod1":
                        frmOtvliSatisFaturasi.txtKod1.Text = referansKoduTextBox.Text;
                        this.Close();
                        break;

                    case "stokKod2":
                        frmOtvliSatisFaturasi.txtKod2.Text = referansKoduTextBox.Text;
                        this.Close();
                        break;

                    case "stokKod3":
                        frmOtvliSatisFaturasi.txtKod3.Text = referansKoduTextBox.Text;
                        this.Close();
                        break;

                    case "stokKod4":
                        frmOtvliSatisFaturasi.txtKod4.Text = referansKoduTextBox.Text;
                        this.Close();
                        break;

                    case "stokKod5":
                        frmOtvliSatisFaturasi.txtKod5.Text = referansKoduTextBox.Text;
                        this.Close();
                        break;

                    case "Depo":
                        frmOtvliSatisFaturasi.txtDepo.Text = referansKoduTextBox.Text;
                        this.Close();
                        break;

                    case "Vasita":
                        frmOtvliSatisFaturasi.txtVasita.Text = referansKoduTextBox.Text;
                        this.Close();
                        break;

                    //##################################################################
                    case "cariKod1":
                        frmOtvliSatisFaturasi.txtCariKod1.Text = referansKoduTextBox.Text;
                        this.Close();
                        break;

                    case "cariKod2":
                        frmOtvliSatisFaturasi.txtCariKod2.Text = referansKoduTextBox.Text;
                        this.Close();
                        break;

                    case "cariKod3":
                        frmOtvliSatisFaturasi.txtCariKod3.Text = referansKoduTextBox.Text;
                        this.Close();
                        break;

                    case "cariKod4":
                        frmOtvliSatisFaturasi.txtCariKod4.Text = referansKoduTextBox.Text;
                        this.Close();
                        break;

                    case "cariKod5":
                        frmOtvliSatisFaturasi.txtCariKod5.Text = referansKoduTextBox.Text;
                        this.Close();
                        break;

                    case "cariKod6":
                        frmOtvliSatisFaturasi.txtCariKod6.Text = referansKoduTextBox.Text;
                        this.Close();
                        break;

                    case "cariKod7":
                        frmOtvliSatisFaturasi.txtCariKod7.Text = referansKoduTextBox.Text;
                        this.Close();
                        break;
                }
            else
                this.Close();
        }

        private void LookUpStokveCariHareketiSatisdaniadeFatura_Load(object sender, EventArgs e)
        {
            try
            {
                switch (hangiKod)
                {
                    case "stokKod1":
                        this.tblStokVeCariHareketKodlariTableAdapter.stokHareketKoduGetir(dataSet1.tblStokVeCariHareketKodlari, 62);
                        break;

                    case "stokKod2":
                        this.tblStokVeCariHareketKodlariTableAdapter.stokHareketKoduGetir(dataSet1.tblStokVeCariHareketKodlari, 63);
                        break;

                    case "stokKod3":
                        this.tblStokVeCariHareketKodlariTableAdapter.stokHareketKoduGetir(dataSet1.tblStokVeCariHareketKodlari, 64);
                        break;

                    case "stokKod4":
                        this.tblStokVeCariHareketKodlariTableAdapter.stokHareketKoduGetir(dataSet1.tblStokVeCariHareketKodlari, 65);
                        break;

                    case "stokKod5":
                        this.tblStokVeCariHareketKodlariTableAdapter.stokHareketKoduGetir(dataSet1.tblStokVeCariHareketKodlari, 66);
                        break;

                    case "Depo":
                        this.tblStokVeCariHareketKodlariTableAdapter.stokHareketKoduGetir(dataSet1.tblStokVeCariHareketKodlari, 96);
                        break;

                    case "vasita":
                        this.tblStokVeCariHareketKodlariTableAdapter.stokHareketKoduGetir(dataSet1.tblStokVeCariHareketKodlari, 74);
                        break;
                    //#############################################################################################################
                    case "cariKod1":
                        this.tblStokVeCariHareketKodlariTableAdapter.cariHareketKodGetir(dataSet1.tblStokVeCariHareketKodlari, 60);
                        break;

                    case "cariKod2":
                        this.tblStokVeCariHareketKodlariTableAdapter.cariHareketKodGetir(dataSet1.tblStokVeCariHareketKodlari, 61);
                        break;

                    case "cariKod3":
                        this.tblStokVeCariHareketKodlariTableAdapter.cariHareketKodGetir(dataSet1.tblStokVeCariHareketKodlari, 62);
                        break;

                    case "cariKod4":
                        this.tblStokVeCariHareketKodlariTableAdapter.cariHareketKodGetir(dataSet1.tblStokVeCariHareketKodlari, 63);
                        break;

                    case "cariKod5":
                        this.tblStokVeCariHareketKodlariTableAdapter.cariHareketKodGetir(dataSet1.tblStokVeCariHareketKodlari, 64);
                        break;

                    case "cariKod6":
                        this.tblStokVeCariHareketKodlariTableAdapter.cariHareketKodGetir(dataSet1.tblStokVeCariHareketKodlari, 65);
                        break;

                    case "cariKod7":
                        this.tblStokVeCariHareketKodlariTableAdapter.cariHareketKodGetir(dataSet1.tblStokVeCariHareketKodlari, 66);
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            ps_parametreSecimi();
        }

        private void LookUpStokveCariHareketiSatisdaniadeFatura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ps_parametreSecimi();
            }

            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                switch (hangiKod)
                {
                    case "stokKod1":
                        this.evrakNoSeriTableAdapter1.ReferansEkle(62, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.stokHareketKoduGetir(dataSet1.tblStokVeCariHareketKodlari, 62);
                        break;

                    case "stokKod2":
                        this.evrakNoSeriTableAdapter1.ReferansEkle(63, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.stokHareketKoduGetir(dataSet1.tblStokVeCariHareketKodlari, 63);
                        break;

                    case "stokKod3":
                        this.evrakNoSeriTableAdapter1.ReferansEkle(64, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.stokHareketKoduGetir(dataSet1.tblStokVeCariHareketKodlari, 64);
                        break;

                    case "stokKod4":
                        this.evrakNoSeriTableAdapter1.ReferansEkle(65, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.stokHareketKoduGetir(dataSet1.tblStokVeCariHareketKodlari, 65);
                        break;

                    case "stokKod5":
                        this.evrakNoSeriTableAdapter1.ReferansEkle(66, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.stokHareketKoduGetir(dataSet1.tblStokVeCariHareketKodlari, 66);
                        break;

                    case "Depo":
                        this.evrakNoSeriTableAdapter1.ReferansEkle(96, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.stokHareketKoduGetir(dataSet1.tblStokVeCariHareketKodlari, 96);
                        break;

                    case "vasita":
                        this.evrakNoSeriTableAdapter1.ReferansEkle(74, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.stokHareketKoduGetir(dataSet1.tblStokVeCariHareketKodlari, 74);
                        break;
                    //#############################################################################################################
                    case "cariKod1":
                        this.evrakNoSeriTableAdapter1.CarReferansEkle(60, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.cariHareketKodGetir(dataSet1.tblStokVeCariHareketKodlari, 60);
                        break;

                    case "cariKod2":
                        this.evrakNoSeriTableAdapter1.CarReferansEkle(61, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.cariHareketKodGetir(dataSet1.tblStokVeCariHareketKodlari, 61);
                        break;

                    case "cariKod3":
                        this.evrakNoSeriTableAdapter1.CarReferansEkle(62, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.cariHareketKodGetir(dataSet1.tblStokVeCariHareketKodlari, 62);
                        break;

                    case "cariKod4":
                        this.evrakNoSeriTableAdapter1.CarReferansEkle(63, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.cariHareketKodGetir(dataSet1.tblStokVeCariHareketKodlari, 63);
                        break;

                    case "cariKod5":
                        this.evrakNoSeriTableAdapter1.CarReferansEkle(64, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.cariHareketKodGetir(dataSet1.tblStokVeCariHareketKodlari, 64);
                        break;

                    case "cariKod6":
                        this.evrakNoSeriTableAdapter1.CarReferansEkle(65, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.cariHareketKodGetir(dataSet1.tblStokVeCariHareketKodlari, 65);
                        break;

                    case "cariKod7":
                        this.evrakNoSeriTableAdapter1.CarReferansEkle(66, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.cariHareketKodGetir(dataSet1.tblStokVeCariHareketKodlari, 66);
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                switch (hangiKod)
                {
                    case "stokKod1":
                        this.evrakNoSeriTableAdapter1.ReferansSil(62, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.stokHareketKoduGetir(dataSet1.tblStokVeCariHareketKodlari, 62);
                        break;

                    case "stokKod2":
                        this.evrakNoSeriTableAdapter1.ReferansSil(63, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.stokHareketKoduGetir(dataSet1.tblStokVeCariHareketKodlari, 63);
                        break;

                    case "stokKod3":
                        this.evrakNoSeriTableAdapter1.ReferansSil(64, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.stokHareketKoduGetir(dataSet1.tblStokVeCariHareketKodlari, 64);
                        break;

                    case "stokKod4":
                        this.evrakNoSeriTableAdapter1.ReferansSil(65, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.stokHareketKoduGetir(dataSet1.tblStokVeCariHareketKodlari, 65);
                        break;

                    case "stokKod5":
                        this.evrakNoSeriTableAdapter1.ReferansSil(66, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.stokHareketKoduGetir(dataSet1.tblStokVeCariHareketKodlari, 66);
                        break;

                    case "Depo":
                        this.evrakNoSeriTableAdapter1.ReferansSil(96, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.stokHareketKoduGetir(dataSet1.tblStokVeCariHareketKodlari, 96);
                        break;

                    case "vasita":
                        this.evrakNoSeriTableAdapter1.ReferansSil(74, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.stokHareketKoduGetir(dataSet1.tblStokVeCariHareketKodlari, 74);
                        break;
                    //#############################################################################################################
                    case "cariKod1":
                        this.evrakNoSeriTableAdapter1.CarReferansSil(60, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.cariHareketKodGetir(dataSet1.tblStokVeCariHareketKodlari, 60);
                        break;

                    case "cariKod2":
                        this.evrakNoSeriTableAdapter1.CarReferansSil(61, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.cariHareketKodGetir(dataSet1.tblStokVeCariHareketKodlari, 61);
                        break;

                    case "cariKod3":
                        this.evrakNoSeriTableAdapter1.CarReferansSil(62, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.cariHareketKodGetir(dataSet1.tblStokVeCariHareketKodlari, 62);
                        break;

                    case "cariKod4":
                        this.evrakNoSeriTableAdapter1.CarReferansSil(63, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.cariHareketKodGetir(dataSet1.tblStokVeCariHareketKodlari, 63);
                        break;

                    case "cariKod5":
                        this.evrakNoSeriTableAdapter1.CarReferansSil(64, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.cariHareketKodGetir(dataSet1.tblStokVeCariHareketKodlari, 64);
                        break;

                    case "cariKod6":
                        this.evrakNoSeriTableAdapter1.CarReferansSil(65, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.cariHareketKodGetir(dataSet1.tblStokVeCariHareketKodlari, 65);
                        break;

                    case "cariKod7":
                        this.evrakNoSeriTableAdapter1.CarReferansSil(66, txtKod.Text, txtAciklama.Text);
                        this.tblStokVeCariHareketKodlariTableAdapter.cariHareketKodGetir(dataSet1.tblStokVeCariHareketKodlari, 66);
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}