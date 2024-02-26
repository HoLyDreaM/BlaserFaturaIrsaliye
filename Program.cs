using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using System.Threading;
namespace Blaser_ÖTV_Fatura_Irsaliye
{
    static class Program
    {
        internal static ApplicationContext ac = new ApplicationContext();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("Black");
            //FiyatListesi.IskontoListemiz frm = new FiyatListesi.IskontoListemiz();
            ac.MainForm = new GirisFormu();
            Application.Run(ac);
        }
    }
}
