using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automation.SendMessageWebService;
using DataModelLayer.Models;
using Automation.modula;


namespace Automation.Admin_panel
{
    public partial class Frm_sendSMS : Form
    {
        automation_systemEntities database = new automation_systemEntities(PublicVariable.MainConnectionString);
        public Frm_sendSMS()
        {
            InitializeComponent();
        }

        private void btn_getInfo_Click(object sender, EventArgs e)
        {
            if (txt_username.Text == "" || txt_password.Text == "")
            {
                MessageBox.Show("Please enter your username and password");
                return;
            }

            SendMessageWebService.SendReceive ws = new SendMessageWebService.SendReceive();
            string message = string.Empty;
            var smsLine = ws.GetSMSLines(txt_username.Text, txt_password.Text, ref message);
            dgv_getLineID.DataSource = smsLine;
            dgv_getLineID.Columns[0].HeaderText = "Line ID";
            dgv_getLineID.Columns[1].HeaderText = "Line number";
            dgv_getLineID.Columns[0].Width = 90;
            dgv_getLineID.Columns[1].Width = 135;
        }

        private void dgv_getLineID_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lbl_LineNo.Text = dgv_getLineID.CurrentRow.Cells["LineNumber"].Value.ToString();
        }

        private void ShowUserInfo()
        {
            //Query performance
            var query = database.Database.SqlQuery<Vw_Users>("select * from Vw_Users");
            var result = query.ToList();

            if (result.Count != 0)
            {
                dgv_showUsers.RowCount = result.Count;
                for (int i = 0; i <= result.Count - 1; i++)
                {
                    dgv_showUsers.Rows[i].Cells["col_userId"].Value = result[i].userID;
                    dgv_showUsers.Rows[i].Cells["col_name"].Value = result[i].UserFirstName;
                    dgv_showUsers.Rows[i].Cells["col_family"].Value = result[i].UserFamily;
                    dgv_showUsers.Rows[i].Cells["col_tel"].Value = result[i].UserTel;
                    dgv_showUsers.Rows[i].Cells["col_status"].Value = result[i].farsiActivity;
                    dgv_showUsers.Rows[i].Cells["gender"].Value = result[i].Gender;
                }
                dgv_showUsers.ScrollBars = ScrollBars.Both;
            }
            else
            {
                dgv_showUsers.Rows.Clear();
            }
        }

        private void Frm_sendSMS_Load(object sender, EventArgs e)
        {
            ShowUserInfo();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_message_TextChanged(object sender, EventArgs e)
        {
            lbl_charNo.Text = Convert.ToString(txt_message.Text.Length);
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                int smsLineID = 0;
                List<SendMessageWebService.WebServiceSmsSend> sendDetails = new List<SendMessageWebService.WebServiceSmsSend>();
                {
                    string messageBody = string.Empty;
                    long mobileNo;
                    bool isFlash = false; ///Messages that are only displayed once and do not stay in the inbox.

                    ///Choose which user is selected
                    foreach (DataGridViewRow dr in dgv_showUsers.Rows)
                    {
                        DataGridViewCheckBoxCell checking = dr.Cells["select"] as DataGridViewCheckBoxCell;
                        if (Convert.ToBoolean(checking.Value))
                        {
                            messageBody = "Dear employee" + dr.Cells[1].Value.ToString() + " " + dr.Cells[2].Value.ToString() + txt_message.Text.Trim();
                            mobileNo = Convert.ToInt64(dr.Cells[3].Value);
                            isFlash = false;


                            sendDetails.Add(new SendMessageWebService.WebServiceSmsSend()
                            {
                                MessageBody = messageBody,
                                MobileNo = mobileNo,
                                IsFlash = isFlash
                            });
                        }
                    }
                }
                /// check line Id
                /// 
                if (!int.TryParse(txt_lineSerial.Text, out smsLineID)) throw new Exception("Line ID is not valid");

                /// send list to web service

                SendMessageWebService.SendReceive ws = new SendMessageWebService.SendReceive();
                string message = "";
                long[] result = ws.SendMessage(txt_username.Text.Trim(), txt_password.Text.Trim(),sendDetails.ToArray(),smsLineID ,null ,ref message);
                if (!string.IsNullOrWhiteSpace(message)) throw new Exception(message);
                MessageBox.Show("Your message has been successfully sent.");
                                               
            }
            catch
            {
                MessageBox.Show("There is a problem with the web service");
            }
        }
    }
}
