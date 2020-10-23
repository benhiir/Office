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
    public partial class frm_AddRemember : Form
    {
        automation_systemEntities db = new automation_systemEntities(PublicVariable.MainConnectionString);
        public frm_AddRemember()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_AddRemember_Load(object sender, EventArgs e)
        {
            lbl_date.Text = PublicVariable.TodayDate;
        }

        private void btn_sabt_Click(object sender, EventArgs e)
        {
            try
            {
                ///Insert remember into database using Entity Framework syntaxes
                /// 
                Remember R = new Remember();
                R.subject = txtSubject.Text.Trim();
                R.matn = txtMatn.Text.Trim();
                R.createDate = lbl_date.Text.Trim();
                R.DateRemember = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePickerRemember.Value.Year.ToString() + "/" + persianDateTimePickerRemember.Value.Month.ToString() + "/" + persianDateTimePickerRemember.Value.Day.ToString()));
                R.IsRead = 1;
                R.UserId = 1;

                db.Remembers.Add(R);
                db.SaveChanges();
                MessageBox.Show("A new reminder was recorded.");

                this.Close();
            }
            catch
            {
                MessageBox.Show("There was a problem recording the reminder. Please try again");
            }


            
        }
    }
}
