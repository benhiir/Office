using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automation.modula;
using DataModelLayer.Models;

namespace Automation.Admin_panel
{
    public partial class frm_addSystemPart : Form
    {

        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public int GetSystemPartID { get; set; }



        public frm_addSystemPart()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_sysName.Text == "")
                {
                    MessageBox.Show("Please enter a component name.");
                    return;
                }

                systemPart sys = new systemPart();

                sys.SystemPartName = txt_sysName.Text.Trim();
                sys.SystemPartDetail = txt_description.Text.Trim();
                sys.SystemPartLevel = this.GetSystemPartID;

                database.systemParts.Add(sys);
                database.SaveChanges();

                MessageBox.Show("Information successfully recorded.");
                this.Close();
            }
            catch
            {
                MessageBox.Show("There was a problem communicating with the server. Please try again.");
                return;
            }
        }
    }
}
