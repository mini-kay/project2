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
            this.grpSubjects.SuspendLayout();
            this.FuturePathTabControl.SuspendLayout();
            this.tabRoleSelection.SuspendLayout();
            this.tabLearnerInfo.SuspendLayout();
            this.grpFaculty.SuspendLayout();
            this.grpLearnerInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // radLearner
            // 
            this.radLearner.AutoSize = true;
            this.radLearner.Checked = true;
            this.radLearner.Location = new System.Drawing.Point(38, 187);
            this.radLearner.Name = "radLearner";
            this.radLearner.Size = new System.Drawing.Size(61, 17);
            this.radLearner.TabIndex = 0;
            this.radLearner.TabStop = true;
            this.radLearner.Text = "Learner";
            this.radLearner.UseVisualStyleBackColor = true;
            // 
            // radCareerAdvisor
            // 
            this.radCareerAdvisor.AutoSize = true;
            this.radCareerAdvisor.Location = new System.Drawing.Point(287, 187);
            this.radCareerAdvisor.Name = "radCareerAdvisor";
            this.radCareerAdvisor.Size = new System.Drawing.Size(94, 17);
            this.radCareerAdvisor.TabIndex = 1;
            this.radCareerAdvisor.Text = "Career Advisor";
            this.radCareerAdvisor.UseVisualStyleBackColor = true;
            // 
            // radAdministrator
            // 
            this.radAdministrator.AutoSize = true;
            this.radAdministrator.Location = new System.Drawing.Point(582, 187);
            this.radAdministrator.Name = "radAdministrator";
            this.radAdministrator.Size = new System.Drawing.Size(85, 17);
            this.radAdministrator.TabIndex = 2;
            this.radAdministrator.Text = "Administrator";
            this.radAdministrator.UseVisualStyleBackColor = true;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Location = new System.Drawing.Point(4, 101);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(90, 13);
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
            this.cmbGrade.Location = new System.Drawing.Point(126, 98);
            this.cmbGrade.Name = "cmbGrade";
            this.cmbGrade.Size = new System.Drawing.Size(100, 21);
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
            this.grpSubjects.Location = new System.Drawing.Point(323, 19);
            this.grpSubjects.Name = "grpSubjects";
            this.grpSubjects.Size = new System.Drawing.Size(299, 252);
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
            this.cmbSubject3.Location = new System.Drawing.Point(138, 205);
            this.cmbSubject3.Name = "cmbSubject3";
            this.cmbSubject3.Size = new System.Drawing.Size(100, 21);
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
            this.cmbSubject2.Location = new System.Drawing.Point(138, 178);
            this.cmbSubject2.Name = "cmbSubject2";
            this.cmbSubject2.Size = new System.Drawing.Size(100, 21);
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
            this.cmbSubject1.Location = new System.Drawing.Point(138, 153);
            this.cmbSubject1.Name = "cmbSubject1";
            this.cmbSubject1.Size = new System.Drawing.Size(100, 21);
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
            this.cmbMaths.Location = new System.Drawing.Point(138, 101);
            this.cmbMaths.Name = "cmbMaths";
            this.cmbMaths.Size = new System.Drawing.Size(100, 21);
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
            this.cmbFAL.Location = new System.Drawing.Point(138, 71);
            this.cmbFAL.Name = "cmbFAL";
            this.cmbFAL.Size = new System.Drawing.Size(100, 21);
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
            this.cmbHomeLanguage.Location = new System.Drawing.Point(138, 40);
            this.cmbHomeLanguage.Name = "cmbHomeLanguage";
            this.cmbHomeLanguage.Size = new System.Drawing.Size(100, 21);
            this.cmbHomeLanguage.TabIndex = 23;
            // 
            // lblMark
            // 
            this.lblMark.AutoSize = true;
            this.lblMark.Location = new System.Drawing.Point(262, 16);
            this.lblMark.Name = "lblMark";
            this.lblMark.Size = new System.Drawing.Size(31, 13);
            this.lblMark.TabIndex = 22;
            this.lblMark.Text = "Mark";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(165, 16);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(43, 13);
            this.lblSubject.TabIndex = 21;
            this.lblSubject.Text = "Subject";
            // 
            // lblSubject3
            // 
            this.lblSubject3.AutoSize = true;
            this.lblSubject3.Location = new System.Drawing.Point(6, 208);
            this.lblSubject3.Name = "lblSubject3";
            this.lblSubject3.Size = new System.Drawing.Size(49, 13);
            this.lblSubject3.TabIndex = 20;
            this.lblSubject3.Text = "Subject3";
            // 
            // lblSubject2
            // 
            this.lblSubject2.AutoSize = true;
            this.lblSubject2.Location = new System.Drawing.Point(6, 181);
            this.lblSubject2.Name = "lblSubject2";
            this.lblSubject2.Size = new System.Drawing.Size(49, 13);
            this.lblSubject2.TabIndex = 19;
            this.lblSubject2.Text = "Subject2";
            // 
            // lblSubject1
            // 
            this.lblSubject1.AutoSize = true;
            this.lblSubject1.Location = new System.Drawing.Point(6, 156);
            this.lblSubject1.Name = "lblSubject1";
            this.lblSubject1.Size = new System.Drawing.Size(49, 13);
            this.lblSubject1.TabIndex = 18;
            this.lblSubject1.Text = "Subject1";
            // 
            // lblLO
            // 
            this.lblLO.AutoSize = true;
            this.lblLO.Location = new System.Drawing.Point(6, 130);
            this.lblLO.Name = "lblLO";
            this.lblLO.Size = new System.Drawing.Size(78, 13);
            this.lblLO.TabIndex = 17;
            this.lblLO.Text = "Life Orientation";
            // 
            // lblMaths
            // 
            this.lblMaths.AutoSize = true;
            this.lblMaths.Location = new System.Drawing.Point(6, 104);
            this.lblMaths.Name = "lblMaths";
            this.lblMaths.Size = new System.Drawing.Size(36, 13);
            this.lblMaths.TabIndex = 16;
            this.lblMaths.Text = "Maths";
            // 
            // lblFAL
            // 
            this.lblFAL.AutoSize = true;
            this.lblFAL.Location = new System.Drawing.Point(6, 74);
            this.lblFAL.Name = "lblFAL";
            this.lblFAL.Size = new System.Drawing.Size(126, 13);
            this.lblFAL.TabIndex = 15;
            this.lblFAL.Text = "First Additional Language";
            // 
            // lblHL
            // 
            this.lblHL.AutoSize = true;
            this.lblHL.Location = new System.Drawing.Point(6, 44);
            this.lblHL.Name = "lblHL";
            this.lblHL.Size = new System.Drawing.Size(86, 13);
            this.lblHL.TabIndex = 14;
            this.lblHL.Text = "Home Language";
            // 
            // txtMark3
            // 
            this.txtMark3.Location = new System.Drawing.Point(258, 205);
            this.txtMark3.Name = "txtMark3";
            this.txtMark3.Size = new System.Drawing.Size(35, 20);
            this.txtMark3.TabIndex = 13;
            // 
            // txtMark2
            // 
            this.txtMark2.Location = new System.Drawing.Point(258, 179);
            this.txtMark2.Name = "txtMark2";
            this.txtMark2.Size = new System.Drawing.Size(35, 20);
            this.txtMark2.TabIndex = 12;
            // 
            // txtMark1
            // 
            this.txtMark1.Location = new System.Drawing.Point(258, 153);
            this.txtMark1.Name = "txtMark1";
            this.txtMark1.Size = new System.Drawing.Size(35, 20);
            this.txtMark1.TabIndex = 11;
            // 
            // txtMarkLO
            // 
            this.txtMarkLO.Location = new System.Drawing.Point(258, 127);
            this.txtMarkLO.Name = "txtMarkLO";
            this.txtMarkLO.Size = new System.Drawing.Size(35, 20);
            this.txtMarkLO.TabIndex = 10;
            // 
            // txtMarkMaths
            // 
            this.txtMarkMaths.Location = new System.Drawing.Point(258, 101);
            this.txtMarkMaths.Name = "txtMarkMaths";
            this.txtMarkMaths.Size = new System.Drawing.Size(35, 20);
            this.txtMarkMaths.TabIndex = 9;
            // 
            // txtMarkFAL
            // 
            this.txtMarkFAL.Location = new System.Drawing.Point(258, 71);
            this.txtMarkFAL.Name = "txtMarkFAL";
            this.txtMarkFAL.Size = new System.Drawing.Size(35, 20);
            this.txtMarkFAL.TabIndex = 8;
            // 
            // txtMarkHL
            // 
            this.txtMarkHL.Location = new System.Drawing.Point(258, 41);
            this.txtMarkHL.Name = "txtMarkHL";
            this.txtMarkHL.Size = new System.Drawing.Size(35, 20);
            this.txtMarkHL.TabIndex = 7;
            // 
            // txtLO
            // 
            this.txtLO.Location = new System.Drawing.Point(138, 127);
            this.txtLO.Name = "txtLO";
            this.txtLO.ReadOnly = true;
            this.txtLO.Size = new System.Drawing.Size(100, 20);
            this.txtLO.TabIndex = 3;
            this.txtLO.Text = "Life Orientation";
            // 
            // FuturePathTabControl
            // 
            this.FuturePathTabControl.Controls.Add(this.tabRoleSelection);
            this.FuturePathTabControl.Controls.Add(this.tabLearnerInfo);
            this.FuturePathTabControl.Location = new System.Drawing.Point(12, 12);
            this.FuturePathTabControl.Name = "FuturePathTabControl";
            this.FuturePathTabControl.SelectedIndex = 0;
            this.FuturePathTabControl.Size = new System.Drawing.Size(770, 505);
            this.FuturePathTabControl.TabIndex = 6;
            // 
            // tabRoleSelection
            // 
            this.tabRoleSelection.Controls.Add(this.btnLogin);
            this.tabRoleSelection.Controls.Add(this.lblAccess);
            this.tabRoleSelection.Controls.Add(this.radLearner);
            this.tabRoleSelection.Controls.Add(this.radCareerAdvisor);
            this.tabRoleSelection.Controls.Add(this.radAdministrator);
            this.tabRoleSelection.Location = new System.Drawing.Point(4, 22);
            this.tabRoleSelection.Name = "tabRoleSelection";
            this.tabRoleSelection.Padding = new System.Windows.Forms.Padding(3);
            this.tabRoleSelection.Size = new System.Drawing.Size(762, 479);
            this.tabRoleSelection.TabIndex = 0;
            this.tabRoleSelection.Text = "Role Selection";
            this.tabRoleSelection.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(287, 320);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // lblAccess
            // 
            this.lblAccess.AutoSize = true;
            this.lblAccess.Location = new System.Drawing.Point(214, 65);
            this.lblAccess.Name = "lblAccess";
            this.lblAccess.Size = new System.Drawing.Size(207, 13);
            this.lblAccess.TabIndex = 3;
            this.lblAccess.Text = "How would you like to access the system?";
            // 
            // tabLearnerInfo
            // 
            this.tabLearnerInfo.Controls.Add(this.grpFaculty);
            this.tabLearnerInfo.Controls.Add(this.grpLearnerInfo);
            this.tabLearnerInfo.Controls.Add(this.grpSubjects);
            this.tabLearnerInfo.Location = new System.Drawing.Point(4, 22);
            this.tabLearnerInfo.Name = "tabLearnerInfo";
            this.tabLearnerInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabLearnerInfo.Size = new System.Drawing.Size(762, 479);
            this.tabLearnerInfo.TabIndex = 1;
            this.tabLearnerInfo.Text = "Learner Information";
            this.tabLearnerInfo.UseVisualStyleBackColor = true;
            // 
            // grpFaculty
            // 
            this.grpFaculty.Controls.Add(this.cmbQualification);
            this.grpFaculty.Controls.Add(this.lblQualification);
            this.grpFaculty.Controls.Add(this.cmbFaculty);
            this.grpFaculty.Controls.Add(this.lblFaculty);
            this.grpFaculty.Location = new System.Drawing.Point(23, 314);
            this.grpFaculty.Name = "grpFaculty";
            this.grpFaculty.Size = new System.Drawing.Size(462, 145);
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
            this.cmbQualification.Location = new System.Drawing.Point(226, 64);
            this.cmbQualification.Name = "cmbQualification";
            this.cmbQualification.Size = new System.Drawing.Size(100, 21);
            this.cmbQualification.TabIndex = 16;
            // 
            // lblQualification
            // 
            this.lblQualification.AutoSize = true;
            this.lblQualification.Location = new System.Drawing.Point(6, 67);
            this.lblQualification.Name = "lblQualification";
            this.lblQualification.Size = new System.Drawing.Size(190, 13);
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
            this.cmbFaculty.Location = new System.Drawing.Point(226, 23);
            this.cmbFaculty.Name = "cmbFaculty";
            this.cmbFaculty.Size = new System.Drawing.Size(100, 21);
            this.cmbFaculty.TabIndex = 14;
            // 
            // lblFaculty
            // 
            this.lblFaculty.AutoSize = true;
            this.lblFaculty.Location = new System.Drawing.Point(6, 26);
            this.lblFaculty.Name = "lblFaculty";
            this.lblFaculty.Size = new System.Drawing.Size(120, 13);
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
            this.grpLearnerInfo.Location = new System.Drawing.Point(23, 19);
            this.grpLearnerInfo.Name = "grpLearnerInfo";
            this.grpLearnerInfo.Size = new System.Drawing.Size(232, 252);
            this.grpLearnerInfo.TabIndex = 14;
            this.grpLearnerInfo.TabStop = false;
            this.grpLearnerInfo.Text = "Learner Information";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(125, 214);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 15;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(2, 217);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(122, 26);
            this.lblEmail.TabIndex = 14;
            this.lblEmail.Text = "Enter your email address\r\n(optional)";
            // 
            // lblLearnerName
            // 
            this.lblLearnerName.AutoSize = true;
            this.lblLearnerName.Location = new System.Drawing.Point(2, 26);
            this.lblLearnerName.Name = "lblLearnerName";
            this.lblLearnerName.Size = new System.Drawing.Size(103, 13);
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
            this.cmbProvince.Location = new System.Drawing.Point(126, 176);
            this.cmbProvince.Name = "cmbProvince";
            this.cmbProvince.Size = new System.Drawing.Size(100, 21);
            this.cmbProvince.TabIndex = 13;
            // 
            // txtLearnerName
            // 
            this.txtLearnerName.Location = new System.Drawing.Point(125, 23);
            this.txtLearnerName.Name = "txtLearnerName";
            this.txtLearnerName.Size = new System.Drawing.Size(100, 20);
            this.txtLearnerName.TabIndex = 7;
            // 
            // lblProvince
            // 
            this.lblProvince.AutoSize = true;
            this.lblProvince.Location = new System.Drawing.Point(2, 179);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(104, 13);
            this.lblProvince.TabIndex = 12;
            this.lblProvince.Text = "Select your province";
            // 
            // lblLearnerSurname
            // 
            this.lblLearnerSurname.AutoSize = true;
            this.lblLearnerSurname.Location = new System.Drawing.Point(3, 63);
            this.lblLearnerSurname.Name = "lblLearnerSurname";
            this.lblLearnerSurname.Size = new System.Drawing.Size(103, 13);
            this.lblLearnerSurname.TabIndex = 8;
            this.lblLearnerSurname.Text = "Enter your last name";
            // 
            // txtSchool
            // 
            this.txtSchool.Location = new System.Drawing.Point(126, 136);
            this.txtSchool.Name = "txtSchool";
            this.txtSchool.Size = new System.Drawing.Size(100, 20);
            this.txtSchool.TabIndex = 11;
            // 
            // txtLearnerSurname
            // 
            this.txtLearnerSurname.Location = new System.Drawing.Point(126, 60);
            this.txtLearnerSurname.Name = "txtLearnerSurname";
            this.txtLearnerSurname.Size = new System.Drawing.Size(100, 20);
            this.txtLearnerSurname.TabIndex = 9;
            // 
            // lblSchool
            // 
            this.lblSchool.AutoSize = true;
            this.lblSchool.Location = new System.Drawing.Point(2, 139);
            this.lblSchool.Name = "lblSchool";
            this.lblSchool.Size = new System.Drawing.Size(118, 13);
            this.lblSchool.TabIndex = 10;
            this.lblSchool.Text = "Enter your school name";
            // 
            // FuturePathForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 529);
            this.Controls.Add(this.FuturePathTabControl);
            this.Margin = new System.Windows.Forms.Padding(2);
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
    }
}

