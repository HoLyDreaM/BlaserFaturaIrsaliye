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
    public partial class LookUpKayitliFaturalar_OtviadeFatura : DevExpress.XtraEditors.XtraForm
    {
        public LookUpKayitliFaturalar_OtviadeFatura()
        {
            InitializeComponent();
        }

        public OtvliSatistanIadeFaturasi frmOtvliSatisiadeFaturasi { get; set; }

        private void LookUpKayitliFaturalar_OtviadeFatura_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(frmOtvliSatisiadeFaturasi.txtHesapKodu.Text.ToString()))
            {
                this.tblLookUpKayitliFaturalarTableAdapter.Fill(this.dataSet1.tblLookUpKayitliFaturalar);
            }
            else
            {
                this.tblLookUpKayitliFaturalarTableAdapter.HesapliFaturalar(this.dataSet1.tblLookUpKayitliFaturalar, frmOtvliSatisiadeFaturasi.txtHesapKodu.Text.ToString());
            }

        }

        private void gridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (gridView1.RowCount > 0)
                {
                    if (fatura_NoTextBox.Text.Length > 6)
                    {
                        frmOtvliSatisiadeFaturasi.txtiadeFaturaNo1.Text = fatura_NoTextBox.Text.Substring(0, 2);
                        frmOtvliSatisiadeFaturasi.txtiadeFaturaNo2.Text = fatura_NoTextBox.Text.Substring(2, 6);
                    }
                    frmOtvliSatisiadeFaturasi.ps_kayitliFaturayiGetir(fatura_NoTextBox.Text);
                    frmOtvliSatisiadeFaturasi.ps_kayitliFaturaninCarisi(hesap_KoduTextBox.Text);
                    frmOtvliSatisiadeFaturasi.ps_kayitliFaturaninOndegerleri(fatura_NoTextBox.Text);
                    this.Dispose();
                }
        }

        private void LookUpKayitliFaturalar_OtviadeFatura_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                if (fatura_NoTextBox.Text.Length > 6)
                {
                    frmOtvliSatisiadeFaturasi.txtiadeFaturaNo1.Text = fatura_NoTextBox.Text.Substring(0, 2);
                    frmOtvliSatisiadeFaturasi.txtiadeFaturaNo2.Text = fatura_NoTextBox.Text.Substring(2, 6);
                }
                frmOtvliSatisiadeFaturasi.ps_kayitliFaturayiGetir(fatura_NoTextBox.Text);
                frmOtvliSatisiadeFaturasi.ps_kayitliFaturaninCarisi(hesap_KoduTextBox.Text);
                frmOtvliSatisiadeFaturasi.ps_kayitliFaturaninOndegerleri(fatura_NoTextBox.Text);
                this.Dispose();
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                if (fatura_NoTextBox.Text.Length > 6)
                {
                    frmOtvliSatisiadeFaturasi.txtiadeFaturaNo1.Text = fatura_NoTextBox.Text.Substring(0, 2);
                    frmOtvliSatisiadeFaturasi.txtiadeFaturaNo2.Text = fatura_NoTextBox.Text.Substring(2, 6);
                }
                frmOtvliSatisiadeFaturasi.ps_kayitliFaturayiGetir(fatura_NoTextBox.Text);
                frmOtvliSatisiadeFaturasi.ps_kayitliFaturaninCarisi(hesap_KoduTextBox.Text);
                frmOtvliSatisiadeFaturasi.ps_kayitliFaturaninOndegerleri(fatura_NoTextBox.Text);
                this.Dispose();
            }
        }
    }
}