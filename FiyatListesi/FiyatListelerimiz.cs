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
    public partial class FiyatListelerimiz : DevExpress.XtraEditors.XtraForm
    {
        public FiyatListelerimiz()
        {
            InitializeComponent();
        }

        public string ID { get; set; }
        string SayfaAdi;
        string belgeTamYolu;

        private void FiyatListelerimiz_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'listeler.tblListeCariHesaplari' table. You can move, or remove it, as needed.
            this.tblListeCariHesaplariTableAdapter.Fill(this.listeler.tblListeCariHesaplari);
            // TODO: This line of code loads data into the 'listeler.tblListeMalKodlari' table. You can move, or remove it, as needed.
            this.tblListeMalKodlariTableAdapter.Fill(this.listeler.tblListeMalKodlari);
            // TODO: This line of code loads data into the 'listeler.tblFiyatListeleri' table. You can move, or remove it, as needed.
            //this.tblFiyatListeleriTableAdapter.Fill(this.listeler.tblFiyatListeleri);
            ps_ListeTuru();
            ps_CariTuru();
            dtBaslangicTarihi.DateTime = DateTime.Now;
            dtBitisTarihi.DateTime = DateTime.Now;
            ps_kolonlarıOku_Kaydet(islemTipi.oku);
        }

        int intBasTarih;
        int intBitTarih;
        DateTime stringBasTarih;
        DateTime stringBitTarih;

        #region Tanımlar

        int FiyatListeNo, BaslangicTarihi, BitisTarihi, ListeTuru, CariKodTipi, SatisKdvFlag, SatisBirimi1, SatisKDVFlag2, SatisBirimi2,
            SatisKDVFlag3, SatisBirimi3, SatisKDVFlag4, SatisBirimi4, SatisKDVFlag5, SatisBirimi5, AlisKDVFlag1, AlisBirimi1, AlisKDVFlag2,
            AlisBirimi2, AlisKDVFlag3, AlisBirimi3, AlisKDVFlag4, AlisBirimi4, AlisKDVFlag5, AlisBirimi5, GirisTarihi, GirisSaati, DegistirenTarih,
            ValorGun1, ValorGun2, ValorGun3, ValorGun4, ValorGun5, DvzValorGun1, DvzValorGun2, DvzValorGun3, LinkTarih, LinkiGirenSaat;
        string FiyatListeKodu, FiyatListeAdi, MalKodu, CariKodu, GirKaynakNo, GirKodu, GirVers, DegKaynakNo, DegistirenSaat, DegistirenKodu, DegistirenVersiyon,
            SatisDovizCinsi1, SatisDovizCinsi2, SatisDovizCinsi3, AlisDovizCinsi1, AlisDovizCinsi2, AlisDovizCinsi3, LinkSGirenSaat;
        decimal SatisFiyat1, SatisFiyat2, SatisFiyat3, SatisFiyat4, SatisFiyat5, AlisFiyat1, AlisFiyat2, AlisFiyat3, AlisFiyat4, AlisFiyat5,
            SatisDoviz1, SatisDoviz2, SatisDoviz3, AlisDoviz1, AlisDoviz2, AlisDoviz3;

        #endregion

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

        private void btnBelgeSec_Click(object sender, EventArgs e)
        {
            fnkBelgeSec();
        }

        private delegate void prbardelage(int durum);

        private void prbar(int durum)
        {
            if (base.InvokeRequired)
                base.Invoke(new prbardelage(this.prbar), durum);
            else
                progressBar1.Value = durum;
        }

        private void btnHazirla_Click(object sender, EventArgs e)
        {
            listeler.tblFiyatListeleri.Clear();

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

                        if (!string.IsNullOrEmpty(txtListeNo.Text))
                        {
                            FiyatListeNo = Convert.ToInt32(txtListeNo.Text);
                        }
                        else
                        {
                            FiyatListeNo = Convert.ToInt32(dr[0].ToString());
                        }
                        FiyatListeAdi = txtListeAdi.Text;

                        if (string.IsNullOrEmpty(FiyatListeAdi))
                        {
                            FiyatListeAdi = dr[1].ToString();

                        }
                        FiyatListeKodu = txtListeKodu.Text;

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
                        BBasDate = Convert.ToDateTime(dr[2].ToString());
                        DateTime BBitDate = new DateTime();
                        BBitDate = Convert.ToDateTime(dr[3].ToString());

                        string BasDate = Convert.ToString(BBasDate.ToOADate());
                        BasDate = BasDate.ToString().Substring(0, 5);
                        BaslangicTarihi = Convert.ToInt32(BasDate);

                        string BitDate = Convert.ToString(BBitDate.ToOADate());
                        BitDate = BitDate.ToString().Substring(0, 5);
                        BitisTarihi = Convert.ToInt32(BitDate);

                        string Tarihimiz = Convert.ToString(DateTime.Now.ToOADate());
                        Tarihimiz = Tarihimiz.ToString().Substring(0, 5);
                        LinkTarih = Convert.ToInt32(Tarihimiz);

                        MalKodu = dr[4].ToString();

                        string CariKodTipimiz = dr[5].ToString();

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
                            CariKodu = dr[7].ToString();
                        }

                        if (!string.IsNullOrEmpty(dr[8].ToString()))
                        {
                            SatisFiyat1 = Convert.ToDecimal(dr[8].ToString());
                        }
                        else
                        {
                            SatisFiyat1 = 0;
                        }
                        if (!string.IsNullOrEmpty(dr[9].ToString()))
                        {
                            SatisDoviz1 = Convert.ToDecimal(dr[9].ToString());
                        }
                        else
                        {
                            SatisDoviz1 = 0;
                        }

                        DateTime DtSaat = DateTime.Now;
                        LinkSGirenSaat = Convert.ToString(DtSaat);
                        LinkSGirenSaat = LinkSGirenSaat.ToString().Substring(11, 8);
                        LinkSGirenSaat = LinkSGirenSaat.ToString().Replace(":", "");

                        if (LinkSGirenSaat.ToString().Length > 8)
                        {
                            LinkSGirenSaat = LinkSGirenSaat.ToString().Substring(0, 8);
                        }
                        LinkiGirenSaat = Convert.ToInt32(LinkSGirenSaat);

                        listeler.tblFiyatListeleri.AddtblFiyatListeleriRow(FiyatListeNo, FiyatListeKodu, FiyatListeAdi, MalKodu, BaslangicTarihi, BitisTarihi, ListeTuru, CariKodTipi,
                            CariKodu, SatisFiyat1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, GirKaynakNo, LinkTarih, LinkiGirenSaat, GirKodu, GirVers, DegKaynakNo, LinkTarih, LinkSGirenSaat, DegistirenKodu,
                            DegistirenVersiyon, SatisDoviz1, "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, 0, 0, 0, 0, 0, 0, 0);
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

        private void btnKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Aktarim();
        }

        private void Aktarim()
        {
            if (!string.IsNullOrEmpty(txtDizin.Text.ToString()))
            {
                SqlBulkCopy sbc = new SqlBulkCopy(Properties.Settings.Default.Cs.ToString());
                sbc.DestinationTableName = "STK007";
                sbc.BatchSize = 1000;
                sbc.NotifyAfter = 1;
                sbc.BulkCopyTimeout = 60;
                sbc.ColumnMappings.Add("STK007_FiyatListeNo", "STK007_FiyatListeNo");
                sbc.ColumnMappings.Add("STK007_FiyatListeKodu", "STK007_FiyatListeKodu");
                sbc.ColumnMappings.Add("STK007_FiyatListeAdi", "STK007_FiyatListeAdi");
                sbc.ColumnMappings.Add("STK007_MalKodu", "STK007_MalKodu");
                sbc.ColumnMappings.Add("STK007_BasDate", "STK007_BasDate");
                sbc.ColumnMappings.Add("STK007_BitDate", "STK007_BitDate");
                sbc.ColumnMappings.Add("STK007_ListeTuru", "STK007_ListeTuru");
                sbc.ColumnMappings.Add("STK007_CHKodTipi", "STK007_CHKodTipi");
                sbc.ColumnMappings.Add("STK007_CHKod", "STK007_CHKod");
                sbc.ColumnMappings.Add("STK007_SatisFiyat1", "STK007_SatisFiyat1");
                sbc.ColumnMappings.Add("STK007_SatisKDVFlag1", "STK007_SatisKDVFlag1");
                sbc.ColumnMappings.Add("STK007_SatisBirimi1", "STK007_SatisBirimi1");
                sbc.ColumnMappings.Add("STK007_SatisFiyat2", "STK007_SatisFiyat2");
                sbc.ColumnMappings.Add("STK007_SatisKDVFlag2", "STK007_SatisKDVFlag2");
                sbc.ColumnMappings.Add("STK007_SatisBirimi2", "STK007_SatisBirimi2");
                sbc.ColumnMappings.Add("STK007_SatisFiyat3", "STK007_SatisFiyat3");
                sbc.ColumnMappings.Add("STK007_SatisKDVFlag3", "STK007_SatisKDVFlag3");
                sbc.ColumnMappings.Add("STK007_SatisBirimi3", "STK007_SatisBirimi3");
                sbc.ColumnMappings.Add("STK007_SatisFiyat4", "STK007_SatisFiyat4");
                sbc.ColumnMappings.Add("STK007_SatisKDVFlag4", "STK007_SatisKDVFlag4");
                sbc.ColumnMappings.Add("STK007_SatisBirimi4", "STK007_SatisBirimi4");
                sbc.ColumnMappings.Add("STK007_SatisFiyat5", "STK007_SatisFiyat5");
                sbc.ColumnMappings.Add("STK007_SatisKDVFlag5", "STK007_SatisKDVFlag5");
                sbc.ColumnMappings.Add("STK007_SatisBirimi5", "STK007_SatisBirimi5");
                sbc.ColumnMappings.Add("STK007_AlisFiyat1", "STK007_AlisFiyat1");
                sbc.ColumnMappings.Add("STK007_AlisKDVFlag1", "STK007_AlisKDVFlag1");
                sbc.ColumnMappings.Add("STK007_AlisBirimi1", "STK007_AlisBirimi1");
                sbc.ColumnMappings.Add("STK007_AlisFiyat2", "STK007_AlisFiyat2");
                sbc.ColumnMappings.Add("STK007_AlisKDVFlag2", "STK007_AlisKDVFlag2");
                sbc.ColumnMappings.Add("STK007_AlisBirimi2", "STK007_AlisBirimi2");
                sbc.ColumnMappings.Add("STK007_AlisFiyat3", "STK007_AlisFiyat3");
                sbc.ColumnMappings.Add("STK007_AlisKDVFlag3", "STK007_AlisKDVFlag3");
                sbc.ColumnMappings.Add("STK007_AlisBirimi3", "STK007_AlisBirimi3");
                sbc.ColumnMappings.Add("STK007_AlisFiyat4", "STK007_AlisFiyat4");
                sbc.ColumnMappings.Add("STK007_AlisKDVFlag4", "STK007_AlisKDVFlag4");
                sbc.ColumnMappings.Add("STK007_AlisBirimi4", "STK007_AlisBirimi4");
                sbc.ColumnMappings.Add("STK007_AlisFiyat5", "STK007_AlisFiyat5");
                sbc.ColumnMappings.Add("STK007_AlisKDVFlag5", "STK007_AlisKDVFlag5");
                sbc.ColumnMappings.Add("STK007_AlisBirimi5", "STK007_AlisBirimi5");
                sbc.ColumnMappings.Add("STK007_GirKaynakNo", "STK007_GirKaynakNo");
                sbc.ColumnMappings.Add("STK007_GirDate", "STK007_GirDate");
                sbc.ColumnMappings.Add("STK007_GirTime", "STK007_GirTime");
                sbc.ColumnMappings.Add("STK007_GirKodu", "STK007_GirKodu");
                sbc.ColumnMappings.Add("STK007_GirVers", "STK007_GirVers");
                sbc.ColumnMappings.Add("STK007_DegKaynakNo", "STK007_DegKaynakNo");
                sbc.ColumnMappings.Add("STK007_DegDate", "STK007_DegDate");
                sbc.ColumnMappings.Add("STK007_DegTime", "STK007_DegTime");
                sbc.ColumnMappings.Add("STK007_DegKodu", "STK007_DegKodu");
                sbc.ColumnMappings.Add("STK007_DegVers", "STK007_DegVers");
                sbc.ColumnMappings.Add("STK007_SatisDoviz1", "STK007_SatisDoviz1");
                sbc.ColumnMappings.Add("STK007_SatisDovizCinsi1", "STK007_SatisDovizCinsi1");
                sbc.ColumnMappings.Add("STK007_SatisDoviz2", "STK007_SatisDoviz2");
                sbc.ColumnMappings.Add("STK007_SatisDovizCinsi2", "STK007_SatisDovizCinsi2");
                sbc.ColumnMappings.Add("STK007_SatisDoviz3", "STK007_SatisDoviz3");
                sbc.ColumnMappings.Add("STK007_SatisDovizCinsi3", "STK007_SatisDovizCinsi3");
                sbc.ColumnMappings.Add("STK007_AlisDoviz1", "STK007_AlisDoviz1");
                sbc.ColumnMappings.Add("STK007_AlisDovizCinsi1", "STK007_AlisDovizCinsi1");
                sbc.ColumnMappings.Add("STK007_AlisDoviz2", "STK007_AlisDoviz2");
                sbc.ColumnMappings.Add("STK007_AlisDovizCinsi2", "STK007_AlisDovizCinsi2");
                sbc.ColumnMappings.Add("STK007_AlisDoviz3", "STK007_AlisDoviz3");
                sbc.ColumnMappings.Add("STK007_AlisDovizCinsi3", "STK007_AlisDovizCinsi3");
                sbc.ColumnMappings.Add("STK007_ValorGun1", "STK007_ValorGun1");
                sbc.ColumnMappings.Add("STK007_ValorGun2", "STK007_ValorGun2");
                sbc.ColumnMappings.Add("STK007_ValorGun3", "STK007_ValorGun3");
                sbc.ColumnMappings.Add("STK007_ValorGun4", "STK007_ValorGun4");
                sbc.ColumnMappings.Add("STK007_ValorGun5", "STK007_ValorGun5");
                sbc.ColumnMappings.Add("STK007_DvzValorGun1", "STK007_DvzValorGun1");
                sbc.ColumnMappings.Add("STK007_DvzValorGun2", "STK007_DvzValorGun2");
                sbc.ColumnMappings.Add("STK007_DvzValorGun3", "STK007_DvzValorGun3");
                sbc.WriteToServer(listeler.tblFiyatListeleri);
                sbc.Close();
            }
            else
            {
                ps_FiyatListesiKaydet();
            }
            MessageBox.Show("Liste Kaydedilmiştir.");
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //tblFiyatListeleriBindingSource.EndEdit();

                    DataRow dr = gridView1.GetFocusedDataRow();

                }
                catch (Exception) { }
            }
        }

        private void btnYeni_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listeler.tblFiyatListeleri.Clear();
            txtDizin.Text = "";
            txtListeAdi.Text = "";
            txtListeKodu.Text = "";
            txtListeNo.Text = "";
            txtSayfaAdi.Text = "";
        }

        private void btnKolonlarıKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                    grdFiyatListesi.MainView.RestoreLayoutFromXml(Application.StartupPath + "\\KullaniciAyarlari\\" + ID + "_FiyatListeleri.xml");
                }
                else if (islemTipi == islemTipi.kaydet)
                {
                    grdFiyatListesi.MainView.SaveLayoutToXml(Application.StartupPath + "\\KullaniciAyarlari\\" + ID + "_FiyatListeleri.xml");
                    ps_kolonlarıOku_Kaydet(FiyatListelerimiz.islemTipi.oku);
                }
            }
            catch { }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //this.tblFiyatListeleriBindingSource.EndEdit();
        }

        private void grdLookUpMalKodlari_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            try
            {
                GridLookUpEdit GridLookUpMalKodu = sender as GridLookUpEdit;
                DataRow dr = GridLookUpMalKodu.Properties.View.GetDataRow(GridLookUpMalKodu.Properties.View.FocusedRowHandle);
                gridView1.SetFocusedRowCellValue(colSTK007_MalKodu, dr[0].ToString());
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
                gridView1.SetFocusedRowCellValue(colSTK007_CHKod, dr[0].ToString());
            }
            catch (Exception)
            {
            }
        }

        private void gridLookUpListeTuru_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            try
            {
                GridLookUpEdit GridLookUpListeTuru = sender as GridLookUpEdit;
                DataRow dr = GridLookUpListeTuru.Properties.View.GetDataRow(GridLookUpListeTuru.Properties.View.FocusedRowHandle);
                gridView1.SetFocusedRowCellValue(colSTK007_ListeTuru, dr[0].ToString());
            }
            catch (Exception)
            {
            }
        }

        private void ps_FiyatListesiKaydet()
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
            

            foreach (DataRow dr in listeler.tblFiyatListeleri.Rows)
            {
                ListeTuru = (int)dr[colSTK007_ListeTuru.FieldName];
                CariKodTipi = (int)dr[colSTK007_CHKodTipi.FieldName];
                CariKodu = dr[colSTK007_CHKod.FieldName].ToString();
                SatisFiyat1 = (decimal)dr[colSTK007_SatisFiyat1.FieldName];
                SatisFiyat2 = (decimal)dr[colSTK007_SatisFiyat2.FieldName];
                SatisFiyat3 = (decimal)dr[colSTK007_SatisFiyat3.FieldName];
                SatisFiyat4 = (decimal)dr[colSTK007_SatisFiyat4.FieldName];
                SatisFiyat5 = (decimal)dr[colSTK007_SatisFiyat5.FieldName];
                AlisFiyat1 = (decimal)dr[colSTK007_AlisFiyat1.FieldName];
                AlisFiyat2 = (decimal)dr[colSTK007_AlisFiyat2.FieldName];
                AlisFiyat3 = (decimal)dr[colSTK007_AlisFiyat3.FieldName];
                AlisFiyat4 = (decimal)dr[colSTK007_AlisFiyat4.FieldName];
                AlisFiyat5 = (decimal)dr[colSTK007_AlisFiyat5.FieldName];
                SatisDoviz1 = (decimal)dr[colSTK007_SatisDoviz1.FieldName];
                SatisDoviz2 = (decimal)dr[colSTK007_SatisDoviz2.FieldName];
                SatisDoviz3 = (decimal)dr[colSTK007_SatisDoviz3.FieldName];
                AlisDoviz1 = (decimal)dr[colSTK007_AlisDoviz1.FieldName];
                AlisDoviz2 = (decimal)dr[colSTK007_AlisDoviz2.FieldName];
                AlisDoviz3 = (decimal)dr[colSTK007_AlisDoviz3.FieldName];
                SatisDovizCinsi1 = dr[colSTK007_SatisDovizCinsi1.FieldName].ToString();
                SatisDovizCinsi2 = dr[colSTK007_SatisDovizCinsi2.FieldName].ToString();
                SatisDovizCinsi3 = dr[colSTK007_SatisDovizCinsi3.FieldName].ToString();
                AlisDovizCinsi1 = dr[colSTK007_AlisDovizCinsi1.FieldName].ToString();
                AlisDovizCinsi2 = dr[colSTK007_AlisDovizCinsi2.FieldName].ToString();
                AlisDovizCinsi3 = dr[colSTK007_AlisDovizCinsi3.FieldName].ToString();


                this.queriesTableAdapter1.FiyatListesiEkle(Convert.ToInt32(txtListeNo.Text), txtListeKodu.Text, 
                    txtListeAdi.Text, dr[colSTK007_MalKodu.FieldName].ToString(),
                    intBasTarih, intBitTarih, ListeTuru, CariKodTipi, CariKodu, SatisFiyat1,
                    SatisFiyat2, SatisFiyat3, SatisFiyat4, SatisFiyat5, AlisFiyat1,
                    AlisFiyat2, AlisFiyat3, AlisFiyat4, AlisFiyat5, LinkTarih, LinkiGirenSaat, GirKodu,
                    LinkTarih, LinkSGirenSaat, DegistirenKodu, SatisDoviz1, SatisDovizCinsi1, SatisDoviz2,
                    SatisDovizCinsi3, SatisDoviz3, SatisDovizCinsi3, AlisDoviz1,
                    AlisDovizCinsi1, AlisDoviz2, AlisDovizCinsi2,
                    AlisDoviz3, AlisDovizCinsi3.ToString());
            }

        }
    }
}