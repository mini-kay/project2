using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        private readonly DatabaseHelper dbHelper = new DatabaseHelper(); 
        public Career_Advisor()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void Career_Advisor_Load(object sender, EventArgs e)
        {
            grpboxCareerFunctions.Hide();
        }

        private void txtCareerUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCareerLogin_Click(object sender, EventArgs e)
        {
            
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

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            FuturePathForm welcomeScrn = new FuturePathForm();
            welcomeScrn.Show();
            this.Close();
        }

        private void btnSessions_Click(object sender, EventArgs e)
        {
            tabControlCareerAdvisor.SelectedTab = tabAdvisorySum;
            MessageBox.Show("Loading Learner Sessions...", "View Learner Sessions",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLearnerOverview();
        }

        private void LoadLearnerOverview()
        {
            try
            {
                txtLearnerOverview.Clear();
                
                string query = @"SELECT 1.FirstName, 1.LastName, dp.ProgrammeName, a.SessionDate
                                FROM dbo.AdvisorySession a
                                INNER JOIN dbo.Learner 1 ON 1.LearnerID = a.LearnerID
                                INNER JOIN dbo.DegreeProgramme dp ON dp.DegreeProgrammeID = a.DegreeProgrammeID
                                ORDER BY a.SessionDate DESC";

                using (SqlConnection connect = dbHelper.GetConnection())
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand(query, connect);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        txtLearnerOverview.AppendText(
                            "Learner: " + reader["FirstName"] + " " + reader["LastName"] + "\r\n" +
                            "Programme: " + reader["ProgrammeName"] + "r\\n" +
                            "Session Date: " + Convert.ToDateTime(reader["SessionDate"]).ToString("dd/MM/yyyy") + "\r\n" +
                            "===========================================\r\n");
                    }
                    reader.Close();
                      

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error loading sessions: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOutcomes_Click(object sender, EventArgs e)
        {

            tabControlCareerAdvisor.SelectedTab = tabAdvisorySum;
            MessageBox.Show("Loading Advisory Outcomes...", "View Advisory Outcomes",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadAdvisoryOutcomes();
        }

        private void LoadAdvisoryOutcomes()
        {
            try
            {
                txtAdvisoryOutcome.Clear();
                string query = @"SELECT 1.FirstName, 1.LastName,
                                 a.OverallOutcome, aSessionDate FROM dbo.AdvisorySession a
                                 INNER JOIN dbo.Learner 1 ON 1.LearnerID = a.LearnerID
                                 ORDER BY a.SessionDate DESC";

                using (SqlConnection connect = dbHelper.GetConnection())
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand(query, connect);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        txtAdvisoryOutcome.AppendText(
                            "Learner: " + reader["FirstName"] + " " + reader["LastName"] + "\r\n" +
                            "Outcome: " + reader["OverallOutcome"] + "\r\n" +
                            "Date: " + Convert.ToDateTime(reader["SessionDate"]).ToString("dd/MM/yyyy") + "\r\n" + 
                            "==============================\r\n");
                    }
                    reader.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSummaries_Click(object sender, EventArgs e)
        {
            tabControlCareerAdvisor.SelectedTab = tabAdvisorySum;
            MessageBox.Show("Loading Exported Summaries...", "View Exported Summaries",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadFundingOpportunities();
        }

        private void LoadFundingOpportunities()
        {
            try
            {
                txtFundingOpps.Clear();
                string query = @"SELECT FundingName, Description, EligibilityCriteria, ApplicationDeadline
                               FROM dbo.FundingOpportunity ORDER BY ApplicationDeadline";
                using (SqlConnection connect = dbHelper.GetConnection())
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand(query, connect);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        txtFundingOpps.AppendText(
                            "Funding: " + reader["FundingName"] + "\r\n" +
                            "Description: " + reader["Description"] + "\r\n" +
                            "Eligibility: " + reader["EligibilityCriteria"] + "\r\n" +
                            "Deadline: " + Convert.ToDateTime(reader["ApplicationDeadline"]).ToString("dd/MM/yyyy") + "\r\n" +
                            "===============================\r\n");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            tabControlCareerAdvisor.SelectedTab = tabAdvisorySum;
            MessageBox.Show("Generating Report...", "Generate Reports",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadKeyFindings();
        }

        private void LoadKeyFindings()
        {
            try
            {
                txtKeyFindings.Clear();
                string query = @"SELECT 1.FirstName, 1.LastName, s.SubjectName, 1s.Mark
                               FROM dbo.LearnerSubject 1s INNER JOIN dbo.Learner 1 ON 1.LearnerID = 1s.LearnerID
                               INNER JOIN dbo.Subject s ON s.SubjectID = 1s.SubjectID ORDER BY 1.LearnerID, 1s.Mark DESC";

                using (SqlConnection connect = dbHelper.GetConnection())
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand(query, connect);
                    SqlDataReader reader = cmd.ExecuteReader();
                    string currentLearner = "";
                    while (reader.Read())
                    {
                        string learnerName = reader["FirstName"] + " " + reader["LastName"];
                        if (learnerName != currentLearner)
                        {
                            if (currentLearner != "")
                                txtKeyFindings.AppendText("======================================\r\n");
                            txtKeyFindings.AppendText("Learner: " + learnerName + "\r\n");
                            currentLearner = learnerName;
                        }

                        txtKeyFindings.AppendText(
                            " - " + reader["SubjectName"] + ": " + reader["Mark"] + "%\r\n");

                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("back button was clicked");
            tabControlCareerAdvisor.SelectedTab = tabCareerAdvisor;
            grpboxCareerLogin.Visible = false;
            grpboxCareerFunctions.Visible = true;
        }
    }
}
