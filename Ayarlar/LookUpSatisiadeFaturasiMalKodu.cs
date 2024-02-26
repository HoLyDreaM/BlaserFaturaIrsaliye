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
    public partial class LookUpSatisiadeFaturasiMalKodu : DevExpress.XtraEditors.XtraForm
    {
        public LookUpSatisiadeFaturasiMalKodu()
        {
            InitializeComponent();
        }

        public string Birim;
        public int SatirNumarasi;
        public string DovizParaBirimimiz;
        public decimal dovizKurumuz;
        public int Durum, IskontoDurum, Tarih, ListNo, IskontoOranKontrol;
        public string ListeAdi, ListeNo, HesapKodu, MalKodu;
        decimal BirimFiyatimiz;
        decimal IskontoOrani;

        public OtvliSatistanIadeFaturasi frmOtvliSatisiadeFaturasi { get; set; }

        private void LookUpSatisiadeFaturasiMalKodu_Load(object sender, EventArgs e)
        {
            this.tblLookUpStokKartlariTableAdapter.lookUpStokKartlari(this.dataSet1.tblLookUpStokKartlari, Birim);
        }

        private void gridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                foreach (int item in this.gridView1.GetSelectedRows())
                {
                    DataRow dr = gridView1.GetDataRow(item);

                    if (string.IsNullOrEmpty(ListeAdi.ToString()))
                    {
                        ListeAdi = "";
                    }

                    ListNo = Convert.ToInt32(ListeNo);
                    MalKodu = dr[0].ToString();

                    Durum = (int)this.evrakNoSeriTableAdapter1.FiyatListesiDurumu(MalKodu, ListeAdi, ListNo, HesapKodu, Tarih);
                    IskontoDurum = (int)this.evrakNoSeriTableAdapter1.StokListeDurum(MalKodu, Tarih);

                    if (IskontoDurum > 0)
                    {
                        IskontoOrani = (decimal)this.evrakNoSeriTableAdapter1.IskontoListesiCarili(MalKodu, HesapKodu, Tarih);
                    }
                    else
                    {
                        IskontoOranKontrol = (int)this.evrakNoSeriTableAdapter1.IskontoOranKontrolCarisiz(MalKodu, Tarih);
                        if (IskontoOranKontrol > 0)
                        {
                            IskontoOrani = (decimal)this.evrakNoSeriTableAdapter1.IskontoListesiCarisiz(MalKodu, Tarih);
                        }
                        else
                        {
                            IskontoOrani = 0;
                        }
                    }

                    if (Durum > 0)
                    {
                        BirimFiyatimiz = (decimal)this.evrakNoSeriTableAdapter1.ListeBirimFiyatGetir(Birim, ListeNo, ListeAdi, dr[0].ToString(), HesapKodu, Tarih);
                    }
                    else
                    {
                        BirimFiyatimiz = (decimal)this.evrakNoSeriTableAdapter1.ListeBirimFiyati1(Birim, ListeNo, ListeAdi, dr[0].ToString(), Tarih);
                    }

                    frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK005_MalKodu", dr[0].ToString());
                    frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK004_Aciklama", dr[1].ToString());
                    frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK004_Birim1", dr["Birim 1"].ToString());
                    frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK004_Birim2", dr["Birim 2"].ToString());
                    frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK004_Birim3", dr["Birim 3"].ToString());
                    frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK004_KafileBuyuklugu", dr["Kafile Büyüklüğü"].ToString());
                    frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "OtvOranKilo", dr["OtvBirim"].ToString());
                    frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK005_DovizCinsi", DovizParaBirimimiz);
                    frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK005_DovizKuru", dovizKurumuz);
                    frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK005_KalemIskontoOrani1", IskontoOrani);
                }
                this.Close();
            }
        }

        private void grdMalKodlari_DoubleClick(object sender, EventArgs e)
        {
            foreach (int item in this.gridView1.GetSelectedRows())
            {
                DataRow dr = gridView1.GetDataRow(item);

                if (string.IsNullOrEmpty(ListeAdi.ToString()))
                {
                    ListeAdi = "";
                }

                ListNo = Convert.ToInt32(ListeNo);
                MalKodu = dr[0].ToString();

                Durum = (int)this.evrakNoSeriTableAdapter1.FiyatListesiDurumu(MalKodu, ListeAdi, ListNo, HesapKodu, Tarih);
                IskontoDurum = (int)this.evrakNoSeriTableAdapter1.StokListeDurum(MalKodu, Tarih);

                if (IskontoDurum > 0)
                {
                    IskontoOrani = (decimal)this.evrakNoSeriTableAdapter1.IskontoListesiCarili(MalKodu, HesapKodu, Tarih);
                }
                else
                {
                    IskontoOranKontrol = (int)this.evrakNoSeriTableAdapter1.IskontoOranKontrolCarisiz(MalKodu, Tarih);
                    if (IskontoOranKontrol > 0)
                    {
                        IskontoOrani = (decimal)this.evrakNoSeriTableAdapter1.IskontoListesiCarisiz(MalKodu, Tarih);
                    }
                    else
                    {
                        IskontoOrani = 0;
                    }
                }

                if (Durum > 0)
                {
                    BirimFiyatimiz = (decimal)this.evrakNoSeriTableAdapter1.ListeBirimFiyatGetir(Birim, ListeNo, ListeAdi, dr[0].ToString(), HesapKodu, Tarih);
                }
                else
                {
                    BirimFiyatimiz = (decimal)this.evrakNoSeriTableAdapter1.ListeBirimFiyati1(Birim, ListeNo, ListeAdi, dr[0].ToString(), Tarih);
                }

                frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK005_MalKodu", dr[0].ToString());
                frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK004_Aciklama", dr[1].ToString());
                frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK004_Birim1", dr["Birim 1"].ToString());
                frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK004_Birim2", dr["Birim 2"].ToString());
                frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK004_Birim3", dr["Birim 3"].ToString());
                frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK004_KafileBuyuklugu", dr["Kafile Büyüklüğü"].ToString());
                frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "OtvOranKilo", dr["OtvBirim"].ToString());
                frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK005_DovizCinsi", DovizParaBirimimiz);
                frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK005_DovizKuru", dovizKurumuz);
                frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK005_KalemIskontoOrani1", IskontoOrani);
            }
            this.Close();
        }

        private void LookUpSatisiadeFaturasiMalKodu_DoubleClick(object sender, EventArgs e)
        {
            foreach (int item in this.gridView1.GetSelectedRows())
            {
                DataRow dr = gridView1.GetDataRow(item);

                if (string.IsNullOrEmpty(ListeAdi.ToString()))
                {
                    ListeAdi = "";
                }

                ListNo = Convert.ToInt32(ListeNo);
                MalKodu = dr[0].ToString();

                Durum = (int)this.evrakNoSeriTableAdapter1.FiyatListesiDurumu(MalKodu, ListeAdi, ListNo, HesapKodu, Tarih);
                IskontoDurum = (int)this.evrakNoSeriTableAdapter1.StokListeDurum(MalKodu, Tarih);

                if (IskontoDurum > 0)
                {
                    IskontoOrani = (decimal)this.evrakNoSeriTableAdapter1.IskontoListesiCarili(MalKodu, HesapKodu, Tarih);
                }
                else
                {
                    IskontoOranKontrol = (int)this.evrakNoSeriTableAdapter1.IskontoOranKontrolCarisiz(MalKodu, Tarih);
                    if (IskontoOranKontrol > 0)
                    {
                        IskontoOrani = (decimal)this.evrakNoSeriTableAdapter1.IskontoListesiCarisiz(MalKodu, Tarih);
                    }
                    else
                    {
                        IskontoOrani = 0;
                    }
                }

                if (Durum > 0)
                {
                    BirimFiyatimiz = (decimal)this.evrakNoSeriTableAdapter1.ListeBirimFiyatGetir(Birim, ListeNo, ListeAdi, dr[0].ToString(), HesapKodu, Tarih);
                }
                else
                {
                    BirimFiyatimiz = (decimal)this.evrakNoSeriTableAdapter1.ListeBirimFiyati1(Birim, ListeNo, ListeAdi, dr[0].ToString(), Tarih);
                }

                frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK005_MalKodu", dr[0].ToString());
                frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK004_Aciklama", dr[1].ToString());
                frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK004_Birim1", dr["Birim 1"].ToString());
                frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK004_Birim2", dr["Birim 2"].ToString());
                frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK004_Birim3", dr["Birim 3"].ToString());
                frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK004_KafileBuyuklugu", dr["Kafile Büyüklüğü"].ToString());
                frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "OtvOranKilo", dr["OtvBirim"].ToString());
                frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK005_DovizCinsi", DovizParaBirimimiz);
                frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK005_DovizKuru", dovizKurumuz);
                frmOtvliSatisiadeFaturasi.gridView1.SetRowCellValue(SatirNumarasi, "STK005_KalemIskontoOrani1", IskontoOrani);
            }
            this.Close();
        }
    }
}