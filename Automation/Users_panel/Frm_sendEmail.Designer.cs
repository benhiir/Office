namespace Automation.Users_panel
{
    partial class Frm_sendEmail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btn_exit = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btn_send = new DevComponents.DotNetBar.ButtonX();
            this.chk_ssl = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txt_smtp = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.txt_port = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.txt_pass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_yourMail = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.lbl_yourMail = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txt_matn = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_subject = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_cc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_to = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btn_send);
            this.panelEx1.Controls.Add(this.btn_exit);
            this.panelEx1.Controls.Add(this.groupPanel2);
            this.panelEx1.Controls.Add(this.groupPanel1);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(554, 547);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // btn_exit
            // 
            this.btn_exit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_exit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_exit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_exit.ImageTextSpacing = 10;
            this.btn_exit.Location = new System.Drawing.Point(5, 512);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(7);
            this.btn_exit.Size = new System.Drawing.Size(87, 28);
            this.btn_exit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_exit.SymbolSize = 10F;
            this.btn_exit.TabIndex = 26;
            this.btn_exit.Text = "Cancel";
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.chk_ssl);
            this.groupPanel2.Controls.Add(this.txt_smtp);
            this.groupPanel2.Controls.Add(this.labelX8);
            this.groupPanel2.Controls.Add(this.txt_port);
            this.groupPanel2.Controls.Add(this.labelX7);
            this.groupPanel2.Controls.Add(this.txt_pass);
            this.groupPanel2.Controls.Add(this.txt_yourMail);
            this.groupPanel2.Controls.Add(this.labelX6);
            this.groupPanel2.Controls.Add(this.lbl_yourMail);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(3, 321);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(548, 180);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 2;
            this.groupPanel2.Text = "Settings";
            // 
            // btn_send
            // 
            this.btn_send.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_send.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_send.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_send.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_send.ImageTextSpacing = 10;
            this.btn_send.Location = new System.Drawing.Point(447, 516);
            this.btn_send.Name = "btn_send";
            this.btn_send.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(7);
            this.btn_send.Size = new System.Drawing.Size(95, 24);
            this.btn_send.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_send.SymbolSize = 10F;
            this.btn_send.TabIndex = 27;
            this.btn_send.Text = "Send Email";
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // chk_ssl
            // 
            // 
            // 
            // 
            this.chk_ssl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk_ssl.Location = new System.Drawing.Point(19, 103);
            this.chk_ssl.Name = "chk_ssl";
            this.chk_ssl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk_ssl.Size = new System.Drawing.Size(46, 23);
            this.chk_ssl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk_ssl.TabIndex = 14;
            this.chk_ssl.Text = "SSL";
            // 
            // txt_smtp
            // 
            // 
            // 
            // 
            this.txt_smtp.Border.Class = "TextBoxBorder";
            this.txt_smtp.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_smtp.Location = new System.Drawing.Point(277, 67);
            this.txt_smtp.Name = "txt_smtp";
            this.txt_smtp.PreventEnterBeep = true;
            this.txt_smtp.Size = new System.Drawing.Size(250, 22);
            this.txt_smtp.TabIndex = 13;
            this.txt_smtp.Text = "smtp.gmail.com";
            this.txt_smtp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(233, 67);
            this.labelX8.Name = "labelX8";
            this.labelX8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelX8.Size = new System.Drawing.Size(38, 23);
            this.labelX8.TabIndex = 12;
            this.labelX8.Text = "SMTP:";
            // 
            // txt_port
            // 
            // 
            // 
            // 
            this.txt_port.Border.Class = "TextBoxBorder";
            this.txt_port.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_port.Location = new System.Drawing.Point(104, 67);
            this.txt_port.Name = "txt_port";
            this.txt_port.PreventEnterBeep = true;
            this.txt_port.Size = new System.Drawing.Size(111, 22);
            this.txt_port.TabIndex = 11;
            this.txt_port.Text = "587";
            this.txt_port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(11, 64);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(75, 23);
            this.labelX7.TabIndex = 10;
            this.labelX7.Text = "Port number:";
            // 
            // txt_pass
            // 
            // 
            // 
            // 
            this.txt_pass.Border.Class = "TextBoxBorder";
            this.txt_pass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_pass.Location = new System.Drawing.Point(104, 35);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '*';
            this.txt_pass.PreventEnterBeep = true;
            this.txt_pass.Size = new System.Drawing.Size(423, 22);
            this.txt_pass.TabIndex = 9;
            this.txt_pass.WatermarkText = "Enter your password";
            // 
            // txt_yourMail
            // 
            // 
            // 
            // 
            this.txt_yourMail.Border.Class = "TextBoxBorder";
            this.txt_yourMail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_yourMail.Location = new System.Drawing.Point(104, 3);
            this.txt_yourMail.Name = "txt_yourMail";
            this.txt_yourMail.PreventEnterBeep = true;
            this.txt_yourMail.Size = new System.Drawing.Size(423, 22);
            this.txt_yourMail.TabIndex = 8;
            this.txt_yourMail.WatermarkText = "Enter your email address";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(11, 35);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 7;
            this.labelX6.Text = "Your password:";
            // 
            // lbl_yourMail
            // 
            // 
            // 
            // 
            this.lbl_yourMail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_yourMail.Location = new System.Drawing.Point(11, 3);
            this.lbl_yourMail.Name = "lbl_yourMail";
            this.lbl_yourMail.Size = new System.Drawing.Size(75, 23);
            this.lbl_yourMail.TabIndex = 6;
            this.lbl_yourMail.Text = "Your email:";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.txt_matn);
            this.groupPanel1.Controls.Add(this.txt_subject);
            this.groupPanel1.Controls.Add(this.txt_cc);
            this.groupPanel1.Controls.Add(this.txt_to);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(3, 41);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(548, 274);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 1;
            this.groupPanel1.Text = "Recipient Details";
            // 
            // txt_matn
            // 
            // 
            // 
            // 
            this.txt_matn.Border.Class = "TextBoxBorder";
            this.txt_matn.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_matn.Location = new System.Drawing.Point(104, 113);
            this.txt_matn.Multiline = true;
            this.txt_matn.Name = "txt_matn";
            this.txt_matn.PreventEnterBeep = true;
            this.txt_matn.Size = new System.Drawing.Size(423, 128);
            this.txt_matn.TabIndex = 7;
            this.txt_matn.WatermarkText = "Email Text";
            // 
            // txt_subject
            // 
            // 
            // 
            // 
            this.txt_subject.Border.Class = "TextBoxBorder";
            this.txt_subject.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_subject.Location = new System.Drawing.Point(104, 73);
            this.txt_subject.Name = "txt_subject";
            this.txt_subject.PreventEnterBeep = true;
            this.txt_subject.Size = new System.Drawing.Size(423, 22);
            this.txt_subject.TabIndex = 6;
            this.txt_subject.WatermarkText = "Email subject";
            // 
            // txt_cc
            // 
            // 
            // 
            // 
            this.txt_cc.Border.Class = "TextBoxBorder";
            this.txt_cc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_cc.Location = new System.Drawing.Point(104, 38);
            this.txt_cc.Name = "txt_cc";
            this.txt_cc.PreventEnterBeep = true;
            this.txt_cc.Size = new System.Drawing.Size(423, 22);
            this.txt_cc.TabIndex = 5;
            this.txt_cc.WatermarkText = "Copy email address";
            // 
            // txt_to
            // 
            // 
            // 
            // 
            this.txt_to.Border.Class = "TextBoxBorder";
            this.txt_to.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_to.Location = new System.Drawing.Point(104, 6);
            this.txt_to.Name = "txt_to";
            this.txt_to.PreventEnterBeep = true;
            this.txt_to.Size = new System.Drawing.Size(423, 22);
            this.txt_to.TabIndex = 4;
            this.txt_to.WatermarkText = "Recipient email address";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(11, 113);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 3;
            this.labelX5.Text = "Text:";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(11, 72);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 2;
            this.labelX4.Text = "Subject:";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(11, 38);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 1;
            this.labelX3.Text = "Copy to:";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(14, 5);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "recipient:";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(232, 13);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(99, 25);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Send Email form";
            // 
            // Frm_sendEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 547);
            this.ControlBox = false;
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Frm_sendEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelEx1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.CheckBoxX chk_ssl;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_smtp;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_port;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_pass;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_yourMail;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX lbl_yourMail;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_matn;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_subject;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_cc;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_to;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btn_exit;
        private DevComponents.DotNetBar.ButtonX btn_send;
    }
}