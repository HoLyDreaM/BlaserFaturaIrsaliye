using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;

namespace Blaser_ÖTV_Fatura_Irsaliye.FiyatListesi
{
    public partial class IskontoListemiz : DevExpress.XtraEditors.XtraForm
    {
        public IskontoListemiz()
        {
            InitializeComponent();
        }

        public string ID { get; set; }
        string SayfaAdi;
        string belgeTamYolu;
        int intBasTarih;
        int intBitTarih;
        DateTime stringBasTarih;
        DateTime stringBitTarih;

        #region Tanımlar

        int BaslangicTarihi, BitisTarihi, LinkTarih, LinkiGirenSaat, ListeTuru, CariKodTipi, MalKoduTipi;
        decimal iskontoOrani;
        string MalKodu, CariKodu, GirKaynakNo, GirKodu, GirVers, DegKaynakNo,
            DegistirenSaat, DegistirenKodu, DegistirenVersiyon, LinkSGirenSaat;

        #endregion

        private void IskontoListemiz_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'listeler.tblListeCariHesaplari' table. You can move, or remove it, as needed.
            this.tblListeCariHesaplariTableAdapter.Fill(this.listeler.tblListeCariHesaplari);
            // TODO: This line of code loads data into the 'listeler.tblListeMalKodlari' table. You can move, or remove it, as needed.
            this.tblListeMalKodlariTableAdapter.Fill(this.listeler.tblListeMalKodlari);
            //// TODO: This line of code loads data into the 'listeler.tbliskontoListesi' table. You can move, or remove it, as needed.
            //this.tbliskontoListesiTableAdapter.Fill(this.listeler.tbliskontoListesi);
            
            ps_ListeTuru();
            ps_CariTuru();
            ps_IskontoTuru();
            dtBaslangicTarihi.DateTime = DateTime.Now;
            dtBitisTarihi.DateTime = DateTime.Now;
            ps_kolonlarıOku_Kaydet(islemTipi.oku);
        }

        private void ps_ListeTuru()
        {
            listeler.tblListeTuru.Clear();
            DataRow dr = listeler.tblListeTuru.NewRow();
            dr[0] = 1;
            dr[1] = "Tüm Müşteriler";
            listeler.tblListeTuru.Rows.Add(dr);

            DataRow dr1 = listeler.tblListeTuru.NewRow();
            dr1[0] = 2;
            dr1[1] = "Müşteri Kodların Göre";
            listeler.tblListeTuru.Rows.Add(dr1);

        }

        private void ps_CariTuru()
        {
            listeler.tblCariKod.Clear();

            DataRow dr = listeler.tblCariKod.NewRow();
            dr[0] = 0;
            dr[1] = "00";
            listeler.tblCariKod.Rows.Add(dr);

            DataRow dr1 = listeler.tblCariKod.NewRow();
            dr1[0] = 1;
            dr1[1] = "Hesap Kodları";
            listeler.tblCariKod.Rows.Add(dr1);

        }

        private void ps_IskontoTuru()
        {
            listeler.tblIskontoTuru.Clear();

            DataRow dr = listeler.tblIskontoTuru.NewRow();
            dr[0] = 1;
            dr[1] = "Mal kodu";
            listeler.tblIskontoTuru.Rows.Add(dr);

            DataRow dr1 = listeler.tblIskontoTuru.NewRow();
            dr1[0] = 3;
            dr1[1] = "Grup Kodu";
            listeler.tblIskontoTuru.Rows.Add(dr1);

            DataRow dr2 = listeler.tblIskontoTuru.NewRow();
            dr2[0] = 50;
            dr2[1] = "Özel Kodu";
            listeler.tblIskontoTuru.Rows.Add(dr2);

            DataRow dr3 = listeler.tblIskontoTuru.NewRow();
            dr3[0] = 51;
            dr3[1] = "Tip Kodu";
            listeler.tblIskontoTuru.Rows.Add(dr3);

            DataRow dr4 = listeler.tblIskontoTuru.NewRow();
            dr4[0] = 52;
            dr4[1] = "Kod1";
            listeler.tblIskontoTuru.Rows.Add(dr4);

            DataRow dr5 = listeler.tblIskontoTuru.NewRow();
            dr5[0] = 53;
            dr5[1] = "Kod2";
            listeler.tblIskontoTuru.Rows.Add(dr5);

            DataRow dr6 = listeler.tblIskontoTuru.NewRow();
            dr6[0] = 57;
            dr6[1] = "Kod3";
            listeler.tblIskontoTuru.Rows.Add(dr6);

            DataRow dr7 = listeler.tblIskontoTuru.NewRow();
            dr7[0] = 55;
            dr7[1] = "Kod4";
            listeler.tblIskontoTuru.Rows.Add(dr7);

            DataRow dr8 = listeler.tblIskontoTuru.NewRow();
            dr8[0] = 56;
            dr8[1] = "Kod5";
            listeler.tblIskontoTuru.Rows.Add(dr8);

            DataRow dr9 = listeler.tblIskontoTuru.NewRow();
            dr9[0] = 57;
            dr9[1] = "Kod6";
            listeler.tblIskontoTuru.Rows.Add(dr9);

            DataRow dr10 = listeler.tblIskontoTuru.NewRow();
            dr10[0] = 58;
            dr10[1] = "Kod7";
            listeler.tblIskontoTuru.Rows.Add(dr10);

            DataRow dr11 = listeler.tblIskontoTuru.NewRow();
            dr11[0] = 61;
            dr11[1] = "Üretici Kodu 1";
            listeler.tblIskontoTuru.Rows.Add(dr11);

            DataRow dr12 = listeler.tblIskontoTuru.NewRow();
            dr12[0] = 62;
            dr12[1] = "Üretici Kodu 2";
            listeler.tblIskontoTuru.Rows.Add(dr12);

            DataRow dr13 = listeler.tblIskontoTuru.NewRow();
            dr13[0] = 63;
            dr13[1] = "Üretici Kodu 3";
            listeler.tblIskontoTuru.Rows.Add(dr13);

        }

        private void btnBelgeSec_Click(object sender, EventArgs e)
        {
            fnkBelgeSec();
        }

        private void fnkBelgeSec()
        {
            BelgeSec.Title = "Kaynak Dosyayı Seçiniz";
            BelgeSec.FileName = "Fiyat Listesi";
            //BelgeSec.Filter = "Excel dosyaları |*.xls,*.xls";
            BelgeSec.Filter = "(*.xlsx)|*.xlsx|(*.xls)|*.xls";
            BelgeSec.InitialDirectory = Application.ExecutablePath.ToString();
            BelgeSec.FilterIndex = 1;
            BelgeSec.RestoreDirectory = true;

            if (BelgeSec.ShowDialog() == DialogResult.OK)
            {
                string belgeYolu = BelgeSec.FileName;
                belgeTamYolu = Path.GetFullPath(belgeYolu);
                txtDizin.Text = belgeYolu.ToString();
                SayfaAdi = txtSayfaAdi.Text;
            }

        }

        private delegate void prbardelage(int durum);

        private void prbar(int durum)
        {
            if (base.InvokeRequired)
                base.Invoke(new prbardelage(this.prbar), durum);
            else
                progressBar1.Value = durum;
        }

        enum islemTipi
        {
            oku = 0,
            kaydet = 1
        }

        private void ps_kolonlarıOku_Kaydet(islemTipi islemTipi)
        {
            try
            {
                if (islemTipi == islemTipi.oku)
                {
                    grdiskontoListesi.MainView.RestoreLayoutFromXml(Application.StartupPath + "\\KullaniciAyarlari\\" + ID + "_IskontoListeleri.xml");
                }
                else if (islemTipi == islemTipi.kaydet)
                {
                    grdiskontoListesi.MainView.SaveLayoutToXml(Application.StartupPath + "\\KullaniciAyarlari\\" + ID + "_IskontoListeleri.xml");
                    ps_kolonlarıOku_Kaydet(IskontoListemiz.islemTipi.oku);
                }
            }
            catch { }
        }

        private void btnHazirla_Click(object sender, EventArgs e)
        {
            listeler.tbliskontoListesi.Clear();

            if (string.IsNullOrEmpty(txtDizin.Text.ToString()))
            {
                MessageBox.Show("Lütfen Excel Dosyanızı Seçiniz");
                return;
            }
            else
            {
                try
                {
                    string BaglantiYolu = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + belgeTamYolu + "; Extended Properties=Excel 12.0";
                    OleDbConnection baglanti = new OleDbConnection(BaglantiYolu);
                    baglanti.Open();
                    SayfaAdi = txtSayfaAdi.Text;
                    string sorgu = "select * from [" + SayfaAdi.ToString() + "$] ";
                    OleDbCommand cmd = new OleDbCommand(sorgu, baglanti);
                    OleDbDataAdapter da = new OleDbDataAdapter(sorgu, baglanti);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int i = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    while (dr.Read())
                    {
                        prbar(i);

                        GirKodu = Environment.UserName.ToString();
                        if (GirKodu.ToString().Length > 10)
                        {
                            GirKodu = GirKodu.ToString().Substring(0, 10);
                        }

                        DegistirenKodu = GirKodu;
                        GirKaynakNo = "Y4099";
                        DegKaynakNo = GirKaynakNo;
                        GirVers = "6.1.00";
                        DegistirenVersiyon = GirVers;

                        DateTime BBasDate = new DateTime();
                        BBasDate = Convert.ToDateTime(dtBaslangicTarihi.DateTime);
                        DateTime BBitDate = new DateTime();
                        BBitDate = Convert.ToDateTime(dtBitisTarihi.DateTime);

                        string BasDate = Convert.ToString(BBasDate.ToOADate());
                        BasDate = BasDate.ToString().Substring(0, 5);
                        BaslangicTarihi = Convert.ToInt32(BasDate);

                        string BitDate = Convert.ToString(BBitDate.ToOADate());
                        BitDate = BitDate.ToString().Substring(0, 5);
                        BitisTarihi = Convert.ToInt32(BitDate);

                        string Tarihimiz = Convert.ToString(DateTime.Now.ToOADate());
                        Tarihimiz = Tarihimiz.ToString().Substring(0, 5);
                        LinkTarih = Convert.ToInt32(Tarihimiz);

                        MalKodu = dr[1].ToString();
                        string MalKoduTipimiz = dr[0].ToString();

                        #region Mal Kodu Tipimiz

                        if (MalKoduTipimiz == "Mal Kodu")
                        {
                            MalKoduTipi = 1;
                        }
                        else if (MalKoduTipimiz == "Grup Kodu")
                        {
                            MalKoduTipi = 2;
                        }
                        else if (MalKoduTipimiz == "Özel Kodu")
                        {
                            MalKoduTipi = 3;
                        }
                        else if (MalKoduTipimiz == "Tip Kodu")
                        {
                            MalKoduTipi = 4;
                        }
                        else if (MalKoduTipimiz == "Kod1")
                        {
                            MalKoduTipi = 5;
                        }
                        else if (MalKoduTipimiz == "Kod2")
                        {
                            MalKoduTipi = 6;
                        }
                        else if (MalKoduTipimiz == "Kod3")
                        {
                            MalKoduTipi = 7;
                        }
                        else if (MalKoduTipimiz == "Kod4")
                        {
                            MalKoduTipi = 8;
                        }
                        else if (MalKoduTipimiz == "Kod5")
                        {
                            MalKoduTipi = 9;
                        }
                        else if (MalKoduTipimiz == "Kod6")
                        {
                            MalKoduTipi = 10;
                        }
                        else if (MalKoduTipimiz == "Kod7")
                        {
                            MalKoduTipi = 11;
                        }
                        else if (MalKoduTipimiz == "Üretici Kodu 1")
                        {
                            MalKoduTipi = 12;
                        }
                        else if (MalKoduTipimiz == "Üretici Kodu 2")
                        {
                            MalKoduTipi = 13;
                        }
                        else if (MalKoduTipimiz == "Üretici Kodu 3")
                        {
                            MalKoduTipi = 14;
                        }

                        #endregion

                        string CariKodTipimiz = dr[2].ToString();

                        if (CariKodTipimiz == "Tüm Müşteriler")
                        {
                            ListeTuru = 1;
                        }
                        else if (CariKodTipimiz == "Müşteri Kodlarına Göre")
                        {
                            ListeTuru = 2;
                        }
                        if (CariKodTipimiz == "Tüm Müşteriler")
                        {
                            CariKodTipi = 0;
                            CariKodu = "";
                        }
                        if (CariKodTipimiz == "Müşteri Kodlarına Göre")
                        {
                            CariKodTipi = 1;
                            CariKodu = dr[4].ToString();
                        }
                        iskontoOrani = Convert.ToDecimal(dr[5].ToString());

                        DateTime DtSaat = DateTime.Now;
                        LinkSGirenSaat = Convert.ToString(DtSaat);
                        LinkSGirenSaat = LinkSGirenSaat.ToString().Substring(11, 8);
                        LinkSGirenSaat = LinkSGirenSaat.ToString().Replace(":", "");

                        if (LinkSGirenSaat.ToString().Length > 8)
                        {
                            LinkSGirenSaat = LinkSGirenSaat.ToString().Substring(0, 8);
                        }
                        LinkiGirenSaat = Convert.ToInt32(LinkSGirenSaat);

                        listeler.tbliskontoListesi.AddtbliskontoListesiRow(MalKoduTipi, MalKodu, BaslangicTarihi, BitisTarihi, ListeTuru, CariKodTipi,
                            CariKodu, iskontoOrani, "Y4100", LinkTarih, LinkSGirenSaat, GirKodu, "6.1.00", "Y4100", LinkTarih, LinkSGirenSaat, GirKodu, "6.1.00");

                        i++;
                    }

                    MessageBox.Show("Hazırlama İşlemi Tamamlanmıştır.Toplam Kayıt Sayisi: " + Convert.ToString(dt.Rows.Count));
                    progressBar1.Value = 0;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Bir Hata Oluştu.Hata Kodu: " + ex.ToString());
                }
            }
        }

        private void btnYeni_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listeler.tbliskontoListesi.Clear();
            txtDizin.Text = "";
            txtSayfaAdi.Text = "";
        }

        private void btnKolonKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ps_kolonlarıOku_Kaydet(islemTipi.kaydet);
                MessageBox.Show("Kolonlar Kaydeydetildi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Aktarim();
        }

        private void Aktarim()
        {
            if (!string.IsNullOrEmpty(txtDizin.Text.ToString()))
            {
                SqlBulkCopy sbc = new SqlBulkCopy(Properties.Settings.Default.Cs.ToString());
                sbc.DestinationTableName = "STK008";
                sbc.BatchSize = 1000;
                sbc.NotifyAfter = 1;
                sbc.BulkCopyTimeout = 60;
                sbc.ColumnMappings.Add("STK008_MalKoduTipi", "STK008_MalKoduTipi");
                sbc.ColumnMappings.Add("STK008_MalKodu", "STK008_MalKodu");
                sbc.ColumnMappings.Add("STK008_BasDate", "STK008_BasDate");
                sbc.ColumnMappings.Add("STK008_BitDate", "STK008_BitDate");
                sbc.ColumnMappings.Add("STK008_IndTuru", "STK008_IndTuru");
                sbc.ColumnMappings.Add("STK008_IndCHKodTipi", "STK008_IndCHKodTipi");
                sbc.ColumnMappings.Add("STK008_IndCHKod", "STK008_IndCHKod");
                sbc.ColumnMappings.Add("STK008_IndOrani", "STK008_IndOrani");
                sbc.ColumnMappings.Add("STK008_GirKaynakNo", "STK008_GirKaynakNo");
                sbc.ColumnMappings.Add("STK008_GirDate", "STK008_GirDate");
                sbc.ColumnMappings.Add("STK008_GirTime", "STK008_GirTime");
                sbc.ColumnMappings.Add("STK008_GirKodu", "STK008_GirKodu");
                sbc.ColumnMappings.Add("STK008_GirVers", "STK008_GirVers");
                sbc.ColumnMappings.Add("STK008_DegKaynakNo", "STK008_DegKaynakNo");
                sbc.ColumnMappings.Add("STK008_DegDate", "STK008_DegDate");
                sbc.ColumnMappings.Add("STK008_DegTime", "STK008_DegTime");
                sbc.ColumnMappings.Add("STK008_DegKodu", "STK008_DegKodu");
                sbc.ColumnMappings.Add("STK008_DegVers", "STK008_DegVers");
                sbc.WriteToServer(listeler.tbliskontoListesi);
                sbc.Close();
            }
            else
            {
                ps_iskontoListesiKaydet();
            }
            MessageBox.Show("Liste Kaydedilmiştir.");
        }

        private void ps_iskontoListesiKaydet()
        {
            GirKodu = Environment.UserName.ToString();
            if (GirKodu.ToString().Length > 10)
            {
                GirKodu = GirKodu.ToString().Substring(0, 10);
            }

            stringBasTarih = dtBaslangicTarihi.DateTime;
            stringBitTarih = dtBitisTarihi.DateTime;

            string BasTarih = Convert.ToString(stringBasTarih.ToOADate());
            BasTarih = BasTarih.ToString().Substring(0, 5);
            intBasTarih = Convert.ToInt32(BasTarih);

            string BitTarih = Convert.ToString(stringBitTarih.ToOADate());
            BitTarih = BitTarih.ToString().Substring(0, 5);
            intBitTarih = Convert.ToInt32(BitTarih);

            DegistirenKodu = GirKodu;
            GirKaynakNo = "Y4099";
            DegKaynakNo = GirKaynakNo;
            GirVers = "6.1.00";
            DegistirenVersiyon = GirVers;

            DateTime girisTarihimiz = DateTime.Now;
            string LinkGirisTarihimiz = Convert.ToString(girisTarihimiz.ToOADate());
            LinkGirisTarihimiz = LinkGirisTarihimiz.ToString().Substring(0, 5);
            LinkTarih = Convert.ToInt32(LinkGirisTarihimiz);

            DateTime DtSaat = DateTime.Now;
            LinkSGirenSaat = Convert.ToString(DtSaat);
            LinkSGirenSaat = LinkSGirenSaat.ToString().Substring(11, 8);
            LinkSGirenSaat = LinkSGirenSaat.ToString().Replace(":", "");

            if (LinkSGirenSaat.ToString().Length > 8)
            {
                LinkSGirenSaat = LinkSGirenSaat.ToString().Substring(0, 8);
            }
            LinkiGirenSaat = Convert.ToInt32(LinkSGirenSaat);


            foreach (DataRow dr in listeler.tbliskontoListesi.Rows)
            {
                int MalKoduTipi = (int)dr[colSTK008_MalKoduTipi.FieldName];
                MalKodu = dr[colSTK008_MalKodu.FieldName].ToString();
                ListeTuru = (int)dr[colSTK008_IndTuru.FieldName];
                CariKodTipi = (int)dr[colSTK008_IndCHKodTipi.FieldName];
                CariKodu = dr[colSTK008_IndCHKod.FieldName].ToString();
                iskontoOrani = (decimal)dr[colSTK008_IndOrani.FieldName];
                this.queriesTableAdapter1.IskontoListesiEkle(MalKoduTipi, MalKodu, intBasTarih, intBitTarih, ListeTuru, CariKodTipi,
                    CariKodu, iskontoOrani, GirKaynakNo, LinkTarih, LinkSGirenSaat, GirKodu, GirVers, DegKaynakNo, LinkTarih, LinkSGirenSaat,
                    DegistirenKodu, DegistirenVersiyon);

                //this.queriesTableAdapter1.IskontoListesiEkle(
            }
        }

        private void grdLookUpMalKodlari_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            try
            {
                GridLookUpEdit GridLookUpMalKodu = sender as GridLookUpEdit;
                DataRow dr = GridLookUpMalKodu.Properties.View.GetDataRow(GridLookUpMalKodu.Properties.View.FocusedRowHandle);
                gridView1.SetFocusedRowCellValue(colSTK008_MalKodu, dr[0].ToString());
            }
            catch (Exception)
            {
            }
        }

        private void grdLookUpCariKodlari_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            try
            {
                GridLookUpEdit GridLookUpCariKod = sender as GridLookUpEdit;
                DataRow dr = GridLookUpCariKod.Properties.View.GetDataRow(GridLookUpCariKod.Properties.View.FocusedRowHandle);
                gridView1.SetFocusedRowCellValue(colSTK008_IndCHKod, dr[0].ToString());
            }
            catch (Exception)
            {
            }
        }

        private void gridLookUpListeTuru_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                GridLookUpEdit GridLookUpListeTuru = sender as GridLookUpEdit;
                DataRow dr = GridLookUpListeTuru.Properties.View.GetDataRow(GridLookUpListeTuru.Properties.View.FocusedRowHandle);
                gridView1.SetFocusedRowCellValue(colSTK008_IndTuru, dr[0].ToString());
            }
            catch (Exception)
            {
            }
        }

        private void gridLookUpStokKoduTipi_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                GridLookUpEdit GridLookUpStokKoduTipi = sender as GridLookUpEdit;
                DataRow dr = GridLookUpStokKoduTipi.Properties.View.GetDataRow(GridLookUpStokKoduTipi.Properties.View.FocusedRowHandle);
                gridView1.SetFocusedRowCellValue(colSTK008_MalKoduTipi, dr[0].ToString());
            }
            catch (Exception)
            {
            }
        }
    }
}