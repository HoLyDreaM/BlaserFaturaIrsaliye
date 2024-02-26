using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Localization;
using System.IO;
using FastReport;
using FastReport.Data;
using System.Collections;

namespace Blaser_ÖTV_Fatura_Irsaliye
{
    public partial class OtvliSatisFaturasi : DevExpress.XtraEditors.XtraForm
    {
        iniOku.iniOku ini = new iniOku.iniOku(Application.StartupPath+"\\LoginSettings.ini");

        public OtvliSatisFaturasi()
        {
            InitializeComponent();
        }

        public string ID { get; set; }
        Boolean gridDurum = false;
        int f = 0;
        Boolean DovizDurum = false;
        decimal DovizliKdv;
        decimal DovizliNetTutar;
        string Dovizislemi;
        int KontrolEdiyoruz = 0;
        int CarpKontrol = 0;

        private void raporListele(string ustDizin)
        {
            try
            {
                cmbFaturalar.Items.Clear();

                FileInfo fi = new FileInfo(ustDizin);
                foreach (var file in fi.Directory.GetFiles("*.frx"))
                    cmbFaturalar.Items.Add(file.Name.ToString());

                cmbFaturalar.SelectedIndex = 0;
            }
            catch { }
        }

        #region Tanımlar

        string DovizHesapKodumuz;
        string DovizParaBirimimiz;
        string KdvSekli;
        decimal IskontoOranimiz;
        decimal IskToplamimiz;
        decimal dovizKurumuz;
        string UygulanacakFiyatKolonID;
        string FiyatID;
        string sonuc;
        int OpsiyonGunu;

        #endregion

        #region Form Bağlantıları

        Ayarlar.LookUpStokVeCariHareketi frmLookUpStokVeCariHareketleri;
        Ayarlar.LookUpKayitlikFaturalar_OtvFatura frmLookUpKayitliFaturalar;
        Ayarlar.LookUpFormMalSeriNo frmMalSeriNo;
        Ayarlar.frmKayitliSiparis_OtvFatura frmKayitliSiparisler;
        Ayarlar.frmKayitliIrsaliye_OtvFatura frmKayitliIrsaliyeler;
        Ayarlar.LookUpSatisFaturasiMalKodu frmLookUpSatisFaturasiMalKodu;
        FiyatListesi.frmFiyatListeleriFaturalar frmfiyatlarimiz;

        #endregion

        #region Form Load İşlemleri

        private void OtvliSatisFaturasi_Load(object sender, EventArgs e)
        {
            ps_yenSatirEkle();

            try
            {
                ps_kolonlarıOku_Kaydet(islemTipi.oku);
                ps_EvrakSeri_EvrakNo_Getir();
            }
            catch
            {
                txtFaturaNo.Text = "000001";
            }

            try
            {
                raporListele(Application.StartupPath +@"\Raporlar\Satis Faturasi\");

                dtFaturaTarihi.DateTime = DateTime.Now;
                dtVadeTarihi.DateTime = DateTime.Now;
                dtKdvTarihi.DateTime = DateTime.Now;
                dtOtvTarihi.DateTime = DateTime.Now;

                dtIrsaliyeTarihi.DateTime = DateTime.Now;
                dtSevkTarihi.DateTime = DateTime.Now;
                dtSiparisTarihi.DateTime = DateTime.Now;
                dtBaslangicTarihi.DateTime = DateTime.Now;
                dtKdvVadeTarihi.DateTime = DateTime.Now;

                this.tblCariHesaplarTableAdapter1.cariHesaplariGetir(this.dataSet2.tblCariHesaplar);
                UygulanacakFiyatGetir(cmUygulanacakFiyat.EditValue.ToString());
                cmUygulanacakFiyat.EditValue = UygulanacakFiyatGetirCariden(FiyatID);
                this.tblLookUpStokKartlariTableAdapter.lookUpStokKartlari(this.dataSet1.tblLookUpStokKartlari, FiyatID);
               
                txtBaslik.Text = "0224-549 10 78";
                txtBaslik1.Text = "0224-549 24 92";
                txtMasrafMerkezi.Text = "1100";
               
                
                ps_kdvOranlariniEkle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region Insert Tanımları

        string StokMalKodu, MalAdi, CariHesapKodu, EvrakSeriNumarasi, Aciklama1, Aciklama2, Birim1, Birim2, Birim3, Depo, DovizCinsi, IrsaliyeNo, KarsiMuhasebeKodu,
                Kod1, Kod2, Kod3, Kod4, Kod5, Kod6, Kod7, Kod8, Kod9, Kod10, MasrafMerkezi, MalSeriNo, SiparisNo, TeslimChdKodu, Vasita, GirenSaat, PcAdi;
        decimal Miktari, BirimFiyati, Tutari, BirimAgirligi, DovizKuru, DovizTutari, Iskonto, KafileBuyuklugu, KdvTutari, Kod11, Kod12, Masraf,
              Miktar2, KalemIskontoOrani1, KalemIskontoOrani2, KalemIskontoOrani3, KalemIskontoOrani4, KalemIskontoOrani5, KalemIskontoTutari1,
             KalemIskontoTutari2, KalemIskontoTutari3, KalemIskontoTutari4, KalemIskontoTutari5, Tutar2, OtvTutari, TeslimMiktari;
        int IslemTarihi, IrsaliyeFaturaTarihi, SevkTarihi, SiparisTarihi, VadeTarihi, GirenTarih, SEQNO, KdvOraniYuzde, islemTipimiz,
            kdvVadeTarihi,otvVadeTarihi;
        byte ParaBirimi, KdvOranFlag, KdvDurumu, MuhasebelesmeDurumu;
        double DbIslemTarihi, DbIrsaliyeFaturaTarihi, DbSevkTarihi, DbSiparisTarihi, DbVadeTarihi, DbGirenTarih, DbKdvVadeTarihi, DbOtvVadeTarihi;

        #endregion

        #region Fonksiyonlar
        private string sayiyiYaziyaCevir(decimal rakam)
        {
            string sTutar = rakam.ToString("F2").Replace('.', ',');
            string lira = sTutar.Substring(0, sTutar.IndexOf(','));
            string kurus = sTutar.Substring(sTutar.IndexOf(',') + 1, 2);
            string yazi = "";

            string[] birler = { "", "BİR", "İKİ", "ÜÇ", "DÖRT", "BEŞ", "ALTI", "YEDİ", "SEKİZ", "DOKUZ" };
            string[] onlar = { "", "ON", "YİRMİ", "OTUZ", "KIRK", "ELLİ", "ALTMIŞ", "YETMİŞ", "SEKSEN", "DOKSAN" };
            string[] binler = { "KATRİLYON", "TRİLYON", "MİLYAR", "MİLYON", "BİN", "" };

            int grupSayisi = 6;

            lira = lira.PadLeft(grupSayisi * 3, '0');

            string grupDegeri;

            for (int i = 0; i < grupSayisi * 3; i += 3)
            {
                grupDegeri = "";

                if (lira.Substring(i, 1) != "0")
                    grupDegeri += birler[Convert.ToInt32(lira.Substring(i, 1))] + "YÜZ"; //yüzler                

                if (grupDegeri == "BİRYÜZ")
                    grupDegeri = "YÜZ";

                grupDegeri += onlar[Convert.ToInt32(lira.Substring(i + 1, 1))]; //onlar

                grupDegeri += birler[Convert.ToInt32(lira.Substring(i + 2, 1))]; //birler                

                if (grupDegeri != "")
                    grupDegeri += binler[i / 3];

                if (grupDegeri == "BİRBİN")
                    grupDegeri = "BİN";

                yazi += grupDegeri;
            }

            if (yazi != "")
                yazi += " TL ";

            int yaziUzunlugu = yazi.Length;

            if (kurus.Substring(0, 1) != "0") //kuruş onlar
                yazi += onlar[Convert.ToInt32(kurus.Substring(0, 1))];

            if (kurus.Substring(1, 1) != "0") //kuruş birler
                yazi += birler[Convert.ToInt32(kurus.Substring(1, 1))];

            if (yazi.Length > yaziUzunlugu)
                yazi += " KR.";
            else
                yazi += "SIFIR KR.";

            return "Y/" + yazi;
        }

        private void frmLookUpStokVeCariHareketleriAc(string pencereBasligi,string hangiKod) {
            frmLookUpStokVeCariHareketleri = new Ayarlar.LookUpStokVeCariHareketi();
            frmLookUpStokVeCariHareketleri.frmOtvliSatisFaturasi = this;
            frmLookUpStokVeCariHareketleri.Text = pencereBasligi;
            frmLookUpStokVeCariHareketleri.hangiKod = hangiKod;
            frmLookUpStokVeCariHareketleri.ShowDialog();
        }

        private void ps_yenSatirEkle() {
                this.tblFaturaHareketleriBindingSource.AddNew();
        }
        
        private void ps_satirSil() {
            if (dataSet1.tblFaturaHareketleri.Rows.Count > 1)
            {
                this.tblFaturaHareketleriBindingSource.RemoveCurrent();
            }
            else
            {
                this.tblFaturaHareketleriBindingSource.RemoveCurrent();
                ps_yenSatirEkle();
            }
        }    
        
        private void ps_kdvOranlariniEkle() 
        {
            dataSet1.tblLookUpKDV.Clear();

            DataRow dr = dataSet1.tblLookUpKDV.NewRow();
            dr[0] = 1;
            dr[1] = 0;
            dataSet1.tblLookUpKDV.Rows.Add(dr);

            DataRow dr1 = dataSet1.tblLookUpKDV.NewRow();
            dr1[0] = 2;
            dr1[1] = 1;
            dataSet1.tblLookUpKDV.Rows.Add(dr1);

            DataRow dr2 = dataSet1.tblLookUpKDV.NewRow();
            dr2[0] = 3;
            dr2[1] = 8;
            dataSet1.tblLookUpKDV.Rows.Add(dr2);

            DataRow dr3 = dataSet1.tblLookUpKDV.NewRow();
            dr3[0] = 4;
            dr3[1] = 18;
            dataSet1.tblLookUpKDV.Rows.Add(dr3);        
        }
     
        enum islemTipi
        {
            oku = 0,
            kaydet = 1           
        }
        
        private void ps_kolonlarıOku_Kaydet(islemTipi islemTipi) {
            try
            {
                if (islemTipi == islemTipi.oku)
                {
                    gridControl1.MainView.RestoreLayoutFromXml(Application.StartupPath + "\\KullaniciAyarlari\\" + ID + "_OtvFatura.xml");
                }
                else if (islemTipi == islemTipi.kaydet)
                {
                    gridControl1.MainView.SaveLayoutToXml(Application.StartupPath + "\\KullaniciAyarlari\\" + ID + "_OtvFatura.xml");
                    ps_kolonlarıOku_Kaydet(OtvliSatisFaturasi.islemTipi.oku);
                }
            }
            catch{}    
        }

        public void ps_kayitliFaturayiGetir(string faturaNo) {
            try
            {
                this.tblFaturaHareketleriTableAdapter.kayitliFaturalar(dataSet1.tblFaturaHareketleri, faturaNo);
                ps_GenelToplam();
                ps_MalBedeliHesapla();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        
        public void ps_kayitliFaturaninCarisi(string cariKodu)
        {
            this.tblCariHesaplar1TableAdapter.cariKayitGetir(this.dataSet1.tblCariHesaplar1,cariKodu);

            if (dataSet1.tblCariHesaplar1.Rows.Count > 0)
            {
                DataRow dr = dataSet1.tblCariHesaplar1.Rows[0];
                txtHesapKodu.Text = dr[0].ToString();
                txtUnvan.Text = dr[1].ToString();
                txtUnvan1.Text = dr[2].ToString();
                txtAdres.Text = dr[3].ToString();
                txtAdres1.Text = dr[4].ToString();
                txtAdres2.Text = dr[5].ToString();
                txtVergiDairesiKodu.Text = dr[6].ToString();
                txtVergiDairesi.Text = dr[7].ToString();
                txtVergiNo.Text = dr[8].ToString();
                lblBA.Text = dr[9].ToString();
                txtBA.EditValue = dr[10];
            }
        }
        
        public void ps_kayitliFaturaninOndegerleri(string faturaNo) {
            this.tblEskiKayitOnDegerleriTableAdapter1.Fill(this.dataSet1.tblEskiKayitOnDegerleri,faturaNo);
          
            if (dataSet1.tblEskiKayitOnDegerleri.Rows.Count > 0)
            {
                DataRow dr = dataSet1.tblEskiKayitOnDegerleri.Rows[0];
                txtKod1.Text = dr[colSTK005_Kod1.FieldName].ToString();
                txtKod2.Text = dr[colSTK005_Kod2.FieldName].ToString();
                txtKod3.Text = dr[colSTK005_Kod3.FieldName].ToString();
                txtKod4.Text = dr[colSTK005_Kod4.FieldName].ToString();
                txtKod5.Text = dr[colSTK005_Kod5.FieldName].ToString();
                txtVasita.Text = dr[colSTK005_Vasita.FieldName].ToString();
                txtDepo.Text = dr[colSTK005_Depo.FieldName].ToString();

                txtAciklama.Text = dr["CAR003_Aciklama"].ToString();
                txtAciklama1.Text = dr["CAR003_Aciklama2"].ToString();

                txtCariKod1.Text = dr["CAR003_Kod1"].ToString();
                txtCariKod2.Text = dr["CAR003_Kod2"].ToString();
                txtCariKod3.Text = dr["CAR003_Kod3"].ToString();
                txtCariKod4.Text = dr["CAR003_Kod4"].ToString();
                txtCariKod5.Text = dr["CAR003_Kod5"].ToString();
                txtCariKod6.Text = dr["CAR003_Kod6"].ToString();
                txtCariKod7.Text = dr["CAR003_Kod7"].ToString();
                string aaa = dr["STK005_IslemTarihi"].ToString();
                dtFaturaTarihi.DateTime = (DateTime)dr["STK005_IslemTarihi"];
                dtIrsaliyeTarihi.DateTime = (DateTime)dr["STK005_IrsaliyeFaturaTarihi"]; 
                txtIrsaliyeNo.Text = dr["STK005_IrsaliyeNo"].ToString();
                dtSevkTarihi.DateTime = (DateTime)dr["STK005_SevkTarihi"];
                dtSiparisTarihi.DateTime = (DateTime)dr["STK005_SiparisTarihi"]; 
                txtSiparisNo.Text = dr["STK005_SiparisNo"].ToString();
                dtVadeTarihi.DateTime = (DateTime)dr["STK005_VadeTarihi"];
                dtKdvTarihi.DateTime = (DateTime)dr["STK005_VadeTarihi"];
                dtOtvTarihi.DateTime = (DateTime)dr["STK005_VadeTarihi"];
            }
        }

        private void ps_linkeStokHareketleriniKaydet()
        {
            PcAdi = Environment.UserName.ToString();

            if (PcAdi.ToString().Length > 10)
            {
                PcAdi = PcAdi.ToString().Substring(0, 10);
            }
            string faturaSeriNo = "";

            foreach (DataRow dr in dataSet1.tblFaturaHareketleri.Rows)
            {
                if (dr[colSatirTipi.FieldName].ToString() == "M")
                {

                    #region Stok Hareketlerine Ekle
                    //String Değerler
                    StokMalKodu = dr[colSTK005_MalKodu.FieldName].ToString();

                    CariHesapKodu = txtHesapKodu.Text;

                    if (string.IsNullOrEmpty(CariHesapKodu))
                    {
                        MessageBox.Show("Hesap Kodunu Seçmediniz.Lütfen Kontrol Edip Tekrar Deneyin.");
                        return;
                    }

                    faturaSeriNo = txtFaturaSeri.Text;

                    if (faturaSeriNo.Length == 1)
                    {
                        faturaSeriNo = faturaSeriNo + " ";
                    }

                    EvrakSeriNumarasi = faturaSeriNo + txtFaturaNo.Text;
                    Aciklama1 = dr[colSTK005_Aciklama1.FieldName].ToString();
                    Aciklama2 = dr[colSTK005_Aciklama2.FieldName].ToString();
                    Birim1 = dr[colSTK004_Birim1.FieldName].ToString();
                    Birim2 = dr[colSTK004_Birim2.FieldName].ToString();
                    Birim3 = dr[colSTK004_Birim3.FieldName].ToString();
                    Depo = txtDepo.Text;
                    DovizCinsi = ""; //dr[colSTK005_DovizCinsi.FieldName].ToString();
                    IrsaliyeNo = dr[colSTK005_IrsaliyeNo.FieldName].ToString();
                    KarsiMuhasebeKodu = dr[colSTK005_KarsiMuhasebeKodu.FieldName].ToString();
                    Kod1 = txtKod1.Text;
                    Kod2 = txtKod2.Text;
                    Kod3 = txtKod3.Text;
                    Kod4 = txtKod4.Text;
                    Kod5 = txtKod5.Text;
                    Kod6 = dr[colSTK005_Kod6.FieldName].ToString();
                    Kod7 = dr[colSTK005_Kod7.FieldName].ToString();
                    Kod8 = dr[colSTK005_Kod8.FieldName].ToString();
                    Kod9 = dr[colSTK005_Kod9.FieldName].ToString();
                    Kod10 = dr[colSTK005_Kod10.FieldName].ToString();
                    MasrafMerkezi = dr[colSTK005_MasrafMerkezi.FieldName].ToString();
                    MalSeriNo = dr[colSTK005_MalSeriNo.FieldName].ToString();
                    SiparisNo = txtSiparisNo.Text;
                    TeslimChdKodu = txtHesapKodu.Text;

                    if (!string.IsNullOrEmpty(txtHesapKodu2.Text))
                    {
                        TeslimChdKodu = txtHesapKodu2.Text;
                    }

                    Vasita = txtVasita.Text;
                    //Decimal Değerler
                    Miktari = (decimal)dr[colSTK005_Miktari.FieldName];
                    BirimFiyati = (decimal)dr[colSTK005_BirimFiyati.FieldName];
                    Tutari = (decimal)dr[colSTK005_Tutari.FieldName];
                    BirimAgirligi = (decimal)dr[colSTK004_BirimAgirligi.FieldName];
                    DovizKuru = (decimal)dr[colSTK005_DovizKuru.FieldName];
                    DovizTutari = (decimal)dr[colSTK005_DovizTutari.FieldName];
                    Iskonto = (decimal)dr[colSTK005_Iskonto.FieldName];
                    KafileBuyuklugu = (decimal)dr[colSTK004_KafileBuyuklugu.FieldName];
                    KdvTutari = (decimal)dr[colSTK005_KDVTutari.FieldName];
                    Kod11 = (decimal)dr[colSTK005_Kod11.FieldName];
                    Kod12 = (decimal)dr[colSTK005_Kod12.FieldName];
                    Masraf = (decimal)dr[colSTK005_Masraf.FieldName];
                    Miktar2 = (decimal)dr[colSTK005_Miktar2.FieldName];
                    KalemIskontoOrani1 = (decimal)dr[colSTK005_KalemIskontoOrani1.FieldName];
                    KalemIskontoOrani2 = (decimal)dr[colSTK005_KalemIskontoOrani2.FieldName];
                    KalemIskontoOrani3 = (decimal)dr[colSTK005_KalemIskontoOrani3.FieldName];
                    KalemIskontoOrani4 = (decimal)dr[colSTK005_KalemIskontoOrani4.FieldName];
                    KalemIskontoOrani5 = (decimal)dr[colSTK005_KalemIskontoOrani5.FieldName];
                    KalemIskontoTutari1 = (decimal)dr[colSTK005_KalemIskontoTutari1.FieldName];
                    KalemIskontoTutari2 = (decimal)dr[colSTK005_KalemIskontoTutari2.FieldName];
                    KalemIskontoTutari3 = (decimal)dr[colSTK005_KalemIskontoTutari3.FieldName];
                    KalemIskontoTutari4 = (decimal)dr[colSTK005_KalemIskontoTutari4.FieldName];
                    KalemIskontoTutari5 = (decimal)dr[colSTK005_KalemIskontoTutari5.FieldName];
                    Tutar2 = (decimal)dr[colSTK005_Tutar2.FieldName];
                    OtvTutari = (decimal)dr[colOtvTutari.FieldName];
                    //Byte Değerler
                    ParaBirimi = (byte)dr[colSTK005_ParaBirimi.FieldName];
                    KdvOranFlag = (byte)dr[colSTK005_KDVOranFlag.FieldName];
                    KdvDurumu = (byte)dr[colSTK005_KDVDurumu.FieldName];
                    MuhasebelesmeDurumu = (byte)dr[colSTK005_MuhasebelesmeDurumu.FieldName];
                    islemTipimiz = cmbIslemTipi.SelectedIndex;
                    //Tarih İşlemleri
                    //Tarih İşlemleri
                    string IslemTarihimiz = Convert.ToString(DateTime.Now.ToOADate());
                    IslemTarihimiz = IslemTarihimiz.ToString().Substring(0, 5);
                    IslemTarihi = Convert.ToInt32(IslemTarihimiz);
                    //Irsaliye Tarihi
                    string IrsaliyeFaturaTarihimiz = Convert.ToString(DateTime.Now.ToOADate());
                    IrsaliyeFaturaTarihimiz = IrsaliyeFaturaTarihimiz.ToString().Substring(0, 5);
                    IrsaliyeFaturaTarihi = Convert.ToInt32(IrsaliyeFaturaTarihimiz);
                    //Vade Tarihimiz
                    string VadeTarihimiz = Convert.ToString(dtVadeTarihi.DateTime.ToOADate());
                    VadeTarihimiz = VadeTarihimiz.ToString().Substring(0, 5);
                    VadeTarihi = Convert.ToInt32(VadeTarihimiz);
                    //Giren Tarihimiz
                    string GirenTarihimiz = Convert.ToString(DateTime.Now.ToOADate());
                    GirenTarihimiz = GirenTarihimiz.ToString().Substring(0, 5);
                    GirenTarih = Convert.ToInt32(GirenTarihimiz);
                    //
                    if (string.IsNullOrEmpty(dtSevkTarihi.Text))
                    {
                        SevkTarihi = 0;
                    }
                    else
                    {
                        string SevkTarihimiz = Convert.ToString(dtSevkTarihi.DateTime.ToOADate());
                        SevkTarihimiz = SevkTarihimiz.ToString().Substring(0, 5);
                        SevkTarihi = Convert.ToInt32(SevkTarihimiz);
                    }

                    if (string.IsNullOrEmpty(dtSiparisTarihi.Text))
                    {
                        SiparisTarihi = 0;
                    }
                    else
                    {
                        string SiparisTarihimiz = Convert.ToString(dtSiparisTarihi.DateTime.ToOADate());
                        SiparisTarihimiz = SiparisTarihimiz.ToString().Substring(0, 5);
                        SiparisTarihi = Convert.ToInt32(SiparisTarihimiz);
                    }
                    //
                    DateTime DtSaat = DateTime.Now;
                    GirenSaat = Convert.ToString(DtSaat);
                    GirenSaat = GirenSaat.ToString().Substring(11, 8);
                    GirenSaat = GirenSaat.ToString().Replace(":", "");

                    if (GirenSaat.ToString().Length > 8)
                    {
                        GirenSaat = GirenSaat.ToString().Substring(0, 8);
                    }

                    if (!string.IsNullOrEmpty(IrsaliyeNo))
                    {
                        this.evrakNoSeriTableAdapter1.IrsaliyeDurumGuncelle(EvrakSeriNumarasi, 2, Miktari, IrsaliyeNo);
                    }
                    //Insert Yapıyoruz
                    this.queriesTableAdapter1.stokHareketiEkle(StokMalKodu, IslemTarihi, CariHesapKodu, EvrakSeriNumarasi, Miktari, BirimFiyati, Tutari,
                       Iskonto, KdvTutari, islemTipimiz, Kod1, Kod2, IrsaliyeNo, KdvDurumu, ParaBirimi, this.queriesTableAdapter1.stk005SonSeqNo(), GirenTarih, GirenSaat, PcAdi, GirenTarih, GirenSaat, PcAdi, GirenTarih, SevkTarihi, 0,
                       OtvTutari, Miktar2, Tutar2, KalemIskontoOrani1, KalemIskontoOrani2, KalemIskontoOrani3, KalemIskontoOrani4, KalemIskontoOrani5, KalemIskontoTutari1,
                       KalemIskontoTutari2, KalemIskontoTutari3, KalemIskontoTutari4, KalemIskontoTutari5, DovizCinsi, DovizTutari, DovizKuru, Aciklama1, Aciklama2, Depo, Kod3,
                       Kod4, Kod5, Kod6, Kod7, Kod8, Kod9, Kod10, Kod11, Kod12, Vasita, MalSeriNo, "", SiparisNo, VadeTarihi, IrsaliyeFaturaTarihi, SiparisTarihi, Masraf, 0, MasrafMerkezi, 0,
                       0, KdvOranFlag, TeslimChdKodu);
                    #endregion

                    #region Siparişleri Güncelliyoruz

                    if (!string.IsNullOrEmpty(SiparisNo))
                    {
                        byte SipDurumu = 0;

                        TeslimMiktari = (int)this.queriesTableAdapter1.TeslimMiktari(SiparisNo, StokMalKodu);

                        if (Miktari >= TeslimMiktari)
                        {
                            SipDurumu = 1;
                        }

                        TeslimMiktari = TeslimMiktari + Miktari;
                        this.queriesTableAdapter1.SiparisGuncelle(EvrakSeriNumarasi, TeslimMiktari, SipDurumu, GirenTarih, GirenSaat, PcAdi, SiparisNo, StokMalKodu);
                    }

                    #endregion

                    #region Stok Kartını Güncelle
                    if (string.IsNullOrEmpty(dr[colSTK005_IrsaliyeNo.FieldName].ToString()))
                    {
                    this.queriesTableAdapter1.stokKartiGuncelle((decimal)dr[colSTK005_Miktari.FieldName],Miktar2,
                (decimal)dr[colSTK005_Tutari.FieldName],
                (decimal)dr[colSTK005_Iskonto.FieldName],
                (int)dtFaturaTarihi.DateTime.ToOADate(),
                txtFaturaSeri.Text + txtFaturaNo.Text,
                0,
                txtHesapKodu.Text,(decimal)dr[colSTK005_DovizTutari.FieldName],
                dr[colSTK005_MalKodu.FieldName].ToString());
                    }

                    #endregion
                }

            }
        }
        
        private void ps_linkeCariHareketleriKaydet() 
        {
            short kayitSayisi = Convert.ToInt16(dataSet1.tblFaturaHareketleri.Rows.Count + 1);
            string IrsaliyeFaturaTarihimiz = Convert.ToString(dtFaturaTarihi.DateTime.ToOADate());
            IrsaliyeFaturaTarihimiz = IrsaliyeFaturaTarihimiz.ToString().Substring(0, 5);
            IrsaliyeFaturaTarihi = Convert.ToInt32(IrsaliyeFaturaTarihimiz);

            foreach (DataRow dr in dataSet1.tblFaturaHareketleri.Rows)
            {
                if (dr[colSatirTipi.FieldName].ToString() == "A")
                {
                    this.queriesTableAdapter1.cariHareketSatiriEkle(15,//Z
                         IrsaliyeFaturaTarihi, txtFaturaSeri.Text + txtFaturaNo.Text, "B", 4, "A", kayitSayisi++, "", "", dr[colSTK004_Aciklama.FieldName].ToString(), txtHesapKodu.Text, 0, 0);
                }
            }

            this.queriesTableAdapter1.cariHareketSatiriEkle(15,//Z
                IrsaliyeFaturaTarihi, txtFaturaSeri.Text + txtFaturaNo.Text, "B", 4, "Z", kayitSayisi++, "", "", "", txtHesapKodu.Text, 0, 0);

            this.queriesTableAdapter1.cariHareketSatiriEkle(15,//T
                 IrsaliyeFaturaTarihi, txtFaturaSeri.Text + txtFaturaNo.Text, "B", 4, "T", kayitSayisi++, "", "", "MAL BEDELİ", txtHesapKodu.Text, Convert.ToDecimal(txtMalBedeli.EditValue), 0);

            this.queriesTableAdapter1.cariHareketSatiriEkle(15,//I
                 IrsaliyeFaturaTarihi, txtFaturaSeri.Text + txtFaturaNo.Text, "B", 4, "I", kayitSayisi++, "", "1", "İSKONTO", txtHesapKodu.Text, Convert.ToDecimal(txtIskonto.EditValue), 0);

            this.queriesTableAdapter1.cariHareketSatiriEkle(15,//Z
                  IrsaliyeFaturaTarihi, txtFaturaSeri.Text + txtFaturaNo.Text, "B", 4, "Z", kayitSayisi++, "", "1", "", txtHesapKodu.Text, 0, 0);

            this.queriesTableAdapter1.cariHareketSatiriEkle(15,//N
                IrsaliyeFaturaTarihi, txtFaturaSeri.Text + txtFaturaNo.Text, "B", 4, "N", kayitSayisi++, "", "1", "NET TOPLAM", txtHesapKodu.Text, Convert.ToDecimal(txtNetTutar.EditValue), 0);

            this.queriesTableAdapter1.cariHareketSatiriEkle(15,//O
                 IrsaliyeFaturaTarihi, txtFaturaSeri.Text + txtFaturaNo.Text, "B", 4, "O", kayitSayisi++, "", "1", "ÖZEL TÜKETİM VERGİSİ", txtHesapKodu.Text, Convert.ToDecimal(txtOtv.EditValue), 0);

            this.queriesTableAdapter1.cariHareketSatiriEkle(15,//U
                IrsaliyeFaturaTarihi, txtFaturaSeri.Text + txtFaturaNo.Text, "B", 4, "U", kayitSayisi++, "", "1", "KDV MATRAHI", txtHesapKodu.Text, Convert.ToDecimal(txtKdvMatrahi.EditValue), 0);

            this.queriesTableAdapter1.cariHareketSatiriEkle(15,//K
                IrsaliyeFaturaTarihi, txtFaturaSeri.Text + txtFaturaNo.Text, "B", 4, "K", kayitSayisi++, "", "1", "KATMA DEĞER VEGİSİ", txtHesapKodu.Text, Convert.ToDecimal(txtKdv.EditValue), 0);

            this.queriesTableAdapter1.cariHareketSatiriEkle(15,//Z
                IrsaliyeFaturaTarihi, txtFaturaSeri.Text + txtFaturaNo.Text, "B", 4, "Z", kayitSayisi++, "", "1", "", txtHesapKodu.Text, 0, 0);

            this.queriesTableAdapter1.cariHareketSatiriEkle(15,//K
                  IrsaliyeFaturaTarihi, txtFaturaSeri.Text + txtFaturaNo.Text, "B", 4, "G", kayitSayisi++, "", "1", "GENEL TOPLAM", txtHesapKodu.Text, Convert.ToDecimal(txtGenelToplam.EditValue), 0);

            this.queriesTableAdapter1.cariHareketSatiriEkle(15,//Z
                IrsaliyeFaturaTarihi, txtFaturaSeri.Text + txtFaturaNo.Text, "B", 4, "Y", kayitSayisi++, "", "1", "", txtHesapKodu.Text, 0, 0);

            //A 349607	B	4	Z	3		B	            	        M0158	0.00	0.00
            //A 349607	B	4	T	4		B	            MAL BEDELİ	M0158	2614.84	0.00
            //A 349607	B	4	I	5		1	               İSKONTO	M0158	653.71	25.00
            //A 349607	B	4	Z	6		1	                       	M0158	0.00	0.00
            //A 349607	B	4	N	7		1	            NET TOPLAM	M0158	1961.13	0.00
            //A 349607	B	4	O	8		1	ÖZEL TÜKETİM VERGİSİ	M0158	255.78	0.00
            //A 349607	B	4	U	9		1	            KDV MATRAHI	M0158	2216.91	0.00
            //A 349607	B	4	K	10		1	    KATMA DEĞER VEGİSİ	M0158	399.04	18.00
            //A 349607	B	4	Z	11		1	                    	M0158	0.00	0.00
            //A 349607	B	4	G	12		1	        GENEL TOPLAM	M0158	2615.95	0.00
            //A 349607	B	4	Y	13		1	                    	M0158	0.00	0.00
            int taksitsayimiz = Convert.ToInt32(txtTaksitSayisi.Text);

            if (taksitsayimiz == 1)
            {
                this.queriesTableAdapter1.car003HareketEkle(txtHesapKodu.Text,
               (int)dtFaturaTarihi.DateTime.ToOADate(), 4, txtFaturaSeri.Text + txtFaturaNo.Text
                , txtAciklama.Text, (decimal)txtMalBedeli.EditValue, (int)dtVadeTarihi.DateTime.ToOADate(), "", txtCariKod1.Text
                , txtCariKod2.Text,
                this.queriesTableAdapter1.car003SonSeqNo(),
                (int)DateTime.Now.ToOADate(),
                DateTime.Now.ToShortTimeString(), "", 0,
                txtHesapKodu.Text, txtCariKod3.Text, txtCariKod4.Text, txtCariKod5.Text, txtCariKod6.Text, txtCariKod7.Text, "", "", "", 0, 0, txtAciklama1.Text,
                "", "", 0, 0, "0", 1);
            }
            else if (taksitsayimiz > 1)
            {
                decimal TaksitNetTutari = Convert.ToDecimal(txtNetTutar.Text);
                decimal TaksitIskonto = Convert.ToDecimal(txtIskonto.Text);
                decimal TaksitPesinat = Convert.ToDecimal(txtTaksitPesinat.Text);
                TaksitNetTutari = TaksitNetTutari - TaksitIskonto - TaksitPesinat;
                decimal TaksitTutarlari = TaksitNetTutari / taksitsayimiz;

                for (int i = 0; i < taksitsayimiz; i++)
                {
                    if (i == 0)
                    {
                        if (TaksitPesinat > 0)
                        {
                            string TaksitPesinatVademiz = Convert.ToString(dtPesinatTarihi.DateTime.ToOADate());
                            TaksitPesinatVademiz = TaksitPesinatVademiz.ToString().Substring(0, 5);
                            VadeTarihi = Convert.ToInt32(TaksitPesinatVademiz);

                            //Peşinatı Ekliyoruz
                            this.queriesTableAdapter1.car003HareketEkle(txtHesapKodu.Text,(int)dtFaturaTarihi.DateTime.ToOADate(), 4, txtFaturaSeri.Text + txtFaturaNo.Text,txtAciklama.Text, TaksitPesinat, VadeTarihi, "", txtCariKod1.Text,txtCariKod2.Text,
                            this.queriesTableAdapter1.car003SonSeqNo(),(int)DateTime.Now.ToOADate(),DateTime.Now.ToShortTimeString(), "", 0,
                            txtHesapKodu.Text, txtCariKod3.Text, txtCariKod4.Text, txtCariKod5.Text, txtCariKod6.Text, txtCariKod7.Text, "", "", "", 0, 0, txtAciklama1.Text,
                            "", "", 0, 0, "0", 1);
                       
                        }
                        if (TaksitPesinat == 0)
                        {
                            this.queriesTableAdapter1.car003HareketEkle(txtHesapKodu.Text,
                            (int)dtFaturaTarihi.DateTime.ToOADate(), 4, txtFaturaSeri.Text + txtFaturaNo.Text,txtAciklama.Text, 0, VadeTarihi, "", txtCariKod1.Text,txtCariKod2.Text,
                            this.queriesTableAdapter1.car003SonSeqNo(),(int)DateTime.Now.ToOADate(),DateTime.Now.ToShortTimeString(), "", 0,
                            txtHesapKodu.Text, txtCariKod3.Text, txtCariKod4.Text, txtCariKod5.Text, txtCariKod6.Text, txtCariKod7.Text, "", "", "", 0, 0, txtAciklama1.Text,
                            "", "", 0, 0, "0", 1);
                        }
                       //Normal Taksiti Ekliyoruz
                        string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                        TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                        VadeTarihi = Convert.ToInt32(TaksitVademiz);
                        VadeTarihi = VadeTarihi + 30;

                        this.queriesTableAdapter1.car003HareketEkle(txtHesapKodu.Text,(int)dtFaturaTarihi.DateTime.ToOADate(), 4, txtFaturaSeri.Text + txtFaturaNo.Text,txtAciklama.Text, TaksitTutarlari, VadeTarihi, "", txtCariKod1.Text,txtCariKod2.Text,
                        this.queriesTableAdapter1.car003SonSeqNo(),(int)DateTime.Now.ToOADate(),DateTime.Now.ToShortTimeString(), "", 0,
                        txtHesapKodu.Text, txtCariKod3.Text, txtCariKod4.Text, txtCariKod5.Text, txtCariKod6.Text, txtCariKod7.Text, "", "", "", 0, 0, txtAciklama1.Text,
                        "", "", 0, 0, "0", 1);


                    }
                    else if (i == 1)
                    {
                        string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                        TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                        VadeTarihi = Convert.ToInt32(TaksitVademiz);
                        VadeTarihi = VadeTarihi + 60;

                        this.queriesTableAdapter1.car003HareketEkle(txtHesapKodu.Text, (int)dtFaturaTarihi.DateTime.ToOADate(), 4, txtFaturaSeri.Text + txtFaturaNo.Text, txtAciklama.Text, TaksitTutarlari, VadeTarihi, "", txtCariKod1.Text, txtCariKod2.Text,
                        this.queriesTableAdapter1.car003SonSeqNo(), (int)DateTime.Now.ToOADate(), DateTime.Now.ToShortTimeString(), "", 0,
                        txtHesapKodu.Text, txtCariKod3.Text, txtCariKod4.Text, txtCariKod5.Text, txtCariKod6.Text, txtCariKod7.Text, "", "", "", 0, 0, txtAciklama1.Text,
                        "", "", 0, 0, "0", 1);

                    }
                    else if (i == 2)
                    {
                        string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                        TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                        VadeTarihi = Convert.ToInt32(TaksitVademiz);
                        VadeTarihi = VadeTarihi + 90;

                        this.queriesTableAdapter1.car003HareketEkle(txtHesapKodu.Text, (int)dtFaturaTarihi.DateTime.ToOADate(), 4, txtFaturaSeri.Text + txtFaturaNo.Text, txtAciklama.Text, TaksitTutarlari, VadeTarihi, "", txtCariKod1.Text, txtCariKod2.Text,
                        this.queriesTableAdapter1.car003SonSeqNo(), (int)DateTime.Now.ToOADate(), DateTime.Now.ToShortTimeString(), "", 0,
                        txtHesapKodu.Text, txtCariKod3.Text, txtCariKod4.Text, txtCariKod5.Text, txtCariKod6.Text, txtCariKod7.Text, "", "", "", 0, 0, txtAciklama1.Text,
                        "", "", 0, 0, "0", 1);

                    }
                    else if (i == 3)
                    {

                        string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                        TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                        VadeTarihi = Convert.ToInt32(TaksitVademiz);
                        VadeTarihi = VadeTarihi + 120;

                        this.queriesTableAdapter1.car003HareketEkle(txtHesapKodu.Text, (int)dtFaturaTarihi.DateTime.ToOADate(), 4, txtFaturaSeri.Text + txtFaturaNo.Text, txtAciklama.Text, TaksitTutarlari, VadeTarihi, "", txtCariKod1.Text, txtCariKod2.Text,
                        this.queriesTableAdapter1.car003SonSeqNo(), (int)DateTime.Now.ToOADate(), DateTime.Now.ToShortTimeString(), "", 0,
                        txtHesapKodu.Text, txtCariKod3.Text, txtCariKod4.Text, txtCariKod5.Text, txtCariKod6.Text, txtCariKod7.Text, "", "", "", 0, 0, txtAciklama1.Text,
                        "", "", 0, 0, "0", 1);

                    }
                    else if (i == 4)
                    {
                        string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                        TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                        VadeTarihi = Convert.ToInt32(TaksitVademiz);
                        VadeTarihi = VadeTarihi + 150;

                        this.queriesTableAdapter1.car003HareketEkle(txtHesapKodu.Text, (int)dtFaturaTarihi.DateTime.ToOADate(), 4, txtFaturaSeri.Text + txtFaturaNo.Text, txtAciklama.Text, TaksitTutarlari, VadeTarihi, "", txtCariKod1.Text, txtCariKod2.Text,
                        this.queriesTableAdapter1.car003SonSeqNo(), (int)DateTime.Now.ToOADate(), DateTime.Now.ToShortTimeString(), "", 0,
                        txtHesapKodu.Text, txtCariKod3.Text, txtCariKod4.Text, txtCariKod5.Text, txtCariKod6.Text, txtCariKod7.Text, "", "", "", 0, 0, txtAciklama1.Text,
                        "", "", 0, 0, "0", 1);

                    }
                    else if (i == 5)
                    {
                        string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                        TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                        VadeTarihi = Convert.ToInt32(TaksitVademiz);
                        VadeTarihi = VadeTarihi + 180;

                        this.queriesTableAdapter1.car003HareketEkle(txtHesapKodu.Text, (int)dtFaturaTarihi.DateTime.ToOADate(), 4, txtFaturaSeri.Text + txtFaturaNo.Text, txtAciklama.Text, TaksitTutarlari, VadeTarihi, "", txtCariKod1.Text, txtCariKod2.Text,
                        this.queriesTableAdapter1.car003SonSeqNo(), (int)DateTime.Now.ToOADate(), DateTime.Now.ToShortTimeString(), "", 0,
                        txtHesapKodu.Text, txtCariKod3.Text, txtCariKod4.Text, txtCariKod5.Text, txtCariKod6.Text, txtCariKod7.Text, "", "", "", 0, 0, txtAciklama1.Text,
                        "", "", 0, 0, "0", 1);

                    }
                    else if (i == 6)
                    {
                        string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                        TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                        VadeTarihi = Convert.ToInt32(TaksitVademiz);
                        VadeTarihi = VadeTarihi + 210;

                        this.queriesTableAdapter1.car003HareketEkle(txtHesapKodu.Text, (int)dtFaturaTarihi.DateTime.ToOADate(), 4, txtFaturaSeri.Text + txtFaturaNo.Text, txtAciklama.Text, TaksitTutarlari, VadeTarihi, "", txtCariKod1.Text, txtCariKod2.Text,
                        this.queriesTableAdapter1.car003SonSeqNo(), (int)DateTime.Now.ToOADate(), DateTime.Now.ToShortTimeString(), "", 0,
                        txtHesapKodu.Text, txtCariKod3.Text, txtCariKod4.Text, txtCariKod5.Text, txtCariKod6.Text, txtCariKod7.Text, "", "", "", 0, 0, txtAciklama1.Text,
                        "", "", 0, 0, "0", 1);

                    }
                    else if (i == 7)
                    {
                        string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                        TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                        VadeTarihi = Convert.ToInt32(TaksitVademiz);
                        VadeTarihi = VadeTarihi + 240;

                        this.queriesTableAdapter1.car003HareketEkle(txtHesapKodu.Text, (int)dtFaturaTarihi.DateTime.ToOADate(), 4, txtFaturaSeri.Text + txtFaturaNo.Text, txtAciklama.Text, TaksitTutarlari, VadeTarihi, "", txtCariKod1.Text, txtCariKod2.Text,
                        this.queriesTableAdapter1.car003SonSeqNo(), (int)DateTime.Now.ToOADate(), DateTime.Now.ToShortTimeString(), "", 0,
                        txtHesapKodu.Text, txtCariKod3.Text, txtCariKod4.Text, txtCariKod5.Text, txtCariKod6.Text, txtCariKod7.Text, "", "", "", 0, 0, txtAciklama1.Text,
                        "", "", 0, 0, "0", 1);

                    }
                    else if (i == 8)
                    {
                        string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                        TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                        VadeTarihi = Convert.ToInt32(TaksitVademiz);
                        VadeTarihi = VadeTarihi + 270;

                        this.queriesTableAdapter1.car003HareketEkle(txtHesapKodu.Text, (int)dtFaturaTarihi.DateTime.ToOADate(), 4, txtFaturaSeri.Text + txtFaturaNo.Text, txtAciklama.Text, TaksitTutarlari, VadeTarihi, "", txtCariKod1.Text, txtCariKod2.Text,
                        this.queriesTableAdapter1.car003SonSeqNo(), (int)DateTime.Now.ToOADate(), DateTime.Now.ToShortTimeString(), "", 0,
                        txtHesapKodu.Text, txtCariKod3.Text, txtCariKod4.Text, txtCariKod5.Text, txtCariKod6.Text, txtCariKod7.Text, "", "", "", 0, 0, txtAciklama1.Text,
                        "", "", 0, 0, "0", 1);

                    }
                    else if (i == 9)
                    {
                        string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                        TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                        VadeTarihi = Convert.ToInt32(TaksitVademiz);
                        VadeTarihi = VadeTarihi + 300;

                        this.queriesTableAdapter1.car003HareketEkle(txtHesapKodu.Text, (int)dtFaturaTarihi.DateTime.ToOADate(), 4, txtFaturaSeri.Text + txtFaturaNo.Text, txtAciklama.Text, TaksitTutarlari, VadeTarihi, "", txtCariKod1.Text, txtCariKod2.Text,
                        this.queriesTableAdapter1.car003SonSeqNo(), (int)DateTime.Now.ToOADate(), DateTime.Now.ToShortTimeString(), "", 0,
                        txtHesapKodu.Text, txtCariKod3.Text, txtCariKod4.Text, txtCariKod5.Text, txtCariKod6.Text, txtCariKod7.Text, "", "", "", 0, 0, txtAciklama1.Text,
                        "", "", 0, 0, "0", 1);

                    }
                    else if (i == 10)
                    {
                        string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                        TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                        VadeTarihi = Convert.ToInt32(TaksitVademiz);
                        VadeTarihi = VadeTarihi + 330;

                        this.queriesTableAdapter1.car003HareketEkle(txtHesapKodu.Text, (int)dtFaturaTarihi.DateTime.ToOADate(), 4, txtFaturaSeri.Text + txtFaturaNo.Text, txtAciklama.Text, TaksitTutarlari, VadeTarihi, "", txtCariKod1.Text, txtCariKod2.Text,
                        this.queriesTableAdapter1.car003SonSeqNo(), (int)DateTime.Now.ToOADate(), DateTime.Now.ToShortTimeString(), "", 0,
                        txtHesapKodu.Text, txtCariKod3.Text, txtCariKod4.Text, txtCariKod5.Text, txtCariKod6.Text, txtCariKod7.Text, "", "", "", 0, 0, txtAciklama1.Text,
                        "", "", 0, 0, "0", 1);

                    }
                    else if (i == 11)
                    {
                        string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                        TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                        VadeTarihi = Convert.ToInt32(TaksitVademiz);
                        VadeTarihi = VadeTarihi + 360;

                        this.queriesTableAdapter1.car003HareketEkle(txtHesapKodu.Text, (int)dtFaturaTarihi.DateTime.ToOADate(), 4, txtFaturaSeri.Text + txtFaturaNo.Text, txtAciklama.Text, TaksitTutarlari, VadeTarihi, "", txtCariKod1.Text, txtCariKod2.Text,
                        this.queriesTableAdapter1.car003SonSeqNo(), (int)DateTime.Now.ToOADate(), DateTime.Now.ToShortTimeString(), "", 0,
                        txtHesapKodu.Text, txtCariKod3.Text, txtCariKod4.Text, txtCariKod5.Text, txtCariKod6.Text, txtCariKod7.Text, "", "", "", 0, 0, txtAciklama1.Text,
                        "", "", 0, 0, "0", 1);

                    }
                }
            }

            this.queriesTableAdapter1.car003HareketEkle(txtHesapKodu.Text, (int)dtFaturaTarihi.DateTime.ToOADate(), 5, txtFaturaSeri.Text + txtFaturaNo.Text
     , txtAciklama.Text, (decimal)txtIskonto.EditValue, (int)dtVadeTarihi.DateTime.ToOADate(), "", txtCariKod1.Text
     , txtCariKod2.Text, this.queriesTableAdapter1.car003SonSeqNo(), (int)DateTime.Now.ToOADate(), DateTime.Now.ToShortTimeString(), "", 0,
     txtHesapKodu.Text, txtCariKod3.Text, txtCariKod4.Text, txtCariKod5.Text, txtCariKod6.Text, txtCariKod7.Text, "", "", "", 0, 0, txtAciklama1.Text,
     "", "", 0, 0, "0", 0);

            this.queriesTableAdapter1.car003HareketEkle(txtHesapKodu.Text, (int)dtFaturaTarihi.DateTime.ToOADate(), 6, txtFaturaSeri.Text + txtFaturaNo.Text
     , txtAciklama.Text, (decimal)txtKdv.EditValue, Convert.ToInt32(dtVadeTarihi.DateTime.ToOADate()), "", txtCariKod1.Text
     , txtCariKod2.Text, this.queriesTableAdapter1.car003SonSeqNo(), (int)DateTime.Now.ToOADate(), DateTime.Now.ToShortTimeString(), "", 0,
     txtHesapKodu.Text, txtCariKod3.Text, txtCariKod4.Text, txtCariKod5.Text, txtCariKod6.Text, txtCariKod7.Text, "", "", "", 0, 0, txtAciklama1.Text,
     "", "", 0, 0, "0", 0);

            this.queriesTableAdapter1.car003HareketEkle(txtHesapKodu.Text, (int)dtFaturaTarihi.DateTime.ToOADate(), 71, txtFaturaSeri.Text + txtFaturaNo.Text
     , txtAciklama.Text, (decimal)txtOtv.EditValue, Convert.ToInt32(dtVadeTarihi.DateTime.ToOADate()), "", txtCariKod1.Text
     , txtCariKod2.Text, this.queriesTableAdapter1.car003SonSeqNo(), (int)DateTime.Now.ToOADate(), DateTime.Now.ToShortTimeString(), "", 0,
     txtHesapKodu.Text, txtCariKod3.Text, txtCariKod4.Text, txtCariKod5.Text, txtCariKod6.Text, txtCariKod7.Text, "", "", "", 0, 0, txtAciklama1.Text,
     "", "", 0, 0, "1", 0);
        
        
        }//Cari Hareket Ekle Z-Y-I-Z-N-K-G
        
        private void ps_linkteCariKartBakiyesiniGuncelle() {
            try
            {
                this.queriesTableAdapter1.cariBakiyeGuncelle((decimal)txtNetTutar.EditValue, (decimal)txtKdv.EditValue, 
                    (decimal)txtOtv.EditValue, Convert.ToInt32(dtFaturaTarihi.DateTime.ToOADate()),
                    (decimal)txtDovizNetToplam.EditValue,(decimal)txtDovizOtv.EditValue,(decimal)txtDovizKdv.EditValue, 
                    txtHesapKodu.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:CAR002|CariBakiye:" + ex.Message.ToString());
            }
        }//Cari kartların bakiyeleri || tek hareket
        
        private void ps_faturaKaydet() {
            try
            {
                if (string.IsNullOrEmpty(txtHesapKodu.Text))
                {
                    MessageBox.Show("Hesap Kodu Boş Geçilemez!");
                    return;
                }
                else
                {
                    if (dataSet1.tblFaturaHareketleri.Rows.Count < 1)
                    {
                        MessageBox.Show("Fatura Kalemi Girilmedi!");
                        return;
                    }
                    else
                    {
                        ps_linkeStokHareketleriniKaydet();
                        ps_linkteCariKartBakiyesiniGuncelle();
                        ps_linkeCariHareketleriKaydet();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ps_EvrakSeri_EvrakNo_Getir()
        {
            txtFaturaSeri.Text = this.queriesTableAdapter1.blaserEvrakSeri(1).ToString();

            int evrakNo = (int)this.queriesTableAdapter1.blaserEvrakNo(1);//1 Satış
            string strEvrakNo = null;

            for (int i = evrakNo.ToString().Length; i < 6; i++)
            {
                strEvrakNo += 0;
            }

            strEvrakNo += evrakNo.ToString();
            txtFaturaNo.Text = strEvrakNo;
        }

        private void TaksitSil()
        {
            txtTaksit1.Text = "";
            txtTaksit2.Text = "";
            txtTaksit3.Text = "";
            txtTaksit4.Text = "";
            txtTaksit5.Text = "";
            txtTaksit6.Text = "";
            txtTaksit7.Text = "";
            txtTaksit8.Text = "";
            txtTaksit9.Text = "";
            txtTaksit10.Text = "";
            txtTaksit11.Text = "";
            txtTaksit12.Text = "";

            dtTaksit1.EditValue = null;
            dtTaksit2.EditValue = null;
            dtTaksit3.EditValue = null;
            dtTaksit4.EditValue = null;
            dtTaksit5.EditValue = null;
            dtTaksit6.EditValue = null;
            dtTaksit7.EditValue = null;
            dtTaksit8.EditValue = null;
            dtTaksit9.EditValue = null;
            dtTaksit10.EditValue = null;
            dtTaksit11.EditValue = null;
            dtTaksit12.EditValue = null;

        }

        private void TopluIrsaliyeSil()
        {
            txtIrsaliyeNo.Text = "";
            txt30luIrsaliyeNo1.Text = "";
            txt30luIrsaliyeNo2.Text = "";
            txt30luIrsaliyeNo3.Text = "";
            txt30luIrsaliyeNo4.Text = "";
            txt30luIrsaliyeNo5.Text = "";
            txt30luIrsaliyeNo6.Text = "";
            txt30luIrsaliyeNo7.Text = "";
            txt30luIrsaliyeNo8.Text = "";
            txt30luIrsaliyeNo9.Text = "";
            txt30luIrsaliyeNo10.Text = "";
            txt30luIrsaliyeNo11.Text = "";
            txt30luIrsaliyeNo12.Text = "";
            txt30luIrsaliyeNo13.Text = "";
            txt30luIrsaliyeNo14.Text = "";
            txt30luIrsaliyeNo15.Text = "";
            txt30luIrsaliyeNo16.Text = "";
            txt30luIrsaliyeNo17.Text = "";
            txt30luIrsaliyeNo18.Text = "";
            txt30luIrsaliyeNo19.Text = "";
            txt30luIrsaliyeNo20.Text = "";
            txt30luIrsaliyeNo21.Text = "";
            txt30luIrsaliyeNo22.Text = "";
            txt30luIrsaliyeNo23.Text = "";
            txt30luIrsaliyeNo24.Text = "";
            txt30luIrsaliyeNo25.Text = "";
            txt30luIrsaliyeNo26.Text = "";
            txt30luIrsaliyeNo27.Text = "";
            txt30luIrsaliyeNo28.Text = "";
            txt30luIrsaliyeNo29.Text = "";
            txt30luIrsaliyeNo30.Text = "";

            txt30luIrsaliyeSeri1.Text = "";
            txt30luIrsaliyeSeri2.Text = "";
            txt30luIrsaliyeSeri3.Text = "";
            txt30luIrsaliyeSeri4.Text = "";
            txt30luIrsaliyeSeri5.Text = "";
            txt30luIrsaliyeSeri6.Text = "";
            txt30luIrsaliyeSeri7.Text = "";
            txt30luIrsaliyeSeri8.Text = "";
            txt30luIrsaliyeSeri9.Text = "";
            txt30luIrsaliyeSeri10.Text = "";
            txt30luIrsaliyeSeri11.Text = "";
            txt30luIrsaliyeSeri12.Text = "";
            txt30luIrsaliyeSeri13.Text = "";
            txt30luIrsaliyeSeri14.Text = "";
            txt30luIrsaliyeSeri15.Text = "";
            txt30luIrsaliyeSeri16.Text = "";
            txt30luIrsaliyeSeri17.Text = "";
            txt30luIrsaliyeSeri18.Text = "";
            txt30luIrsaliyeSeri19.Text = "";
            txt30luIrsaliyeSeri20.Text = "";
            txt30luIrsaliyeSeri21.Text = "";
            txt30luIrsaliyeSeri22.Text = "";
            txt30luIrsaliyeSeri23.Text = "";
            txt30luIrsaliyeSeri24.Text = "";
            txt30luIrsaliyeSeri25.Text = "";
            txt30luIrsaliyeSeri26.Text = "";
            txt30luIrsaliyeSeri27.Text = "";
            txt30luIrsaliyeSeri28.Text = "";
            txt30luIrsaliyeSeri29.Text = "";
            txt30luIrsaliyeSeri30.Text = "";

            dtIrsaliyeTarihi.EditValue = null;
            dt30luTarih1.EditValue = null;
            dt30luTarih2.EditValue = null;
            dt30luTarih3.EditValue = null;
            dt30luTarih4.EditValue = null;
            dt30luTarih5.EditValue = null;
            dt30luTarih6.EditValue = null;
            dt30luTarih7.EditValue = null;
            dt30luTarih8.EditValue = null;
            dt30luTarih9.EditValue = null;
            dt30luTarih10.EditValue = null;
            dt30luTarih11.EditValue = null;
            dt30luTarih12.EditValue = null;
            dt30luTarih13.EditValue = null;
            dt30luTarih14.EditValue = null;
            dt30luTarih15.EditValue = null;
            dt30luTarih16.EditValue = null;
            dt30luTarih17.EditValue = null;
            dt30luTarih18.EditValue = null;
            dt30luTarih19.EditValue = null;
            dt30luTarih20.EditValue = null;
            dt30luTarih21.EditValue = null;
            dt30luTarih22.EditValue = null;
            dt30luTarih23.EditValue = null;
            dt30luTarih24.EditValue = null;
            dt30luTarih25.EditValue = null;
            dt30luTarih26.EditValue = null;
            dt30luTarih27.EditValue = null;
            dt30luTarih28.EditValue = null;
            dt30luTarih29.EditValue = null;
            dt30luTarih30.EditValue = null;
        }

        private void TopluSiparisleriSil()
        {
            txtSiparisNo.Text = "";
            txt30luSiparisNo1.Text = "";
            txt30luSiparisNo2.Text = "";
            txt30luSiparisNo3.Text = "";
            txt30luSiparisNo4.Text = "";
            txt30luSiparisNo5.Text = "";
            txt30luSiparisNo6.Text = "";
            txt30luSiparisNo7.Text = "";
            txt30luSiparisNo8.Text = "";
            txt30luSiparisNo9.Text = "";
            txt30luSiparisNo10.Text = "";
            txt30luSiparisNo11.Text = "";
            txt30luSiparisNo12.Text = "";
            txt30luSiparisNo13.Text = "";
            txt30luSiparisNo14.Text = "";
            txt30luSiparisNo15.Text = "";
            txt30luSiparisNo16.Text = "";
            txt30luSiparisNo17.Text = "";
            txt30luSiparisNo18.Text = "";
            txt30luSiparisNo19.Text = "";
            txt30luSiparisNo20.Text = "";
            txt30luSiparisNo21.Text = "";
            txt30luSiparisNo22.Text = "";
            txt30luSiparisNo23.Text = "";
            txt30luSiparisNo24.Text = "";
            txt30luSiparisNo25.Text = "";
            txt30luSiparisNo26.Text = "";
            txt30luSiparisNo27.Text = "";
            txt30luSiparisNo28.Text = "";
            txt30luSiparisNo29.Text = "";
            txt30luSiparisNo30.Text = "";

            txt30luSiparisSeri1.Text = "";
            txt30luSiparisSeri2.Text = "";
            txt30luSiparisSeri3.Text = "";
            txt30luSiparisSeri4.Text = "";
            txt30luSiparisSeri5.Text = "";
            txt30luSiparisSeri6.Text = "";
            txt30luSiparisSeri7.Text = "";
            txt30luSiparisSeri8.Text = "";
            txt30luSiparisSeri9.Text = "";
            txt30luSiparisSeri10.Text = "";
            txt30luSiparisSeri11.Text = "";
            txt30luSiparisSeri12.Text = "";
            txt30luSiparisSeri13.Text = "";
            txt30luSiparisSeri14.Text = "";
            txt30luSiparisSeri15.Text = "";
            txt30luSiparisSeri16.Text = "";
            txt30luSiparisSeri17.Text = "";
            txt30luSiparisSeri18.Text = "";
            txt30luSiparisSeri19.Text = "";
            txt30luSiparisSeri20.Text = "";
            txt30luSiparisSeri21.Text = "";
            txt30luSiparisSeri22.Text = "";
            txt30luSiparisSeri23.Text = "";
            txt30luSiparisSeri24.Text = "";
            txt30luSiparisSeri25.Text = "";
            txt30luSiparisSeri26.Text = "";
            txt30luSiparisSeri27.Text = "";
            txt30luSiparisSeri28.Text = "";
            txt30luSiparisSeri29.Text = "";
            txt30luSiparisSeri30.Text = "";

            dtSiparisTarihi.EditValue = null;
            dt30luSiparisTarih1.EditValue = null;
            dt30luSiparisTarih2.EditValue = null;
            dt30luSiparisTarih3.EditValue = null;
            dt30luSiparisTarih4.EditValue = null;
            dt30luSiparisTarih5.EditValue = null;
            dt30luSiparisTarih6.EditValue = null;
            dt30luSiparisTarih7.EditValue = null;
            dt30luSiparisTarih8.EditValue = null;
            dt30luSiparisTarih9.EditValue = null;
            dt30luSiparisTarih10.EditValue = null;
            dt30luSiparisTarih11.EditValue = null;
            dt30luSiparisTarih12.EditValue = null;
            dt30luSiparisTarih13.EditValue = null;
            dt30luSiparisTarih14.EditValue = null;
            dt30luSiparisTarih15.EditValue = null;
            dt30luSiparisTarih16.EditValue = null;
            dt30luSiparisTarih17.EditValue = null;
            dt30luSiparisTarih18.EditValue = null;
            dt30luSiparisTarih19.EditValue = null;
            dt30luSiparisTarih20.EditValue = null;
            dt30luSiparisTarih21.EditValue = null;
            dt30luSiparisTarih22.EditValue = null;
            dt30luSiparisTarih23.EditValue = null;
            dt30luSiparisTarih24.EditValue = null;
            dt30luSiparisTarih25.EditValue = null;
            dt30luSiparisTarih26.EditValue = null;
            dt30luSiparisTarih27.EditValue = null;
            dt30luSiparisTarih28.EditValue = null;
            dt30luSiparisTarih29.EditValue = null;
            dt30luSiparisTarih30.EditValue = null;
        }

        #endregion

        #region "Dip Toplamlar"

        private void ps_MalBedeliHesapla()
        {
            decimal malBedeli = 0;
            decimal iskonto = 0;
            decimal iskontomuz = 0;
            decimal otvTutari = 0;
            decimal kdvTutari = 0;
            decimal kdvTutari2 = 0;
            decimal OtvTutarimiz = 0;
            decimal DovizOtvTutarimiz = 0;
            decimal KdvDipSatir = 0;
            decimal KdvDipSatir2 = 0;
            decimal Toplammimiz = 0;
            decimal KalemToplamimiz = 0;
            decimal DovizKalemToplamimiz = 0;
            decimal Oranimiz = 0;
            decimal DovizliTutarimizx = 0;
            decimal YeniDovizMalBedelimiz = 0;

            #region Normal Fiyatımız

            if (DovizDurum == false)
            {
                foreach (DataRow dr in dataSet2.tblStk005Irsaliye.Rows)
                {
                    if (dr["SatirTipi"].ToString() == "M")
                    {
                        IskToplamimiz = Convert.ToDecimal(dr[colSTK005_Tutari.FieldName]) * (decimal)dr[colSTK005_KalemIskontoOrani1.FieldName] / 100;
                        IskToplamimiz = Math.Round(IskToplamimiz, 4);
                        gridView1.SetFocusedRowCellValue(colSTK005_Iskonto, IskToplamimiz);

                        malBedeli += Math.Round((decimal)dr[colSTK005_Tutari.FieldName], 2);
                        iskonto += Math.Round(Convert.ToDecimal(dr[colSTK005_Iskonto.FieldName]), 2);

                        iskontomuz = Math.Round(IskToplamimiz, 2);

                        //gridView1.SetFocusedRowCellValue(colSTK005_Iskonto, iskontomuz);

                        KalemIskontoOrani1 = (decimal)dr[colSTK005_KalemIskontoOrani1.FieldName];
                        KalemIskontoOrani2 = (decimal)dr[colSTK005_KalemIskontoOrani2.FieldName];
                        KalemIskontoOrani3 = (decimal)dr[colSTK005_KalemIskontoOrani3.FieldName];
                        KalemIskontoOrani4 = (decimal)dr[colSTK005_KalemIskontoOrani4.FieldName];
                        KalemIskontoOrani5 = (decimal)dr[colSTK005_KalemIskontoOrani5.FieldName];

                        if (iskonto <= 0)
                        {
                            iskonto = KalemIskontoOrani1 + KalemIskontoOrani2 + KalemIskontoOrani3 + KalemIskontoOrani4 + KalemIskontoOrani5;
                        }

                        if (iskontomuz <= 0)
                        {
                            iskontomuz = KalemIskontoOrani1 + KalemIskontoOrani2 + KalemIskontoOrani3 + KalemIskontoOrani4 + KalemIskontoOrani5;
                        }

                        IskToplamimiz = Convert.ToDecimal(dr[colSTK005_Tutari.FieldName]) * iskontomuz / 100;
                        IskToplamimiz = Math.Round(IskToplamimiz, 4);
                        gridView1.SetFocusedRowCellValue(colSTK005_Iskonto, IskToplamimiz);

                        gridView1.SetFocusedRowCellValue(colSTK005_Iskonto, iskontomuz);
                        Toplammimiz += (decimal)dr[colSTK005_Tutari.FieldName];
                        KalemToplamimiz = (decimal)dr[colSTK005_Tutari.FieldName];
                        otvTutari += Math.Round((decimal)dr[colOtvTutari.FieldName], 2);
                        OtvTutarimiz = (Convert.ToDecimal(dr[colOtvOranKilo.FieldName]) * Convert.ToDecimal(dr[colSTK005_Miktari.FieldName])) / 1000;
                        OtvTutarimiz = Math.Round(OtvTutarimiz, 2);
                        gridView1.SetFocusedRowCellValue(colOtvTutari, OtvTutarimiz);


                        decimal KdvCmbOran = Convert.ToDecimal(cmbKdvOrani.EditValue.ToString().Replace(".", ","));

                        #region Kdv Oranları

                        int Flags = Convert.ToInt32(dr[colSTK005_KDVOranFlag.FieldName]);

                        if (Flags == 0)
                        {
                            Oranimiz = 0;
                        }
                        else if (Flags == 2)
                        {
                            Oranimiz = 1;
                        }
                        else if (Flags == 3)
                        {
                            Oranimiz = 8;
                        }
                        else if (Flags == 4)
                        {
                            Oranimiz = 18;
                        }

                        #endregion

                        if (KalemToplamimiz > 0)
                        {
                            if (KdvSekli == "Var")
                            {
                                kdvTutari = ((KalemToplamimiz - iskontomuz + OtvTutarimiz) * Oranimiz) / 100;
                                kdvTutari = Math.Round(kdvTutari, 2);
                                KdvDipSatir += kdvTutari;
                                gridView1.SetFocusedRowCellValue(colSTK005_KDVTutari, kdvTutari);
                            }
                            else
                            {
                                if (Oranimiz != KdvCmbOran)
                                {
                                    kdvTutari = ((KalemToplamimiz - iskontomuz + OtvTutarimiz) * Oranimiz) / 100;
                                    kdvTutari = Math.Round(kdvTutari, 4);
                                    KdvDipSatir += kdvTutari;
                                    gridView1.SetFocusedRowCellValue(colSTK005_KDVTutari, kdvTutari);
                                }
                                else
                                {
                                    kdvTutari = ((KalemToplamimiz - iskontomuz + OtvTutarimiz) * KdvCmbOran) / 100;
                                    kdvTutari = Math.Round(kdvTutari, 4);
                                    KdvDipSatir += kdvTutari;
                                    gridView1.SetFocusedRowCellValue(colSTK005_KDVTutari, kdvTutari);

                                }
                            }
                        }
                    }
                    txtMalBedeli.EditValue = malBedeli;
                    txtIskonto.EditValue = iskonto;
                    txtNetTutar.EditValue = malBedeli - iskonto;


                    txtOtv.EditValue = otvTutari;
                    txtKdv.EditValue = KdvDipSatir;
                }
            }

            #endregion

            #region Doviz Kuruna Böl

            if (DovizDurum == true && Dovizislemi == "Bol")
            {
                malBedeli = 0;
                iskonto = 0;
                iskontomuz = 0;
                otvTutari = 0;
                kdvTutari2 = 0;
                kdvTutari = 0;
                OtvTutarimiz = 0;
                KdvDipSatir2 = 0;
                KdvDipSatir = 0;
                Toplammimiz = 0;
                KalemToplamimiz = 0;
                DovizKalemToplamimiz = 0;
                Oranimiz = 0;
                DovizliTutarimizx = 0;
                DovizOtvTutarimiz = 0;
                decimal iskdovizli = 0;
                decimal iskDovizToplami = 0;
                decimal DovizIskontomuz = 0;

                if (Convert.ToInt32(txtDovizMalBedeli.EditValue) < 1)
                {
                    foreach (DataRow dr in dataSet2.tblStk005Irsaliye.Rows)
                    {
                        if (dr["SatirTipi"].ToString() == "M")
                        {
                            try
                            {
                                malBedeli += Math.Round((decimal)dr[colSTK005_Tutari.FieldName], 2) / (decimal)dr[colSTK005_DovizKuru.FieldName];
                                iskonto += (decimal)dr[colSTK005_Iskonto.FieldName] / (decimal)dr[colSTK005_DovizKuru.FieldName];
                                IskToplamimiz = (decimal)dr[colSTK005_Iskonto.FieldName] / (decimal)dr[colSTK005_DovizKuru.FieldName];

                                DovizliTutarimizx = Math.Round((decimal)dr[colSTK005_Tutari.FieldName], 2) / (decimal)dr[colSTK005_DovizKuru.FieldName];
                                dr[colSTK005_DovizTutari.FieldName] = DovizliTutarimizx;
                                iskontomuz = Math.Round(IskToplamimiz, 2);

                                KalemIskontoOrani1 = (decimal)dr[colSTK005_KalemIskontoOrani1.FieldName];
                                KalemIskontoOrani2 = (decimal)dr[colSTK005_KalemIskontoOrani2.FieldName];
                                KalemIskontoOrani3 = (decimal)dr[colSTK005_KalemIskontoOrani3.FieldName];
                                KalemIskontoOrani4 = (decimal)dr[colSTK005_KalemIskontoOrani4.FieldName];
                                KalemIskontoOrani5 = (decimal)dr[colSTK005_KalemIskontoOrani5.FieldName];

                                if (iskonto <= 0)
                                {
                                    iskonto = KalemIskontoOrani1 + KalemIskontoOrani2 + KalemIskontoOrani3 + KalemIskontoOrani4 + KalemIskontoOrani5;
                                    iskonto = iskonto / (decimal)dr[colSTK005_DovizKuru.FieldName];
                                }
                                if (iskontomuz <= 0)
                                {
                                    iskontomuz = KalemIskontoOrani1 + KalemIskontoOrani2 + KalemIskontoOrani3 + KalemIskontoOrani4 + KalemIskontoOrani5;
                                    iskontomuz = iskontomuz / (decimal)dr[colSTK005_DovizKuru.FieldName];
                                }
                                KalemToplamimiz = (decimal)dr[colSTK005_Tutari.FieldName] / (decimal)dr[colSTK005_DovizKuru.FieldName];

                                otvTutari += Math.Round((decimal)dr[colOtvTutari.FieldName], 2) / (decimal)dr[colSTK005_DovizKuru.FieldName];
                                OtvTutarimiz = (Convert.ToDecimal(dr[colOtvOranKilo.FieldName]) * Convert.ToDecimal(dr[colSTK005_Miktari.FieldName])) / 1000;
                                OtvTutarimiz = Math.Round(OtvTutarimiz, 2) / (decimal)dr[colSTK005_DovizKuru.FieldName];

                                decimal KdvCmbOran = Convert.ToDecimal(cmbKdvOrani.EditValue.ToString().Replace(".", ","));

                                #region Kdv Oranları

                                int Flags = Convert.ToInt32(dr[colSTK005_KDVOranFlag.FieldName]);

                                if (Flags == 0)
                                {
                                    Oranimiz = 0;
                                }
                                else if (Flags == 2)
                                {
                                    Oranimiz = 1;
                                }
                                else if (Flags == 3)
                                {
                                    Oranimiz = 8;
                                }
                                else if (Flags == 4)
                                {
                                    Oranimiz = 18;
                                }

                                #endregion

                                if (KalemToplamimiz > 0)
                                {
                                    if (KdvSekli == "Var")
                                    {
                                        kdvTutari = ((KalemToplamimiz - iskontomuz + OtvTutarimiz) * Oranimiz) / 100;
                                        kdvTutari = Math.Round(kdvTutari, 2);
                                        KdvDipSatir += kdvTutari;
                                    }
                                    else
                                    {
                                        if (Oranimiz != KdvCmbOran)
                                        {
                                            kdvTutari = ((KalemToplamimiz - iskontomuz + OtvTutarimiz) * Oranimiz) / 100;
                                            kdvTutari = Math.Round(kdvTutari, 2);
                                            KdvDipSatir += kdvTutari;
                                        }
                                        else
                                        {
                                            kdvTutari = ((KalemToplamimiz - iskontomuz + OtvTutarimiz) * KdvCmbOran) / 100;
                                            kdvTutari = Math.Round(kdvTutari, 2);
                                            KdvDipSatir += kdvTutari;

                                        }
                                    }
                                }
                            }
                            catch (Exception)
                            {


                            }
                        }
                        txtDovizMalBedeli.EditValue = malBedeli;
                        txtDovizOtv.EditValue = otvTutari;
                        txtDovizNetToplam.EditValue = malBedeli - iskonto;
                        txtDovizIskonto.EditValue = iskonto;
                        txtDovizKdv.EditValue = KdvDipSatir;
                    }
                }
                else
                {
                    foreach (DataRow dr in dataSet2.tblStk005Irsaliye.Rows)
                    {
                        if (dr["SatirTipi"].ToString() == "M")
                        {
                            try
                            {
                                DovizliTutarimizx = Math.Round((decimal)dr[colSTK005_DovizTutari.FieldName], 2) / (decimal)dr[colSTK005_DovizKuru.FieldName];
                                dr[colSTK005_DovizTutari.FieldName] = DovizliTutarimizx;

                                iskonto += (decimal)txtIskonto.EditValue / (decimal)dr[colSTK005_DovizKuru.FieldName];
                                iskdovizli += (decimal)txtDovizIskonto.EditValue / (decimal)dr[colSTK005_DovizKuru.FieldName];

                                IskToplamimiz = (decimal)txtIskonto.EditValue / (decimal)dr[colSTK005_DovizKuru.FieldName];
                                iskDovizToplami = (decimal)txtDovizIskonto.EditValue / (decimal)dr[colSTK005_DovizKuru.FieldName];

                                iskontomuz = Math.Round(IskToplamimiz, 2);
                                DovizIskontomuz = Math.Round(iskDovizToplami, 2);

                                gridView1.SetFocusedRowCellValue(colSTK005_Iskonto, iskontomuz);

                                decimal BirimDovizFiyati = Math.Round((decimal)dr[colSTK005_BirimFiyati.FieldName], 6);
                                BirimDovizFiyati = BirimDovizFiyati / (decimal)dr[colSTK005_DovizKuru.FieldName];
                                dr[colSTK005_BirimFiyati.FieldName] = BirimDovizFiyati;

                                decimal YeniTutar = Math.Round((decimal)dr[colSTK005_Miktari.FieldName], 2) * Math.Round((decimal)dr[colSTK005_BirimFiyati.FieldName], 2);
                                YeniTutar = Math.Round(YeniTutar, 2);
                                dr[colSTK005_Tutari.FieldName] = YeniTutar;

                                YeniDovizMalBedelimiz += Math.Round((decimal)dr[colSTK005_Tutari.FieldName], 2) / (decimal)dr[colSTK005_DovizKuru.FieldName];
                                YeniDovizMalBedelimiz = Math.Round(YeniDovizMalBedelimiz, 2);
                                malBedeli += Math.Round((decimal)dr[colSTK005_Tutari.FieldName], 2);

                                KalemIskontoOrani1 = (decimal)dr[colSTK005_KalemIskontoOrani1.FieldName];
                                KalemIskontoOrani2 = (decimal)dr[colSTK005_KalemIskontoOrani2.FieldName];
                                KalemIskontoOrani3 = (decimal)dr[colSTK005_KalemIskontoOrani3.FieldName];
                                KalemIskontoOrani4 = (decimal)dr[colSTK005_KalemIskontoOrani4.FieldName];
                                KalemIskontoOrani5 = (decimal)dr[colSTK005_KalemIskontoOrani5.FieldName];

                                if (iskonto <= 0)
                                {
                                    iskonto = KalemIskontoOrani1 + KalemIskontoOrani2 + KalemIskontoOrani3 + KalemIskontoOrani4 + KalemIskontoOrani5;
                                    iskonto = iskonto / (decimal)dr[colSTK005_DovizKuru.FieldName];
                                }
                                if (iskontomuz <= 0)
                                {
                                    iskontomuz = KalemIskontoOrani1 + KalemIskontoOrani2 + KalemIskontoOrani3 + KalemIskontoOrani4 + KalemIskontoOrani5;
                                    iskontomuz = iskontomuz / (decimal)dr[colSTK005_DovizKuru.FieldName];
                                }

                                KalemToplamimiz = (decimal)dr[colSTK005_Tutari.FieldName] / (decimal)dr[colSTK005_DovizKuru.FieldName];
                                DovizKalemToplamimiz = (decimal)dr[colSTK005_Tutari.FieldName];
                                otvTutari += Math.Round((decimal)dr[colOtvTutari.FieldName], 2);// / (decimal)dr[colSTK005_DovizKuru.FieldName];
                                OtvTutarimiz = (Convert.ToDecimal(dr[colOtvOranKilo.FieldName]) * Convert.ToDecimal(dr[colSTK005_Miktari.FieldName])) / 1000;
                                DovizOtvTutarimiz = OtvTutarimiz / (decimal)dr[colSTK005_DovizKuru.FieldName];
                                OtvTutarimiz = Math.Round(OtvTutarimiz, 2);// / (decimal)dr[colSTK005_DovizKuru.FieldName];

                                decimal KdvCmbOran = Convert.ToDecimal(cmbKdvOrani.EditValue.ToString().Replace(".", ","));

                                #region Kdv Oranları

                                int Flags = Convert.ToInt32(dr[colSTK005_KDVOranFlag.FieldName]);

                                if (Flags == 0)
                                {
                                    Oranimiz = 0;
                                }
                                else if (Flags == 2)
                                {
                                    Oranimiz = 1;
                                }
                                else if (Flags == 3)
                                {
                                    Oranimiz = 8;
                                }
                                else if (Flags == 4)
                                {
                                    Oranimiz = 18;
                                }

                                #endregion

                                if (KalemToplamimiz > 0)
                                {
                                    if (KdvSekli == "Var")
                                    {
                                        kdvTutari = ((YeniDovizMalBedelimiz - DovizIskontomuz + DovizOtvTutarimiz) * Oranimiz) / 100;
                                        kdvTutari = Math.Round(kdvTutari, 2);
                                        KdvDipSatir += kdvTutari;

                                        kdvTutari2 = ((YeniTutar - iskontomuz + OtvTutarimiz) * Oranimiz) / 100;
                                        kdvTutari2 = Math.Round(kdvTutari2, 2);
                                        KdvDipSatir2 += kdvTutari2;
                                        //gridView1.SetFocusedRowCellValue(colSTK005_KDVTutari, kdvTutari);
                                    }
                                    else
                                    {
                                        if (Oranimiz != KdvCmbOran)
                                        {
                                            kdvTutari = ((YeniDovizMalBedelimiz - DovizIskontomuz + DovizOtvTutarimiz) * Oranimiz) / 100;
                                            kdvTutari = Math.Round(kdvTutari, 2);
                                            KdvDipSatir += kdvTutari;

                                            kdvTutari2 = ((YeniTutar - iskontomuz + OtvTutarimiz) * Oranimiz) / 100;
                                            kdvTutari2 = Math.Round(kdvTutari2, 2);
                                            KdvDipSatir2 += kdvTutari2;
                                            //gridView1.SetFocusedRowCellValue(colSTK005_KDVTutari, kdvTutari);
                                        }
                                        else
                                        {
                                            kdvTutari = ((YeniDovizMalBedelimiz - DovizIskontomuz + DovizOtvTutarimiz) * KdvCmbOran) / 100;
                                            kdvTutari = Math.Round(kdvTutari, 2);
                                            KdvDipSatir += kdvTutari;

                                            kdvTutari2 = ((YeniTutar - iskontomuz + OtvTutarimiz) * KdvCmbOran) / 100;
                                            kdvTutari2 = Math.Round(kdvTutari2, 2);
                                            KdvDipSatir2 += kdvTutari2;
                                            //gridView1.SetFocusedRowCellValue(colSTK005_KDVTutari, kdvTutari);

                                        }
                                    }
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }

                        txtDovizMalBedeli.EditValue = YeniDovizMalBedelimiz;
                        txtIskonto.EditValue = iskonto;
                        txtMalBedeli.EditValue = malBedeli;
                        txtNetTutar.EditValue = malBedeli - iskonto;
                        txtKdv.EditValue = KdvDipSatir2;
                        txtDovizOtv.EditValue = otvTutari;
                        txtDovizIskonto.EditValue = DovizIskontomuz;
                        txtDovizNetToplam.EditValue = YeniDovizMalBedelimiz - iskdovizli;
                        txtDovizKdv.EditValue = KdvDipSatir;
                        txtDovizGenelToplam.EditValue = KdvDipSatir + (YeniDovizMalBedelimiz - iskdovizli);
                    }
                }
            }

            #endregion

            #region Doviz Kuruna Çarp

            if (DovizDurum == true && Dovizislemi == "Carp")
            {
                malBedeli = 0;
                iskonto = 0;
                iskontomuz = 0;
                otvTutari = 0;
                kdvTutari = 0;
                OtvTutarimiz = 0;
                KdvDipSatir = 0;
                Toplammimiz = 0;
                KalemToplamimiz = 0;
                Oranimiz = 0;
                decimal DovizBirimFiyat = 0;
                decimal DovizToplamTutar = 0;
                decimal DovizToplamTutar2 = 0;
                decimal OtvTutarimiz2 = 0;
                decimal KalemiskOranimiz2 = 0;
                decimal KalemToplamimiz2 = 0;
                kdvTutari2 = 0;
                decimal otvTutari2 = 0;
                KdvDipSatir2 = 0;
                decimal iskdovizli = 0;
                decimal iskDovizToplami = 0;

                foreach (DataRow dr in dataSet2.tblStk005Irsaliye.Rows)
                {
                    if (dr["SatirTipi"].ToString() == "M")
                    {

                        try
                        {
                            iskonto += (decimal)txtIskonto.EditValue * (decimal)dr[colSTK005_DovizKuru.FieldName];
                            iskdovizli += (decimal)txtDovizIskonto.EditValue * (decimal)dr[colSTK005_DovizKuru.FieldName];

                            IskToplamimiz = (decimal)txtIskonto.EditValue * (decimal)dr[colSTK005_DovizKuru.FieldName];
                            iskDovizToplami = (decimal)txtDovizIskonto.EditValue * (decimal)dr[colSTK005_DovizKuru.FieldName];

                            DovizBirimFiyat = (decimal)dr[colSTK005_BirimFiyati.FieldName] * (decimal)dr[colSTK005_DovizKuru.FieldName];
                            dr[colSTK005_BirimFiyati.FieldName] = DovizBirimFiyat;
                            DovizToplamTutar = DovizBirimFiyat * (decimal)dr[colSTK005_Miktari.FieldName];
                            dr[colSTK005_Tutari.FieldName] = DovizToplamTutar;

                            dr[colSTK005_DovizTutari.FieldName] = (decimal)dr[colSTK005_DovizKuru.FieldName] * (decimal)dr[colSTK005_DovizTutari.FieldName];

                            malBedeli += Math.Round((decimal)dr[colSTK005_Tutari.FieldName], 2);
                            iskontomuz = Math.Round(IskToplamimiz, 2);

                            //iskontomuz = Math.Round(IskToplamimiz, 4);

                            gridView1.SetFocusedRowCellValue(colSTK005_Iskonto, iskontomuz);

                            KalemIskontoOrani1 = (decimal)dr[colSTK005_KalemIskontoOrani1.FieldName];
                            KalemIskontoOrani2 = (decimal)dr[colSTK005_KalemIskontoOrani2.FieldName];
                            KalemIskontoOrani3 = (decimal)dr[colSTK005_KalemIskontoOrani3.FieldName];
                            KalemIskontoOrani4 = (decimal)dr[colSTK005_KalemIskontoOrani4.FieldName];
                            KalemIskontoOrani5 = (decimal)dr[colSTK005_KalemIskontoOrani5.FieldName];

                            if (iskonto <= 0)
                            {
                                iskonto = KalemIskontoOrani1 + KalemIskontoOrani2 + KalemIskontoOrani3 + KalemIskontoOrani4 + KalemIskontoOrani5;
                            }

                            if (iskontomuz <= 0)
                            {
                                iskontomuz = KalemIskontoOrani1 + KalemIskontoOrani2 + KalemIskontoOrani3 + KalemIskontoOrani4 + KalemIskontoOrani5;
                            }

                            //doviz hesaplama
                            DovizToplamTutar2 += (decimal)dr[colSTK005_DovizTutari.FieldName];

                            Toplammimiz += (decimal)dr[colSTK005_Tutari.FieldName];
                            KalemToplamimiz = (decimal)dr[colSTK005_Tutari.FieldName];
                            KalemToplamimiz2 = (decimal)dr[colSTK005_DovizTutari.FieldName];

                            otvTutari += Math.Round((decimal)dr[colOtvTutari.FieldName], 2);
                            OtvTutarimiz = (Convert.ToDecimal(dr[colOtvOranKilo.FieldName]) * Convert.ToDecimal(dr[colSTK005_Miktari.FieldName])) / 1000;
                            //OtvTutarimiz = Math.Round(OtvTutarimiz, 2) / (decimal)dr[colSTK005_DovizKuru.FieldName];

                            OtvTutarimiz2 = (Convert.ToDecimal(dr[colOtvOranKilo.FieldName]) * Convert.ToDecimal(dr[colSTK005_Miktari.FieldName])) / 1000;
                            OtvTutarimiz2 = Math.Round(OtvTutarimiz2, 2) / (decimal)dr[colSTK005_DovizKuru.FieldName];

                            gridView1.SetFocusedRowCellValue(colOtvTutari, OtvTutarimiz);


                            decimal KdvCmbOran = Convert.ToDecimal(cmbKdvOrani.EditValue.ToString().Replace(".", ","));

                            #region Kdv Oranları

                            int Flags = Convert.ToInt32(dr[colSTK005_KDVOranFlag.FieldName]);

                            if (Flags == 0)
                            {
                                Oranimiz = 0;
                            }
                            else if (Flags == 2)
                            {
                                Oranimiz = 1;
                            }
                            else if (Flags == 3)
                            {
                                Oranimiz = 8;
                            }
                            else if (Flags == 4)
                            {
                                Oranimiz = 18;
                            }

                            #endregion

                            if (KalemToplamimiz > 0)
                            {
                                if (KdvSekli == "Var")
                                {
                                    kdvTutari = ((KalemToplamimiz - iskontomuz + OtvTutarimiz) * Oranimiz) / 100;
                                    kdvTutari = Math.Round(kdvTutari, 2);// *(decimal)dr[colSTK005_DovizKuru.FieldName];
                                    KdvDipSatir += kdvTutari;

                                    kdvTutari2 = ((KalemToplamimiz2 - iskdovizli + OtvTutarimiz2) * Oranimiz) / 100;
                                    kdvTutari2 = Math.Round(kdvTutari2, 2);
                                    KdvDipSatir2 += kdvTutari2;

                                    gridView1.SetFocusedRowCellValue(colSTK005_KDVTutari, kdvTutari);
                                }
                                else
                                {
                                    if (Oranimiz != KdvCmbOran)
                                    {
                                        kdvTutari = ((KalemToplamimiz - iskontomuz + OtvTutarimiz) * Oranimiz) / 100;
                                        kdvTutari = Math.Round(kdvTutari, 2);// *(decimal)dr[colSTK005_DovizKuru.FieldName];
                                        KdvDipSatir += kdvTutari;

                                        kdvTutari2 = ((KalemToplamimiz2 - iskdovizli + OtvTutarimiz2) * Oranimiz) / 100;
                                        kdvTutari2 = Math.Round(kdvTutari2, 2);
                                        KdvDipSatir2 += kdvTutari2;

                                        gridView1.SetFocusedRowCellValue(colSTK005_KDVTutari, kdvTutari);
                                    }
                                    else
                                    {
                                        kdvTutari = ((KalemToplamimiz - iskontomuz + OtvTutarimiz) * KdvCmbOran) / 100;
                                        kdvTutari = Math.Round(kdvTutari, 2);// *(decimal)dr[colSTK005_DovizKuru.FieldName];
                                        KdvDipSatir += kdvTutari;

                                        kdvTutari2 = ((KalemToplamimiz2 - iskdovizli + OtvTutarimiz2) * Oranimiz) / 100;
                                        kdvTutari2 = Math.Round(kdvTutari2, 2);
                                        KdvDipSatir2 += kdvTutari2;

                                        gridView1.SetFocusedRowCellValue(colSTK005_KDVTutari, kdvTutari);

                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                    txtMalBedeli.EditValue = malBedeli;
                    txtIskonto.EditValue = iskonto;
                    txtNetTutar.EditValue = malBedeli - iskonto;
                    txtOtv.EditValue = otvTutari;
                    txtKdv.EditValue = KdvDipSatir;

                    txtDovizMalBedeli.EditValue = DovizToplamTutar2;
                    txtDovizIskonto.EditValue = iskdovizli;
                    txtDovizKdv.EditValue = KdvDipSatir2;
                    txtDovizNetToplam.EditValue = DovizToplamTutar2 - iskdovizli;
                    txtDovizGenelToplam.EditValue = KdvDipSatir2 + (DovizToplamTutar2 - iskdovizli);
                }
            }

            #endregion
        }

        private void ps_KdvMatrahiHesapla(){
            decimal kdvMatrahi = 0;
            kdvMatrahi = Convert.ToDecimal(txtNetTutar.EditValue) + Convert.ToDecimal(txtOtv.EditValue);
            txtKdvMatrahi.EditValue = kdvMatrahi;
        }

        private void ps_GenelToplam()
        {
            decimal genelToplam = 0;

            if (DovizDurum == false)
            {
                genelToplam = Convert.ToDecimal(txtKdv.Text) + Convert.ToDecimal(txtKdvMatrahi.Text);
                txtGenelToplam.EditValue = genelToplam;
            }
            if (DovizDurum == true && Dovizislemi == "Bol")
            {

                genelToplam = Convert.ToDecimal(txtDovizKdv.Text) + Convert.ToDecimal(txtDovizNetToplam.Text);
                txtDovizGenelToplam.EditValue = genelToplam;
                DovizDurum = false;
                KontrolEdiyoruz = 1;
            }
            if (DovizDurum == true && Dovizislemi == "Carp")
            {
                genelToplam = Convert.ToDecimal(txtKdv.Text) + Convert.ToDecimal(txtKdvMatrahi.Text);
                txtGenelToplam.EditValue = genelToplam;

                //genelToplam = Convert.ToDecimal(txtDovizKdv.Text) + Convert.ToDecimal(txtDovizNetToplam.Text);

                //MessageBox.Show(genelToplam + " genel toplam");
                //txtDovizGenelToplam.EditValue = genelToplam;
                DovizDurum = false;
                CarpKontrol = 1;
            }
        }

        private void ps_MalBedeliHesaplaCtrlN()
        {
            decimal malBedeli = 0;
            decimal iskonto = 0;
            decimal iskontomuz = 0;
            decimal otvTutari = 0;
            decimal kdvTutari = 0;
            decimal OtvTutarimiz = 0;
            decimal KdvDipSatir = 0;
            decimal Toplammimiz = 0;
            decimal KalemToplamimiz = 0;
            decimal Oranimiz = 0;

            foreach (DataRow dr in dataSet1.tblFaturaHareketleri.Rows)
            {
                if (dr["SatirTipi"].ToString() == "M")
                {
                    malBedeli += Math.Round((decimal)dr[colSTK005_Tutari.FieldName], 2);
                    iskontomuz += Math.Round((decimal)dr[colSTK005_Iskonto.FieldName], 2);
                    iskonto = Math.Round((decimal)dr[colSTK005_Iskonto.FieldName], 2);

                    IskToplamimiz = Convert.ToDecimal(dr[colSTK005_Tutari.FieldName]) * iskontomuz / 100;
                    //IskToplamimiz = Math.Round(IskToplamimiz, 4);
                    //gridView1.SetFocusedRowCellValue(colSTK005_Iskonto, IskToplamimiz);

                    //gridView1.SetFocusedRowCellValue(colSTK005_Iskonto, iskontomuz);
                    Toplammimiz += (decimal)dr[colSTK005_Tutari.FieldName];
                    KalemToplamimiz = (decimal)dr[colSTK005_Tutari.FieldName];
                    otvTutari += Math.Round((decimal)dr[colOtvTutari.FieldName], 2);
                    OtvTutarimiz = (Convert.ToDecimal(dr[colOtvOranKilo.FieldName]) * Convert.ToDecimal(dr[colSTK005_Miktari.FieldName])) / 1000;
                    OtvTutarimiz = Math.Round(OtvTutarimiz, 2);
                    gridView1.SetFocusedRowCellValue(colOtvTutari, OtvTutarimiz);


                    decimal KdvCmbOran = Convert.ToDecimal(cmbKdvOrani.EditValue.ToString().Replace(".", ","));

                    #region Kdv Oranları

                    int Flags = Convert.ToInt32(dr[colSTK005_KDVOranFlag.FieldName]);

                    if (Flags == 0)
                    {
                        Oranimiz = 0;
                    }
                    else if (Flags == 2)
                    {
                        Oranimiz = 1;
                    }
                    else if (Flags == 3)
                    {
                        Oranimiz = 8;
                    }
                    else if (Flags == 4)
                    {
                        Oranimiz = 18;
                    }

                    #endregion

                    if (KalemToplamimiz > 0)
                    {
                        if (KdvSekli == "Var")
                        {
                            kdvTutari = ((KalemToplamimiz - iskonto + OtvTutarimiz) * Oranimiz) / 100;
                            kdvTutari = Math.Round(kdvTutari, 2);
                            KdvDipSatir += kdvTutari;
                            gridView1.SetFocusedRowCellValue(colSTK005_KDVTutari, kdvTutari);
                        }
                        else
                        {
                            if (Oranimiz != KdvCmbOran)
                            {
                                kdvTutari = ((KalemToplamimiz - iskonto + OtvTutarimiz) * Oranimiz) / 100;
                                kdvTutari = Math.Round(kdvTutari, 4);
                                KdvDipSatir += kdvTutari;
                                gridView1.SetFocusedRowCellValue(colSTK005_KDVTutari, kdvTutari);
                            }
                            else
                            {
                                kdvTutari = ((KalemToplamimiz - iskonto + OtvTutarimiz) * KdvCmbOran) / 100;
                                kdvTutari = Math.Round(kdvTutari, 4);
                                KdvDipSatir += kdvTutari;
                                gridView1.SetFocusedRowCellValue(colSTK005_KDVTutari, kdvTutari);

                            }
                        }
                    }
                }
                txtMalBedeli.EditValue = malBedeli;
                txtIskonto.EditValue = iskontomuz;
                txtNetTutar.EditValue = malBedeli - iskontomuz;


                txtOtv.EditValue = otvTutari;
                txtKdv.EditValue = KdvDipSatir;
            }
        }

        #endregion

        #region Hesap Kodu ve Ünvanı İşlemleri

        private void txtHesapKodu_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                GridLookUpEdit hesapKoduLookUpEdit = sender as GridLookUpEdit;
                DataRow dr = hesapKoduLookUpEdit.Properties.View.GetDataRow(hesapKoduLookUpEdit.Properties.View.FocusedRowHandle);
                txtHesapKodu.Text = dr[0].ToString();
                txtUnvan.Text = dr[1].ToString();
                txtUnvan1.Text = dr[2].ToString();
                txtAdres.Text = dr[3].ToString();
                txtAdres1.Text = dr[4].ToString();
                txtAdres2.Text = dr[5].ToString();
                txtVergiDairesiKodu.Text = dr[6].ToString();
                txtVergiDairesi.Text = dr[7].ToString();
                txtVergiNo.Text = dr[8].ToString();
                lblBA.Text = dr[14].ToString();
                txtBA.Text = dr[13].ToString();
                cmbDovizCinsi.EditValue = dr[9].ToString();
                IskontoOranimiz = Convert.ToDecimal(dr[12].ToString());
                DovizHesapKodumuz = dr[0].ToString();
                DovizParaBirimimiz = dr[9].ToString();
                OpsiyonGunu = Convert.ToInt32(dr[17].ToString());

                if (Convert.ToDecimal(dr[16].ToString()) == 0)
                {
                    dovizKurumuz = (decimal)this.queriesTableAdapter1.DovizKuru(DovizHesapKodumuz, DovizParaBirimimiz);
                    //frmLookUpSatisFaturasiMalKodu.dovizKurumuz = dovizKurumuz;
                }
                else
                {
                    dovizKurumuz = Convert.ToDecimal(dr[16].ToString());
                    //frmLookUpSatisFaturasiMalKodu.dovizKurumuz = dovizKurumuz;
                }
                //Vade Tarihini Opsiyon Gününe Göre Ayarlıyoruz
                DateTime dtsVadeTarihi = new DateTime();
                string VadeTarihimiz = Convert.ToString(dtVadeTarihi.DateTime.ToOADate());
                VadeTarihimiz = VadeTarihimiz.ToString().Substring(0, 5);
                VadeTarihi = Convert.ToInt32(VadeTarihimiz);
                VadeTarihi = VadeTarihi + OpsiyonGunu;
                dtsVadeTarihi = DateTime.FromOADate(VadeTarihi);
                dtVadeTarihi.DateTime = dtsVadeTarihi;
                //Kdv Vade Tarihini Opsiyon Gününe Göre Ayarlıyoruz
                DateTime dtsKdvVadeTarihi = new DateTime();
                string KdvVadeTarihimiz = Convert.ToString(dtKdvTarihi.DateTime.ToOADate());
                KdvVadeTarihimiz = KdvVadeTarihimiz.ToString().Substring(0, 5);
                kdvVadeTarihi = Convert.ToInt32(KdvVadeTarihimiz);
                kdvVadeTarihi = kdvVadeTarihi + OpsiyonGunu;
                dtsKdvVadeTarihi = DateTime.FromOADate(kdvVadeTarihi);
                dtKdvTarihi.DateTime = dtsKdvVadeTarihi;
                dtKdvVadeTarihi.DateTime = dtsKdvVadeTarihi;
                dtBaslangicTarihi.DateTime = dtsKdvVadeTarihi;
                dtPesinatTarihi.DateTime = dtsKdvVadeTarihi;
                //Ötv Vade Tarihini Ayarlıyoruz
                DateTime dtsOtvVadeTarihi = new DateTime();
                string OtvVadeTarihimiz = Convert.ToString(dtOtvTarihi.DateTime.ToOADate());
                OtvVadeTarihimiz = OtvVadeTarihimiz.ToString().Substring(0, 5);
                otvVadeTarihi = Convert.ToInt32(OtvVadeTarihimiz);
                otvVadeTarihi = otvVadeTarihi + OpsiyonGunu;
                dtsOtvVadeTarihi = DateTime.FromOADate(otvVadeTarihi);
                dtOtvTarihi.DateTime = dtsOtvVadeTarihi;
                //

                txtDovizKuru.Text = Convert.ToString(dovizKurumuz);
                gridView1.SetFocusedRowCellValue(colSTK005_Iskonto, IskontoOranimiz);
                this.tblAltCariHesaplarTableAdapter.AltCariHesaplariGetir(dataSet2.tblAltCariHesaplar, txtHesapKodu.Text);
            }
            catch (Exception)
            {
            }
        }

        private void txtUnvan_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                GridLookUpEdit hesapKoduLookUpEdit = sender as GridLookUpEdit;
                DataRow dr = hesapKoduLookUpEdit.Properties.View.GetDataRow(hesapKoduLookUpEdit.Properties.View.FocusedRowHandle);
                txtHesapKodu.Text = dr[0].ToString();
                txtUnvan.Text = dr[1].ToString();
                txtUnvan1.Text = dr[2].ToString();
                txtAdres.Text = dr[3].ToString();
                txtAdres1.Text = dr[4].ToString();
                txtAdres2.Text = dr[5].ToString();
                txtVergiDairesiKodu.Text = dr[6].ToString();
                txtVergiDairesi.Text = dr[7].ToString();
                txtVergiNo.Text = dr[8].ToString();
                lblBA.Text = dr[14].ToString();
                txtBA.Text = dr[13].ToString();
                cmbDovizCinsi.EditValue = dr[9].ToString();
                IskontoOranimiz = Convert.ToDecimal(dr[12].ToString());
                DovizHesapKodumuz = dr[0].ToString();
                DovizParaBirimimiz = dr[9].ToString();
                frmLookUpSatisFaturasiMalKodu.DovizParaBirimimiz = DovizParaBirimimiz;
                OpsiyonGunu = Convert.ToInt32(dr[17].ToString());

                if (Convert.ToDecimal(dr[16].ToString()) == 0)
                {
                    dovizKurumuz = (decimal)this.queriesTableAdapter1.DovizKuru(DovizHesapKodumuz, DovizParaBirimimiz);
                    frmLookUpSatisFaturasiMalKodu.dovizKurumuz = dovizKurumuz;
                }
                else
                {
                    dovizKurumuz = Convert.ToDecimal(dr[16].ToString());
                    frmLookUpSatisFaturasiMalKodu.dovizKurumuz = dovizKurumuz;
                }
                //Vade Tarihini Opsiyon Gününe Göre Ayarlıyoruz
                DateTime dtsVadeTarihi = new DateTime();
                string VadeTarihimiz = Convert.ToString(dtVadeTarihi.DateTime.ToOADate());
                VadeTarihimiz = VadeTarihimiz.ToString().Substring(0, 5);
                VadeTarihi = Convert.ToInt32(VadeTarihimiz);
                VadeTarihi = VadeTarihi + OpsiyonGunu;
                dtsVadeTarihi = DateTime.FromOADate(VadeTarihi);
                dtVadeTarihi.DateTime = dtsVadeTarihi;
                //Kdv Vade Tarihini Opsiyon Gününe Göre Ayarlıyoruz
                DateTime dtsKdvVadeTarihi = new DateTime();
                string KdvVadeTarihimiz = Convert.ToString(dtKdvTarihi.DateTime.ToOADate());
                KdvVadeTarihimiz = KdvVadeTarihimiz.ToString().Substring(0, 5);
                kdvVadeTarihi = Convert.ToInt32(KdvVadeTarihimiz);
                kdvVadeTarihi = kdvVadeTarihi + OpsiyonGunu;
                dtsKdvVadeTarihi = DateTime.FromOADate(kdvVadeTarihi);
                dtKdvTarihi.DateTime = dtsKdvVadeTarihi;
                dtKdvVadeTarihi.DateTime = dtsKdvVadeTarihi;
                dtBaslangicTarihi.DateTime = dtsKdvVadeTarihi;
                dtPesinatTarihi.DateTime = dtsKdvVadeTarihi;
                //Ötv Vade Tarihini Ayarlıyoruz
                DateTime dtsOtvVadeTarihi = new DateTime();
                string OtvVadeTarihimiz = Convert.ToString(dtOtvTarihi.DateTime.ToOADate());
                OtvVadeTarihimiz = OtvVadeTarihimiz.ToString().Substring(0, 5);
                otvVadeTarihi = Convert.ToInt32(OtvVadeTarihimiz);
                otvVadeTarihi = otvVadeTarihi + OpsiyonGunu;
                dtsOtvVadeTarihi = DateTime.FromOADate(otvVadeTarihi);
                dtOtvTarihi.DateTime = dtsOtvVadeTarihi;

                txtDovizKuru.Text = Convert.ToString(dovizKurumuz);
                gridView1.SetFocusedRowCellValue(colSTK005_Iskonto, IskontoOranimiz);
                this.tblAltCariHesaplarTableAdapter.AltCariHesaplariGetir(dataSet2.tblAltCariHesaplar, txtHesapKodu.Text);
            }
            catch (Exception)
            {
            }
        }

        private void lblBA_TextChanged(object sender, EventArgs e)
        {
            if (lblBA.Text == "B")
                lblBA.Appearance.ForeColor = Color.Red;
            else
                lblBA.Appearance.ForeColor = Color.Blue;
        }

        #endregion

        #region "Cari ve Stok Hareket Kodları"
        private void buttonEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUpStokVeCariHareketleriAc("Kod 1","stokKod1");
        }

        private void buttonEdit2_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUpStokVeCariHareketleriAc("Kod 2", "stokKod2");
        }

        private void buttonEdit3_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUpStokVeCariHareketleriAc("Kod 3", "stokKod3");
        }

        private void buttonEdit4_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUpStokVeCariHareketleriAc("Kod 4", "stokKod4");
        }

        private void buttonEdit5_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUpStokVeCariHareketleriAc("Kod 5", "stokKod5");
        }

        private void buttonEdit16_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUpStokVeCariHareketleriAc("Kod 1", "cariKod1");
        }

        private void buttonEdit15_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUpStokVeCariHareketleriAc("Kod 2", "cariKod2");
        }

        private void buttonEdit14_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUpStokVeCariHareketleriAc("Kod 3", "cariKod3");
        }

        private void buttonEdit13_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUpStokVeCariHareketleriAc("Kod 4", "cariKod4");
        }

        private void buttonEdit12_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUpStokVeCariHareketleriAc("Kod 5", "cariKod5");
        }

        private void buttonEdit11_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUpStokVeCariHareketleriAc("Kod 6", "cariKod6");
        }

        private void buttonEdit10_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUpStokVeCariHareketleriAc("Kod 7", "cariKod7");
        }

        private void txtDepo_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUpStokVeCariHareketleriAc("Depo", "Depo");
        }

        private void txtVasita_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUpStokVeCariHareketleriAc("Vasıta", "Vasita");
        }
        #endregion

        #region Mal Kodu ve Adı İşlemleri

        private void GridLookUpMalKodu_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                GridLookUpEdit GridLookUpMalKodu = sender as GridLookUpEdit;
                DataRow dr = GridLookUpMalKodu.Properties.View.GetDataRow(GridLookUpMalKodu.Properties.View.FocusedRowHandle);
                gridView1.SetFocusedRowCellValue(colSTK005_MalKodu, dr[0].ToString());
                gridView1.SetFocusedRowCellValue(colSTK004_Aciklama, dr[1].ToString());
                gridView1.SetFocusedRowCellValue(colSTK004_Birim1, dr["Birim 1"].ToString());
                gridView1.SetFocusedRowCellValue(colSTK004_Birim2, dr["Birim 2"].ToString());
                gridView1.SetFocusedRowCellValue(colSTK004_Birim3, dr["Birim 3"].ToString());
                gridView1.SetFocusedRowCellValue(colSTK004_KafileBuyuklugu, dr["Kafile Büyüklüğü"].ToString());
                gridView1.SetFocusedRowCellValue(colOtvOranKilo, dr["OtvBirim"].ToString());
                gridView1.SetFocusedRowCellValue(colSTK005_DovizCinsi, DovizParaBirimimiz);
                gridView1.SetFocusedRowCellValue(colSTK005_DovizKuru, dovizKurumuz);
                gridView1.SetFocusedRowCellValue(colSTK005_BirimFiyati, Convert.ToDecimal(dr["BirimFiyati"].ToString()));
            }
            catch (Exception)
            {
            }
        }

        private void GridLookUpMalAdi_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                GridLookUpEdit GridLookUpMalAdi = sender as GridLookUpEdit;
                DataRow dr = GridLookUpMalAdi.Properties.View.GetDataRow(GridLookUpMalAdi.Properties.View.FocusedRowHandle);
                gridView1.SetFocusedRowCellValue(colSTK005_MalKodu, dr[0].ToString());
                gridView1.SetFocusedRowCellValue(colSTK004_Aciklama, dr[1].ToString());
                gridView1.SetFocusedRowCellValue(colSTK004_Birim1, dr["Birim 1"].ToString());
                gridView1.SetFocusedRowCellValue(colSTK004_Birim2, dr["Birim 2"].ToString());
                gridView1.SetFocusedRowCellValue(colSTK004_Birim3, dr["Birim 3"].ToString());
                gridView1.SetFocusedRowCellValue(colSTK004_KafileBuyuklugu, dr["Kafile Büyüklüğü"].ToString());
                gridView1.SetFocusedRowCellValue(colOtvOranKilo, dr["OtvBirim"].ToString());
                gridView1.SetFocusedRowCellValue(colSTK005_DovizCinsi, DovizParaBirimimiz);
                gridView1.SetFocusedRowCellValue(colSTK005_DovizKuru, dovizKurumuz);
                gridView1.SetFocusedRowCellValue(colSTK005_BirimFiyati, Convert.ToDecimal(dr["BirimFiyati"].ToString()));
            }
            catch (Exception)
            {
            }
        }

        #endregion

        private void kayıtSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ps_satirSil();
        }

        #region Grid Keydown işlemleri

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (gridView1.FocusedRowHandle == gridView1.RowCount - 1)//en alt satırda ise
                        if (gridView1.FocusedColumn == gridView1.VisibleColumns[gridView1.VisibleColumns.Count - 1])//son kolan ise
                        {
                            ps_yenSatirEkle();
                            gridView1.FocusedColumn = gridView1.VisibleColumns[0];//yeni satır ekleyince ilk kolona gider
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }


            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    tblFaturaHareketleriBindingSource.EndEdit();

                    DataRow dr = gridView1.GetFocusedDataRow();

                    dr[colSTK005_DovizCinsi.FieldName] = cmbDovizCinsi.SelectedItem.ToString();
                    dr[colSTK005_DovizKuru.FieldName] = txtDovizKuru.Text;

                    if (Convert.ToDecimal(dr[colSTK005_Miktari_.FieldName].ToString()) < Convert.ToDecimal(dr[colSTK005_Miktari.FieldName].ToString()))
                    {
                        MessageBox.Show("Stokta Girdiğiniz Miktarda Ürün Bulunmamaktadır!");
                        gridView1.SetFocusedRowCellValue(colSTK005_Miktari.FieldName, (decimal)dr[colSTK005_Miktari_.FieldName]);
                    }
                    ps_MalBedeliHesapla();
                    //ps_KdvTutariHesapla();
                    //ps_OtvTutariHesapla();

                    int Flags = Convert.ToInt32(dr[colSTK005_KDVOranFlag.FieldName]);
                    dataSet1.tblFaturaHareketleri.Rows[0][colSTK005_KDVOranFlag.FieldName] = Flags;

                    if (Flags == 0)
                    {
                        gridView1.SetFocusedRowCellValue(colKdvOrani, 0);
                    }
                    else if (Flags == 2)
                    {
                        gridView1.SetFocusedRowCellValue(colKdvOraniYuzde, 1);
                    }
                    else if (Flags == 3)
                    {
                        gridView1.SetFocusedRowCellValue(colKdvOraniYuzde, 8);
                    }
                    else if (Flags == 4)
                    {
                        gridView1.SetFocusedRowCellValue(colKdvOraniYuzde, 18);
                    }
                }
                catch (Exception){}  
            }

            
            if (e.KeyCode == Keys.Delete){
                try
                {
                    if (gridView1.DataRowCount > 0)
                        if (MessageBox.Show("Seçili Kalemi Silmek İstediğinize Eminmisiniz?", "Kalem Sil!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            this.tblFaturaHareketleriBindingSource.RemoveCurrent();
                        else
                            MessageBox.Show("Silinecek Kalem Bulunamadı!");
                }
                catch (Exception){}                
            }
           
        }

        #endregion

        #region Mal Seri No ve Grid işlemleri

        private void GridLookUpSeriNo_Popup(object sender, EventArgs e)
        {
            try
            {

            DataRow dr = gridView1.GetFocusedDataRow();
            if (!string.IsNullOrEmpty(dr[0].ToString()))
            {
                //this.tblLookUpStokMiktarlariTableAdapter.stokMiktarlariniGetir(dataSet1.tblLookUpStokMiktarlari, dr[0].ToString());
                this.tblSatisIrsaliyesiMalSeriNoTableAdapter.stokMiktarlariniGetir(dataSet2.tblSatisIrsaliyesiMalSeriNo, dr[0].ToString());


                foreach (DataRow dRow in dataSet2.tblSatisIrsaliyesiMalSeriNo.Rows)
                {
                    if (dRow[0].ToString() == dr[colSTK005_MalKodu.FieldName].ToString() &&
                            dRow[1].ToString() == dr[colSTK005_MalSeriNo.FieldName].ToString())
                    {
                        dRow[5] = (decimal)dRow[5] - (decimal)dr[colSTK005_Miktari.FieldName];
                    }
                }


                foreach (DataRow dRow in dataSet2.tblSatisIrsaliyesiMalSeriNo.Rows)
                {
                    foreach (DataRow dRowGrid in dataSet1.tblFaturaHareketleri.Rows)
                    {
                        if (dRow[0].ToString() == dRowGrid[colSTK005_MalKodu.FieldName].ToString() &&
                            dRow[1].ToString() == dRowGrid[colSTK005_MalSeriNo.FieldName].ToString())
                        {
                            dRow[5] = (decimal)dRow[5] + (decimal)dRowGrid[colSTK005_Miktari.FieldName];
                        }
                    }
                }
            }
            else {
                this.dataSet2.tblSatisIrsaliyesiMalSeriNo.Clear();
            }
            }

            catch (Exception)
            {
            }
        }

        private void GridLookUpSeriNo_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                decimal miktar = 0;
                GridLookUpEdit GridLookUpSeriNo = sender as GridLookUpEdit;
                DataRow dr = GridLookUpSeriNo.Properties.View.GetDataRow(GridLookUpSeriNo.Properties.View.FocusedRowHandle);  
                miktar=(decimal)dr[4];
                gridView1.SetFocusedRowCellValue(colSTK005_Miktari_, miktar);
            }
            catch (Exception)
            {
            }
        }

        private void GirdLookUpBirimFiyat_Popup(object sender, EventArgs e)
        {
             DataRow dr = gridView1.GetFocusedDataRow();
             if (!string.IsNullOrEmpty(dr[0].ToString()))
             {
                 this.tblLookUpBirimFiyatTableAdapter.birimFiyatlariDoldur(dataSet1.tblLookUpBirimFiyat, dr[0].ToString());
             }
             else
                 this.dataSet1.tblLookUpBirimFiyat.Clear();
        }

        private void GirdLookUpBirimFiyat_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                decimal miktar = 0;
                GridLookUpEdit GirdLookUpBirimFiyat = sender as GridLookUpEdit;
                DataRow dr = GirdLookUpBirimFiyat.Properties.View.GetDataRow(GirdLookUpBirimFiyat.Properties.View.FocusedRowHandle);
                miktar = (decimal)dr[1];
                gridView1.SetFocusedRowCellValue(colSTK005_BirimFiyati, miktar);
            }
            catch (Exception)
            {
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            this.tblFaturaHareketleriBindingSource.EndEdit();
        }

        #endregion

        #region Kaydet,Sil ve Yeni işlem Butonu

        private void btnKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtFaturaNo.Text) && !string.IsNullOrEmpty(txtFaturaNo.Text))
                {
                    if (txtFaturaSeri.Text.Length < 2)
                        for (int i = txtFaturaSeri.Text.Length; i < 2; i++)
                            txtFaturaSeri.Text += " ";
                   
                    if (this.queriesTableAdapter1.evrakNoKontrol(txtFaturaSeri.Text + txtFaturaNo.Text) == 0)
                    {
                        if (string.IsNullOrEmpty(txtHesapKodu.Text))
                        {
                            MessageBox.Show("Hesap Kodu Boş Geçilemez!");
                            return;
                        }
                        if (dataSet1.tblFaturaHareketleri.Rows.Count < 1)
                        {
                            MessageBox.Show("Irsaliye Kalemi Girilmedi.");
                            return;
                        }
                        else
                        {

                        ps_faturaKaydet();
                        this.queriesTableAdapter1.blaserSonraEvrak_Seri_No_Kaydet(txtFaturaSeri.Text,Convert.ToInt32(txtFaturaNo.Text),1);
                        MessageBox.Show(txtFaturaSeri.Text + txtFaturaNo.Text  +" no lu Fatura Sisteme Kaydedilmiştir!");
                        ps_EvrakSeri_EvrakNo_Getir();
                        
                        }

                    }
                    else
                        MessageBox.Show("Bu Fatura No Sistemde Kayıtlı!");
                }
                else
                    MessageBox.Show("Fatura No Boş Girilemez!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }          
        }

        private void btnYeni_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            satirTipiTextBox.Text = "";
            txtHesapKodu.Text = "";
            txtUnvan.Text = "";
            txtUnvan1.Text = "";
            txtAdres.Text = "";
            txtAdres1.Text = "";
            txtAdres2.Text = "";
            txtVergiDairesi.Text = "";
            txtVergiDairesiKodu.Text = "";
            txtVergiNo.Text = "";
            lblBA.Text = "";
            txtBA.EditValue = "0";

            txtHesapKodu2.Text = "";
            txtUnvan11.Text = "";
            txtUnvan12.Text = "";
            txtAdres11.Text = "";
            txtAdres12.Text = "";
            txtAdres13.Text = "";
            txtVergiDairesi2.Text = "";
            txtVergiDairesiKodu2.Text = "";
            txtVergiNo2.Text = "";
            lblBA2.Text = "";
            txtBA2.EditValue = "0";

            dtFaturaTarihi.DateTime = DateTime.Now;
            //son fatura no
            dtIrsaliyeTarihi.DateTime = DateTime.Now;
            dtSevkTarihi.DateTime = DateTime.Now;
            dtSiparisTarihi.DateTime = DateTime.Now;
            dtVadeTarihi.DateTime = DateTime.Now;
            dtKdvTarihi.DateTime = DateTime.Now;
            dtOtvTarihi.DateTime = DateTime.Now;

            txtKod1.Text = "";
            txtKod2.Text = "";
            txtKod3.Text = "";
            txtKod4.Text = "";
            txtKod5.Text = "";

            txtCariKod1.Text = "";
            txtCariKod2.Text = "";
            txtCariKod3.Text = "";
            txtCariKod4.Text = "";
            txtCariKod5.Text = "";
            txtCariKod6.Text = "";
            txtCariKod7.Text = "";

            txtVasita.Text = "";
            txtTaksitSayisi.Text = "1";
            dataSet1.tblFaturaHareketleri.Clear();
            TaksitSil();
            TopluIrsaliyeSil();
            TopluSiparisleriSil();
            ps_yenSatirEkle();
        }

        private void btnSil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Silmek İstediğinize Emin misiniz?","Fatura Sil",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                
            }
        }

        #endregion

        #region "Dip Toplam İşlemleri"
        private void txtMalBedeli_EditValueChanged(object sender, EventArgs e)
        {
            ps_KdvMatrahiHesapla();
        }
        private void txtNetTutar_EditValueChanged(object sender, EventArgs e)
        {
            ps_KdvMatrahiHesapla();
        }
        private void txtOtv_EditValueChanged(object sender, EventArgs e)
        {
            ps_KdvMatrahiHesapla();
        }

        private void txtKdvMatrahi_EditValueChanged(object sender, EventArgs e)
        {
            ps_GenelToplam();
        }

        private void txtKdv_EditValueChanged(object sender, EventArgs e)
        {
            ps_GenelToplam();
        }
        #endregion

        #region Grid Kolonlarını Kaydediyoruz

        private void btnKolonlarıiKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        #endregion

        #region KdvOrani LookupGrid

        private void GridLookUpKdvOrani_KeyUp(object sender, KeyEventArgs e)
        {         
          
        }

        private void GridLookUpKdvOrani_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                int flag = 0;
                GridLookUpEdit GridLookUpKdvOrani = sender as GridLookUpEdit;
                DataRow dr = GridLookUpKdvOrani.Properties.View.GetDataRow(GridLookUpKdvOrani.Properties.View.FocusedRowHandle);
                flag = Convert.ToInt16(dr[0]);
                gridView1.SetFocusedRowCellValue(colSTK005_KDVOranFlag, flag);
            }
            catch (Exception)
            {
            }
        }
        
        #endregion

        #region SeriNumarası Butonu,Irsaliyeler ve Siparişler İşlemleri

        private void btnSeriyeGoreSonNumara_Click(object sender, EventArgs e)
        {
        }

        private void txtFaturaNo_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUpKayitliFaturalar = new Ayarlar.LookUpKayitlikFaturalar_OtvFatura();
            frmLookUpKayitliFaturalar.frmOtvliSatisFaturasi = this;
            frmLookUpKayitliFaturalar.Owner = this;
            frmLookUpKayitliFaturalar.ShowDialog();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //ps_MalBedeliHesapla();
        }

        private void btnSeriNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (gridView1.RowCount>0)
                {
                    DataRow dr = gridView1.GetFocusedDataRow();
                    if (!string.IsNullOrEmpty(dr[0].ToString()))
	                {
                        MessageBox.Show(dr[0].ToString());
                        frmMalSeriNo = new Ayarlar.LookUpFormMalSeriNo();
                        frmMalSeriNo.malKodu = dr[0].ToString();
                        frmMalSeriNo.Text = "Mal Seri No"+"{"+dr[0]+"}";
                        frmMalSeriNo.ShowDialog();
	                } 
                }                
            }
            catch (Exception)
            {
            }
        }

        private void txtIrsaliyeNo_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmKayitliIrsaliyeler = new Ayarlar.frmKayitliIrsaliye_OtvFatura();
            frmKayitliIrsaliyeler.frmOtvliSatisFaturasi = this;
            frmKayitliIrsaliyeler.Owner = this;
            frmKayitliIrsaliyeler.ShowDialog();

            if (!string.IsNullOrEmpty(dtIrsaliyeTarihi.DateTime.ToString()))
            {
                dt30luTarih1.DateTime = dtIrsaliyeTarihi.DateTime;
                if (!string.IsNullOrEmpty(txtIrsaliyeNo.Text.ToString()))
                {
                    txt30luIrsaliyeSeri1.Text = txtIrsaliyeNo.Text.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo1.Text = txtIrsaliyeNo.Text.ToString().Substring(1, 7);
                }
            }

        }

        private void txtSiparisNo_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmKayitliSiparisler = new Ayarlar.frmKayitliSiparis_OtvFatura();
            frmKayitliSiparisler.frmOtvliSatisFaturasi = this;
            frmKayitliSiparisler.Owner = this;
            frmKayitliSiparisler.ShowDialog();

            if (!string.IsNullOrEmpty(dtSiparisTarihi.DateTime.ToString()))
            {
                dt30luSiparisTarih1.DateTime = dtSiparisTarihi.DateTime;
                if (!string.IsNullOrEmpty(txtSiparisNo.Text.ToString()))
                {
                    txt30luSiparisNo1.Text = txtSiparisNo.Text.ToString().Substring(1, 7);
                    txt30luSiparisSeri1.Text = txtSiparisNo.Text.ToString().Substring(0, 2);
                }
            }

        }

        #endregion

        #region Kayıtlı Irsaliye ve Cariyi Getiriyoruz

        public void ps_kayitliIrsaliyeGetir(string IrsaliyeNumarasi)
        {
            this.tblFaturaHareketleriTableAdapter.KayitliIrsaliyeler(dataSet1.tblFaturaHareketleri, IrsaliyeNumarasi);
            ps_GenelToplam();
            ps_MalBedeliHesapla();

            txtHesapKodu2.Text = "";
            txtUnvan11.Text = "";
            txtUnvan12.Text = "";
            txtAdres11.Text = "";
            txtAdres12.Text = "";
            txtAdres13.Text = "";
            txtVergiDairesi2.Text = "";
            txtVergiDairesiKodu2.Text = "";
            txtVergiNo2.Text = "";
            lblBA2.Text = "";
            txtBA2.EditValue = "0";
        }

        public void ps_kayitliIrsaliyeninCarisi(string cariKodu)
        {
            this.tblCariHesaplarTableAdapter1.HesapKodluCariHesaplar(this.dataSet2.tblCariHesaplar, cariKodu);

            if (dataSet2.tblCariHesaplar.Rows.Count > 0)
            {
                DataRow dr = dataSet2.tblCariHesaplar.Rows[0];
                txtHesapKodu.Text = dr[0].ToString();
                txtUnvan.Text = dr[1].ToString();
                txtUnvan1.Text = dr[2].ToString();
                txtAdres.Text = dr[3].ToString();
                txtAdres1.Text = dr[4].ToString();
                txtAdres2.Text = dr[5].ToString();
                txtVergiDairesiKodu.Text = dr[6].ToString();
                txtVergiDairesi.Text = dr[7].ToString();
                txtVergiNo.Text = dr[8].ToString();
                lblBA.Text = dr[14].ToString();
                txtBA.Text = dr[13].ToString();
                cmbDovizCinsi.EditValue = dr[9].ToString();
                IskontoOranimiz = Convert.ToDecimal(dr[12].ToString());
                DovizHesapKodumuz = dr[0].ToString();
                DovizParaBirimimiz = dr[9].ToString();
                OpsiyonGunu = Convert.ToInt32(dr[17].ToString());

                if (Convert.ToDecimal(dr[16].ToString()) == 0)
                {
                    dovizKurumuz = (decimal)this.evrakNoSeriTableAdapter1.DovizKuru(DovizHesapKodumuz, DovizParaBirimimiz);
                    //frmLookUpSatisIrsaliyesiMalKodu.dovizKurumuz = dovizKurumuz;
                }
                else
                {
                    dovizKurumuz = Convert.ToDecimal(dr[16].ToString());
                    //frmLookUpSatisIrsaliyesiMalKodu.dovizKurumuz = dovizKurumuz;
                }
                //Vade Tarihini Opsiyon Gününe Göre Ayarlıyoruz
                DateTime dtsVadeTarihi = new DateTime();
                string VadeTarihimiz = Convert.ToString(dtVadeTarihi.DateTime.ToOADate());
                VadeTarihimiz = VadeTarihimiz.ToString().Substring(0, 5);
                VadeTarihi = Convert.ToInt32(VadeTarihimiz);
                VadeTarihi = VadeTarihi + OpsiyonGunu;
                dtsVadeTarihi = DateTime.FromOADate(VadeTarihi);
                dtVadeTarihi.DateTime = dtsVadeTarihi;
                dtSevkTarihi.DateTime = dtsVadeTarihi;
                //

                txtDovizKuru.Text = Convert.ToString(dovizKurumuz);
                gridView1.SetFocusedRowCellValue(colSTK005_Iskonto, IskontoOranimiz);
                this.tblAltCariHesaplarTableAdapter.AltCariHesaplariGetir(dataSet2.tblAltCariHesaplar, txtHesapKodu.Text);
            }

            txtHesapKodu2.Text = "";
            txtUnvan11.Text = "";
            txtUnvan12.Text = "";
            txtAdres11.Text = "";
            txtAdres12.Text = "";
            txtAdres13.Text = "";
            txtVergiDairesi2.Text = "";
            txtVergiDairesiKodu2.Text = "";
            txtVergiNo2.Text = "";
            lblBA2.Text = "";
            txtBA2.EditValue = "0";

        }

        public void ps_KayitliSiparisGetir(string SiparisNumarasi)
        {
            this.tblFaturaHareketleriTableAdapter.KayitliSiparisler(dataSet1.tblFaturaHareketleri, SiparisNumarasi);
            ps_GenelToplam();


            foreach (DataRow dr in dataSet1.tblFaturaHareketleri.Rows)
            {
                decimal MalToplamDeger = (decimal)dr[colSTK005_Miktari.FieldName] * (decimal)dr[colSTK005_BirimFiyati.FieldName];
                MalToplamDeger = Math.Round(MalToplamDeger, 2);
                gridView1.SetFocusedRowCellValue(colSTK005_Tutari, MalToplamDeger);
            }

            ps_MalBedeliHesapla();

            txtHesapKodu2.Text = "";
            txtUnvan11.Text = "";
            txtUnvan12.Text = "";
            txtAdres11.Text = "";
            txtAdres12.Text = "";
            txtAdres13.Text = "";
            txtVergiDairesi2.Text = "";
            txtVergiDairesiKodu2.Text = "";
            txtVergiNo2.Text = "";
            lblBA2.Text = "";
            txtBA2.EditValue = "0";

        }

        public void ps_kayitliIrsaliyeOnDegerleri(string IrsaliyeEvrakNo)
        {
            this.tblEskiKayitIrsaliyeOnDegerleriTableAdapter1.Fill(this.dataSet1.tblEskiKayitIrsaliyeOnDegerleri, IrsaliyeEvrakNo);

            if (dataSet1.tblEskiKayitIrsaliyeOnDegerleri.Rows.Count > 0)
            {
                DataRow dr = dataSet1.tblEskiKayitIrsaliyeOnDegerleri.Rows[0];
                txtKod1.Text = dr[colSTK005_Kod1.FieldName].ToString();
                txtKod2.Text = dr[colSTK005_Kod2.FieldName].ToString();
                txtKod3.Text = dr[colSTK005_Kod3.FieldName].ToString();
                txtKod4.Text = dr[colSTK005_Kod4.FieldName].ToString();
                txtKod5.Text = dr[colSTK005_Kod5.FieldName].ToString();
                txtVasita.Text = dr[colSTK005_Vasita.FieldName].ToString();
                txtDepo.Text = dr[colSTK005_Depo.FieldName].ToString();

                string SevkiyatTarihi = Convert.ToString(dr["STK005_SevkTarihi"]);

                if (string.IsNullOrEmpty(SevkiyatTarihi))
                {
                    dtSevkTarihi.DateTime = DateTime.Now;
                }
                else
                {
                    dtSevkTarihi.DateTime = (DateTime)dr["STK005_SevkTarihi"];
                }

                string SiparisTarimiz = Convert.ToString(dr["STK005_SiparisTarihi"]);

                if (string.IsNullOrEmpty(SiparisTarimiz))
                {
                    dtSiparisTarihi.DateTime = DateTime.Now;
                }
                else
                {
                    dtSiparisTarihi.DateTime = (DateTime)dr["STK005_SiparisTarihi"];
                }

                dtIrsaliyeTarihi.DateTime = (DateTime)dr["STK005_IrsaliyeFaturaTarihi"];
                txtSiparisNo.Text = dr["STK005_SiparisNo"].ToString();
                dtVadeTarihi.DateTime = (DateTime)dr["STK005_VadeTarihi"];
                cmbIslemTipi.SelectedIndex = (int)dr["STK005_IslemTipi"];

            }
        }

        public void ps_KayitiliSiparisOnDegerleri(string SiparisNumber)
        {
            this.tblEskiSiparisOnDegerleriTableAdapter1.Fill(this.dataSet1.tblEskiSiparisOnDegerleri, SiparisNumber);

            if (dataSet1.tblEskiSiparisOnDegerleri.Rows.Count > 0)
            {
                DataRow dr = dataSet1.tblEskiSiparisOnDegerleri.Rows[0];
                txtKod1.Text = dr[colSTK005_Kod1.FieldName].ToString();
                txtKod2.Text = dr[colSTK005_Kod2.FieldName].ToString();
                txtKod3.Text = dr[colSTK005_Kod3.FieldName].ToString();
                txtKod4.Text = dr[colSTK005_Kod4.FieldName].ToString();
                txtKod5.Text = dr[colSTK005_Kod5.FieldName].ToString();
                txtVasita.Text = dr[colSTK005_Vasita.FieldName].ToString();
                txtDepo.Text = dr[colSTK005_Depo.FieldName].ToString();

                dtIrsaliyeTarihi.DateTime = (DateTime)dr["STK005_IrsaliyeFaturaTarihi"];
                dtSiparisTarihi.DateTime = (DateTime)dr["STK005_SiparisTarihi"];
                dtVadeTarihi.DateTime = (DateTime)dr["STK005_VadeTarihi"];
                cmbIslemTipi.SelectedIndex = (int)dr["STK005_IslemTipi"];
            }
        }

        #endregion

        #region Bayilerin Seçim İşlemleri

        private void txtHesapKodu2_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            try
            {
                GridLookUpEdit hesapKoduLookUpEdit = sender as GridLookUpEdit;
                DataRow dr = hesapKoduLookUpEdit.Properties.View.GetDataRow(hesapKoduLookUpEdit.Properties.View.FocusedRowHandle);
                txtHesapKodu2.Text = dr[0].ToString();
                txtUnvan11.Text = dr[1].ToString();
                txtUnvan12.Text = dr[2].ToString();
                txtAdres11.Text = dr[3].ToString();
                txtAdres12.Text = dr[4].ToString();
                txtAdres13.Text = dr[5].ToString();
                txtVergiDairesiKodu2.Text = dr[6].ToString();
                txtVergiDairesi2.Text = dr[7].ToString();
                txtVergiNo2.Text = dr[8].ToString();
                lblBA2.Text = dr[14].ToString();
                txtBA2.Text = dr[13].ToString();

            }
            catch (Exception)
            {
            }
        }

        private void txtBA2_TextChanged(object sender, EventArgs e)
        {
            if (lblBA2.Text == "B")
                lblBA2.Appearance.ForeColor = Color.Red;
            else
                lblBA2.Appearance.ForeColor = Color.Blue;
        }

        private void txtUnvan11_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            try
            {
                GridLookUpEdit hesapKoduLookUpEdit = sender as GridLookUpEdit;
                DataRow dr = hesapKoduLookUpEdit.Properties.View.GetDataRow(hesapKoduLookUpEdit.Properties.View.FocusedRowHandle);
                txtHesapKodu2.Text = dr[0].ToString();
                txtUnvan11.Text = dr[1].ToString();
                txtUnvan12.Text = dr[2].ToString();
                txtAdres11.Text = dr[3].ToString();
                txtAdres12.Text = dr[4].ToString();
                txtAdres13.Text = dr[5].ToString();
                txtVergiDairesiKodu2.Text = dr[6].ToString();
                txtVergiDairesi2.Text = dr[7].ToString();
                txtVergiNo2.Text = dr[8].ToString();
                lblBA2.Text = dr[14].ToString();
                txtBA2.Text = dr[13].ToString();
            }
            catch (Exception)
            {
            }
        }

        #endregion

        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (satirTipiTextBox.Text == "M")
            {
                if (e.FocusedColumn == colSTK005_Miktari || e.FocusedColumn == colSTK005_BirimFiyati || e.FocusedColumn == colSTK005_Tutari)//enetera bastığında  Miktar veya BirimFiyat  kolonundaysa  => Tutarı hesapla
                {
                    double miktar = Convert.ToDouble(gridView1.GetFocusedRowCellValue(colSTK005_Miktari));
                    double birimFiyat = Convert.ToDouble(gridView1.GetFocusedRowCellValue(colSTK005_BirimFiyati));
                    double sonuc = miktar * birimFiyat;
                    gridView1.SetFocusedRowCellValue(colSTK005_Tutari, sonuc);
                }

                if (e.FocusedColumn == colSTK005_Miktar2 || e.FocusedColumn == colSTK004_Birim2)//enetera bastığında  Miktar*KafileBüyüklüğü ile Miktarı Buluyoruz
                {
                    int Nums = gridView1.FocusedRowHandle;
                    if ((string)dataSet2.tblStk005Irsaliye.Rows[Nums]["STK004_Birim1"].ToString() == "KG" || (string)dataSet2.tblStk005Irsaliye.Rows[Nums]["STK004_Birim1"].ToString() == "LT")
                    {
                        decimal miktar2 = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(colSTK005_Miktar2));
                        decimal KafileBuyuklugumuz = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(colSTK004_KafileBuyuklugu));
                        decimal sonuc = miktar2 * KafileBuyuklugumuz;
                        gridView1.SetFocusedRowCellValue(colSTK005_Miktari, sonuc);
                    }
                }
            }
        }

        #region Uygulanacak Fiyat Tipleri

        private string UygulanacakFiyatGetirCariden(string KolonID)
        {
            switch (KolonID)
            {
                case "00": sonuc = "Valör gün üzerinden bulunsun"; break;
                case "01": sonuc = "Alış Fiyatı 1"; break;
                case "02": sonuc = "Alış Fiyatı 2"; break;
                case "03": sonuc = "Alış Fiyatı 3"; break;
                case "04": sonuc = "Satış Fiyatı 1"; break;
                case "05": sonuc = "Satış Fiyatı 2"; break;
                case "06": sonuc = "Satış Fiyatı 3"; break;
                case "07": sonuc = "Satış Fiyatı 4"; break;
                case "08": sonuc = "Satış Fiyatı 5"; break;
                case "09": sonuc = "Satış Fiyatı 6"; break;
                case "11": sonuc = "Döviz Alış Fiyatı 1"; break;
                case "12": sonuc = "Döviz Alış Fiyatı 2"; break;
                case "13": sonuc = "Döviz Alış Fiyatı 3"; break;
                case "14": sonuc = "Döviz Satış Fiyatı 1"; break;
                case "15": sonuc = "Döviz Satış Fiyatı 2"; break;
                case "16": sonuc = "Döviz Satış Fiyatı 3"; break;
                case "17": sonuc = "Ort.Alış Fiyatı"; break;
                case "18": sonuc = "Ort.Satış Fiyatı"; break;
                case "19": sonuc = "Son Maliyet Birim Fiyatı"; break;
                case "20": sonuc = "Son Alış Fiyatı"; break;
                case "21": sonuc = "Son Satış Fiyatı"; break;
                case "22": sonuc = "Son Döviz Alış Fiyatı"; break;
                case "23": sonuc = "Son Döviz Satış Fiyatı"; break;
                case "24": sonuc = "Ortalama Maliyet"; break;
                case "25": sonuc = "Bakiye Ortalama Maliyet"; break;
                case "26": sonuc = "Ortalama Net Fiyat"; break;
                case "27": sonuc = "Bakiye Ortalama Net Fiyat"; break;
            }
            string Yeniislem = sonuc;
            return Yeniislem;
        }

        private string UygulanacakFiyatGetir(string KolonID)
        {
            switch (KolonID)
            {
                case "Valör gün üzerinden bulunsun": sonuc = "00"; break;
                case "Alış Fiyatı 1": sonuc = "01"; break;
                case "Alış Fiyatı 2": sonuc = "02"; break;
                case "Alış Fiyatı 3": sonuc = "03"; break;
                case "Satış Fiyatı 1": sonuc = "04"; break;
                case "Satış Fiyatı 2": sonuc = "05"; break;
                case "Satış Fiyatı 3": sonuc = "06"; break;
                case "Satış Fiyatı 4": sonuc = "07"; break;
                case "Satış Fiyatı 5": sonuc = "08"; break;
                case "Satış Fiyatı 6": sonuc = "09"; break;
                case "Döviz Alış Fiyatı 1": sonuc = "11"; break;
                case "Döviz Alış Fiyatı 2": sonuc = "12"; break;
                case "Döviz Alış Fiyatı 3": sonuc = "13"; break;
                case "Döviz Satış Fiyatı 1": sonuc = "14"; break;
                case "Döviz Satış Fiyatı 2": sonuc = "15"; break;
                case "Döviz Satış Fiyatı 3": sonuc = "16"; break;
                case "Ort.Alış Fiyatı": sonuc = "17"; break;
                case "Ort.Satış Fiyatı": sonuc = "18"; break;
                case "Son Maliyet Birim Fiyatı": sonuc = "19"; break;
                case "Son Alış Fiyatı": sonuc = "20"; break;
                case "Son Satış Fiyatı": sonuc = "21"; break;
                case "Son Döviz Alış Fiyatı": sonuc = "22"; break;
                case "Son Döviz Satış Fiyatı": sonuc = "23"; break;
                case "Ortalama Maliyet": sonuc = "24"; break;
                case "Bakiye Ortalama Maliyet": sonuc = "25"; break;
                case "Ortalama Net Fiyat": sonuc = "26"; break;
                case "Bakiye Ortalama Net Fiyat": sonuc = "27"; break;
            }
            string Yeniislem = sonuc;
            FiyatID = sonuc;
            return Yeniislem;
        }

        private void cmUygulanacakFiyat_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Fiyatimiz = cmUygulanacakFiyat.EditValue.ToString();
            UygulanacakFiyatKolonID = UygulanacakFiyatGetir(Fiyatimiz);
            this.tblLookUpStokKartlariTableAdapter.lookUpStokKartlari(this.dataSet1.tblLookUpStokKartlari, FiyatID);
        }

        #endregion

        private void cmbKalemdeKdv_SelectedIndexChanged(object sender, EventArgs e)
        {
            KdvSekli = cmbKalemdeKdv.EditValue.ToString();
        }

        private void OtvliSatisFaturasi_KeyDown(object sender, KeyEventArgs e)
        {
            #region enter geçiş
            if (e.KeyCode == Keys.Enter && gridDurum == false)
            {
                if (f < 3)
                {
                    if (dtIrsaliyeTarihi.IsEditorActive)
                    {
                        if (f != 3)
                        {
                            if (f < 2 || f == 1)
                            {
                                SendKeys.Send(".");
                                dtIrsaliyeTarihi.EnterMoveNextControl = false;
                            }
                            f++;
                            if (f == 3)
                            {
                                f = 0;
                                dtIrsaliyeTarihi.EnterMoveNextControl = true;
                            }

                        }
                    }
                    if (dtSevkTarihi.IsEditorActive)
                    {
                        if (f != 3)
                        {
                            if (f < 2 || f == 1)
                            {
                                SendKeys.Send(".");
                                dtSevkTarihi.EnterMoveNextControl = false;
                            }
                            f++;
                            if (f == 3)
                            {
                                f = 0;
                                dtSevkTarihi.EnterMoveNextControl = true;
                            }
                        }
                    }
                    if (dtVadeTarihi.IsEditorActive)
                    {
                        if (f != 3)
                        {
                            if (f < 2 || f == 1)
                            {
                                SendKeys.Send(".");
                                dtVadeTarihi.EnterMoveNextControl = false;
                            }
                            f++;
                            if (f == 3)
                            {
                                f = 0;
                                dtVadeTarihi.EnterMoveNextControl = true;
                            }
                        }
                    }
                    if (dtSiparisTarihi.IsEditorActive)
                    {
                        if (f != 3)
                        {
                            if (f < 2 || f == 1)
                            {
                                SendKeys.Send(".");
                                dtSiparisTarihi.EnterMoveNextControl = false;
                            }
                            f++;
                            if (f == 3)
                            {
                                f = 0;
                                dtSiparisTarihi.EnterMoveNextControl = true;
                            }
                        }
                    }
                    if (dtFaturaTarihi.IsEditorActive)
                    {
                        if (f != 3)
                        {
                            if (f < 2 || f == 1)
                            {
                                SendKeys.Send(".");
                                dtFaturaTarihi.EnterMoveNextControl = false;
                            }
                            f++;
                            if (f == 3)
                            {
                                f = 0;
                                dtFaturaTarihi.EnterMoveNextControl = true;
                            }
                        }
                    }
                    if (dtKdvTarihi.IsEditorActive)
                    {
                        if (f != 3)
                        {
                            if (f < 2 || f == 1)
                            {
                                SendKeys.Send(".");
                                dtKdvTarihi.EnterMoveNextControl = false;
                            }
                            f++;
                            if (f == 3)
                            {
                                f = 0;
                                dtKdvTarihi.EnterMoveNextControl = true;
                            }
                        }
                    }
                    if (dtOtvTarihi.IsEditorActive)
                    {
                        if (f != 3)
                        {
                            if (f < 2 || f == 1)
                            {
                                SendKeys.Send(".");
                                dtOtvTarihi.EnterMoveNextControl = false;
                            }
                            f++;
                            if (f == 3)
                            {
                                f = 0;
                                dtOtvTarihi.EnterMoveNextControl = true;
                            }
                        }
                    }
                    if (dtPanelSiparis.IsEditorActive)
                    {
                        if (f != 3)
                        {
                            if (f < 2 || f == 1)
                            {
                                SendKeys.Send(".");
                                dtPanelSiparis.EnterMoveNextControl = false;
                            }
                            f++;
                            if (f == 3)
                            {
                                f = 0;
                                dtPanelSiparis.EnterMoveNextControl = true;
                            }
                        }
                    }
                    if (dtPanelIrsaliye.IsEditorActive)
                    {
                        if (f != 3)
                        {
                            if (f < 2 || f == 1)
                            {
                                SendKeys.Send(".");
                                dtPanelIrsaliye.EnterMoveNextControl = false;
                            }
                            f++;
                            if (f == 3)
                            {
                                f = 0;
                                dtPanelIrsaliye.EnterMoveNextControl = true;
                            }
                        }
                    }
                }
                //if (f == 0 || f > 3 || f == 3)
                //{
                //    this.SelectNextControl(ActiveControl, true, true, true, true);
                //}
            }

            #endregion

            if (e.KeyCode == Keys.Insert)
            {
                btnKaydet.PerformClick();
            }
            if (e.Control&&e.KeyCode==Keys.N)
            {
                if (string.IsNullOrEmpty(txtHesapKodu.Text))
                {
                    MessageBox.Show("Hesap Kodu Seçmediniz.");
                }
                else
                {
                    dataSet2.tblCtrlNIrsaliyeler.Clear();
                    pnIrsaliye.Location = new Point(0, 0);
                    pnIrsaliye.Width = 718;
                    pnIrsaliye.Height = 225;
                    pnIrsaliye.Visible = true;
                }
            }
            if (e.Control && e.KeyCode == Keys.E)
            {
                if (string.IsNullOrEmpty(txtHesapKodu.Text))
                {
                    MessageBox.Show("Hesap Kodu Seçmediniz.");
                }
                else
                {
                    dataSet2.tblCtrlNIrsaliyeler.Clear();
                    pnSiparisler.Location = new Point(0, 0);
                    pnSiparisler.Width = 718;
                    pnSiparisler.Height = 225;
                    pnSiparisler.Visible = true;
                    
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (pnIrsaliye.Visible == true || pn30luIrsaliye.Visible == true)
                {
                    pnIrsaliye.Visible = false;
                    dtPanelIrsaliye.EditValue = null;
                    pn30luIrsaliye.Visible = false;
                }
                if (pnSiparisler.Visible == true || pn30luSiparisler.Visible == true)
                {
                    pnSiparisler.Visible = false;
                    dtPanelSiparis.EditValue = null;
                    pn30luSiparisler.Visible = false;
                }
                dataSet2.tblCtrlNIrsaliyeler.Clear();

                if (pnGtipNo.Visible == true)
                {
                    txtgtipAciklama1.Text = null;
                    txtgtipAciklama2.Text = null;
                    txtgtipAciklama3.Text = null;
                    txtgtipAciklama4.Text = null;
                    txtgtipKilo.Text = null;
                    txtgtipno.Text = null;
                    txtgtipListe.Text = null;
                    txtgtipOran.Text = null;
                    gtipTarih.EditValue = null;
                    pnGtipNo.Visible = false;
                    dataSet2.tblGtipNo.Clear();
                }
            }
        }

        private void btnYazdir_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (cmbFaturalar.SelectedIndex == -1 || string.IsNullOrEmpty(cmbFaturalar.SelectedItem.ToString()))
                    MessageBox.Show("Kayıtlı Fatura Tasarımı Bulunamadı!");
                else
                    if (!string.IsNullOrEmpty(txtHesapKodu.Text) || !string.IsNullOrEmpty(txtFaturaNo.Text + txtFaturaSeri.Text))
                    {
                        this.rapor_CariBilgilerTableAdapter1.Fill(this.dataSet1.rapor_CariBilgiler, txtHesapKodu.Text);
                        this.rapor_EvrakHareketleriTableAdapter1.Fill(this.dataSet1.rapor_EvrakHareketleri, txtFaturaSeri.Text + txtFaturaNo.Text);

                        report1.Load(Application.StartupPath + @"\Raporlar\Satis Faturasi\" + cmbFaturalar.SelectedItem.ToString());
                        report1.RegisterData(this.dataSet1.Tables["rapor_CariBilgiler"], "CariBilgiler");
                        report1.RegisterData(this.dataSet1.Tables["rapor_EvrakHareketleri"], "EvrakSatirlari");

                        report1.SetParameterValue("Başlık1", txtBaslik.Text);
                        report1.SetParameterValue("Başlık2", txtBaslik1.Text);
                        report1.SetParameterValue("DovizKuru", txtDovizKuru.Text);

                        report1.SetParameterValue("AraToplam", txtMalBedeli.Text);
                        report1.SetParameterValue("İskonto", txtIskonto.Text);
                        report1.SetParameterValue("Toplam", txtNetTutar.Text);
                        report1.SetParameterValue("ÖTV_Tutari", txtOtv.Text);
                        report1.SetParameterValue("KDV_Matrahi", txtKdvMatrahi.Text);
                        report1.SetParameterValue("KDV", txtKdv.Text);
                        report1.SetParameterValue("GenelToplam", txtGenelToplam.Text);

                        report1.SetParameterValue("YaziylaTutar", sayiyiYaziyaCevir(Convert.ToDecimal(txtGenelToplam.Text)));

                        report1.Show();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnPnIrsaliyeGetir_Click(object sender, EventArgs e)
        {
            int TarihliSorgu = 0;
            dataSet2.tblCtrlNIrsaliyeler.Clear();

            if (string.IsNullOrEmpty(Convert.ToString(dtPanelIrsaliye.EditValue)))
            {
                tblCtrlNIrsaliyelerTableAdapter.CtrlNIrsaliyeleri(dataSet2.tblCtrlNIrsaliyeler, txtHesapKodu.Text);

                if (dataSet2.tblCtrlNIrsaliyeler.Rows.Count == 0)
                {
                    MessageBox.Show("Kayıt Bulunamadı.");
                }
            }
            else
            {
                string TarihliSorgumuz = Convert.ToString(dtPanelIrsaliye.DateTime.ToOADate());
                TarihliSorgumuz = TarihliSorgumuz.ToString().Substring(0, 5);
                TarihliSorgu = Convert.ToInt32(TarihliSorgumuz);

                tblCtrlNIrsaliyelerTableAdapter.CtrlTarihliIrsaliyeler(dataSet2.tblCtrlNIrsaliyeler,txtHesapKodu.Text, TarihliSorgu);

                if (dataSet2.tblCtrlNIrsaliyeler.Rows.Count == 0)
                {
                    MessageBox.Show("Kayıt Bulunamadı.");
                }
            
            }
        }

        private void btnTaksitHesapla_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TaksitSil();
            
            decimal TaksitNetTutari = Convert.ToDecimal(txtNetTutar.Text);
            decimal TaksitIskonto = Convert.ToDecimal(txtIskonto.Text);
            decimal TaksitPesinat = Convert.ToDecimal(txtTaksitPesinat.Text);
            int TaksitSayisi = Convert.ToInt32(txtTaksitSayisi.Text);

            //TaksitSayisi = TaksitSayisi;
            TaksitNetTutari = TaksitNetTutari - TaksitIskonto - TaksitPesinat;
            decimal TaksitTutarlari = TaksitNetTutari / TaksitSayisi;

            txtTaksitToplami.Text = txtNetTutar.Text;
            txtTaksitKdvTutari.Text = txtKdv.Text;
            txtTaksitNetTutari.Text = txtNetTutar.Text;

            #region Taksit Hesaplama

            for (int i = 0; i < TaksitSayisi; i++)
            {
                if (i == 0)
                {
                    txtTaksit1.Text = Convert.ToString(TaksitTutarlari);

                    DateTime dtsTaksit1 = new DateTime();
                    string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                    TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                    VadeTarihi = Convert.ToInt32(TaksitVademiz);
                    VadeTarihi = VadeTarihi + 30;
                    dtsTaksit1 = DateTime.FromOADate(VadeTarihi);
                    dtTaksit1.DateTime = dtsTaksit1;
                }
                else if (i == 1)
                {
                    txtTaksit2.Text = Convert.ToString(TaksitTutarlari);

                    DateTime dtsTaksit2 = new DateTime();
                    string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                    TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                    VadeTarihi = Convert.ToInt32(TaksitVademiz);
                    VadeTarihi = VadeTarihi + 60;
                    dtsTaksit2 = DateTime.FromOADate(VadeTarihi);
                    dtTaksit2.DateTime = dtsTaksit2;
                }
                else if (i == 2)
                {
                    txtTaksit3.Text = Convert.ToString(TaksitTutarlari);

                    DateTime dtsTaksit3 = new DateTime();
                    string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                    TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                    VadeTarihi = Convert.ToInt32(TaksitVademiz);
                    VadeTarihi = VadeTarihi + 90;
                    dtsTaksit3 = DateTime.FromOADate(VadeTarihi);
                    dtTaksit3.DateTime = dtsTaksit3;
                }
                else if (i == 3)
                {
                    txtTaksit4.Text = Convert.ToString(TaksitTutarlari);

                    DateTime dtsTaksit4 = new DateTime();
                    string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                    TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                    VadeTarihi = Convert.ToInt32(TaksitVademiz);
                    VadeTarihi = VadeTarihi + 120;
                    dtsTaksit4 = DateTime.FromOADate(VadeTarihi);
                    dtTaksit4.DateTime = dtsTaksit4;
                }
                else if (i == 4)
                {
                    txtTaksit5.Text = Convert.ToString(TaksitTutarlari);

                    DateTime dtsTaksit5 = new DateTime();
                    string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                    TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                    VadeTarihi = Convert.ToInt32(TaksitVademiz);
                    VadeTarihi = VadeTarihi + 150;
                    dtsTaksit5 = DateTime.FromOADate(VadeTarihi);
                    dtTaksit5.DateTime = dtsTaksit5;
                }
                else if (i == 5)
                {
                    txtTaksit6.Text = Convert.ToString(TaksitTutarlari);

                    DateTime dtsTaksit6 = new DateTime();
                    string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                    TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                    VadeTarihi = Convert.ToInt32(TaksitVademiz);
                    VadeTarihi = VadeTarihi + 180;
                    dtsTaksit6 = DateTime.FromOADate(VadeTarihi);
                    dtTaksit6.DateTime = dtsTaksit6;
                }
                else if (i == 6)
                {
                    txtTaksit7.Text = Convert.ToString(TaksitTutarlari);

                    DateTime dtsTaksit7 = new DateTime();
                    string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                    TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                    VadeTarihi = Convert.ToInt32(TaksitVademiz);
                    VadeTarihi = VadeTarihi + 210;
                    dtsTaksit7 = DateTime.FromOADate(VadeTarihi);
                    dtTaksit7.DateTime = dtsTaksit7;
                }
                else if (i == 7)
                {
                    txtTaksit8.Text = Convert.ToString(TaksitTutarlari);

                    DateTime dtsTaksit8 = new DateTime();
                    string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                    TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                    VadeTarihi = Convert.ToInt32(TaksitVademiz);
                    VadeTarihi = VadeTarihi + 240;
                    dtsTaksit8 = DateTime.FromOADate(VadeTarihi);
                    dtTaksit8.DateTime = dtsTaksit8;
                }
                else if (i == 8)
                {
                    txtTaksit9.Text = Convert.ToString(TaksitTutarlari);

                    DateTime dtsTaksit9 = new DateTime();
                    string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                    TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                    VadeTarihi = Convert.ToInt32(TaksitVademiz);
                    VadeTarihi = VadeTarihi + 270;
                    dtsTaksit9 = DateTime.FromOADate(VadeTarihi);
                    dtTaksit9.DateTime = dtsTaksit9;
                }
                else if (i == 9)
                {
                    txtTaksit10.Text = Convert.ToString(TaksitTutarlari);

                    DateTime dtsTaksit10 = new DateTime();
                    string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                    TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                    VadeTarihi = Convert.ToInt32(TaksitVademiz);
                    VadeTarihi = VadeTarihi + 300;
                    dtsTaksit10 = DateTime.FromOADate(VadeTarihi);
                    dtTaksit10.DateTime = dtsTaksit10;
                }
                else if (i == 10)
                {
                    txtTaksit11.Text = Convert.ToString(TaksitTutarlari);

                    DateTime dtsTaksit11 = new DateTime();
                    string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                    TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                    VadeTarihi = Convert.ToInt32(TaksitVademiz);
                    VadeTarihi = VadeTarihi + 330;
                    dtsTaksit11 = DateTime.FromOADate(VadeTarihi);
                    dtTaksit11.DateTime = dtsTaksit11;
                }
                else if (i == 11)
                {
                    txtTaksit12.Text = Convert.ToString(TaksitTutarlari);

                    DateTime dtsTaksit12 = new DateTime();
                    string TaksitVademiz = Convert.ToString(dtBaslangicTarihi.DateTime.ToOADate());
                    TaksitVademiz = TaksitVademiz.ToString().Substring(0, 5);
                    VadeTarihi = Convert.ToInt32(TaksitVademiz);
                    VadeTarihi = VadeTarihi + 360;
                    dtsTaksit12 = DateTime.FromOADate(VadeTarihi);
                    dtTaksit12.DateTime = dtsTaksit12;
                }
            }

            #endregion

        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            this.dataSet1.tblFaturaHareketleri.Clear();
            TaksitSil();
            TopluIrsaliyeSil();
            TopluSiparisleriSil();

            foreach (int item in this.gridView4.GetSelectedRows())
            {
                DataRow dr1 = gridView4.GetDataRow(item);
                DataRow dr = this.dataSet1.tblFaturaHareketleri.NewRow();

                for (int i = 0; i < this.dataSet2.tblCtrlNIrsaliyeler.Columns.Count; i++)
                {
                    if (i == 1)
                    {
                        DateTime dtsIslemTarihimizPanel = Convert.ToDateTime(dr1[i].ToString());
                        string IslemTarihimiz = Convert.ToString(dtsIslemTarihimizPanel.ToOADate());
                        IslemTarihimiz = IslemTarihimiz.ToString().Substring(0, 5);
                        IslemTarihi = Convert.ToInt32(IslemTarihimiz);
                        dr[i] = IslemTarihi;
                    }
                    else if (i <=65)
                    {
                        dr[i] = dr1[i];
                    }
                }

                this.dataSet1.tblFaturaHareketleri.Rows.Add(dr.ItemArray);

            }
            ps_MalBedeliHesaplaCtrlN();
            ps_GenelToplam();

            for (int i = 0; i < dataSet1.tblFaturaHareketleri.Rows.Count; i++)
            {
                if (i == 0)
                {
                    txtIrsaliyeNo.Text = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri1.Text = txtIrsaliyeNo.Text.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo1.Text = txtIrsaliyeNo.Text.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi1 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi1 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih1.DateTime = dtsIslemTarihi1;
                    dtIrsaliyeTarihi.DateTime = dtsIslemTarihi1;
                }
                else if (i == 1)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri2.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo2.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi2 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi2 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih2.DateTime = dtsIslemTarihi2;
                }
                else if (i == 2)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri3.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo3.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi3 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi3 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih3.DateTime = dtsIslemTarihi3;
                }
                else if (i == 3)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri4.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo4.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi4 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi4 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih4.DateTime = dtsIslemTarihi4;
                }
                else if (i == 4)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri5.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo5.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi5 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi5 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih5.DateTime = dtsIslemTarihi5;
                }
                else if (i == 5)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri6.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo6.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi6 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi6 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih6.DateTime = dtsIslemTarihi6;
                }
                else if (i == 6)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri7.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo7.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi7 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi7 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih7.DateTime = dtsIslemTarihi7;
                }
                else if (i == 7)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri8.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo8.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi8 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi8 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih8.DateTime = dtsIslemTarihi8;
                }
                else if (i == 8)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri9.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo9.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi9 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi9 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih9.DateTime = dtsIslemTarihi9;
                }
                else if (i == 9)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri10.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo10.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi10 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi10 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih10.DateTime = dtsIslemTarihi10;
                }
                else if (i == 10)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri11.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo11.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi11 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi11 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih11.DateTime = dtsIslemTarihi11;
                }
                else if (i == 11)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri12.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo12.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi12 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi12 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih12.DateTime = dtsIslemTarihi12;
                }
                else if (i == 12)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri13.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo13.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi13 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi13 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih13.DateTime = dtsIslemTarihi13;
                }
                else if (i == 13)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri14.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo14.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi14 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi14 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih14.DateTime = dtsIslemTarihi14;
                }
                else if (i == 14)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri15.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo15.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi15 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi15 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih15.DateTime = dtsIslemTarihi15;
                }
                else if (i == 15)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri16.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo16.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi16 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi16 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih16.DateTime = dtsIslemTarihi16;
                }
                else if (i == 16)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri17.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo17.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi17 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi17 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih17.DateTime = dtsIslemTarihi17;
                }
                else if (i == 17)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri18.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo18.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi18 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi18 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih18.DateTime = dtsIslemTarihi18;
                }
                else if (i == 18)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri19.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo19.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi19 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi19 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih19.DateTime = dtsIslemTarihi19;
                }
                else if (i == 19)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri20.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo20.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi20 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi20 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih20.DateTime = dtsIslemTarihi20;
                }
                //
                else if (i == 20)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri21.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo21.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi21 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi21 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih21.DateTime = dtsIslemTarihi21;
                }
                else if (i == 21)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri22.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo22.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi22 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi22 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih22.DateTime = dtsIslemTarihi22;
                }
                else if (i == 22)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri23.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo23.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi23 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi23 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih23.DateTime = dtsIslemTarihi23;
                }
                else if (i == 23)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri24.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo24.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi24 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi24 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih24.DateTime = dtsIslemTarihi24;
                }
                else if (i == 24)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri25.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo25.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi25 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi25 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih25.DateTime = dtsIslemTarihi25;
                }
                else if (i == 25)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri26.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo26.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi26 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi26 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih26.DateTime = dtsIslemTarihi26;
                }
                else if (i == 26)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri27.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo27.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi27 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi27 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih27.DateTime = dtsIslemTarihi27;
                }
                else if (i == 27)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri28.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo28.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi28 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi28 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih28.DateTime = dtsIslemTarihi28;
                }
                else if (i == 28)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri29.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo29.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi29 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi29 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih29.DateTime = dtsIslemTarihi29;
                }
                else if (i == 29)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IrsaliyeNo.FieldName];
                    txt30luIrsaliyeSeri30.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luIrsaliyeNo30.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi30 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_IslemTarihi.FieldName]);
                    dtsIslemTarihi30 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luTarih30.DateTime = dtsIslemTarihi30;
                }
            }
        }

        private void btn30luIrsaliyeler_Click(object sender, EventArgs e)
        {
            pn30luIrsaliye.Location = new Point(488, 23);
            pn30luIrsaliye.Width = 540;
            pn30luIrsaliye.Height = 416;
            pn30luIrsaliye.Visible = true;
        }

        private void btnPnSiparisGetir_Click(object sender, EventArgs e)
        {
            int TarihliSorgu = 0;
            dataSet2.tblCtrlNIrsaliyeler.Clear();

            if (string.IsNullOrEmpty(Convert.ToString(dtPanelSiparis.EditValue)))
            {
                tblCtrlNIrsaliyelerTableAdapter.CtrlESiparisKayitlari(dataSet2.tblCtrlNIrsaliyeler, txtHesapKodu.Text);

                if (dataSet2.tblCtrlNIrsaliyeler.Rows.Count == 0)
                {
                    MessageBox.Show("Kayıt Bulunamadı.");
                }
            }
            else
            {
                string TarihliSorgumuz = Convert.ToString(dtPanelSiparis.DateTime.ToOADate());
                TarihliSorgumuz = TarihliSorgumuz.ToString().Substring(0, 5);
                TarihliSorgu = Convert.ToInt32(TarihliSorgumuz);

                tblCtrlNIrsaliyelerTableAdapter.CtrlETarihliSiparisler(dataSet2.tblCtrlNIrsaliyeler, txtHesapKodu.Text, TarihliSorgu);

                if (dataSet2.tblCtrlNIrsaliyeler.Rows.Count == 0)
                {
                    MessageBox.Show("Kayıt Bulunamadı.");
                }
            
            }
        }

        private void btnSiparisGetir_Click(object sender, EventArgs e)
        {
            this.dataSet1.tblFaturaHareketleri.Clear();
            TaksitSil();
            TopluIrsaliyeSil();
            TopluSiparisleriSil();

            foreach (int item in this.gridview5.GetSelectedRows())
            {
                DataRow dr1 = gridview5.GetDataRow(item);
                DataRow dr = this.dataSet1.tblFaturaHareketleri.NewRow();

                for (int i = 0; i < this.dataSet2.tblCtrlNIrsaliyeler.Columns.Count; i++)
                {
                    if (i == 1)
                    {
                        DateTime dtsIslemTarihimizPanel = Convert.ToDateTime(dr1[i].ToString());
                        string IslemTarihimiz = Convert.ToString(dtsIslemTarihimizPanel.ToOADate());
                        IslemTarihimiz = IslemTarihimiz.ToString().Substring(0, 5);
                        IslemTarihi = Convert.ToInt32(IslemTarihimiz);
                        dr[i] = IslemTarihi;
                    }
                    else if (i <= 65)
                    {
                        dr[i] = dr1[i];
                    }
                }

                this.dataSet1.tblFaturaHareketleri.Rows.Add(dr.ItemArray);

            }
            ps_MalBedeliHesaplaCtrlN();
            ps_GenelToplam();

            for (int i = 0; i < dataSet1.tblFaturaHareketleri.Rows.Count; i++)
            {
                if (i == 0)
                {
                    txtSiparisNo.Text = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri1.Text = txtSiparisNo.Text.ToString().Substring(0, 2);
                    txt30luSiparisNo1.Text = txtSiparisNo.Text.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi1 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi1 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih1.DateTime = dtsIslemTarihi1;
                    dtSiparisTarihi.DateTime = dtsIslemTarihi1;
                }
                else if (i == 1)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri2.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo2.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi2 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi2 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih2.DateTime = dtsIslemTarihi2;
                }
                else if (i == 2)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri3.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo3.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi3 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi3 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih3.DateTime = dtsIslemTarihi3;
                }
                else if (i == 3)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri4.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo4.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi4 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi4 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih4.DateTime = dtsIslemTarihi4;
                }
                else if (i == 4)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri5.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo5.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi5 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi5 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih5.DateTime = dtsIslemTarihi5;
                }
                else if (i == 5)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri6.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo6.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi6 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi6 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih6.DateTime = dtsIslemTarihi6;
                }
                else if (i == 6)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri7.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo7.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi7 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi7 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih7.DateTime = dtsIslemTarihi7;
                }
                else if (i == 7)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri8.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo8.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi8 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi8 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih8.DateTime = dtsIslemTarihi8;
                }
                else if (i == 8)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri9.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo9.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi9 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi9 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih9.DateTime = dtsIslemTarihi9;
                }
                else if (i == 9)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri10.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo10.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi10 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi10 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih10.DateTime = dtsIslemTarihi10;
                }
                else if (i == 10)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri11.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo11.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi11 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi11 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih11.DateTime = dtsIslemTarihi11;
                }
                else if (i == 11)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri12.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo12.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi12 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi12 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih12.DateTime = dtsIslemTarihi12;
                }
                else if (i == 12)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri13.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo13.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi13 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi13 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih13.DateTime = dtsIslemTarihi13;
                }
                else if (i == 13)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri14.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo14.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi14 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi14 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih14.DateTime = dtsIslemTarihi14;
                }
                else if (i == 14)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri15.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo15.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi15 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi15 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih15.DateTime = dtsIslemTarihi15;
                }
                else if (i == 15)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri16.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo16.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi16 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi16 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih16.DateTime = dtsIslemTarihi16;
                }
                else if (i == 16)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri17.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo17.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi17 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi17 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih17.DateTime = dtsIslemTarihi17;
                }
                else if (i == 17)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri18.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo18.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi18 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi18 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih18.DateTime = dtsIslemTarihi18;
                }
                else if (i == 18)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri19.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo19.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi19 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi19 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih19.DateTime = dtsIslemTarihi19;
                }
                else if (i == 19)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri20.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo20.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi20 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi20 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih20.DateTime = dtsIslemTarihi20;
                }
                //
                else if (i == 20)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri21.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo21.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi21 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi21 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih21.DateTime = dtsIslemTarihi21;
                }
                else if (i == 21)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri22.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo22.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi22 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi22 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih22.DateTime = dtsIslemTarihi22;
                }
                else if (i == 22)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri23.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo23.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi23 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi23 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih23.DateTime = dtsIslemTarihi23;
                }
                else if (i == 23)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri24.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo24.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi24 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi24 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih24.DateTime = dtsIslemTarihi24;
                }
                else if (i == 24)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri25.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo25.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi25 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi25 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih25.DateTime = dtsIslemTarihi25;
                }
                else if (i == 25)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri26.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo26.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi26 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi26 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih26.DateTime = dtsIslemTarihi26;
                }
                else if (i == 26)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri27.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo27.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi27 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi27 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih27.DateTime = dtsIslemTarihi27;
                }
                else if (i == 27)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri28.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo28.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi28 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi28 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih28.DateTime = dtsIslemTarihi28;
                }
                else if (i == 28)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri29.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo29.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi29 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi29 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih29.DateTime = dtsIslemTarihi29;
                }
                else if (i == 29)
                {
                    string panelIrsaliyeNumarasi = (string)dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisNo.FieldName];
                    txt30luSiparisSeri30.Text = panelIrsaliyeNumarasi.ToString().Substring(0, 2);
                    txt30luSiparisNo30.Text = panelIrsaliyeNumarasi.ToString().Substring(1, 7);

                    DateTime dtsIslemTarihi30 = new DateTime();
                    int TarihimiziAliyoruz = Convert.ToInt32(dataSet1.tblFaturaHareketleri.Rows[i][colSTK005_SiparisTarihi.FieldName]);
                    dtsIslemTarihi30 = DateTime.FromOADate(TarihimiziAliyoruz);
                    dt30luSiparisTarih30.DateTime = dtsIslemTarihi30;
                }
            }
        }

        private void btn30luSiparisler_Click(object sender, EventArgs e)
        {
            pn30luSiparisler.Location = new Point(488, 23);
            pn30luSiparisler.Width = 540;
            pn30luSiparisler.Height = 416;
            pn30luSiparisler.Visible = true;
            
        }

        private void repositoryBtnMalKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (satirTipiTextBox.Text == "M")
            {
                int numarasatir = gridView1.FocusedRowHandle;
                string GirenTarihimiz = Convert.ToString(DateTime.Now.ToOADate());
                GirenTarihimiz = GirenTarihimiz.ToString().Substring(0, 5);
                GirenTarih = Convert.ToInt32(GirenTarihimiz);

                frmLookUpSatisFaturasiMalKodu = new Ayarlar.LookUpSatisFaturasiMalKodu();
                frmLookUpSatisFaturasiMalKodu.frmOtvliSatisFaturasi = this;
                frmLookUpSatisFaturasiMalKodu.Owner = this;
                frmLookUpSatisFaturasiMalKodu.Birim = FiyatID;
                frmLookUpSatisFaturasiMalKodu.HesapKodu = txtHesapKodu.Text;
                frmLookUpSatisFaturasiMalKodu.ListeAdi = txtListeAdi.Text;
                frmLookUpSatisFaturasiMalKodu.ListeNo = txtListeNo.Text;
                frmLookUpSatisFaturasiMalKodu.Tarih = GirenTarih;
                frmLookUpSatisFaturasiMalKodu.SatirNumarasi = numarasatir;
                frmLookUpSatisFaturasiMalKodu.ShowDialog();
                
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

        }

        private void repositoryBtnMalAdi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (satirTipiTextBox.Text == "M")
            {
                int numarasatir = gridView1.FocusedRowHandle;
                string GirenTarihimiz = Convert.ToString(DateTime.Now.ToOADate());
                GirenTarihimiz = GirenTarihimiz.ToString().Substring(0, 5);
                GirenTarih = Convert.ToInt32(GirenTarihimiz);

                frmLookUpSatisFaturasiMalKodu = new Ayarlar.LookUpSatisFaturasiMalKodu();
                frmLookUpSatisFaturasiMalKodu.frmOtvliSatisFaturasi = this;
                frmLookUpSatisFaturasiMalKodu.Owner = this;
                frmLookUpSatisFaturasiMalKodu.Birim = FiyatID;
                frmLookUpSatisFaturasiMalKodu.HesapKodu = txtHesapKodu.Text;
                frmLookUpSatisFaturasiMalKodu.ListeAdi = txtListeAdi.Text;
                frmLookUpSatisFaturasiMalKodu.ListeNo = txtListeNo.Text;
                frmLookUpSatisFaturasiMalKodu.Tarih = GirenTarih;
                frmLookUpSatisFaturasiMalKodu.SatirNumarasi = numarasatir;
                frmLookUpSatisFaturasiMalKodu.ShowDialog();
            }
        }

        private void repositoryBtnMalKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                int numarasatir = gridView1.FocusedRowHandle;
                frmLookUpSatisFaturasiMalKodu = new Ayarlar.LookUpSatisFaturasiMalKodu();
                frmLookUpSatisFaturasiMalKodu.frmOtvliSatisFaturasi = this;
                frmLookUpSatisFaturasiMalKodu.Owner = this;
                frmLookUpSatisFaturasiMalKodu.Birim = FiyatID;
                frmLookUpSatisFaturasiMalKodu.SatirNumarasi = numarasatir;
                frmLookUpSatisFaturasiMalKodu.ShowDialog();
            }
            if (e.KeyCode == Keys.F4)
            {
                int numarasatir = gridView1.FocusedRowHandle;
                if (dataSet1.tblFaturaHareketleri.Rows.Count > 0)
                {
                    string GtipNoMalKodu = dataSet1.tblFaturaHareketleri.Rows[numarasatir][0].ToString();
                    string GtipNoVeri = evrakNoSeriTableAdapter1.GtipNoMalKodu(GtipNoMalKodu);
                    this.tblGtipNoTableAdapter.Fill(dataSet2.tblGtipNo, GtipNoVeri);

                    foreach (DataRow dr in dataSet2.tblGtipNo.Rows)
                    {
                        txtgtipno.Text = dr[0].ToString();
                        gtipTarih.DateTime = Convert.ToDateTime(dr[1].ToString());
                        txtgtipAciklama1.Text = dr[2].ToString();
                        txtgtipAciklama2.Text = dr[3].ToString();
                        txtgtipAciklama3.Text = dr[4].ToString();
                        txtgtipAciklama4.Text = dr[5].ToString();
                        cmGtipNoUygulamaSekli.SelectedIndex = Convert.ToInt32(dr[6].ToString()) - 1;
                        txtgtipOran.Text = dr[7].ToString();
                        txtgtipKilo.Text = dr[8].ToString();
                        txtgtipListe.Text = dr[9].ToString();
                    }

                    pnGtipNo.Width = 364;
                    pnGtipNo.Height = 236;
                    pnGtipNo.Location = new Point(74, 25);
                    pnGtipNo.Visible = true;
                }
                else
                {
                    pnGtipNo.Visible = false;
                }
            }
        }

        private void repositoryBtnMalAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                int numarasatir = gridView1.FocusedRowHandle;
                string GirenTarihimiz = Convert.ToString(DateTime.Now.ToOADate());
                GirenTarihimiz = GirenTarihimiz.ToString().Substring(0, 5);
                GirenTarih = Convert.ToInt32(GirenTarihimiz);

                frmLookUpSatisFaturasiMalKodu = new Ayarlar.LookUpSatisFaturasiMalKodu();
                frmLookUpSatisFaturasiMalKodu.frmOtvliSatisFaturasi = this;
                frmLookUpSatisFaturasiMalKodu.Owner = this;
                frmLookUpSatisFaturasiMalKodu.Birim = FiyatID;
                frmLookUpSatisFaturasiMalKodu.HesapKodu = txtHesapKodu.Text;
                frmLookUpSatisFaturasiMalKodu.ListeAdi = txtListeAdi.Text;
                frmLookUpSatisFaturasiMalKodu.ListeNo = txtListeNo.Text;
                frmLookUpSatisFaturasiMalKodu.Tarih = GirenTarih;
                frmLookUpSatisFaturasiMalKodu.SatirNumarasi = numarasatir;
                frmLookUpSatisFaturasiMalKodu.ShowDialog();
            }
            if (e.KeyCode == Keys.F4)
            {
                int numarasatir = gridView1.FocusedRowHandle;
                if (dataSet1.tblFaturaHareketleri.Rows.Count > 0)
                {
                    string GtipNoMalKodu = dataSet1.tblFaturaHareketleri.Rows[numarasatir][0].ToString();
                    string GtipNoVeri = evrakNoSeriTableAdapter1.GtipNoMalKodu(GtipNoMalKodu);
                    this.tblGtipNoTableAdapter.Fill(dataSet2.tblGtipNo, GtipNoVeri);

                    foreach (DataRow dr in dataSet2.tblGtipNo.Rows)
                    {
                        txtgtipno.Text = dr[0].ToString();
                        gtipTarih.DateTime = Convert.ToDateTime(dr[1].ToString());
                        txtgtipAciklama1.Text = dr[2].ToString();
                        txtgtipAciklama2.Text = dr[3].ToString();
                        txtgtipAciklama3.Text = dr[4].ToString();
                        txtgtipAciklama4.Text = dr[5].ToString();
                        cmGtipNoUygulamaSekli.SelectedIndex = Convert.ToInt32(dr[6].ToString()) - 1;
                        txtgtipOran.Text = dr[7].ToString();
                        txtgtipKilo.Text = dr[8].ToString();
                        txtgtipListe.Text = dr[9].ToString();
                    }

                    pnGtipNo.Width = 364;
                    pnGtipNo.Height = 236;
                    pnGtipNo.Location = new Point(74, 25);
                    pnGtipNo.Visible = true;
                }
                else
                {
                    pnGtipNo.Visible = false;
                }
            }
        }

        private void gridControl1_MouseLeave(object sender, EventArgs e)
        {
            gridDurum = false;
        }

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            gridDurum = true;
        }

        private void txtListeNo_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmfiyatlarimiz = new FiyatListesi.frmFiyatListeleriFaturalar();
            frmfiyatlarimiz.frmOtvliSatisFaturasi = this;
            frmfiyatlarimiz.Owner = this;
            frmfiyatlarimiz.ShowDialog();
        }

        private void btnDovizKurunaBol_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DovizDurum = true;
            Dovizislemi = "Bol";
            ps_MalBedeliHesapla();
            ps_GenelToplam();
        }

        private void btnDovizKuruileCarp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DovizDurum = true;
            Dovizislemi = "Carp";
            ps_MalBedeliHesapla();
            ps_GenelToplam();
        }
    }
}