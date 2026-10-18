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

        private void btnSessions_Click(object sender, EventArgs e)
        {
            tabControlCareerAdvisor.SelectedTab = tabAdvisorySum;
            LoadOverview();
        }

        private void LoadOverview()
        {
            try
            {
                txtLearnerOverview.Clear();
                string query = @"SELECT l.FirstName, l.LastName, 
                        dp.ProgrammeName, a.SessionDate
                        FROM dbo.AdvisorySession a
                        INNER JOIN dbo.Learner l ON l.LearnerID = a.LearnerID
                        INNER JOIN dbo.DegreeProgramme dp 
                        ON dp.DegreeProgrammeID = a.DegreeProgrammeID
                        ORDER BY a.SessionDate DESC";

                using (SqlConnection conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        txtLearnerOverview.AppendText(
                            "Learner: " + reader["FirstName"] + " " + reader["LastName"] + "\r\n" +
                            "Programme: " + reader["ProgrammeName"] + "\r\n" +
                            "Session Date: " + Convert.ToDateTime(reader["SessionDate"]).ToString("dd/MM/yyyy") + "\r\n" +
                            "================================\r\n");
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

        private void btnOutcomes_Click(object sender, EventArgs e)
        {
            tabControlCareerAdvisor.SelectedTab = tabAdvisorySum;
            LoadAdvisoryOutcome();
        }

        private void LoadAdvisoryOutcome()
        {
            try
            {
                string results = "";
                string query = @"SELECT 1.FirstName, 1.LastName, a.OverallOutcome, a.SessionDate
                        FROM dbo.AdvisorySession a
                        INNER JOIN dbo.Learner l ON l.LearnerID = a.LearnerID
                        ORDER BY a.SessionDate DESC ";

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
                            "================================\r\n");
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

        private void btnSummaries_Click(object sender, EventArgs e)
        {
            tabControlCareerAdvisor.SelectedTab = tabAdvisorySum;
            LoadFundingOpps();
        }

        private void LoadFundingOpps()
        {
            try
            {
                txtFundingOpportunities.Clear();
                string query = @"SELECT FundingName, Description, 
                        EligibilityCriteria, ApplicationDeadline
                        FROM dbo.FundingOpportunity
                        ORDER BY ApplicationDeadline";

                using (SqlConnection conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        txtFundingOpportunities.AppendText(
                            "Funding: " + reader["FundingName"] + "\r\n" +
                            "Description: " + reader["Description"] + "\r\n" +
                            "Eligibility: " + reader["EligibilityCriteria"] + "\r\n" +
                            "Deadline: " + Convert.ToDateTime(reader["ApplicationDeadline"]).ToString("dd/MM/yyyy") + "\r\n" +
                            "================================\r\n");
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

        private void LoadLearnerOverview()
        {
            try
            {
                txtLearnerOverview.Clear();
                string query = @"SELECT l.FirstName, l.LastName, 
                        dp.ProgrammeName, a.SessionDate
                        FROM dbo.AdvisorySession a
                        INNER JOIN dbo.Learner l ON l.LearnerID = a.LearnerID
                        INNER JOIN dbo.DegreeProgramme dp 
                        ON dp.DegreeProgrammeID = a.DegreeProgrammeID
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
                            "Programme: " + reader["ProgrammeName"] + "\r\n" +
                            "Session Date: " + Convert.ToDateTime(reader["SessionDate"]).ToString("dd/MM/yyyy") + "\r\n" +
                            "================================\r\n");
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

        private void LoadKeyFindings()
        {
            try
            {
                txtKeyFindings.Clear();
                string query = @"SELECT l.FirstName, l.LastName,
                        s.SubjectName, ls.Mark
                        FROM dbo.LearnerSubject ls
                        INNER JOIN dbo.Learner l ON l.LearnerID = ls.LearnerID
                        INNER JOIN dbo.Subject s ON s.SubjectID = ls.SubjectID
                        ORDER BY l.LearnerID, ls.Mark DESC";

                using (SqlConnection conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    string currentLearner = "";
                    while (reader.Read())
                    {
                        string learnerName = reader["FirstName"] + " " + reader["LastName"];
                        if (learnerName != currentLearner)
                        {
                            if (currentLearner != "")
                                txtKeyFindings.AppendText("================================\r\n");
                            txtKeyFindings.AppendText("Learner: " + learnerName + "\r\n");
                            currentLearner = learnerName;
                        }
                        txtKeyFindings.AppendText(
                            "  - " + reader["SubjectName"] + ": " + reader["Mark"] + "%\r\n");
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
            LoadKeyFindings();
        }

        private void btnBack3_Click(object sender, EventArgs e)
        {
            tabControlCareerAdvisor.SelectedTab = tabCareerAdvisor;
            grpboxCareerLogin.Visible = false;
            grpboxCareerFunctions.Visible = true;

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string exportSum = "ADVISORY SUMMARY\r\n" +
                               "=========================\r\n\r\n" +
                               "LEARNER OVERVIEW:\r\n" + txtLearnerOverview.Text + "\r\n" +
                               "ADVISORY OUTCOME: \r\n" + txtAdvisoryOutcome.Text + "\r\n" +
                               "FUNDING OPPORTUNITES: \r\n" + txtFundingOpportunities.Text + "\r\n" +
                               "KEY FINDINGS: \r\n" + txtKeyFindings.Text;
            MessageBox.Show(exportSum, "Advisory Summary Report", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string printSum = "ADVISORY SUMMARY\r\n" +
                               "=========================\r\n\r\n" +
                               "LEARNER OVERVIEW:\r\n" + txtLearnerOverview.Text + "\r\n" +
                               "ADVISORY OUTCOME: \r\n" + txtAdvisoryOutcome.Text + "\r\n" +
                               "FUNDING OPPORTUNITES: \r\n" + txtFundingOpportunities.Text + "\r\n" +
                               "KEY FINDINGS: \r\n" + txtKeyFindings.Text;
            MessageBox.Show(printSum, "Print Review", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            DialogResult results = MessageBox.Show("Are you sure you want to end the session?",
                "Finishing Session", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (results == DialogResult.Yes)
            {
                txtLearnerOverview.Clear();
                txtAdvisoryOutcome.Clear();
                txtKeyFindings.Clear();
                txtFundingOpportunities.Clear();
                tabControlCareerAdvisor.SelectedTab = tabCareerAdvisor;
                grpboxCareerLogin.Visible = false;
                grpboxCareerFunctions.Visible = true;
            }

        }
    }
}
