namespace Automation.Admin_panel
{
    partial class Frm_CreateNews
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
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btn_sendSMS = new DevComponents.DotNetBar.ButtonX();
            this.btn_showallnews = new DevComponents.DotNetBar.ButtonX();
            this.btn_ok = new DevComponents.DotNetBar.ButtonX();
            this.btn_exit = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lbl_newsDate = new DevComponents.DotNetBar.LabelX();
            this.lbl_userCreator = new DevComponents.DotNetBar.LabelX();
            this.txt_subject = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.lbl_attachmentFile = new DevComponents.DotNetBar.LabelX();
            this.btn_attachment = new DevComponents.DotNetBar.ButtonX();
            this.txt_matn = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelEx1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.groupPanel2);
            this.panelEx1.Controls.Add(this.groupPanel1);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(748, 291);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btn_sendSMS);
            this.groupPanel2.Controls.Add(this.btn_showallnews);
            this.groupPanel2.Controls.Add(this.btn_ok);
            this.groupPanel2.Controls.Add(this.btn_exit);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(6, 238);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(742, 47);
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
            // 
            // btn_sendSMS
            // 
            this.btn_sendSMS.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_sendSMS.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_sendSMS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sendSMS.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_sendSMS.ImageTextSpacing = 8;
            this.btn_sendSMS.Location = new System.Drawing.Point(613, 6);
            this.btn_sendSMS.Name = "btn_sendSMS";
            this.btn_sendSMS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_sendSMS.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(7);
            this.btn_sendSMS.Size = new System.Drawing.Size(117, 29);
            this.btn_sendSMS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_sendSMS.SymbolSize = 15F;
            this.btn_sendSMS.TabIndex = 21;
            this.btn_sendSMS.Text = "Send SMS";
            this.btn_sendSMS.Click += new System.EventHandler(this.btn_sendSMS_Click);
            // 
            // btn_showallnews
            // 
            this.btn_showallnews.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_showallnews.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_showallnews.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_showallnews.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_showallnews.ImageTextSpacing = 8;
            this.btn_showallnews.Location = new System.Drawing.Point(382, 6);
            this.btn_showallnews.Name = "btn_showallnews";
            this.btn_showallnews.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_showallnews.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(7);
            this.btn_showallnews.Size = new System.Drawing.Size(117, 29);
            this.btn_showallnews.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_showallnews.SymbolSize = 15F;
            this.btn_showallnews.TabIndex = 20;
            this.btn_showallnews.Text = "News list";
            this.btn_showallnews.Click += new System.EventHandler(this.btn_showallnews_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_ok.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ok.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_ok.ImageTextSpacing = 8;
            this.btn_ok.Location = new System.Drawing.Point(220, 6);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_ok.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(7);
            this.btn_ok.Size = new System.Drawing.Size(122, 29);
            this.btn_ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_ok.SymbolSize = 15F;
            this.btn_ok.TabIndex = 18;
            this.btn_ok.Text = "Send news";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_exit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_exit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_exit.ImageTextSpacing = 10;
            this.btn_exit.Location = new System.Drawing.Point(6, 6);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_exit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(7);
            this.btn_exit.Size = new System.Drawing.Size(121, 29);
            this.btn_exit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_exit.SymbolSize = 15F;
            this.btn_exit.TabIndex = 19;
            this.btn_exit.Text = "Cancel";
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.groupPanel3);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(3, 37);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(742, 195);
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
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.lbl_newsDate);
            this.groupPanel3.Controls.Add(this.lbl_userCreator);
            this.groupPanel3.Controls.Add(this.txt_subject);
            this.groupPanel3.Controls.Add(this.labelX2);
            this.groupPanel3.Controls.Add(this.lbl_attachmentFile);
            this.groupPanel3.Controls.Add(this.btn_attachment);
            this.groupPanel3.Controls.Add(this.txt_matn);
            this.groupPanel3.Controls.Add(this.labelX8);
            this.groupPanel3.Controls.Add(this.labelX9);
            this.groupPanel3.Controls.Add(this.labelX10);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Location = new System.Drawing.Point(-3, -3);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(742, 187);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 7;
            // 
            // lbl_newsDate
            // 
            this.lbl_newsDate.AutoSize = true;
            // 
            // 
            // 
            this.lbl_newsDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_newsDate.Location = new System.Drawing.Point(676, 12);
            this.lbl_newsDate.Name = "lbl_newsDate";
            this.lbl_newsDate.SingleLineColor = System.Drawing.SystemColors.GrayText;
            this.lbl_newsDate.Size = new System.Drawing.Size(14, 18);
            this.lbl_newsDate.TabIndex = 4;
            this.lbl_newsDate.Text = "...";
            this.lbl_newsDate.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lbl_userCreator
            // 
            this.lbl_userCreator.AutoSize = true;
            // 
            // 
            // 
            this.lbl_userCreator.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_userCreator.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_userCreator.Location = new System.Drawing.Point(634, 58);
            this.lbl_userCreator.Name = "lbl_userCreator";
            this.lbl_userCreator.Size = new System.Drawing.Size(14, 18);
            this.lbl_userCreator.TabIndex = 5;
            this.lbl_userCreator.Text = "...";
            this.lbl_userCreator.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txt_subject
            // 
            this.txt_subject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.txt_subject.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_subject.FocusHighlightColor = System.Drawing.Color.WhiteSmoke;
            this.txt_subject.Location = new System.Drawing.Point(96, 12);
            this.txt_subject.Name = "txt_subject";
            this.txt_subject.PreventEnterBeep = true;
            this.txt_subject.Size = new System.Drawing.Size(287, 17);
            this.txt_subject.TabIndex = 6;
            this.txt_subject.WatermarkText = "News subject ...";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(3, 9);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(87, 23);
            this.labelX2.TabIndex = 21;
            this.labelX2.Text = "News subject:";
            // 
            // lbl_attachmentFile
            // 
            // 
            // 
            // 
            this.lbl_attachmentFile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_attachmentFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl_attachmentFile.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_attachmentFile.Location = new System.Drawing.Point(402, 152);
            this.lbl_attachmentFile.Name = "lbl_attachmentFile";
            this.lbl_attachmentFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_attachmentFile.Size = new System.Drawing.Size(331, 18);
            this.lbl_attachmentFile.TabIndex = 20;
            this.lbl_attachmentFile.Text = "...";
            this.lbl_attachmentFile.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btn_attachment
            // 
            this.btn_attachment.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_attachment.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_attachment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_attachment.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_attachment.ImageTextSpacing = 8;
            this.btn_attachment.Location = new System.Drawing.Point(506, 119);
            this.btn_attachment.Name = "btn_attachment";
            this.btn_attachment.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_attachment.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(7);
            this.btn_attachment.Size = new System.Drawing.Size(118, 27);
            this.btn_attachment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_attachment.SymbolSize = 15F;
            this.btn_attachment.TabIndex = 19;
            this.btn_attachment.Text = "Attach file";
            this.btn_attachment.Click += new System.EventHandler(this.btn_attachment_Click);
            // 
            // txt_matn
            // 
            this.txt_matn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.txt_matn.Border.Class = "TextBoxBorder";
            this.txt_matn.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_matn.FocusHighlightColor = System.Drawing.Color.WhiteSmoke;
            this.txt_matn.Location = new System.Drawing.Point(96, 54);
            this.txt_matn.Multiline = true;
            this.txt_matn.Name = "txt_matn";
            this.txt_matn.PreventEnterBeep = true;
            this.txt_matn.Size = new System.Drawing.Size(287, 110);
            this.txt_matn.TabIndex = 7;
            this.txt_matn.WatermarkText = "News text...";
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(402, 53);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(82, 18);
            this.labelX8.TabIndex = 3;
            this.labelX8.Text = "Sending user:";
            // 
            // labelX9
            // 
            this.labelX9.AutoSize = true;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(402, 11);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(222, 18);
            this.labelX9.TabIndex = 2;
            this.labelX9.Text = "Date of creation and sending of news:";
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(26, 53);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(75, 23);
            this.labelX10.TabIndex = 1;
            this.labelX10.Text = "News text:";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(260, 13);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(247, 18);
            this.labelX1.Symbol = "";
            this.labelX1.SymbolSize = 10F;
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "News and announcement creation form";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Frm_CreateNews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 291);
            this.ControlBox = false;
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_CreateNews";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Frm_CreateNews_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btn_ok;
        private DevComponents.DotNetBar.ButtonX btn_exit;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.LabelX lbl_attachmentFile;
        private DevComponents.DotNetBar.ButtonX btn_attachment;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_matn;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_subject;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX lbl_newsDate;
        private DevComponents.DotNetBar.LabelX lbl_userCreator;
        private DevComponents.DotNetBar.ButtonX btn_showallnews;
        private DevComponents.DotNetBar.ButtonX btn_sendSMS;
    }
}