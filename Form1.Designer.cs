namespace project2
{
    partial class FuturePathForm
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
            this.radLearner = new System.Windows.Forms.RadioButton();
            this.radCareerAdvisor = new System.Windows.Forms.RadioButton();
            this.radAdministrator = new System.Windows.Forms.RadioButton();
            this.lblGrade = new System.Windows.Forms.Label();
            this.cmbGrade = new System.Windows.Forms.ComboBox();
            this.grpSubjects = new System.Windows.Forms.GroupBox();
            this.cmbSubject3 = new System.Windows.Forms.ComboBox();
            this.cmbSubject2 = new System.Windows.Forms.ComboBox();
            this.cmbSubject1 = new System.Windows.Forms.ComboBox();
            this.cmbMaths = new System.Windows.Forms.ComboBox();
            this.cmbFAL = new System.Windows.Forms.ComboBox();
            this.cmbHomeLanguage = new System.Windows.Forms.ComboBox();
            this.lblMark = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblSubject3 = new System.Windows.Forms.Label();
            this.lblSubject2 = new System.Windows.Forms.Label();
            this.lblSubject1 = new System.Windows.Forms.Label();
            this.lblLO = new System.Windows.Forms.Label();
            this.lblMaths = new System.Windows.Forms.Label();
            this.lblFAL = new System.Windows.Forms.Label();
            this.lblHL = new System.Windows.Forms.Label();
            this.txtMark3 = new System.Windows.Forms.TextBox();
            this.txtMark2 = new System.Windows.Forms.TextBox();
            this.txtMark1 = new System.Windows.Forms.TextBox();
            this.txtMarkLO = new System.Windows.Forms.TextBox();
            this.txtMarkMaths = new System.Windows.Forms.TextBox();
            this.txtMarkFAL = new System.Windows.Forms.TextBox();
            this.txtMarkHL = new System.Windows.Forms.TextBox();
            this.txtLO = new System.Windows.Forms.TextBox();
            this.FuturePathTabControl = new System.Windows.Forms.TabControl();
            this.tabRoleSelection = new System.Windows.Forms.TabPage();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblAccess = new System.Windows.Forms.Label();
            this.tabLearnerInfo = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.grpFaculty = new System.Windows.Forms.GroupBox();
            this.cmbQualification = new System.Windows.Forms.ComboBox();
            this.lblQualification = new System.Windows.Forms.Label();
            this.cmbFaculty = new System.Windows.Forms.ComboBox();
            this.lblFaculty = new System.Windows.Forms.Label();
            this.grpLearnerInfo = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblLearnerName = new System.Windows.Forms.Label();
            this.cmbProvince = new System.Windows.Forms.ComboBox();
            this.txtLearnerName = new System.Windows.Forms.TextBox();
            this.lblProvince = new System.Windows.Forms.Label();
            this.lblLearnerSurname = new System.Windows.Forms.Label();
            this.txtSchool = new System.Windows.Forms.TextBox();
            this.txtLearnerSurname = new System.Windows.Forms.TextBox();
            this.lblSchool = new System.Windows.Forms.Label();
            this.tabQuestionnaire = new System.Windows.Forms.TabPage();
            this.flowQuestions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSubmitQuestions = new System.Windows.Forms.Button();
            this.grpSubjects.SuspendLayout();
            this.FuturePathTabControl.SuspendLayout();
            this.tabRoleSelection.SuspendLayout();
            this.tabLearnerInfo.SuspendLayout();
            this.grpFaculty.SuspendLayout();
            this.grpLearnerInfo.SuspendLayout();
            this.tabQuestionnaire.SuspendLayout();
            this.SuspendLayout();
            // 
            // radLearner
            // 
            this.radLearner.AutoSize = true;
            this.radLearner.Checked = true;
            this.radLearner.Location = new System.Drawing.Point(57, 288);
            this.radLearner.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radLearner.Name = "radLearner";
            this.radLearner.Size = new System.Drawing.Size(89, 24);
            this.radLearner.TabIndex = 0;
            this.radLearner.TabStop = true;
            this.radLearner.Text = "Learner";
            this.radLearner.UseVisualStyleBackColor = true;
            this.radLearner.CheckedChanged += new System.EventHandler(this.radLearner_CheckedChanged);
            // 
            // radCareerAdvisor
            // 
            this.radCareerAdvisor.AutoSize = true;
            this.radCareerAdvisor.Location = new System.Drawing.Point(430, 288);
            this.radCareerAdvisor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radCareerAdvisor.Name = "radCareerAdvisor";
            this.radCareerAdvisor.Size = new System.Drawing.Size(138, 24);
            this.radCareerAdvisor.TabIndex = 1;
            this.radCareerAdvisor.Text = "Career Advisor";
            this.radCareerAdvisor.UseVisualStyleBackColor = true;
            // 
            // radAdministrator
            // 
            this.radAdministrator.AutoSize = true;
            this.radAdministrator.Location = new System.Drawing.Point(873, 288);
            this.radAdministrator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radAdministrator.Name = "radAdministrator";
            this.radAdministrator.Size = new System.Drawing.Size(128, 24);
            this.radAdministrator.TabIndex = 2;
            this.radAdministrator.Text = "Administrator";
            this.radAdministrator.UseVisualStyleBackColor = true;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Location = new System.Drawing.Point(6, 155);
            this.lblGrade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(133, 20);
            this.lblGrade.TabIndex = 3;
            this.lblGrade.Text = "Select your grade";
            // 
            // cmbGrade
            // 
            this.cmbGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrade.FormattingEnabled = true;
            this.cmbGrade.Items.AddRange(new object[] {
            "Grade 11",
            "Grade 12"});
            this.cmbGrade.Location = new System.Drawing.Point(189, 151);
            this.cmbGrade.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbGrade.Name = "cmbGrade";
            this.cmbGrade.Size = new System.Drawing.Size(148, 28);
            this.cmbGrade.TabIndex = 4;
            // 
            // grpSubjects
            // 
            this.grpSubjects.Controls.Add(this.cmbSubject3);
            this.grpSubjects.Controls.Add(this.cmbSubject2);
            this.grpSubjects.Controls.Add(this.cmbSubject1);
            this.grpSubjects.Controls.Add(this.cmbMaths);
            this.grpSubjects.Controls.Add(this.cmbFAL);
            this.grpSubjects.Controls.Add(this.cmbHomeLanguage);
            this.grpSubjects.Controls.Add(this.lblMark);
            this.grpSubjects.Controls.Add(this.lblSubject);
            this.grpSubjects.Controls.Add(this.lblSubject3);
            this.grpSubjects.Controls.Add(this.lblSubject2);
            this.grpSubjects.Controls.Add(this.lblSubject1);
            this.grpSubjects.Controls.Add(this.lblLO);
            this.grpSubjects.Controls.Add(this.lblMaths);
            this.grpSubjects.Controls.Add(this.lblFAL);
            this.grpSubjects.Controls.Add(this.lblHL);
            this.grpSubjects.Controls.Add(this.txtMark3);
            this.grpSubjects.Controls.Add(this.txtMark2);
            this.grpSubjects.Controls.Add(this.txtMark1);
            this.grpSubjects.Controls.Add(this.txtMarkLO);
            this.grpSubjects.Controls.Add(this.txtMarkMaths);
            this.grpSubjects.Controls.Add(this.txtMarkFAL);
            this.grpSubjects.Controls.Add(this.txtMarkHL);
            this.grpSubjects.Controls.Add(this.txtLO);
            this.grpSubjects.Location = new System.Drawing.Point(621, 29);
            this.grpSubjects.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSubjects.Name = "grpSubjects";
            this.grpSubjects.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSubjects.Size = new System.Drawing.Size(448, 388);
            this.grpSubjects.TabIndex = 5;
            this.grpSubjects.TabStop = false;
            this.grpSubjects.Text = "Enter your 7 best subjects";
            // 
            // cmbSubject3
            // 
            this.cmbSubject3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubject3.FormattingEnabled = true;
            this.cmbSubject3.Items.AddRange(new object[] {
            "Accounting",
            "",
            "Agricultural Management Practices",
            "",
            "Agricultural Sciences",
            "",
            "Agricultural Technology",
            "",
            "Business Studies",
            "",
            "Civil Technology",
            "",
            "Computer Applications Technology (CAT)",
            "",
            "Consumer Studies",
            "",
            "Dance Studies",
            "",
            "Design",
            "",
            "Dramatic Arts",
            "",
            "Economics",
            "",
            "Electrical Technology",
            "",
            "Engineering Graphics and Design (EGD)",
            "",
            "Geography",
            "",
            "History",
            "",
            "Hospitality Studies",
            "",
            "Information Technology (IT)",
            "",
            "Life Sciences",
            "",
            "Marine Sciences",
            "",
            "Maritime Economics",
            "",
            "Mechanical Technology",
            "",
            "Music",
            "",
            "Nautical Sciences",
            "",
            "Physical Sciences",
            "",
            "Religion Studies",
            "",
            "Technical Sciences",
            "",
            "Tourism",
            "",
            "Visual Arts"});
            this.cmbSubject3.Location = new System.Drawing.Point(207, 315);
            this.cmbSubject3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSubject3.Name = "cmbSubject3";
            this.cmbSubject3.Size = new System.Drawing.Size(148, 28);
            this.cmbSubject3.TabIndex = 28;
            // 
            // cmbSubject2
            // 
            this.cmbSubject2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubject2.FormattingEnabled = true;
            this.cmbSubject2.Items.AddRange(new object[] {
            "Accounting",
            "",
            "Agricultural Management Practices",
            "",
            "Agricultural Sciences",
            "",
            "Agricultural Technology",
            "",
            "Business Studies",
            "",
            "Civil Technology",
            "",
            "Computer Applications Technology (CAT)",
            "",
            "Consumer Studies",
            "",
            "Dance Studies",
            "",
            "Design",
            "",
            "Dramatic Arts",
            "",
            "Economics",
            "",
            "Electrical Technology",
            "",
            "Engineering Graphics and Design (EGD)",
            "",
            "Geography",
            "",
            "History",
            "",
            "Hospitality Studies",
            "",
            "Information Technology (IT)",
            "",
            "Life Sciences",
            "",
            "Marine Sciences",
            "",
            "Maritime Economics",
            "",
            "Mechanical Technology",
            "",
            "Music",
            "",
            "Nautical Sciences",
            "",
            "Physical Sciences",
            "",
            "Religion Studies",
            "",
            "Technical Sciences",
            "",
            "Tourism",
            "",
            "Visual Arts"});
            this.cmbSubject2.Location = new System.Drawing.Point(207, 274);
            this.cmbSubject2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSubject2.Name = "cmbSubject2";
            this.cmbSubject2.Size = new System.Drawing.Size(148, 28);
            this.cmbSubject2.TabIndex = 27;
            // 
            // cmbSubject1
            // 
            this.cmbSubject1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubject1.FormattingEnabled = true;
            this.cmbSubject1.Items.AddRange(new object[] {
            "Accounting",
            "",
            "Agricultural Management Practices",
            "",
            "Agricultural Sciences",
            "",
            "Agricultural Technology",
            "",
            "Business Studies",
            "",
            "Civil Technology",
            "",
            "Computer Applications Technology (CAT)",
            "",
            "Consumer Studies",
            "",
            "Dance Studies",
            "",
            "Design",
            "",
            "Dramatic Arts",
            "",
            "Economics",
            "",
            "Electrical Technology",
            "",
            "Engineering Graphics and Design (EGD)",
            "",
            "Geography",
            "",
            "History",
            "",
            "Hospitality Studies",
            "",
            "Information Technology (IT)",
            "",
            "Life Sciences",
            "",
            "Marine Sciences",
            "",
            "Maritime Economics",
            "",
            "Mechanical Technology",
            "",
            "Music",
            "",
            "Nautical Sciences",
            "",
            "Physical Sciences",
            "",
            "Religion Studies",
            "",
            "Technical Sciences",
            "",
            "Tourism",
            "",
            "Visual Arts"});
            this.cmbSubject1.Location = new System.Drawing.Point(207, 235);
            this.cmbSubject1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSubject1.Name = "cmbSubject1";
            this.cmbSubject1.Size = new System.Drawing.Size(148, 28);
            this.cmbSubject1.TabIndex = 26;
            // 
            // cmbMaths
            // 
            this.cmbMaths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaths.FormattingEnabled = true;
            this.cmbMaths.Items.AddRange(new object[] {
            "Mathematics",
            "Mathematical Literacy",
            "Technical Mathematics"});
            this.cmbMaths.Location = new System.Drawing.Point(207, 155);
            this.cmbMaths.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbMaths.Name = "cmbMaths";
            this.cmbMaths.Size = new System.Drawing.Size(148, 28);
            this.cmbMaths.TabIndex = 25;
            // 
            // cmbFAL
            // 
            this.cmbFAL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFAL.FormattingEnabled = true;
            this.cmbFAL.Items.AddRange(new object[] {
            "Afrikaans FAL",
            "English FAL",
            "isiNdebele FAL",
            "isiXhosa FAL",
            "isiZulu FAL",
            "Sepedi FAL",
            "Sesotho FAL",
            "Setswana FAL",
            "SiSwati FAL",
            "Tshivenda FAL",
            "Xitsonga FAL"});
            this.cmbFAL.Location = new System.Drawing.Point(207, 109);
            this.cmbFAL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbFAL.Name = "cmbFAL";
            this.cmbFAL.Size = new System.Drawing.Size(148, 28);
            this.cmbFAL.TabIndex = 24;
            // 
            // cmbHomeLanguage
            // 
            this.cmbHomeLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHomeLanguage.FormattingEnabled = true;
            this.cmbHomeLanguage.Items.AddRange(new object[] {
            "Afrikaans HL",
            "English HL",
            "isiNdebele HL",
            "isiXhosa HL",
            "isiZulu HL",
            "Sepedi HL",
            "Sesotho HL",
            "Setswana HL",
            "SiSwati HL",
            "Tshivenda HL",
            "Xitsonga HL"});
            this.cmbHomeLanguage.Location = new System.Drawing.Point(207, 62);
            this.cmbHomeLanguage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbHomeLanguage.Name = "cmbHomeLanguage";
            this.cmbHomeLanguage.Size = new System.Drawing.Size(148, 28);
            this.cmbHomeLanguage.TabIndex = 23;
            // 
            // lblMark
            // 
            this.lblMark.AutoSize = true;
            this.lblMark.Location = new System.Drawing.Point(393, 25);
            this.lblMark.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMark.Name = "lblMark";
            this.lblMark.Size = new System.Drawing.Size(44, 20);
            this.lblMark.TabIndex = 22;
            this.lblMark.Text = "Mark";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(248, 25);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(63, 20);
            this.lblSubject.TabIndex = 21;
            this.lblSubject.Text = "Subject";
            // 
            // lblSubject3
            // 
            this.lblSubject3.AutoSize = true;
            this.lblSubject3.Location = new System.Drawing.Point(9, 320);
            this.lblSubject3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubject3.Name = "lblSubject3";
            this.lblSubject3.Size = new System.Drawing.Size(72, 20);
            this.lblSubject3.TabIndex = 20;
            this.lblSubject3.Text = "Subject3";
            // 
            // lblSubject2
            // 
            this.lblSubject2.AutoSize = true;
            this.lblSubject2.Location = new System.Drawing.Point(9, 278);
            this.lblSubject2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubject2.Name = "lblSubject2";
            this.lblSubject2.Size = new System.Drawing.Size(72, 20);
            this.lblSubject2.TabIndex = 19;
            this.lblSubject2.Text = "Subject2";
            // 
            // lblSubject1
            // 
            this.lblSubject1.AutoSize = true;
            this.lblSubject1.Location = new System.Drawing.Point(9, 240);
            this.lblSubject1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubject1.Name = "lblSubject1";
            this.lblSubject1.Size = new System.Drawing.Size(72, 20);
            this.lblSubject1.TabIndex = 18;
            this.lblSubject1.Text = "Subject1";
            // 
            // lblLO
            // 
            this.lblLO.AutoSize = true;
            this.lblLO.Location = new System.Drawing.Point(9, 200);
            this.lblLO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLO.Name = "lblLO";
            this.lblLO.Size = new System.Drawing.Size(117, 20);
            this.lblLO.TabIndex = 17;
            this.lblLO.Text = "Life Orientation";
            // 
            // lblMaths
            // 
            this.lblMaths.AutoSize = true;
            this.lblMaths.Location = new System.Drawing.Point(9, 160);
            this.lblMaths.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaths.Name = "lblMaths";
            this.lblMaths.Size = new System.Drawing.Size(53, 20);
            this.lblMaths.TabIndex = 16;
            this.lblMaths.Text = "Maths";
            // 
            // lblFAL
            // 
            this.lblFAL.AutoSize = true;
            this.lblFAL.Location = new System.Drawing.Point(9, 114);
            this.lblFAL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFAL.Name = "lblFAL";
            this.lblFAL.Size = new System.Drawing.Size(190, 20);
            this.lblFAL.TabIndex = 15;
            this.lblFAL.Text = "First Additional Language";
            // 
            // lblHL
            // 
            this.lblHL.AutoSize = true;
            this.lblHL.Location = new System.Drawing.Point(9, 68);
            this.lblHL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHL.Name = "lblHL";
            this.lblHL.Size = new System.Drawing.Size(128, 20);
            this.lblHL.TabIndex = 14;
            this.lblHL.Text = "Home Language";
            // 
            // txtMark3
            // 
            this.txtMark3.Location = new System.Drawing.Point(387, 315);
            this.txtMark3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMark3.Name = "txtMark3";
            this.txtMark3.Size = new System.Drawing.Size(50, 26);
            this.txtMark3.TabIndex = 13;
            // 
            // txtMark2
            // 
            this.txtMark2.Location = new System.Drawing.Point(387, 275);
            this.txtMark2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMark2.Name = "txtMark2";
            this.txtMark2.Size = new System.Drawing.Size(50, 26);
            this.txtMark2.TabIndex = 12;
            // 
            // txtMark1
            // 
            this.txtMark1.Location = new System.Drawing.Point(387, 235);
            this.txtMark1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMark1.Name = "txtMark1";
            this.txtMark1.Size = new System.Drawing.Size(50, 26);
            this.txtMark1.TabIndex = 11;
            // 
            // txtMarkLO
            // 
            this.txtMarkLO.Location = new System.Drawing.Point(387, 195);
            this.txtMarkLO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMarkLO.Name = "txtMarkLO";
            this.txtMarkLO.Size = new System.Drawing.Size(50, 26);
            this.txtMarkLO.TabIndex = 10;
            // 
            // txtMarkMaths
            // 
            this.txtMarkMaths.Location = new System.Drawing.Point(387, 155);
            this.txtMarkMaths.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMarkMaths.Name = "txtMarkMaths";
            this.txtMarkMaths.Size = new System.Drawing.Size(50, 26);
            this.txtMarkMaths.TabIndex = 9;
            // 
            // txtMarkFAL
            // 
            this.txtMarkFAL.Location = new System.Drawing.Point(387, 109);
            this.txtMarkFAL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMarkFAL.Name = "txtMarkFAL";
            this.txtMarkFAL.Size = new System.Drawing.Size(50, 26);
            this.txtMarkFAL.TabIndex = 8;
            // 
            // txtMarkHL
            // 
            this.txtMarkHL.Location = new System.Drawing.Point(387, 63);
            this.txtMarkHL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMarkHL.Name = "txtMarkHL";
            this.txtMarkHL.Size = new System.Drawing.Size(50, 26);
            this.txtMarkHL.TabIndex = 7;
            // 
            // txtLO
            // 
            this.txtLO.Location = new System.Drawing.Point(207, 195);
            this.txtLO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLO.Name = "txtLO";
            this.txtLO.ReadOnly = true;
            this.txtLO.Size = new System.Drawing.Size(148, 26);
            this.txtLO.TabIndex = 3;
            this.txtLO.Text = "Life Orientation";
            // 
            // FuturePathTabControl
            // 
            this.FuturePathTabControl.Controls.Add(this.tabRoleSelection);
            this.FuturePathTabControl.Controls.Add(this.tabLearnerInfo);
            this.FuturePathTabControl.Controls.Add(this.tabQuestionnaire);
            this.FuturePathTabControl.Location = new System.Drawing.Point(18, 18);
            this.FuturePathTabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FuturePathTabControl.Name = "FuturePathTabControl";
            this.FuturePathTabControl.SelectedIndex = 0;
            this.FuturePathTabControl.Size = new System.Drawing.Size(1167, 777);
            this.FuturePathTabControl.TabIndex = 6;
            this.FuturePathTabControl.SelectedIndexChanged += new System.EventHandler(this.FuturePathTabControl_SelectedIndexChanged);
            // 
            // tabRoleSelection
            // 
            this.tabRoleSelection.Controls.Add(this.btnLogin);
            this.tabRoleSelection.Controls.Add(this.lblAccess);
            this.tabRoleSelection.Controls.Add(this.radLearner);
            this.tabRoleSelection.Controls.Add(this.radCareerAdvisor);
            this.tabRoleSelection.Controls.Add(this.radAdministrator);
            this.tabRoleSelection.Location = new System.Drawing.Point(4, 29);
            this.tabRoleSelection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabRoleSelection.Name = "tabRoleSelection";
            this.tabRoleSelection.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabRoleSelection.Size = new System.Drawing.Size(1147, 744);
            this.tabRoleSelection.TabIndex = 0;
            this.tabRoleSelection.Text = "Role Selection";
            this.tabRoleSelection.UseVisualStyleBackColor = true;
            this.tabRoleSelection.Click += new System.EventHandler(this.tabRoleSelection_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(430, 492);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(112, 35);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblAccess
            // 
            this.lblAccess.AutoSize = true;
            this.lblAccess.Location = new System.Drawing.Point(321, 100);
            this.lblAccess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAccess.Name = "lblAccess";
            this.lblAccess.Size = new System.Drawing.Size(304, 20);
            this.lblAccess.TabIndex = 3;
            this.lblAccess.Text = "How would you like to access the system?";
            // 
            // tabLearnerInfo
            // 
            this.tabLearnerInfo.Controls.Add(this.btnClear);
            this.tabLearnerInfo.Controls.Add(this.btnSubmit);
            this.tabLearnerInfo.Controls.Add(this.grpFaculty);
            this.tabLearnerInfo.Controls.Add(this.grpLearnerInfo);
            this.tabLearnerInfo.Controls.Add(this.grpSubjects);
            this.tabLearnerInfo.Location = new System.Drawing.Point(4, 29);
            this.tabLearnerInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabLearnerInfo.Name = "tabLearnerInfo";
            this.tabLearnerInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabLearnerInfo.Size = new System.Drawing.Size(1147, 744);
            this.tabLearnerInfo.TabIndex = 1;
            this.tabLearnerInfo.Text = "Learner Information";
            this.tabLearnerInfo.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(621, 629);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(112, 35);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(288, 629);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(112, 35);
            this.btnSubmit.TabIndex = 16;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // grpFaculty
            // 
            this.grpFaculty.Controls.Add(this.cmbQualification);
            this.grpFaculty.Controls.Add(this.lblQualification);
            this.grpFaculty.Controls.Add(this.cmbFaculty);
            this.grpFaculty.Controls.Add(this.lblFaculty);
            this.grpFaculty.Location = new System.Drawing.Point(250, 426);
            this.grpFaculty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpFaculty.Name = "grpFaculty";
            this.grpFaculty.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpFaculty.Size = new System.Drawing.Size(568, 165);
            this.grpFaculty.TabIndex = 15;
            this.grpFaculty.TabStop = false;
            this.grpFaculty.Text = "Faculty && Qualification";
            // 
            // cmbQualification
            // 
            this.cmbQualification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQualification.FormattingEnabled = true;
            this.cmbQualification.Items.AddRange(new object[] {
            "Bachelor of Business Science (BBusSci) and Bachelor of Commerce (BCom) - All stre" +
                "ams except Acturial Science (ActSci), Computer Science (ComSci), Statistics & Da" +
                "ta Science",
            "BBusSci and Bcom - ONLY ComSci and Statistics & Data Science",
            "BBusSci and BCom - ONLY ActSci and Quantitative Finance",
            "BSc Engineering (Civil Engineering)",
            "Bsc Engineering (Electrical, Electrical & Computer, Mechatronics)",
            "BSc Construction Studies",
            "BSc Property Studies",
            "BSc Architectural Studies",
            "BSc Engineering (Chemical Engineering)",
            "BSc Engineering (Mechanical, Mechanical & Mechatronic Engineering)",
            "BSc Geomatics",
            "Bachelor of Medicine and Bachelor of Surgery (MBChB)",
            "BSc in Physiotherapy",
            "BSc in Occupational Therapy",
            "BSc in Audiology",
            "BSc in Speech-Language Pathology",
            "Bachelor of Arts (BA) and Bachelor of Social Science (BSocSci)",
            "BA in Fine Art",
            "BSocSci in Philosophy, Politics and Economics (PPE)",
            "BA in Theatre and Performance",
            "Bachelor of Social Work (BSW)",
            "Bachelor of Music (BMus)",
            "Bachelor of Laws (LLB)",
            "Bachelor of Sciences (majors to be picked later)",
            "NOT SURE YET"});
            this.cmbQualification.Location = new System.Drawing.Point(339, 98);
            this.cmbQualification.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbQualification.Name = "cmbQualification";
            this.cmbQualification.Size = new System.Drawing.Size(148, 28);
            this.cmbQualification.TabIndex = 16;
            // 
            // lblQualification
            // 
            this.lblQualification.AutoSize = true;
            this.lblQualification.Location = new System.Drawing.Point(9, 103);
            this.lblQualification.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQualification.Name = "lblQualification";
            this.lblQualification.Size = new System.Drawing.Size(285, 20);
            this.lblQualification.TabIndex = 15;
            this.lblQualification.Text = "Select Preferred Qualification (optional)";
            // 
            // cmbFaculty
            // 
            this.cmbFaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFaculty.FormattingEnabled = true;
            this.cmbFaculty.Items.AddRange(new object[] {
            "Commerce",
            "Engineering",
            "Health Sciences",
            "Humanities",
            "Law",
            "Science"});
            this.cmbFaculty.Location = new System.Drawing.Point(339, 35);
            this.cmbFaculty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbFaculty.Name = "cmbFaculty";
            this.cmbFaculty.Size = new System.Drawing.Size(148, 28);
            this.cmbFaculty.TabIndex = 14;
            // 
            // lblFaculty
            // 
            this.lblFaculty.AutoSize = true;
            this.lblFaculty.Location = new System.Drawing.Point(9, 40);
            this.lblFaculty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFaculty.Name = "lblFaculty";
            this.lblFaculty.Size = new System.Drawing.Size(179, 20);
            this.lblFaculty.TabIndex = 7;
            this.lblFaculty.Text = "Select Preferred Faculty";
            // 
            // grpLearnerInfo
            // 
            this.grpLearnerInfo.Controls.Add(this.txtEmail);
            this.grpLearnerInfo.Controls.Add(this.lblEmail);
            this.grpLearnerInfo.Controls.Add(this.lblLearnerName);
            this.grpLearnerInfo.Controls.Add(this.cmbProvince);
            this.grpLearnerInfo.Controls.Add(this.txtLearnerName);
            this.grpLearnerInfo.Controls.Add(this.lblProvince);
            this.grpLearnerInfo.Controls.Add(this.lblLearnerSurname);
            this.grpLearnerInfo.Controls.Add(this.txtSchool);
            this.grpLearnerInfo.Controls.Add(this.txtLearnerSurname);
            this.grpLearnerInfo.Controls.Add(this.lblSchool);
            this.grpLearnerInfo.Controls.Add(this.lblGrade);
            this.grpLearnerInfo.Controls.Add(this.cmbGrade);
            this.grpLearnerInfo.Location = new System.Drawing.Point(63, 29);
            this.grpLearnerInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpLearnerInfo.Name = "grpLearnerInfo";
            this.grpLearnerInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpLearnerInfo.Size = new System.Drawing.Size(348, 388);
            this.grpLearnerInfo.TabIndex = 14;
            this.grpLearnerInfo.TabStop = false;
            this.grpLearnerInfo.Text = "Learner Information";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(188, 329);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(148, 26);
            this.txtEmail.TabIndex = 15;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(3, 334);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(184, 40);
            this.lblEmail.TabIndex = 14;
            this.lblEmail.Text = "Enter your email address\r\n(optional)";
            // 
            // lblLearnerName
            // 
            this.lblLearnerName.AutoSize = true;
            this.lblLearnerName.Location = new System.Drawing.Point(3, 40);
            this.lblLearnerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLearnerName.Name = "lblLearnerName";
            this.lblLearnerName.Size = new System.Drawing.Size(156, 20);
            this.lblLearnerName.TabIndex = 6;
            this.lblLearnerName.Text = "Enter your first name";
            // 
            // cmbProvince
            // 
            this.cmbProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvince.FormattingEnabled = true;
            this.cmbProvince.Items.AddRange(new object[] {
            "Eastern Cape",
            "Free State",
            "Gauteng",
            "KwaZulu-Natal",
            "Limpopo",
            "Mpumalanga",
            "Northern Cape",
            "North West",
            "Western Cape"});
            this.cmbProvince.Location = new System.Drawing.Point(189, 271);
            this.cmbProvince.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbProvince.Name = "cmbProvince";
            this.cmbProvince.Size = new System.Drawing.Size(148, 28);
            this.cmbProvince.TabIndex = 13;
            // 
            // txtLearnerName
            // 
            this.txtLearnerName.Location = new System.Drawing.Point(188, 35);
            this.txtLearnerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLearnerName.Name = "txtLearnerName";
            this.txtLearnerName.Size = new System.Drawing.Size(148, 26);
            this.txtLearnerName.TabIndex = 7;
            // 
            // lblProvince
            // 
            this.lblProvince.AutoSize = true;
            this.lblProvince.Location = new System.Drawing.Point(3, 275);
            this.lblProvince.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(151, 20);
            this.lblProvince.TabIndex = 12;
            this.lblProvince.Text = "Select your province";
            // 
            // lblLearnerSurname
            // 
            this.lblLearnerSurname.AutoSize = true;
            this.lblLearnerSurname.Location = new System.Drawing.Point(4, 97);
            this.lblLearnerSurname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLearnerSurname.Name = "lblLearnerSurname";
            this.lblLearnerSurname.Size = new System.Drawing.Size(155, 20);
            this.lblLearnerSurname.TabIndex = 8;
            this.lblLearnerSurname.Text = "Enter your last name";
            // 
            // txtSchool
            // 
            this.txtSchool.Location = new System.Drawing.Point(189, 209);
            this.txtSchool.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSchool.Name = "txtSchool";
            this.txtSchool.Size = new System.Drawing.Size(148, 26);
            this.txtSchool.TabIndex = 11;
            // 
            // txtLearnerSurname
            // 
            this.txtLearnerSurname.Location = new System.Drawing.Point(189, 92);
            this.txtLearnerSurname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLearnerSurname.Name = "txtLearnerSurname";
            this.txtLearnerSurname.Size = new System.Drawing.Size(148, 26);
            this.txtLearnerSurname.TabIndex = 9;
            // 
            // lblSchool
            // 
            this.lblSchool.AutoSize = true;
            this.lblSchool.Location = new System.Drawing.Point(3, 214);
            this.lblSchool.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSchool.Name = "lblSchool";
            this.lblSchool.Size = new System.Drawing.Size(176, 20);
            this.lblSchool.TabIndex = 10;
            this.lblSchool.Text = "Enter your school name";
            // 
            // tabQuestionnaire
            // 
            this.tabQuestionnaire.Controls.Add(this.btnSubmitQuestions);
            this.tabQuestionnaire.Controls.Add(this.flowQuestions);
            this.tabQuestionnaire.Location = new System.Drawing.Point(4, 29);
            this.tabQuestionnaire.Name = "tabQuestionnaire";
            this.tabQuestionnaire.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuestionnaire.Size = new System.Drawing.Size(1159, 744);
            this.tabQuestionnaire.TabIndex = 2;
            this.tabQuestionnaire.Text = "Interest Questionnaire";
            this.tabQuestionnaire.UseVisualStyleBackColor = true;
            // 
            // flowQuestions
            // 
            this.flowQuestions.AutoScroll = true;
            this.flowQuestions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowQuestions.Location = new System.Drawing.Point(3, 3);
            this.flowQuestions.Name = "flowQuestions";
            this.flowQuestions.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.flowQuestions.Size = new System.Drawing.Size(1153, 738);
            this.flowQuestions.TabIndex = 0;
            // 
            // btnSubmitQuestions
            // 
            this.btnSubmitQuestions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSubmitQuestions.Location = new System.Drawing.Point(3, 696);
            this.btnSubmitQuestions.Name = "btnSubmitQuestions";
            this.btnSubmitQuestions.Size = new System.Drawing.Size(1153, 45);
            this.btnSubmitQuestions.TabIndex = 2;
            this.btnSubmitQuestions.Text = "Submit Questionnaire";
            this.btnSubmitQuestions.UseVisualStyleBackColor = true;
            this.btnSubmitQuestions.Click += new System.EventHandler(this.btnSubmitQuestions_Click);
            // 
            // FuturePathForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1191, 814);
            this.Controls.Add(this.FuturePathTabControl);
            this.Name = "FuturePathForm";
            this.Text = "Future Path Learner System";
            this.Load += new System.EventHandler(this.FuturePathForm_Load);
            this.grpSubjects.ResumeLayout(false);
            this.grpSubjects.PerformLayout();
            this.FuturePathTabControl.ResumeLayout(false);
            this.tabRoleSelection.ResumeLayout(false);
            this.tabRoleSelection.PerformLayout();
            this.tabLearnerInfo.ResumeLayout(false);
            this.grpFaculty.ResumeLayout(false);
            this.grpFaculty.PerformLayout();
            this.grpLearnerInfo.ResumeLayout(false);
            this.grpLearnerInfo.PerformLayout();
            this.tabQuestionnaire.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radLearner;
        private System.Windows.Forms.RadioButton radCareerAdvisor;
        private System.Windows.Forms.RadioButton radAdministrator;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.ComboBox cmbGrade;
        private System.Windows.Forms.GroupBox grpSubjects;
        private System.Windows.Forms.TextBox txtMark3;
        private System.Windows.Forms.TextBox txtMark2;
        private System.Windows.Forms.TextBox txtMark1;
        private System.Windows.Forms.TextBox txtMarkLO;
        private System.Windows.Forms.TextBox txtMarkMaths;
        private System.Windows.Forms.TextBox txtMarkFAL;
        private System.Windows.Forms.TextBox txtMarkHL;
        private System.Windows.Forms.TextBox txtLO;
        private System.Windows.Forms.TabControl FuturePathTabControl;
        private System.Windows.Forms.TabPage tabRoleSelection;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblAccess;
        private System.Windows.Forms.TabPage tabLearnerInfo;
        private System.Windows.Forms.TextBox txtLearnerSurname;
        private System.Windows.Forms.Label lblLearnerSurname;
        private System.Windows.Forms.TextBox txtLearnerName;
        private System.Windows.Forms.Label lblLearnerName;
        private System.Windows.Forms.Label lblSchool;
        private System.Windows.Forms.ComboBox cmbProvince;
        private System.Windows.Forms.Label lblProvince;
        private System.Windows.Forms.TextBox txtSchool;
        private System.Windows.Forms.GroupBox grpLearnerInfo;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblLO;
        private System.Windows.Forms.Label lblMaths;
        private System.Windows.Forms.Label lblFAL;
        private System.Windows.Forms.Label lblHL;
        private System.Windows.Forms.Label lblMark;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblSubject3;
        private System.Windows.Forms.Label lblSubject2;
        private System.Windows.Forms.Label lblSubject1;
        private System.Windows.Forms.ComboBox cmbHomeLanguage;
        private System.Windows.Forms.ComboBox cmbFAL;
        private System.Windows.Forms.ComboBox cmbMaths;
        private System.Windows.Forms.ComboBox cmbSubject1;
        private System.Windows.Forms.ComboBox cmbSubject2;
        private System.Windows.Forms.ComboBox cmbSubject3;
        private System.Windows.Forms.GroupBox grpFaculty;
        private System.Windows.Forms.Label lblQualification;
        private System.Windows.Forms.ComboBox cmbFaculty;
        private System.Windows.Forms.Label lblFaculty;
        private System.Windows.Forms.ComboBox cmbQualification;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TabPage tabQuestionnaire;
        private System.Windows.Forms.FlowLayoutPanel flowQuestions;
        private System.Windows.Forms.Button btnSubmitQuestions;
    }
}

