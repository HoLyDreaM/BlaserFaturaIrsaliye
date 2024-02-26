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
    public partial class frmEvrakNumaralari : DevExpress.XtraEditors.XtraForm
    {
        public frmEvrakNumaralari()
        {
            InitializeComponent();
        }

        private void frmEvrakNumaralari_Load(object sender, EventArgs e)
        {
            this.tblEvrakNumaralariTableAdapter.fill(this.dataSet1.tblEvrakNumaralari);
        }

        private void btnYenile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.tblEvrakNumaralariTableAdapter.fill(this.dataSet1.tblEvrakNumaralari);
        }

        private void btnKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Değişikler Uygulamak İstiyor musunuz?", "Kayıt Düzenle!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) == DialogResult.Yes)
                {
                    this.Validate();
                    this.tblEvrakNumaralariBindingSource.EndEdit();
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