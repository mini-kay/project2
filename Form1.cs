using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Text;

namespace project2
{
    public partial class FuturePathForm : Form
    {
        LearnerManager learnerManager = new LearnerManager();

        public FuturePathForm()
        {
            InitializeComponent();
        }
        #region Interest Questionnaire
        private const string ConnStr =
            @"Server =(localdb)\MSSQLLocalDB;Database=FuturePathDB;Trusted_Connection=True;TrustServerCertificate=True";

        private bool questionsLoaded = false;

        private void LoadQuestions()
        {
            if (questionsLoaded) return;

            var questions = new DataTable();
            try
            {
                using (var conn = new SqlConnection(ConnStr))
                using (var da = new SqlDataAdapter("SELECT InterestQuestionID, InterestCategoryID, " +
                    "QuestionText " + " FROM dbo.InterestQuestion ORDER BY InterestQuestionID", conn))
                {
                    da.Fill(questions);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load questions: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            flowQuestions.SuspendLayout();
            flowQuestions.Controls.Clear();
            flowQuestions.FlowDirection = FlowDirection.TopDown;
            flowQuestions.WrapContents = false;
            flowQuestions.AutoScroll = true;

            foreach (DataRow row in questions.Rows)
            {
                var lbl = new Label
                {
                    Text = row["QuestionText"].ToString(),
                    AutoSize = true,
                    Margin = new Padding(10, 10, 10, 20)
                };

                var rating = new NumericUpDown
                {
                    Minimum = 1,
                    Maximum = 5,
                    Value = 3,
                    Width = 60,
                    Tag = row["InterestQuestionID"]
                };

                flowQuestions.Controls.Add(lbl);
                flowQuestions.Controls.Add(rating);
            }

            flowQuestions.ResumeLayout();
            questionsLoaded = true;
        }

        private DataTable GetAlignmentScores(int learnerID, int sessionID)
        {
            string sql = @"
                SELECT dp.ProgrammeName, SUM(cat.Total * dim.Weight) AS Score
                FROM DBO.DegreeInterestMapping dim
                JOIN dbo.DegreeProgramme dp
                    ON dp.DegreeProgrammeID = dim.DegreeProgrammeID
                JOIN (
                    SELECT q.InterestCategoryID, SUM(r.ResponseValue) AS Total
                    FROM dbo.LearnerInterestResponse r
                    JOIN dbo.InterestQuestion q
                        ON q.InterestQuestionID = r.InterestQuestionID
                    WHERE r.LearnerID = @LearnerID
                        AND r.AdvisorySessionID = @SessionID
                    GROUP BY q.InterestCategoryID
                ) cat ON cat.InterestCategoryID = dim.InterestCategoryID
                WHERE dp.IsActive = 1
                GROUP BY dp.ProgrammeName
                ORDER BY Score DESC;";

            var results = new DataTable();
            using (var conn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@LearnerID", learnerID);
                cmd.Parameters.AddWithValue("@SessionID", sessionID);
                new SqlDataAdapter(cmd).Fill(results);
            }
            return results;
        }

        private int currentLearnerID;

        private int SaveLearner(Learner learner)
        {
            string digits = new string(learner.Grade.Where(char.IsDigit).ToArray());
            int grade = int.Parse(digits);

            const string sql = @"
                INSERT INTO dbo.Learner (FirstName, LastName, Grade, School, Province)
                OUTPUT INSERTED.LearnerID
                VALUES (@First, @Last, @Grade, @School, @Province);";

            using (var conn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@First", learner.FirstName);
                cmd.Parameters.AddWithValue("@Last", learner.LastName);
                cmd.Parameters.AddWithValue("@Grade", learner.Grade);
                cmd.Parameters.AddWithValue("@School", learner.SchoolName);
                cmd.Parameters.AddWithValue("@Province", learner.Province);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
        #endregion

        private void FuturePathForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Please take note of the system functionality below, then click OK to select how you would like to access the system.\n\n" +
                "Future Path is a student advising system designed to help Grade 11 and Grade 12 learners explore possible study pathways after school.\n\n" +
                "This System allows you to: \n" +
                " - Check whether your subjects and marks align with qualification requirements.\n" + 
                " - Identify academic gaps that may need improvements.\n" + 
                " - Discover alternative study options.\n" +
                " - View funding opportunities related to your chosen field(s) of study.\n",
                "Welcome to Future Path", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private bool ValidateLearner()
        {
            
            if (txtLearnerName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a First Name");
                return false;
               
            }
            if (txtLearnerName.Text.Any(char.IsDigit))
            {
                MessageBox.Show("First Name cannot contain numbers");
                return false;
            }
            if (txtLearnerSurname.Text.Trim() == "")
            {
                MessageBox.Show("Please eneter a Last Name");
                return false;
            }
            if(txtLearnerSurname.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Last Name cannot contain numbers");
                return false;
            }
            if (txtSchool.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a School Name");
                return false;
            }
            if (txtSchool.Text.Any(char.IsDigit))
            {
                MessageBox.Show("School Name cannot contain digits");
            }
            if (cmbProvince.Text == "")
            {
                MessageBox.Show("Please select a Province");
                return false;
            }
            if (txtEmail.Text != "" && !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Please enter a valid email address");
                return false;
            }

            return true;
        }
        //add focus to this!
        //improve messageboxes
        //also check spelling

        private void tabRoleSelection_Click(object sender, EventArgs e)
        {
            
        }

        private void radLearner_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (radLearner.Checked)
            {
                FuturePathTabControl.SelectedTab = tabLearnerInfo;
            }
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateLearner())
            {
                return;
            }
            Learner learner = new Learner(txtLearnerName.Text, txtLearnerSurname.Text,
                                          cmbGrade.Text, txtSchool.Text, cmbProvince.Text,
                                          txtEmail.Text);
            learnerManager.AddLearner(learner);
            try { currentLearnerID = SaveLearner(learner); }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save learner: " + ex.Message);
                return;
            }
            MessageBox.Show("Learner Added Successfully!!");





        }

        private void FuturePathTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FuturePathTabControl.SelectedTab == tabQuestionnaire)
                LoadQuestions();
        }

        private void btnSubmitQuestions_Click(object sender, EventArgs e)
        {
            if (currentLearnerID == 0)
            {
                MessageBox.Show("Please complete Learner Information first.");
                return;
            }

            try
            {
                int sessionID;
                using (var conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    using (var trans = conn.BeginTransaction())
                    {
                        using (var cmd = new SqlCommand(
                            "INSERT INTO dbo.AdvisorySession (LearnerID, SessionDate) " +
                            "OUTPUT INSERTED.AdvisorySessionID VALUES (@L, GETDATE());", conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@L", currentLearnerID);
                            sessionID = (int)cmd.ExecuteScalar();
                        }

                        foreach (Control c in flowQuestions.Controls)
                        {
                            if (c is NumericUpDown rating)
                            {
                                using (var cmd = new SqlCommand(
                                    "INSERT INTO dbo.LearnerInterestResponse " + 
                                    "(LearnerID, InterestQuestionID, AdvisorySessionID, ResponseValue) " +
                                    "VALUES (@L, @Q, @S, @V);", conn, trans))
                                {
                                    cmd.Parameters.AddWithValue("@L", currentLearnerID);
                                    cmd.Parameters.AddWithValue("@Q", Convert.ToInt32(rating.Tag));
                                    cmd.Parameters.AddWithValue("@S", sessionID);
                                    cmd.Parameters.AddWithValue("@V", (int)rating.Value);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        trans.Commit();
                    }
                }

                DataTable scores = GetAlignmentScores(currentLearnerID, sessionID);
                string text = "Your best matches:\n";
                for (int i = 0; i < Math.Min(3, scores.Rows.Count); i++)
                    text += (i + 1) + ". " + scores.Rows[i]["ProgrammeName"] + "\n";
                MessageBox.Show(text, "Interest Results");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save answers: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
