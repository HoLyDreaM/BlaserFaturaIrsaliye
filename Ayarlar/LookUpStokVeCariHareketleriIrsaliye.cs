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
    public partial class LookUpStokVeCariHareketleriIrsaliye : DevExpress.XtraEditors.XtraForm
    {
        public LookUpStokVeCariHareketleriIrsaliye()
        {
            InitializeComponent();
        }

        public OtvliSatisIrsaliyesi frmOtvliSatisIrsaliye { get; set; }
        public string hangiKod;

        private void LookUpStokVeCariHareketleriIrsaliye_Load(object sender, EventArgs e)
        {
            try
            {
                //////////////////////////////////////////////////////
                //Stok Hareketleri için     ||   Cari Hareketler İçin
                //--Kod1 = 62               ||   Kod 1 = 60
                //--Kod2 = 63               ||   Kod 2 = 61
                //--Kod3 = 64               ||   Kod 3 = 62
                //--Kod4 = 65               ||   Kod 4 = 63
                //--Kod5 = 66               ||   Kod 5 = 64
                //--Depo = 96               ||   Kod 6 = 65
                //--Vasıta =74              ||   Kod 7 = 66
                /////////////////////////////////////////////////////
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

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ps_parametreSecimi()
        {
            if (!string.IsNullOrEmpty(referansKoduTextBox.Text))
                switch (hangiKod)
                {
                    case "stokKod1":
                        frmOtvliSatisIrsaliye.txtKod1.Text = referansKoduTextBox.Text;
                        this.Close();
                        break;

                    case "stokKod2":
                        frmOtvliSatisIrsaliye.txtKod2.Text = referansKoduTextBox.Text;
                        this.Close();
                        break;

                    case "stokKod3":
                        frmOtvliSatisIrsaliye.txtKod3.Text = referansKoduTextBox.Text;
                        this.Close();
                        break;

                    case "stokKod4":
                        frmOtvliSatisIrsaliye.txtKod4.Text = referansKoduTextBox.Text;
                        this.Close();
                        break;

                    case "stokKod5":
                        frmOtvliSatisIrsaliye.txtKod5.Text = referansKoduTextBox.Text;
                        this.Close();
                        break;

                    case "Depo":
                        frmOtvliSatisIrsaliye.txtDepo.Text = referansKoduTextBox.Text;
                        this.Close();
                        break;

                    case "Vasita":
                        frmOtvliSatisIrsaliye.txtVasita.Text = referansKoduTextBox.Text;
                        this.Close();
                        break;
                }
            else
                this.Close();
        }

        private void LookUpStokVeCariHareketleriIrsaliye_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ps_parametreSecimi();
            }

            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            ps_parametreSecimi();
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

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}