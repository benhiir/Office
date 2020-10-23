namespace Automation.Admin_panel
{
    partial class frm_showUsers
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btn_reports = new DevComponents.DotNetBar.ButtonX();
            this.btn_exit = new DevComponents.DotNetBar.ButtonX();
            this.btn_deactiveUser = new DevComponents.DotNetBar.ButtonX();
            this.btnEditUser = new DevComponents.DotNetBar.ButtonX();
            this.btn_newUser = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdb_woman = new System.Windows.Forms.RadioButton();
            this.rdb_man = new System.Windows.Forms.RadioButton();
            this.rdb_allUsers_gender = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdb_deactive = new System.Windows.Forms.RadioButton();
            this.rdb_active = new System.Windows.Forms.RadioButton();
            this.rdb_allusers_status = new System.Windows.Forms.RadioButton();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.btn_search = new DevComponents.DotNetBar.ButtonX();
            this.txt_family = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_name = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgv_showUsers = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mun_activeuser = new System.Windows.Forms.ToolStripMenuItem();
            this.mun_changePass = new System.Windows.Forms.ToolStripMenuItem();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_family = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_personalcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_birthdaydate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_userId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_showUsers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.groupPanel3);
            this.panelEx1.Controls.Add(this.groupPanel2);
            this.panelEx1.Controls.Add(this.groupPanel1);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(863, 431);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.DarkGray;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.btn_reports);
            this.groupPanel3.Controls.Add(this.btn_exit);
            this.groupPanel3.Controls.Add(this.btn_deactiveUser);
            this.groupPanel3.Controls.Add(this.btnEditUser);
            this.groupPanel3.Controls.Add(this.btn_newUser);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Location = new System.Drawing.Point(3, 383);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(857, 51);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
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
            this.groupPanel3.TabIndex = 3;
            // 
            // btn_reports
            // 
            this.btn_reports.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_reports.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_reports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_reports.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_reports.ImageTextSpacing = 4;
            this.btn_reports.Location = new System.Drawing.Point(737, 3);
            this.btn_reports.Name = "btn_reports";
            this.btn_reports.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_reports.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(7);
            this.btn_reports.Size = new System.Drawing.Size(111, 37);
            this.btn_reports.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_reports.TabIndex = 4;
            this.btn_reports.Text = "Report";
            this.btn_reports.Click += new System.EventHandler(this.btn_reports_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_exit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_exit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_exit.ImageTextSpacing = 4;
            this.btn_exit.Location = new System.Drawing.Point(3, 3);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_exit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(7);
            this.btn_exit.Size = new System.Drawing.Size(111, 37);
            this.btn_exit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "Cancel";
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_deactiveUser
            // 
            this.btn_deactiveUser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_deactiveUser.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_deactiveUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_deactiveUser.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_deactiveUser.ImageTextSpacing = 4;
            this.btn_deactiveUser.Location = new System.Drawing.Point(253, 3);
            this.btn_deactiveUser.Name = "btn_deactiveUser";
            this.btn_deactiveUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_deactiveUser.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(7);
            this.btn_deactiveUser.Size = new System.Drawing.Size(111, 37);
            this.btn_deactiveUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_deactiveUser.TabIndex = 2;
            this.btn_deactiveUser.Text = "Deactive User";
            this.btn_deactiveUser.Click += new System.EventHandler(this.btn_deactiveUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEditUser.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEditUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditUser.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnEditUser.ImageTextSpacing = 4;
            this.btnEditUser.Location = new System.Drawing.Point(374, 3);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEditUser.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(7);
            this.btnEditUser.Size = new System.Drawing.Size(111, 37);
            this.btnEditUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEditUser.TabIndex = 1;
            this.btnEditUser.Text = "Edit User";
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btn_newUser
            // 
            this.btn_newUser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_newUser.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_newUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_newUser.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_newUser.ImageTextSpacing = 4;
            this.btn_newUser.Location = new System.Drawing.Point(490, 3);
            this.btn_newUser.Name = "btn_newUser";
            this.btn_newUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_newUser.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(7);
            this.btn_newUser.Size = new System.Drawing.Size(111, 37);
            this.btn_newUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_newUser.TabIndex = 0;
            this.btn_newUser.Text = "Create User";
            this.btn_newUser.Click += new System.EventHandler(this.btn_newUser_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.panel2);
            this.groupPanel2.Controls.Add(this.panel1);
            this.groupPanel2.Controls.Add(this.btn_search);
            this.groupPanel2.Controls.Add(this.txt_family);
            this.groupPanel2.Controls.Add(this.labelX5);
            this.groupPanel2.Controls.Add(this.txt_name);
            this.groupPanel2.Controls.Add(this.labelX4);
            this.groupPanel2.Controls.Add(this.labelX3);
            this.groupPanel2.Controls.Add(this.labelX2);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(3, 254);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(857, 123);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
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
            this.groupPanel2.Text = "Search";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdb_woman);
            this.panel2.Controls.Add(this.rdb_man);
            this.panel2.Controls.Add(this.rdb_allUsers_gender);
            this.panel2.Location = new System.Drawing.Point(536, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(75, 84);
            this.panel2.TabIndex = 1;
            // 
            // rdb_woman
            // 
            this.rdb_woman.AutoSize = true;
            this.rdb_woman.Location = new System.Drawing.Point(15, 56);
            this.rdb_woman.Name = "rdb_woman";
            this.rdb_woman.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rdb_woman.Size = new System.Drawing.Size(57, 17);
            this.rdb_woman.TabIndex = 14;
            this.rdb_woman.Text = "female";
            this.rdb_woman.UseVisualStyleBackColor = true;
            // 
            // rdb_man
            // 
            this.rdb_man.AutoSize = true;
            this.rdb_man.Location = new System.Drawing.Point(16, 33);
            this.rdb_man.Name = "rdb_man";
            this.rdb_man.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rdb_man.Size = new System.Drawing.Size(47, 17);
            this.rdb_man.TabIndex = 13;
            this.rdb_man.Text = "male";
            this.rdb_man.UseVisualStyleBackColor = true;
            // 
            // rdb_allUsers_gender
            // 
            this.rdb_allUsers_gender.AutoSize = true;
            this.rdb_allUsers_gender.Checked = true;
            this.rdb_allUsers_gender.Location = new System.Drawing.Point(15, 8);
            this.rdb_allUsers_gender.Name = "rdb_allUsers_gender";
            this.rdb_allUsers_gender.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rdb_allUsers_gender.Size = new System.Drawing.Size(35, 17);
            this.rdb_allUsers_gender.TabIndex = 12;
            this.rdb_allUsers_gender.TabStop = true;
            this.rdb_allUsers_gender.Text = "all";
            this.rdb_allUsers_gender.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdb_deactive);
            this.panel1.Controls.Add(this.rdb_active);
            this.panel1.Controls.Add(this.rdb_allusers_status);
            this.panel1.Location = new System.Drawing.Point(682, 4);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(78, 84);
            this.panel1.TabIndex = 13;
            // 
            // rdb_deactive
            // 
            this.rdb_deactive.AutoSize = true;
            this.rdb_deactive.Location = new System.Drawing.Point(11, 60);
            this.rdb_deactive.Name = "rdb_deactive";
            this.rdb_deactive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rdb_deactive.Size = new System.Drawing.Size(66, 17);
            this.rdb_deactive.TabIndex = 11;
            this.rdb_deactive.Text = "deactive";
            this.rdb_deactive.UseVisualStyleBackColor = true;
            // 
            // rdb_active
            // 
            this.rdb_active.AutoSize = true;
            this.rdb_active.Location = new System.Drawing.Point(14, 38);
            this.rdb_active.Name = "rdb_active";
            this.rdb_active.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rdb_active.Size = new System.Drawing.Size(54, 17);
            this.rdb_active.TabIndex = 10;
            this.rdb_active.Text = "active";
            this.rdb_active.UseVisualStyleBackColor = true;
            // 
            // rdb_allusers_status
            // 
            this.rdb_allusers_status.AutoSize = true;
            this.rdb_allusers_status.Checked = true;
            this.rdb_allusers_status.Location = new System.Drawing.Point(14, 14);
            this.rdb_allusers_status.Name = "rdb_allusers_status";
            this.rdb_allusers_status.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rdb_allusers_status.Size = new System.Drawing.Size(35, 17);
            this.rdb_allusers_status.TabIndex = 9;
            this.rdb_allusers_status.TabStop = true;
            this.rdb_allusers_status.Text = "all";
            this.rdb_allusers_status.UseVisualStyleBackColor = true;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelX5.Location = new System.Drawing.Point(481, 41);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(49, 18);
            this.labelX5.TabIndex = 3;
            this.labelX5.Text = "Gender:";
            // 
            // btn_search
            // 
            this.btn_search.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_search.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_search.Image = global::Automation.Properties.Resources.search_icon;
            this.btn_search.ImageFixedSize = new System.Drawing.Size(60, 60);
            this.btn_search.Location = new System.Drawing.Point(780, 14);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(65, 74);
            this.btn_search.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_search.TabIndex = 12;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_family
            // 
            // 
            // 
            // 
            this.txt_family.Border.Class = "TextBoxBorder";
            this.txt_family.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_family.Location = new System.Drawing.Point(304, 42);
            this.txt_family.Name = "txt_family";
            this.txt_family.PreventEnterBeep = true;
            this.txt_family.Size = new System.Drawing.Size(171, 21);
            this.txt_family.TabIndex = 5;
            this.txt_family.WatermarkText = "Last Name ...";
            // 
            // txt_name
            // 
            // 
            // 
            // 
            this.txt_name.Border.Class = "TextBoxBorder";
            this.txt_name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_name.Location = new System.Drawing.Point(90, 42);
            this.txt_name.Name = "txt_name";
            this.txt_name.PreventEnterBeep = true;
            this.txt_name.Size = new System.Drawing.Size(134, 21);
            this.txt_name.TabIndex = 4;
            this.txt_name.WatermarkText = "First Name ...";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelX4.Location = new System.Drawing.Point(617, 41);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(43, 18);
            this.labelX4.TabIndex = 2;
            this.labelX4.Text = "Status:";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelX3.Location = new System.Drawing.Point(230, 45);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(68, 18);
            this.labelX3.TabIndex = 1;
            this.labelX3.Text = "Last Name:";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelX2.Location = new System.Drawing.Point(6, 38);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(78, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "First Name:";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dgv_showUsers);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupPanel1.Location = new System.Drawing.Point(3, 66);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(857, 193);
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
            // dgv_showUsers
            // 
            this.dgv_showUsers.AllowUserToAddRows = false;
            this.dgv_showUsers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgv_showUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_showUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_showUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_showUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_name,
            this.gender,
            this.col_family,
            this.col_personalcode,
            this.col_tel,
            this.col_email,
            this.col_gender,
            this.col_status,
            this.col_birthdaydate,
            this.col_username,
            this.col_userId});
            this.dgv_showUsers.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_showUsers.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_showUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_showUsers.EnableHeadersVisualStyles = false;
            this.dgv_showUsers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_showUsers.Location = new System.Drawing.Point(0, 0);
            this.dgv_showUsers.Name = "dgv_showUsers";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_showUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_showUsers.Size = new System.Drawing.Size(851, 187);
            this.dgv_showUsers.TabIndex = 0;
            this.dgv_showUsers.DoubleClick += new System.EventHandler(this.dgv_showUsers_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mun_activeuser,
            this.mun_changePass});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(152, 48);
            // 
            // mun_activeuser
            // 
            this.mun_activeuser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mun_activeuser.Name = "mun_activeuser";
            this.mun_activeuser.Size = new System.Drawing.Size(151, 22);
            this.mun_activeuser.Text = "فعال کردن کاربر";
            this.mun_activeuser.Click += new System.EventHandler(this.mun_activeuser_Click);
            // 
            // mun_changePass
            // 
            this.mun_changePass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mun_changePass.Name = "mun_changePass";
            this.mun_changePass.Size = new System.Drawing.Size(151, 22);
            this.mun_changePass.Text = "تغییر رمز عبور";
            this.mun_changePass.Click += new System.EventHandler(this.mun_changePass_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelX1.Location = new System.Drawing.Point(354, 28);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(159, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "System users display form";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Silver;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // col_name
            // 
            this.col_name.HeaderText = "First Name";
            this.col_name.Name = "col_name";
            // 
            // gender
            // 
            this.gender.HeaderText = "gender";
            this.gender.Name = "gender";
            this.gender.Visible = false;
            // 
            // col_family
            // 
            this.col_family.HeaderText = "Last Name";
            this.col_family.Name = "col_family";
            // 
            // col_personalcode
            // 
            this.col_personalcode.HeaderText = "Personel ID";
            this.col_personalcode.Name = "col_personalcode";
            // 
            // col_tel
            // 
            this.col_tel.HeaderText = "Contact";
            this.col_tel.Name = "col_tel";
            // 
            // col_email
            // 
            this.col_email.HeaderText = "Email";
            this.col_email.Name = "col_email";
            // 
            // col_gender
            // 
            this.col_gender.HeaderText = "Gender";
            this.col_gender.Name = "col_gender";
            // 
            // col_status
            // 
            this.col_status.HeaderText = "Status";
            this.col_status.Name = "col_status";
            // 
            // col_birthdaydate
            // 
            this.col_birthdaydate.HeaderText = "Date of Birth";
            this.col_birthdaydate.Name = "col_birthdaydate";
            // 
            // col_username
            // 
            this.col_username.HeaderText = "Username";
            this.col_username.Name = "col_username";
            // 
            // col_userId
            // 
            this.col_userId.HeaderText = "userId";
            this.col_userId.Name = "col_userId";
            this.col_userId.Visible = false;
            // 
            // frm_showUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 431);
            this.ControlBox = false;
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_showUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_showUsers_Load);
            this.panelEx1.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_showUsers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.ButtonX btn_exit;
        private DevComponents.DotNetBar.ButtonX btn_deactiveUser;
        private DevComponents.DotNetBar.ButtonX btnEditUser;
        private DevComponents.DotNetBar.ButtonX btn_newUser;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_showUsers;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_family;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_name;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btn_search;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdb_woman;
        private System.Windows.Forms.RadioButton rdb_man;
        private System.Windows.Forms.RadioButton rdb_allUsers_gender;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdb_deactive;
        private System.Windows.Forms.RadioButton rdb_active;
        private System.Windows.Forms.RadioButton rdb_allusers_status;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mun_activeuser;
        private System.Windows.Forms.ToolStripMenuItem mun_changePass;
        private DevComponents.DotNetBar.ButtonX btn_reports;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_family;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_personalcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_email;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_birthdaydate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_username;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_userId;
    }
}