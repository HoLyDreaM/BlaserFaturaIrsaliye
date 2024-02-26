using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using FastReport;
using FastReport.Data;

namespace Blaser_ÖTV_Fatura_Irsaliye.Ayarlar
{
    public partial class frmEvrakTasarimi : DevExpress.XtraEditors.XtraForm
    {
        public frmEvrakTasarimi()
        {
            InitializeComponent();
        }

        private void raporListele(TreeView tw, string ustDizin)
        {
            try
            {
                tw.Nodes.Clear();

                int i = 0;
                DirectoryInfo di = new DirectoryInfo(ustDizin);
                foreach (var item in di.GetDirectories())
                {
                    tw.Nodes.Add(item.ToString());
                    FileInfo fi = new FileInfo(ustDizin + item.ToString() + @"\");
                    foreach (var file in fi.Directory.GetFiles("*.frx"))
                        tw.Nodes[i].Nodes.Add(file.Name.ToString());

                    i++;
                }
                tw.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void raporSil()
        {
            try
            {
                if (treeView1.SelectedNode.FullPath.ToString().IndexOf(@"\") > 0)
                {
                    if (this.treeView1.Nodes.Count > 0)
                        if (MessageBox.Show("Silmek İstediğinize Emin misiniz?", "Rapor Sil!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            File.Delete(Application.StartupPath + @"\Raporlar\" + treeView1.SelectedNode.FullPath.ToString());
                            treeView1.SelectedNode.Remove();
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void raporDuzenle()
        {
            try
            {
                if (treeView1.SelectedNode.FullPath.ToString().IndexOf(@"\") > 0)
                {
                    report1 = new Report();
                    report1.Load(Application.StartupPath + @"\Raporlar\" + treeView1.SelectedNode.FullPath.ToString());
                    report1.Design();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void yeniTasarim()
        {
            try
            {
                report1 = new Report();
                report1.RegisterData(this.dataSet11.Tables["rapor_CariBilgiler"], "CariBilgiler");
                report1.RegisterData(this.dataSet11.Tables["rapor_EvrakHareketleri"], "EvrakSatirlari");

                report1.GetDataSource("CariBilgiler").Enabled = true;
                report1.GetDataSource("EvrakSatirlari").Enabled = true;

                report1.SetParameterValue("Başlık1", "");
                report1.SetParameterValue("Başlık2", "");
                report1.SetParameterValue("DovizKuru", 0.00);

                report1.SetParameterValue("AraToplam", 0.00);
                report1.SetParameterValue("İskonto", 0.00);
                report1.SetParameterValue("Toplam", 0.00);
                report1.SetParameterValue("ÖTV_Tutari", 0.00);
                report1.SetParameterValue("KDV_Matrahi", 0.00);
                report1.SetParameterValue("KDV", 0.00);
                report1.SetParameterValue("GenelToplam", 0.00);

                report1.SetParameterValue("YaziylaTutar", "");

                report1.Design();

                raporListele(treeView1, Application.StartupPath + @"\Raporlar\");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void frmEvrakTasarimi_Load(object sender, EventArgs e)
        {
            raporListele(treeView1,Application.StartupPath+@"\Raporlar\");
        }

        private void btnYenile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            raporListele(treeView1, Application.StartupPath + @"\Raporlar\");
        }

        private void btnSil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            raporSil();  
        }

        private void btnDuzenle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            raporDuzenle();
        }

        private void btnYeniTasarim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            yeniTasarim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}