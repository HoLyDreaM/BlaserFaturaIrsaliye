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
    public partial class LookUpKayitliFaturalariade : DevExpress.XtraEditors.XtraForm
    {
        public LookUpKayitliFaturalariade()
        {
            InitializeComponent();
        }

        public OtvliSatistanIadeFaturasi frmOtvliSatisFaturasi { get; set; }

        private void LookUpKayitliFaturalariade_Load(object sender, EventArgs e)
        {
            this.tblLookUpKayitliiadeFaturalariTableAdapter.Fill(this.dataSet1.tblLookUpKayitliiadeFaturalari);
        }

        private void gridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (gridView1.RowCount > 0)
                {
                    if (fatura_NoTextBox.Text.Length > 6)
                    {
                        frmOtvliSatisFaturasi.txtFaturaSeri.Text = fatura_NoTextBox.Text.Substring(0, 2);
                        frmOtvliSatisFaturasi.txtFaturaNo.Text = fatura_NoTextBox.Text.Substring(2, 6);
                    }
                    frmOtvliSatisFaturasi.ps_kayitliFaturayiGetir(fatura_NoTextBox.Text);
                    frmOtvliSatisFaturasi.ps_kayitliFaturaninCarisi(hesap_KoduTextBox.Text);
                    frmOtvliSatisFaturasi.ps_kayitliFaturaninOndegerleri(fatura_NoTextBox.Text);
                    this.Dispose();
                }
        }

        private void LookUpKayitliFaturalariade_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                if (fatura_NoTextBox.Text.Length > 6)
                {
                    frmOtvliSatisFaturasi.txtFaturaSeri.Text = fatura_NoTextBox.Text.Substring(0, 2);
                    frmOtvliSatisFaturasi.txtFaturaNo.Text = fatura_NoTextBox.Text.Substring(2, 6);
                }
                frmOtvliSatisFaturasi.ps_kayitliFaturayiGetir(fatura_NoTextBox.Text);
                frmOtvliSatisFaturasi.ps_kayitliFaturaninCarisi(hesap_KoduTextBox.Text);
                frmOtvliSatisFaturasi.ps_kayitliFaturaninOndegerleri(fatura_NoTextBox.Text);
                this.Dispose();
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                if (fatura_NoTextBox.Text.Length > 6)
                {
                    frmOtvliSatisFaturasi.txtFaturaSeri.Text = fatura_NoTextBox.Text.Substring(0, 2);
                    frmOtvliSatisFaturasi.txtFaturaNo.Text = fatura_NoTextBox.Text.Substring(2, 6);
                }
                frmOtvliSatisFaturasi.ps_kayitliFaturayiGetir(fatura_NoTextBox.Text);
                frmOtvliSatisFaturasi.ps_kayitliFaturaninCarisi(hesap_KoduTextBox.Text);
                frmOtvliSatisFaturasi.ps_kayitliFaturaninOndegerleri(fatura_NoTextBox.Text);
                this.Dispose();
            }
        }
    }
}