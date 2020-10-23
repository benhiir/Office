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
    public partial class frm_ControlEnterExit : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public frm_ControlEnterExit()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_ControlEnterExit_Load(object sender, EventArgs e)
        {
            date_az.Value = DateTime.Now.AddDays(-10);
            ShowUserLog(searchCondition());
            
        }


        private void ShowUserLog(string search) ///s.24
        {
            //Query performance
            var query = database.Database.SqlQuery<Vw_UserLog>("select * from Vw_UserLog where 1=1" + search + "Order by EnterDateTime Desc");
            var result = query.ToList();

            if (result.Count != 0)
            {
                dgv_UserLog.RowCount = result.Count;
                for (int i = 0; i <= result.Count - 1; i++)
                {
                    dgv_UserLog.Rows[i].Cells["UserLogID"].Value = result[i].UserLogId;
                    dgv_UserLog.Rows[i].Cells["fullName"].Value = result[i].fullName;
                    dgv_UserLog.Rows[i].Cells["ComputerName"].Value = result[i].ComputerName;
                    dgv_UserLog.Rows[i].Cells["IP"].Value = result[i].IpAddress;
                    dgv_UserLog.Rows[i].Cells["EnterDate"].Value = result[i].EnterDateTime;
                    dgv_UserLog.Rows[i].Cells["ExitDate"].Value = result[i].ExitDateTime;
                  
                }
                dgv_UserLog.ScrollBars = ScrollBars.Both;
            }
            else
            {
                dgv_UserLog.Rows.Clear();
            }
        }
       private string searchCondition()
        {
            string dateAz = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(date_az.Value.Year.ToString() + "/" + date_az.Value.Month.ToString() + "/" + date_az.Value.Day.ToString()))+ "-"+ time_Az.Value.ToString("HH:mm:ss");
            string dateTa = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(date_ta.Value.Year.ToString() + "/" + date_ta.Value.Month.ToString() + "/" + date_ta.Value.Day.ToString()))+"-" + Time_Ta.Value.ToString("HH:mm:ss"); ;

            string searchString = " and EnterDateTime between '" + dateAz + "' and '" + dateTa + "'";
            if (txt_fullName.Text != "")
            {
                searchString += " and [fullName] like '%" + txt_fullName.Text.Trim() + "%'";
            }

            if (txt_ComputerName.Text != "")
            {
                searchString += " and [ComputerName] like '%" + txt_ComputerName.Text.Trim() + "%'";
            }

            if (txt_IP.Text != "")
            {
                searchString += " and [IpAddress] like '%" + txt_IP.Text.Trim() + "%'";
            }
            return searchString;
        }

        private void btn_pic_search_Click(object sender, EventArgs e)
        {
            ShowUserLog(searchCondition());
        }
    }
}
