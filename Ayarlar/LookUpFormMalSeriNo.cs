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
    public partial class LookUpFormMalSeriNo : DevExpress.XtraEditors.XtraForm
    {
        public LookUpFormMalSeriNo()
        {
            InitializeComponent();
        }

        public OtvliSatisFaturasi frmOtvliSatisFaturasi { get; set; }
        public string malKodu;

        private void LookUpFormMalSeriNo_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(malKodu))
            this.tblLookUpStokMiktarlariTableAdapter.stokMiktarlariniGetir(this.dataSet1.tblLookUpStokMiktarlari,malKodu);
        }

        private void gridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}