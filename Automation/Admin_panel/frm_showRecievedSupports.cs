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

namespace Automation.Admin_panel
{
    public partial class frm_showRecievedSupports : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);

        public frm_showRecievedSupports()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Showsupport(string search)
        {
            //Query performance
            var query = database.Database.SqlQuery<Vw_supports>("select * from Vw_supports where 1=1" + search);
            var result = query.ToList();

            if (result.Count != 0)
            {
                dgv_showRecievesupport.RowCount = result.Count;
                for (int i = 0; i <= result.Count - 1; i++)
                {
                    dgv_showRecievesupport.Rows[i].Cells["supportId"].Value = result[i].supportID;
                    dgv_showRecievesupport.Rows[i].Cells["support_subject"].Value = result[i].support_subject;
                    dgv_showRecievesupport.Rows[i].Cells["support_description"].Value = result[i].support_description;
                    dgv_showRecievesupport.Rows[i].Cells["support_date"].Value = result[i].support_date;
                    dgv_showRecievesupport.Rows[i].Cells["support_userFullname"].Value = result[i].Fullname;
                    dgv_showRecievesupport.Rows[i].Cells["userid"].Value = result[i].userId;
                                       
                }
                dgv_showRecievesupport.ScrollBars = ScrollBars.Both;
            }
            else
            {
                dgv_showRecievesupport.Rows.Clear();
            }

        }

        private string searchCondition()
        {
            string dateAz = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePickerAz.Value.Year.ToString() + "/" + persianDateTimePickerAz.Value.Month.ToString() + "/" + persianDateTimePickerAz.Value.Day.ToString()));
            string dateTa = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(persianDateTimePickerTa.Value.Year.ToString() + "/" + persianDateTimePickerTa.Value.Month.ToString() + "/" + persianDateTimePickerTa.Value.Day.ToString()));

            string searchString = " and support_date between '" + dateAz + "' and '" + dateTa + "'";
            if (txtSubject.Text != "")
            {
                searchString += " and support_subject like '%" + txtSubject.Text.Trim() + "%'";
            }
            if (txtMatn.Text != "")
            {
                searchString += " and support_description like '%" + txtMatn.Text.Trim() + "%'";
            }
            if (txt_fullname.Text != "")
            {
                searchString += " and fullname like '%" + txt_fullname.Text.Trim() + "%'";
            }
            return searchString;
        }

        private void frm_showRecievedSupports_Load(object sender, EventArgs e)
        {
            Showsupport(searchCondition());
        }

        private void picBoxSearch_Click(object sender, EventArgs e)
        {
            Showsupport(searchCondition());
        }
    }
}
