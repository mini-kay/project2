using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project2
{
    public partial class Career_Advisor : Form
    {
        private const string AdvisorUsername = "advisor";
        private const string AdvisorPasswHash = "600000.1TtRBbI7igDJ9vuvxn8mHA==.mzzgtzmKdYaIE2sFVstQ6zhC+lH6VdBZydYDAlkmP3U=";

        public Career_Advisor()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }



        private void btnCareerLogin_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Username entered:" + txtCareerUsername.Text);
            MessageBox.Show("password entered:" + txtCareerPassword.Text);
            bool passwordmatch = PasswordHasher.VerifyPassword(txtCareerPassword.Text, AdvisorPasswHash);
            MessageBox.Show("password match:" + passwordmatch.ToString());
            if (txtCareerUsername.Text == AdvisorUsername && PasswordHasher.VerifyPassword(txtCareerPassword.Text, AdvisorPasswHash))
            {
                grpboxCareerFunctions.Visible = true;
                grpboxCareerLogin.Visible = false;
            }
            else
            {
                MessageBox.Show("Your password or username is invalid! Please ensure to use the correct login details", "Login unsuccessful",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Career_Advisor_Load(object sender, EventArgs e)
        {
            grpboxCareerFunctions.Hide();

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            FuturePathForm welcomeScrn = new FuturePathForm();
            welcomeScrn.Show();
            this.Close();
        }

        private void tabAdvisorySum_Click(object sender, EventArgs e)
        {

        }

        private void btnSessions_Click(object sender, EventArgs e)
        {
            tabControlCareerAdvisor.SelectedTab = tabAdvisorySum;
            MessageBox.Show("Loading Learner Sessions...", "View Learner Sessions",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOutcomes_Click(object sender, EventArgs e)
        {
            tabControlCareerAdvisor.SelectedTab = tabAdvisorySum;
            MessageBox.Show("Loading Advisory Outcomes...", "View Advisory Outcomes",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSummaries_Click(object sender, EventArgs e)
        {
            tabControlCareerAdvisor.SelectedTab = tabAdvisorySum;
            MessageBox.Show("Loading Exported Summaries...", "View Exported Summaries",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            tabControlCareerAdvisor.SelectedTab = tabAdvisorySum;
            MessageBox.Show("Generating Report...", "Generate Reports",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }
    }
}
