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
    public partial class lookUpKullanicilar : DevExpress.XtraEditors.XtraForm
    {
        public lookUpKullanicilar()
        {
            InitializeComponent();
        }

        public GirisFormu frmGiris { get; set; }

        private void lookUpKullanicilar_Load(object sender, EventArgs e)
        {
            try
            {
                this.tblLookUpKullanicilarTableAdapter.kullanicilar(dataSet1.tblLookUpKullanicilar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void lookUpKullanicilar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Dispose();
            }

            if (e.KeyData == Keys.Enter)
            {
                frmGiris.txtKullanici.Text = this.kullanıcı_AdıTextBox.Text;
                this.Dispose();
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            frmGiris.txtKullanici.Text = this.kullanıcı_AdıTextBox.Text;
            this.Dispose();
        }
    }
}