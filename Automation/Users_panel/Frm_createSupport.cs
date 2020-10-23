using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModelLayer.Models;
using Automation.modula;

namespace Automation.Users_panel
{
    public partial class Frm_createSupport : Form
    {

        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public Frm_createSupport()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_createSupport_Click(object sender, EventArgs e)
        {
            if (txt_subject.Text.Trim() == "" || txt_description.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the required values");
                return;
            }
            try
            {
                support s = new support();
                s.support_subject = txt_subject.Text.Trim();
                s.support_description = txt_description.Text.Trim();
                s.userId = PublicVariable.gUserId;
                s.support_date = PublicVariable.TodayDate;
                database.supports.Add(s);
                database.SaveChanges();
                MessageBox.Show("Your request has been sent successfully.");
                this.Close();
            }
            catch
            {
                MessageBox.Show("There is a problem with the server.");
                return;
            }
        }

        private void Frm_createSupport_Load(object sender, EventArgs e)
        {
            lbl_date.Text = PublicVariable.TodayDate;
        }
    }
}
