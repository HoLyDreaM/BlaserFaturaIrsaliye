using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SQLDMO;
using System.Threading;

namespace Blaser_ÖTV_Fatura_Irsaliye.Ayarlar
{
    public partial class LookUpServers : DevExpress.XtraEditors.XtraForm
    {
        public LookUpServers()
        {
            InitializeComponent();
        }
        public GirisFormu frmGiris { get; set; }

        SQLDMO.Application sqlApp = new SQLDMO.Application();

        private void dbListesi()
        {
            try
            {
                SQLDMO.NameList sqlServers = sqlApp.ListAvailableSQLServers();
                for (int i = 0; i < sqlServers.Count; i++)
                {
                    object srv = sqlServers.Item(i + 1);
                    if (srv != null)
                    {
                        lbEkle(srv.ToString());
                    }
                }
            }
            catch
            {
            }
        }

        private delegate void delegate_lbEkle(string item);
        private void lbEkle(string item)
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new delegate_lbEkle(lbEkle), item);
            }
            else
                this.listBoxControl1.Items.Add(item);
        }

        private void LookUpServers_Load(object sender, EventArgs e)
        {
            Thread t = new Thread(dbListesi);
            t.Start();
        }

        private void LookUpServers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                this.Dispose();
            }

            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                frmGiris.txtServer.Text = listBoxControl1.SelectedItem.ToString();
                this.Dispose();
            }
        }

        private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmGiris.txtServer.Text = listBoxControl1.SelectedItem.ToString();
            this.Dispose();
        }
    }
}