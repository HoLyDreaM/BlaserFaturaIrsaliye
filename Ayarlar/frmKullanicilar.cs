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
    public partial class frmKullanicilar : DevExpress.XtraEditors.XtraForm
    {
        public frmKullanicilar()
        {
            InitializeComponent();
        }

        private void butonDurumlari(Boolean yeni, Boolean kaydet, Boolean vazgec, Boolean sil, Boolean yenile, Boolean onay)
        {
            btnYeni.Enabled = yeni;
            btnKaydet.Enabled = kaydet;
            btnVazgec.Enabled = vazgec;
            btnSil.Enabled = sil;
            btnYenile.Enabled = yenile;
            btnDegisiklik.Enabled = onay;
        }

        private void frmKullanicilar_Load(object sender, EventArgs e)
        {
            this.tblFormKullanicilarTableAdapter.kullanicilariDoldur(this.dataSet1.tblFormKullanicilar);
        }

        private void btnYeni_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.tblFormKullanicilarBindingSource.AddNew();
            butonDurumlari(false, true, true, true, false, false);
            gridControl1.Enabled = false;
        }

        private void btnKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ((!string.IsNullOrEmpty(txtAdiSoyadi.Text)) || (!string.IsNullOrEmpty(txtKulAdi.Text)) || (!string.IsNullOrEmpty(txtSifre.Text)))
            {
                try
                {
                    this.tblFormKullanicilarBindingSource.EndEdit();
                    butonDurumlari(true, true, true, true, true, true);
                    gridControl1.Enabled = true;
                }
                catch (Exception ex)
                {
                    btnVazgec_ItemClick(sender, e);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("{Adı Soyadı} , {Kullanıcı Adı} , {Şifre} Boş bırakılamaz!");
            }
        }

        private void btnVazgec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            butonDurumlari(true, true, true, true, true, true);
            tblFormKullanicilarBindingSource.CancelEdit();
            gridControl1.Enabled = true;
        }

        private void btnSil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Kayıt Silincek! Onaylıyor musunuz?", "Kullanıcı Sil!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) == DialogResult.Yes)
            {
                tblFormKullanicilarBindingSource.RemoveCurrent();
                butonDurumlari(true, true, true, true, true, true);
                gridControl1.Enabled = true;
            }
        }

        private void btnYenile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.tblFormKullanicilarTableAdapter.kullanicilariDoldur(this.dataSet1.tblFormKullanicilar);
        }

        private void btnDegisiklik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Değişikler Kaydetilcek! Onaylıyor musunuz?", "Kayıt Düzenle!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) == DialogResult.Yes)
                {
                    this.Validate();
                    this.tblFormKullanicilarBindingSource.EndEdit();
                    this.tableAdapterManager1.UpdateAll(this.dataSet1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}