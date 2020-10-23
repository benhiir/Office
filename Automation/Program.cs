using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automation.Admin_panel;
using Automation.modula;
using Automation.Users_panel;


namespace Automation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_Login());


            if (PublicVariable.gSetUser == 1)
            {
                frm_mainAdmin frm_mainAdmin = new frm_mainAdmin();
                frm_mainAdmin.ShowDialog();
            }
            else if (PublicVariable.gSetUser == 2)
            {
                frm_MainUser frm_MU = new frm_MainUser();
                frm_MU.ShowDialog();
            }


        }
    }
}
