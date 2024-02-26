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
    public partial class LookUpSirketler : DevExpress.XtraEditors.XtraForm
    {
        public LookUpSirketler()
        {
            InitializeComponent();
        }
        public GirisFormu frmGiris { get; set; }

        private void LookUpSirketler_Load(object sender, EventArgs e)
        {
            this.tblSirketlerTableAdapter.sirketleriDoldur(this.dataSet1.tblSirketler);
        }

        private void LookUpSirketler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                frmGiris.txtSirket.Text = lbSirket.GetItemText(lbSirket.SelectedIndex).ToString();
                this.Close();
            }
        }

        private void lbSirket_DoubleClick(object sender, EventArgs e)
        {
            frmGiris.txtSirket.Text = lbSirket.GetItemText(lbSirket.SelectedIndex).ToString();
            this.Close();
        }


    }
}