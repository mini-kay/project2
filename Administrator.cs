
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project2
{
    public partial class Administrator : Form
    {
        private readonly UserAccountDataAccess accountDataAccess;

        public Administrator()
        {
            InitializeComponent();

            accountDataAccess = new UserAccountDataAccess();

            // Configure the login screen.
            textBox2.UseSystemPasswordChar = true;
            grpboxAdminFunctions.Visible = false;
            tabAdvisorySum.Parent = null;
            

            // Connect the buttons to their event handlers.
            btnAdminLogin.Click += btnAdminLogin_Click;
            btnLogOut.Click += btnLogOut_Click;

            // Configure the account-management controls.
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Learner");
            cmbRole.Items.Add("Career Advisor");
            cmbRole.Items.Add("Administrator");
            cmbRole.SelectedIndex = 0;

            txtPassword.UseSystemPasswordChar = true;

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
        private void btnUserAcc_Click(object sender, EventArgs e)
        {
            tabUserAccounts.SelectedTab = tabPage2;
            LoadUserAccounts();
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

                if (!tabUserAccounts.TabPages.Contains(tabPage2))
                    tabUserAccounts.TabPages.Add(tabPage2);

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
            catch (Exception)
            {
                MessageBox.Show(
                    "The account could not be created. Please check the database and try again.",
                    "Account Creation Failed",
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUserAccounts();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
