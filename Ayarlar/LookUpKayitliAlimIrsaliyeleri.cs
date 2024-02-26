using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class LookUpKayitliAlimIrsaliyeleri : DevExpress.XtraEditors.XtraForm
    {
        public LookUpKayitliAlimIrsaliyeleri()
        {
            InitializeComponent();
        }

        public OtvliAlimIrsaliyesi frmOtvliAlimIrsaliyeleri { get; set; }

        private void LookUpKayitliAlimIrsaliyeleri_Load(object sender, EventArgs e)
        {
            this.tblKayitliAlimIrsaliyeleriTableAdapter.Fill(this.dataSet2.tblKayitliAlimIrsaliyeleri);

        }

        private void grdKayitliIrsaliyeler_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (gridView1.RowCount > 0)
                {
                    if (Irsaliye_NoTextBox.Text.Length > 6)
                    {
                        frmOtvliAlimIrsaliyeleri.txtIrsaliyeSeri.Text = Irsaliye_NoTextBox.Text.Substring(0, 2);
                        frmOtvliAlimIrsaliyeleri.txtIrsaliyeNo.Text = Irsaliye_NoTextBox.Text.Substring(2, 6);
                    }
                    frmOtvliAlimIrsaliyeleri.ps_kayitliIrsaliyeGetir(Irsaliye_NoTextBox.Text);
                    frmOtvliAlimIrsaliyeleri.ps_kayitliIrsaliyeninCarisi(hesap_KoduTextBox.Text);
                    frmOtvliAlimIrsaliyeleri.ps_kayitliIrsaliyeOnDegerleri(Irsaliye_NoTextBox.Text);
                    this.Dispose();
                }
        }

        private void LookUpKayitliAlimIrsaliyeleri_DoubleClick(object sender, System.EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                if (Irsaliye_NoTextBox.Text.Length > 6)
                {
                    frmOtvliAlimIrsaliyeleri.txtIrsaliyeSeri.Text = Irsaliye_NoTextBox.Text.Substring(0, 2);
                    frmOtvliAlimIrsaliyeleri.txtIrsaliyeNo.Text = Irsaliye_NoTextBox.Text.Substring(2, 6);
                }
                frmOtvliAlimIrsaliyeleri.ps_kayitliIrsaliyeGetir(Irsaliye_NoTextBox.Text);
                frmOtvliAlimIrsaliyeleri.ps_kayitliIrsaliyeninCarisi(hesap_KoduTextBox.Text);
                frmOtvliAlimIrsaliyeleri.ps_kayitliIrsaliyeOnDegerleri(Irsaliye_NoTextBox.Text);
                this.Dispose();
            }
        }

        private void grdKayitliIrsaliyeler_DoubleClick(object sender, System.EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                if (Irsaliye_NoTextBox.Text.Length > 6)
                {
                    frmOtvliAlimIrsaliyeleri.txtIrsaliyeSeri.Text = Irsaliye_NoTextBox.Text.Substring(0, 2);
                    frmOtvliAlimIrsaliyeleri.txtIrsaliyeNo.Text = Irsaliye_NoTextBox.Text.Substring(2, 6);
                }
                frmOtvliAlimIrsaliyeleri.ps_kayitliIrsaliyeGetir(Irsaliye_NoTextBox.Text);
                frmOtvliAlimIrsaliyeleri.ps_kayitliIrsaliyeninCarisi(hesap_KoduTextBox.Text);
                frmOtvliAlimIrsaliyeleri.ps_kayitliIrsaliyeOnDegerleri(Irsaliye_NoTextBox.Text);
                this.Dispose();
            }
        }
    }
}