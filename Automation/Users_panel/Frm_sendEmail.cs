using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;


namespace Automation.Users_panel
{
    public partial class Frm_sendEmail : Form
    {
        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;

        public Frm_sendEmail()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {

            /// Login to email
            login = new NetworkCredential(lbl_yourMail.Text, txt_pass.Text);
            client = new SmtpClient(txt_smtp.Text);
            client.Port = Convert.ToInt32(txt_port.Text.Trim());
            client.EnableSsl = chk_ssl.Checked;
            client.Credentials = login;

            /// Email Profile
            msg = new MailMessage {From = new MailAddress(txt_yourMail.Text.Trim() + txt_smtp.Text.Trim().Replace("smtp.","@"), "Office Automation System", Encoding.UTF8) };
            msg.To.Add(new MailAddress(txt_to.Text));
            if (!string.IsNullOrEmpty(txt_cc.Text))  // If the cc was not empty
            {
                msg.To.Add(new MailAddress(txt_cc.Text));
            }
            msg.Subject = txt_subject.Text;
            msg.Body = txt_matn.Text;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;  // To send characters and bolds and ...
            msg.Priority = MailPriority.Normal;
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            string userstate = "sending ...";
            client.SendAsync(msg, userstate);
            
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show("Email sending stopped.");
            if (e.Error != null)
                MessageBox.Show("There was a problem sending the email.");
            else
                MessageBox.Show("Email sent successfully.");   
            
        }
    }
}
