using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Text;

namespace project2
{
    public partial class Administrator : Form
    {
        private readonly UserAccountDataAccess accountDataAccess;
        // Manage Funding controls
        private TabPage tabManageFunding;
        private DataGridView dgvFunding;
        private TextBox txtFundingName;
        private ComboBox cmbFundingType;
        private TextBox txtEligibility;
        private TextBox txtRequiredDocuments;
        private TextBox txtClosingDate;
        private TextBox txtContactInfo;
        private Button btnAddFunding;
        private Button btnRefreshFunding;
        private Button btnToggleFundingStatus;
        private Button btnBackFunding;
        private TabPage tabManageRequirements;
        private ComboBox cmbDegreeProgramme;
        private DataGridView dgvRequirements;
        private Button btnRefreshRequirements;
        private Button btnBackRequirements;

        // Manage Interest Questionnaire controls
        private TabPage tabManageQuestions;
        private DataGridView dgvQuestions;
        private TextBox txtQuestionText;
        private ComboBox cmbInterestCategory;
        private Button btnAddQuestion;
        private Button btnRefreshQuestions;
        private Button btnToggleQuestionStatus;
        private Button btnBackQuestions;

        private TabPage tabSystemReports;
        private ComboBox cmbReportType;
        private DataGridView dgvSystemReports;
        private Button btnRunReport;
        private Button btnBackReports;

        public Administrator()
        {
            InitializeComponent();

            btnManageDocs.Text = "View Systems Reports";
            btnManageDocs.Click += btnManageDocs_Click;
            BuildReportsScreen();

            BuildQuestionsScreen();
            btnInterestQs.Click += btnInterestQs_Click;
            BuildFundingScreen();
            BuildRequirementsScreen();
            accountDataAccess = new UserAccountDataAccess();

            // Configure the login screen.
            textBox2.UseSystemPasswordChar = true;
            grpboxAdminFunctions.Visible = false;
            tabAdvisorySum.Parent = null;
            btnManageReqs.Click += btnManageReqs_Click;

            // Advisory Summary events
            tabAdvisorySum.Enter += (s, e) => LoadAdvisorySummary();

            btnBack3.Click += (s, e) =>
                tabUserAccounts.SelectedTab = tabPage1;

            btnFinish.Click += (s, e) =>
                tabUserAccounts.SelectedTab = tabPage1;

            btnSave.Click += (s, e) => SaveAdvisorySummary();
            btnExport.Click += (s, e) => SaveAdvisorySummary();
            btnPrint.Click += (s, e) => PrintAdvisorySummary();


            // Connect the buttons to their event handlers.
            btnAdminLogin.Click += btnAdminLogin_Click;
            btnLogOut.Click += btnLogOut_Click;

            // Configure the account-management controls.
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Career Advisor");
            cmbRole.Items.Add("Administrator");
            cmbRole.SelectedIndex = 0;

            txtPassword.UseSystemPasswordChar = true;

            btnManageFunding.Click += btnManageFunding_Click;

            dgvUserAccounts.ReadOnly = true;
            dgvUserAccounts.AllowUserToAddRows = false;
            dgvUserAccounts.AllowUserToDeleteRows = false;
            dgvUserAccounts.MultiSelect = false;
            dgvUserAccounts.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvUserAccounts.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            btnCreateAccount.Click += btnCreateAccount_Click;
            btnToggleStatus.Click += btnToggleStatus_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnClose.Click += btnClose_Click;
            tabUserAccounts.Enter += tabUserAccounts_Enter;
            btnUserAcc.Click += btnUserAcc_Click;
        }

        private void btnInterestQs_Click(object sender, EventArgs e)
        {
            if (!tabUserAccounts.TabPages.Contains(tabManageQuestions))
                tabUserAccounts.TabPages.Add(tabManageQuestions);

            tabUserAccounts.SelectedTab = tabManageQuestions;
            LoadInterestQuestions();
        }
        private void BuildFundingScreen()
        {
            tabManageFunding = new TabPage("Manage Funding");

            Label lblName = new Label
            {
                Text = "Funding Name:",
                Location = new System.Drawing.Point(20, 20),
                AutoSize = true
            };

            txtFundingName = new TextBox
            {
                Location = new System.Drawing.Point(150, 17),
                Width = 220
            };

            Label lblType = new Label
            {
                Text = "Funding Type:",
                Location = new System.Drawing.Point(20, 55),
                AutoSize = true
            };

            cmbFundingType = new ComboBox
            {
                Location = new System.Drawing.Point(150, 52),
                Width = 220,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cmbFundingType.Items.AddRange(new object[]
            {
        "Scholarship",
        "Bursary",
        "Financial Aid",
        "External Funding"
            });
            cmbFundingType.SelectedIndex = 0;

            Label lblEligibility = new Label
            {
                Text = "Eligibility:",
                Location = new System.Drawing.Point(20, 90),
                AutoSize = true
            };

            txtEligibility = new TextBox
            {
                Location = new System.Drawing.Point(150, 87),
                Width = 220
            };

            Label lblDocuments = new Label
            {
                Text = "Required Documents:",
                Location = new System.Drawing.Point(20, 125),
                AutoSize = true
            };

            txtRequiredDocuments = new TextBox
            {
                Location = new System.Drawing.Point(150, 122),
                Width = 220
            };

            Label lblClosingDate = new Label
            {
                Text = "Closing Date:",
                Location = new System.Drawing.Point(20, 160),
                AutoSize = true
            };

            txtClosingDate = new TextBox
            {
                Location = new System.Drawing.Point(150, 157),
                Width = 220
            };

            Label lblContact = new Label
            {
                Text = "Contact Info:",
                Location = new System.Drawing.Point(20, 195),
                AutoSize = true
            };

            txtContactInfo = new TextBox
            {
                Location = new System.Drawing.Point(150, 192),
                Width = 220
            };

            btnAddFunding = new Button
            {
                Text = "Add Funding",
                Location = new System.Drawing.Point(20, 235),
                Size = new System.Drawing.Size(110, 30)
            };

            btnRefreshFunding = new Button
            {
                Text = "Refresh",
                Location = new System.Drawing.Point(140, 235),
                Size = new System.Drawing.Size(90, 30)
            };

            btnToggleFundingStatus = new Button
            {
                Text = "Activate/Deactivate",
                Location = new System.Drawing.Point(240, 235),
                Size = new System.Drawing.Size(130, 30)
            };

            btnBackFunding = new Button
            {
                Text = "Back to Dashboard",
                Location = new System.Drawing.Point(20, 355),
                Size = new System.Drawing.Size(140, 30)
            };

            dgvFunding = new DataGridView
            {
                Location = new System.Drawing.Point(390, 17),
                Size = new System.Drawing.Size(340, 320),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            tabManageFunding.Controls.AddRange(new Control[]
            {
        lblName, txtFundingName,
        lblType, cmbFundingType,
        lblEligibility, txtEligibility,
        lblDocuments, txtRequiredDocuments,
        lblClosingDate, txtClosingDate,
        lblContact, txtContactInfo,
        btnAddFunding, btnRefreshFunding,
        btnToggleFundingStatus, btnBackFunding,
        dgvFunding
            });

            btnAddFunding.Click += btnAddFunding_Click;
            btnRefreshFunding.Click += btnRefreshFunding_Click;
            btnToggleFundingStatus.Click += btnToggleFundingStatus_Click;

            btnBackFunding.Click += (sender, e) =>
            {
                tabUserAccounts.SelectedTab = tabPage1;
            };
        }

        private void btnManageFunding_Click(object sender, EventArgs e)
        {
            if (!tabUserAccounts.TabPages.Contains(tabManageFunding))
                tabUserAccounts.TabPages.Add(tabManageFunding);

            tabUserAccounts.SelectedTab = tabManageFunding;
            LoadFundingOptions();
        }
        private void LoadFundingOptions()
        {
            try
            {
                string connectionString =
                    ConfigurationManager.ConnectionStrings["FuturePathDB"]
                    .ConnectionString;

                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT FundingOptionID, FundingName, FundingType,
                       EligibilityDescription, RequiredDocuments,
                       ClosingDate, ContactInfo, IsActive
                FROM dbo.FundingOption
                ORDER BY FundingName";

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgvFunding.DataSource = table;
                    }
                }

                if (dgvFunding.Columns.Contains("FundingOptionID"))
                    dgvFunding.Columns["FundingOptionID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load funding information: " + ex.Message);
            }
        }

        private void btnRefreshFunding_Click(object sender, EventArgs e)
        {
            LoadFundingOptions();
        }
        private void btnAddFunding_Click(object sender, EventArgs e)
        {
            string name = txtFundingName.Text.Trim();
            string type = cmbFundingType.Text;
            string eligibility = txtEligibility.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(type) ||
                string.IsNullOrWhiteSpace(eligibility))
            {
                MessageBox.Show(
                    "Enter the funding name, type and eligibility description.");
                return;
            }

            string closingDate = txtClosingDate.Text.Trim();

            DateTime parsedClosingDate;

            if (!DateTime.TryParseExact(
                    closingDate.Trim(),
                    "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out parsedClosingDate))
            {
                MessageBox.Show(
                    "Enter the closing date as yyyy-MM-dd, for example 2027-03-15.");
                return;
            }

            try
            {
                string connectionString =
                    ConfigurationManager.ConnectionStrings["FuturePathDB"]
                    .ConnectionString;

                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                INSERT INTO dbo.FundingOption
                (FundingName, FundingType, EligibilityDescription,
                 RequiredDocuments, ClosingDate, ContactInfo, IsActive)
                VALUES
                (@Name, @Type, @Eligibility,
                 @Documents, @ClosingDate, @Contact, 1)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = name;
                        command.Parameters.Add("@Type", SqlDbType.VarChar, 30).Value = type;
                        command.Parameters.Add("@Eligibility", SqlDbType.VarChar, 250).Value = eligibility;

                        command.Parameters.Add("@Documents", SqlDbType.VarChar, 250).Value =
                            string.IsNullOrWhiteSpace(txtRequiredDocuments.Text)
                            ? (object)DBNull.Value : txtRequiredDocuments.Text.Trim();

                        command.Parameters.Add("@ClosingDate", SqlDbType.VarChar, 10).Value =
                            closingDate == "" ? (object)DBNull.Value : closingDate;

                        command.Parameters.Add("@Contact", SqlDbType.VarChar, 150).Value =
                            string.IsNullOrWhiteSpace(txtContactInfo.Text)
                            ? (object)DBNull.Value : txtContactInfo.Text.Trim();

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Funding opportunity added successfully.");

                txtFundingName.Clear();
                txtEligibility.Clear();
                txtRequiredDocuments.Clear();
                txtClosingDate.Clear();
                txtContactInfo.Clear();
                cmbFundingType.SelectedIndex = 0;

                LoadFundingOptions();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Could not add funding. Check whether the name already exists " +
                    "or whether the database rejected the entry.\n\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding funding: " + ex.Message);
            }
        }

        private void btnToggleFundingStatus_Click(object sender, EventArgs e)
        {
            if (dgvFunding.CurrentRow == null)
            {
                MessageBox.Show("Select a funding opportunity first.");
                return;
            }

            int fundingID = Convert.ToInt32(
                dgvFunding.CurrentRow.Cells["FundingOptionID"].Value);

            bool isActive = Convert.ToBoolean(
                dgvFunding.CurrentRow.Cells["IsActive"].Value);

            string fundingName = Convert.ToString(
                dgvFunding.CurrentRow.Cells["FundingName"].Value);

            DialogResult answer = MessageBox.Show(
                "Do you want to " + (isActive ? "deactivate" : "activate") +
                " " + fundingName + "?",
                "Confirm Status Change",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
                return;

            try
            {
                string connectionString =
                    ConfigurationManager.ConnectionStrings["FuturePathDB"]
                    .ConnectionString;

                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                UPDATE dbo.FundingOption
                SET IsActive = @IsActive
                WHERE FundingOptionID = @FundingID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = !isActive;
                        command.Parameters.Add("@FundingID", SqlDbType.Int).Value = fundingID;

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                LoadFundingOptions();
                MessageBox.Show("Funding status updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not update funding status: " + ex.Message);
            }
        }


        private void btnUserAcc_Click(object sender, EventArgs e)
        {
            tabUserAccounts.SelectedTab = tabPage2;
            LoadUserAccounts();
        }

        private void BuildRequirementsScreen()
        {
            tabManageRequirements = new TabPage("Manage Requirements");

            Label lblProgramme = new Label();
            lblProgramme.Text = "Select Degree Programme:";
            lblProgramme.Location = new System.Drawing.Point(20, 25);
            lblProgramme.AutoSize = true;

            cmbDegreeProgramme = new ComboBox();
            cmbDegreeProgramme.Location = new System.Drawing.Point(190, 22);
            cmbDegreeProgramme.Size = new System.Drawing.Size(300, 25);
            cmbDegreeProgramme.DropDownStyle = ComboBoxStyle.DropDownList;

            dgvRequirements = new DataGridView();
            dgvRequirements.Location = new System.Drawing.Point(20, 70);
            dgvRequirements.Size = new System.Drawing.Size(700, 270);
            dgvRequirements.ReadOnly = true;
            dgvRequirements.AllowUserToAddRows = false;
            dgvRequirements.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            btnRefreshRequirements = new Button();
            btnRefreshRequirements.Text = "Refresh";
            btnRefreshRequirements.Location =
                new System.Drawing.Point(520, 22);

            btnBackRequirements = new Button();
            btnBackRequirements.Text = "Back to Dashboard";
            btnBackRequirements.Location =
                new System.Drawing.Point(20, 355);
            btnBackRequirements.Size =
                new System.Drawing.Size(140, 30);

            tabManageRequirements.Controls.Add(lblProgramme);
            tabManageRequirements.Controls.Add(cmbDegreeProgramme);
            tabManageRequirements.Controls.Add(dgvRequirements);
            tabManageRequirements.Controls.Add(btnRefreshRequirements);
            tabManageRequirements.Controls.Add(btnBackRequirements);

            cmbDegreeProgramme.SelectedIndexChanged +=
                cmbDegreeProgramme_SelectedIndexChanged;

            btnRefreshRequirements.Click +=
                btnRefreshRequirements_Click;

            btnBackRequirements.Click += (sender, e) =>
            {
                tabUserAccounts.SelectedTab = tabPage1;
            };

            LoadDegreeProgrammes();
        }
        private void LoadDegreeProgrammes()
        {
            try
            {
                string connectionString =
                    ConfigurationManager.ConnectionStrings["FuturePathDB"]
                    .ConnectionString;

                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT DegreeProgrammeID, ProgrammeName
                FROM dbo.DegreeProgramme
                WHERE IsActive = 1
                ORDER BY ProgrammeName";

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        cmbDegreeProgramme.DataSource = table;
                        cmbDegreeProgramme.DisplayMember = "ProgrammeName";
                        cmbDegreeProgramme.ValueMember = "DegreeProgrammeID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load degree programmes: " + ex.Message);
            }
        }

        private void LoadProgrammeRequirements()
        {
            if (cmbDegreeProgramme.SelectedValue == null ||
                !(cmbDegreeProgramme.SelectedValue is int))
                return;

            try
            {
                string connectionString =
                    ConfigurationManager.ConnectionStrings["FuturePathDB"]
                    .ConnectionString;

                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT
                    s.SubjectName AS Subject,
                    pr.MinimumMark AS [Minimum Required Mark]
                FROM dbo.ProgrammeRequirement pr
                INNER JOIN dbo.Subject s
                    ON pr.SubjectID = s.SubjectID
                WHERE pr.DegreeProgrammeID = @ProgrammeID
                ORDER BY s.SubjectName";

                    using (SqlCommand command =
                        new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(
                            "@ProgrammeID",
                            SqlDbType.Int).Value =
                            (int)cmbDegreeProgramme.SelectedValue;

                        using (SqlDataAdapter adapter =
                            new SqlDataAdapter(command))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            dgvRequirements.DataSource = table;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load requirements: " + ex.Message);
            }
        }

        private void cmbDegreeProgramme_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            LoadProgrammeRequirements();
        }

        private void btnRefreshRequirements_Click(
            object sender, EventArgs e)
        {
            LoadDegreeProgrammes();
            LoadProgrammeRequirements();
        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;
            string role;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    "Please enter your username and password.");
                return;
            }

            try
            {
                bool valid = accountDataAccess.VerifyLogin(
                    username, password, out role);

                if (!valid || role != "Administrator")
                {
                    MessageBox.Show(
                        "Invalid login details or insufficient permissions.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                grpboxAdministrator.Visible = false;
                grpboxAdminFunctions.Visible = true;

                // Make the advisory summary available after login.
                if (!tabUserAccounts.TabPages.Contains(tabAdvisorySum))
                    tabUserAccounts.TabPages.Add(tabAdvisorySum);

                if (!tabUserAccounts.TabPages.Contains(tabManageRequirements))
                    tabUserAccounts.TabPages.Add(tabManageRequirements);

                if (!tabUserAccounts.TabPages.Contains(tabPage2))
                    tabUserAccounts.TabPages.Add(tabPage2);

                if (!tabUserAccounts.TabPages.Contains(tabManageFunding))
                    tabUserAccounts.TabPages.Add(tabManageFunding);

                if (!tabUserAccounts.TabPages.Contains(tabManageQuestions))
                    tabUserAccounts.TabPages.Add(tabManageQuestions);

                if (!tabUserAccounts.TabPages.Contains(tabSystemReports))
                    tabUserAccounts.TabPages.Add(tabSystemReports);

                tabUserAccounts.SelectedTab = tabPage1;

                MessageBox.Show("Administrator login successful.");
            }
            catch (SqlException)
            {
                MessageBox.Show(
                    "Could not connect to the database. " +
                    "Please check your database connection.",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "An unexpected error occurred during login.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            grpboxAdminFunctions.Visible = false;
            grpboxAdministrator.Visible = true;

            // Remove access to the summary tab after logout.
            if (tabUserAccounts.TabPages.Contains(tabAdvisorySum))
                tabUserAccounts.TabPages.Remove(tabAdvisorySum);
            if (tabUserAccounts.TabPages.Contains(tabPage2))
                tabUserAccounts.TabPages.Remove(tabPage2);
            if (tabUserAccounts.TabPages.Contains(tabManageRequirements))
                tabUserAccounts.TabPages.Remove(tabManageRequirements);
            if (tabUserAccounts.TabPages.Contains(tabManageFunding))
                tabUserAccounts.TabPages.Remove(tabManageFunding);
            if (tabUserAccounts.TabPages.Contains(tabManageQuestions))
                tabUserAccounts.TabPages.Remove(tabManageQuestions);
            if (tabUserAccounts.TabPages.Contains(tabSystemReports))
                tabUserAccounts.TabPages.Remove(tabSystemReports);

            tabUserAccounts.SelectedTab = tabPage1;

            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();


        }


        private void tabUserAccounts_Enter(object sender, EventArgs e)
        {
            LoadUserAccounts();
        }

        private void LoadUserAccounts()
        {
            try
            {
                dgvUserAccounts.DataSource = accountDataAccess.GetAccounts();

                if (dgvUserAccounts.Columns.Contains("UserAccountID"))
                    dgvUserAccounts.Columns["UserAccountID"].Visible = false;

                if (dgvUserAccounts.Columns.Contains("Username"))
                    dgvUserAccounts.Columns["Username"].HeaderText = "Username";

                if (dgvUserAccounts.Columns.Contains("Role"))
                    dgvUserAccounts.Columns["Role"].HeaderText = "Role";

                if (dgvUserAccounts.Columns.Contains("IsActive"))
                    dgvUserAccounts.Columns["IsActive"].HeaderText = "Active";
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to load user accounts. Please try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem == null
                ? ""
                : cmbRole.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show(
                    "Please enter a username, password and role.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool created = accountDataAccess.CreateAccount(
                    username, password, role);

                if (created)
                {
                    MessageBox.Show(
                        "Account created successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    txtUsername.Clear();
                    txtPassword.Clear();
                    cmbRole.SelectedIndex = 0;

                    LoadUserAccounts();
                }
                else
                {
                    MessageBox.Show(
                        "The account could not be created. Please check your input.",
                        "Account Creation Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Account Already Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Account Creation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnToggleStatus_Click(object sender, EventArgs e)
        {
            if (dgvUserAccounts.CurrentRow == null)
            {
                MessageBox.Show("Please select an account first.");
                return;
            }

            int userAccountID = Convert.ToInt32(
                dgvUserAccounts.CurrentRow.Cells["UserAccountID"].Value);

            string username = Convert.ToString(
                dgvUserAccounts.CurrentRow.Cells["Username"].Value);

            bool currentlyActive = Convert.ToBoolean(
                dgvUserAccounts.CurrentRow.Cells["IsActive"].Value);

            if (MessageBox.Show(
                "Are you sure you want to " +
                (currentlyActive ? "deactivate" : "activate") +
                " the account for " + username + "?",
                "Confirm Account Status",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                bool updated = accountDataAccess.SetAccountActive(
                    userAccountID, !currentlyActive);

                if (updated)
                {
                    MessageBox.Show("Account status updated successfully.");
                    LoadUserAccounts();
                }
                else
                {
                    MessageBox.Show("The account status could not be updated.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to update the account status. Please try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void BuildQuestionsScreen()
        {
            tabManageQuestions = new TabPage("Interest Questionnaires");

            dgvQuestions = new DataGridView
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(700, 220),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };

            txtQuestionText = new TextBox
            {
                Location = new System.Drawing.Point(20, 255),
                Size = new System.Drawing.Size(300, 25)
            };

            cmbInterestCategory = new ComboBox
            {
                Location = new System.Drawing.Point(330, 255),
                Size = new System.Drawing.Size(200, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            btnAddQuestion = new Button
            {
                Text = "Add Question",
                Location = new System.Drawing.Point(540, 255),
                Size = new System.Drawing.Size(120, 30)
            };

            btnToggleQuestionStatus = new Button
            {
                Text = "Activate / Deactivate",
                Location = new System.Drawing.Point(20, 300),
                Size = new System.Drawing.Size(160, 30)
            };

            btnRefreshQuestions = new Button
            {
                Text = "Refresh",
                Location = new System.Drawing.Point(190, 300),
                Size = new System.Drawing.Size(80, 30)
            };

            btnBackQuestions = new Button
            {
                Text = "Back to Dashboard",
                Location = new System.Drawing.Point(280, 300),
                Size = new System.Drawing.Size(140, 30)
            };

            tabManageQuestions.Controls.Add(dgvQuestions);
            tabManageQuestions.Controls.Add(txtQuestionText);
            tabManageQuestions.Controls.Add(cmbInterestCategory);
            tabManageQuestions.Controls.Add(btnAddQuestion);
            tabManageQuestions.Controls.Add(btnToggleQuestionStatus);
            tabManageQuestions.Controls.Add(btnRefreshQuestions);
            tabManageQuestions.Controls.Add(btnBackQuestions);

            btnRefreshQuestions.Click += (s, e) =>
            {
                LoadInterestCategories();
                LoadInterestQuestions();
            };

            btnAddQuestion.Click += btnAddQuestion_Click;
            btnToggleQuestionStatus.Click += btnToggleQuestionStatus_Click;

            btnBackQuestions.Click += (s, e) =>
                tabUserAccounts.SelectedTab = tabPage1;

            LoadInterestCategories();
        }


        private void LoadInterestQuestions()
        {
            try
            {
                string cs = ConfigurationManager
                    .ConnectionStrings["FuturePathDB"].ConnectionString;

                using (SqlConnection con = new SqlConnection(cs))
                using (SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT * FROM dbo.InterestQuestion", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvQuestions.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load interest questions: " + ex.Message);
            }
        }


        private void LoadInterestCategories()
        {
            try
            {
                string cs = ConfigurationManager
                    .ConnectionStrings["FuturePathDB"].ConnectionString;

                using (SqlConnection con = new SqlConnection(cs))
                using (SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT InterestCategoryID, CategoryName " +
                    "FROM dbo.InterestCategory ORDER BY CategoryName", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbInterestCategory.DataSource = dt;
                    cmbInterestCategory.DisplayMember = "CategoryName";
                    cmbInterestCategory.ValueMember = "InterestCategoryID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load categories: " + ex.Message);
            }
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            string question = txtQuestionText.Text.Trim();

            if (question.Length == 0)
            {
                MessageBox.Show("Please enter a question.");
                return;
            }

            if (question.Length > 250)
            {
                MessageBox.Show("The question cannot exceed 250 characters.");
                return;
            }

            if (cmbInterestCategory.SelectedValue == null)
            {
                MessageBox.Show("Please select an interest category.");
                return;
            }

            try
            {
                string cs = ConfigurationManager
                    .ConnectionStrings["FuturePathDB"].ConnectionString;

                string sql = @"
            INSERT INTO dbo.InterestQuestion
                (InterestCategoryID, QuestionText, IsActive)
            VALUES (@CategoryID, @QuestionText, 1);";

                using (SqlConnection con = new SqlConnection(cs))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value =
                        Convert.ToInt32(cmbInterestCategory.SelectedValue);

                    cmd.Parameters.Add("@QuestionText", SqlDbType.VarChar, 250).Value =
                        question;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                txtQuestionText.Clear();
                LoadInterestQuestions();

                MessageBox.Show("Question added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not add question: " + ex.Message);
            }
        }

        private void btnToggleQuestionStatus_Click(object sender, EventArgs e)
        {
            if (dgvQuestions.CurrentRow == null ||
                dgvQuestions.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please select a question first.");
                return;
            }

            int questionID = Convert.ToInt32(
                dgvQuestions.CurrentRow.Cells["InterestQuestionID"].Value);

            bool currentlyActive = Convert.ToBoolean(
                dgvQuestions.CurrentRow.Cells["IsActive"].Value);

            try
            {
                string cs = ConfigurationManager
                    .ConnectionStrings["FuturePathDB"].ConnectionString;

                string sql = @"
            UPDATE dbo.InterestQuestion
            SET IsActive = @IsActive
            WHERE InterestQuestionID = @QuestionID;";

                using (SqlConnection con = new SqlConnection(cs))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value =
                        !currentlyActive;

                    cmd.Parameters.Add("@QuestionID", SqlDbType.Int).Value =
                        questionID;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadInterestQuestions();
                MessageBox.Show("Question status updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not update question status: " + ex.Message);
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUserAccounts();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BuildReportsScreen()
        {
            tabSystemReports = new TabPage("Systems Reports");

            cmbReportType = new ComboBox
            {
                Location = new System.Drawing.Point(20, 20),
                Width = 300,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cmbReportType.Items.AddRange(new object[]
            {
        "Learner Advisory Summary",
        "Degree Interest and Eligibility",
        "Learners Not Currently Eligible"
            });

            cmbReportType.SelectedIndex = 0;

            btnRunReport = new Button
            {
                Text = "Run Report",
                Location = new System.Drawing.Point(340, 20),
                Size = new System.Drawing.Size(100, 25)
            };

            dgvSystemReports = new DataGridView
            {
                Location = new System.Drawing.Point(20, 65),
                Size = new System.Drawing.Size(710, 270),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.DisplayedCells,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            btnBackReports = new Button
            {
                Text = "Back to Dashboard",
                Location = new System.Drawing.Point(20, 355),
                Size = new System.Drawing.Size(140, 30)
            };

            tabSystemReports.Controls.Add(cmbReportType);
            tabSystemReports.Controls.Add(btnRunReport);
            tabSystemReports.Controls.Add(dgvSystemReports);
            tabSystemReports.Controls.Add(btnBackReports);

            btnRunReport.Click += btnRunReport_Click;

            btnBackReports.Click += (s, e) =>
                tabUserAccounts.SelectedTab = tabPage1;
        }

        private void btnManageDocs_Click(object sender, EventArgs e)
        {
            if (!tabUserAccounts.TabPages.Contains(tabSystemReports))
                tabUserAccounts.TabPages.Add(tabSystemReports);

            tabUserAccounts.SelectedTab = tabSystemReports;
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            string query;

            switch (cmbReportType.SelectedIndex)
            {
                case 0:
                    query = @"
                SELECT
                    l.FirstName,
                    l.LastName,
                    l.Grade,
                    l.School,
                    dp.ProgrammeName,
                    a.SessionDate,
                    a.OverallOutcome,
                    rr.OverallScore,
                    rr.GapExplanation
                FROM dbo.Learner l
                INNER JOIN dbo.AdvisorySession a
                    ON a.LearnerID = l.LearnerID
                INNER JOIN dbo.DegreeProgramme dp
                    ON dp.DegreeProgrammeID = a.DegreeProgrammeID
                LEFT JOIN dbo.RecommendationResult rr
                    ON rr.AdvisorySessionID = a.AdvisorySessionID
                ORDER BY a.SessionDate DESC";
                    break;

                case 1:
                    query = @"
                SELECT
                    dp.ProgrammeName,
                    f.FacultyName,
                    COUNT(DISTINCT a.AdvisorySessionID) AS LearnerSessions
                FROM dbo.DegreeProgramme dp
                INNER JOIN dbo.Faculty f
                    ON f.FacultyID = dp.FacultyID
                LEFT JOIN dbo.AdvisorySession a
                    ON a.DegreeProgrammeID = dp.DegreeProgrammeID
                GROUP BY dp.ProgrammeName, f.FacultyName
                ORDER BY LearnerSessions DESC";
                    break;

                case 2:
                    query = @"
                SELECT
                    l.FirstName,
                    l.LastName,
                    l.Grade,
                    dp.ProgrammeName,
                    f.FacultyName,
                    a.SessionDate,
                    a.OverallOutcome,
                    rr.GapExplanation
                FROM dbo.Learner l
                INNER JOIN dbo.AdvisorySession a
                    ON a.LearnerID = l.LearnerID
                INNER JOIN dbo.DegreeProgramme dp
                    ON dp.DegreeProgrammeID = a.DegreeProgrammeID
                INNER JOIN dbo.Faculty f
                    ON f.FacultyID = dp.FacultyID
                LEFT JOIN dbo.RecommendationResult rr
                    ON rr.AdvisorySessionID = a.AdvisorySessionID
                WHERE a.OverallOutcome IN
                    ('Not Currently Eligible',
                     'More Information Needed')
                ORDER BY a.SessionDate DESC";
                    break;

                default:
                    return;
            }

            try
            {
                string cs = ConfigurationManager
                    .ConnectionStrings["FuturePathDB"].ConnectionString;

                using (SqlConnection con = new SqlConnection(cs))
                using (SqlDataAdapter adapter =
                    new SqlDataAdapter(query, con))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvSystemReports.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not run the report: " + ex.Message);
            }
        }


        private string advisorySummaryText = "";

        private void LoadAdvisorySummary()
        {
            try
            {
                string cs = ConfigurationManager
                    .ConnectionStrings["FuturePathDB"].ConnectionString;

                string learnerOverview = "No advisory sessions recorded.";
                string advisoryOutcome = "No outcome available.";
                string keyFindings = "No recommendation findings available.";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    string sessionSql = @"
                SELECT TOP 1
                    l.FirstName,
                    l.LastName,
                    l.Grade,
                    l.School,
                    a.SessionDate,
                    a.OverallOutcome,
                    dp.ProgrammeName,
                    rr.OverallScore,
                    rr.GapExplanation
                FROM dbo.AdvisorySession a
                INNER JOIN dbo.Learner l
                    ON l.LearnerID = a.LearnerID
                INNER JOIN dbo.DegreeProgramme dp
                    ON dp.DegreeProgrammeID = a.DegreeProgrammeID
                OUTER APPLY
                (
                    SELECT TOP 1
                        OverallScore,
                        GapExplanation
                    FROM dbo.RecommendationResult
                    WHERE AdvisorySessionID = a.AdvisorySessionID
                    ORDER BY OverallScore DESC
                ) rr
                ORDER BY a.SessionDate DESC;";

                    using (SqlCommand cmd = new SqlCommand(sessionSql, con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            learnerOverview =
                                "Name: " + reader["FirstName"] + " " +
                                reader["LastName"] +
                                Environment.NewLine +
                                "Grade: " + reader["Grade"] +
                                Environment.NewLine +
                                "School: " + reader["School"] +
                                Environment.NewLine +
                                "Session date: " +
                                Convert.ToDateTime(reader["SessionDate"])
                                    .ToString("dd MMM yyyy");

                            advisoryOutcome =
                                "Programme: " + reader["ProgrammeName"] +
                                Environment.NewLine +
                                "Outcome: " +
                                (reader["OverallOutcome"] == DBNull.Value
                                    ? "Pending"
                                    : reader["OverallOutcome"].ToString());

                            keyFindings =
                                "Overall score: " +
                                (reader["OverallScore"] == DBNull.Value
                                    ? "Not available"
                                    : reader["OverallScore"].ToString() + "/100") +
                                Environment.NewLine +
                                "Eligibility gaps: " +
                                (reader["GapExplanation"] == DBNull.Value
                                    ? "None recorded"
                                    : reader["GapExplanation"].ToString());
                        }
                    }

                    string fundingSql = @"
                SELECT TOP 5 FundingName, FundingType, ClosingDate
                FROM dbo.FundingOption
                WHERE IsActive = 1
                ORDER BY FundingName;";

                    StringBuilder funding = new StringBuilder();

                    using (SqlCommand cmd = new SqlCommand(fundingSql, con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            funding.AppendLine(reader["FundingName"].ToString());
                            funding.AppendLine("Type: " + reader["FundingType"]);

                            funding.AppendLine("Closing date: " +
                                (reader["ClosingDate"] == DBNull.Value
                                    ? "Not specified"
                                    : reader["ClosingDate"].ToString()));

                            funding.AppendLine();
                        }
                    }

                    textBox3.Text = learnerOverview;
                    textBox4.Text = advisoryOutcome;
                    textBox5.Text = funding.Length == 0
                        ? "No active funding opportunities found."
                        : funding.ToString();

                    textBox6.Text = keyFindings;

                    advisorySummaryText =
                        "ADVISORY SUMMARY" + Environment.NewLine +
                        "================" + Environment.NewLine +
                        Environment.NewLine +
                        "LEARNER OVERVIEW" + Environment.NewLine +
                        learnerOverview + Environment.NewLine +
                        Environment.NewLine +
                        "ADVISORY OUTCOME" + Environment.NewLine +
                        advisoryOutcome + Environment.NewLine +
                        Environment.NewLine +
                        "FUNDING OPPORTUNITIES" + Environment.NewLine +
                        textBox5.Text + Environment.NewLine +
                        "KEY FINDINGS" + Environment.NewLine +
                        keyFindings;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load the advisory summary: " + ex.Message,
                    "Advisory Summary",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SaveAdvisorySummary()
        {
            if (string.IsNullOrWhiteSpace(advisorySummaryText))
                LoadAdvisorySummary();

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Save Advisory Summary";
                dialog.Filter = "Text files (*.txt)|*.txt";
                dialog.FileName = "AdvisorySummary.txt";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        System.IO.File.WriteAllText(
                            dialog.FileName, advisorySummaryText);

                        MessageBox.Show("Advisory summary saved successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not save summary: " + ex.Message);
                    }
                }
            }
        }

        private void PrintAdvisorySummary()
        {
            if (string.IsNullOrWhiteSpace(advisorySummaryText))
                LoadAdvisorySummary();

            using (System.Drawing.Printing.PrintDocument document =
                new System.Drawing.Printing.PrintDocument())
            {
                document.PrintPage += (s, e) =>
                {
                    using (System.Drawing.Font font =
                        new System.Drawing.Font("Arial", 10))
                    {
                        e.Graphics.DrawString(
                            advisorySummaryText,
                            font,
                            System.Drawing.Brushes.Black,
                            e.MarginBounds);
                    }
                };

                using (PrintDialog dialog = new PrintDialog())
                {
                    dialog.Document = document;

                    if (dialog.ShowDialog() == DialogResult.OK)
                        document.Print();
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnManageReqs_Click(object sender, EventArgs e)
        {
        
            if (!tabUserAccounts.TabPages.Contains(tabManageRequirements))
                tabUserAccounts.TabPages.Add(tabManageRequirements);

            tabUserAccounts.SelectedTab = tabManageRequirements;
        }
    
    }
}
