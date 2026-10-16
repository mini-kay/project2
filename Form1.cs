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

            List<InterestQuestion> questions;
            try
            {
                questions = new InterestQuestionDataAccess().GetAllQuestions();
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


            foreach (InterestQuestion question in questions)
            {
                var questionLabel = new Label
                {
                    Text = question.QuestionText,
                    AutoSize = true,

                    MaximumSize = new Size(600, 0),
                    Margin = new Padding(3, 12, 3, 5)
                };

                var rating = new NumericUpDown
                {
                    Minimum = 1,
                    Maximum = 5,
                    Value = 3,

                    Width = 70,
                    Tag = question.InterestQuestionID,
                    Margin = new Padding(3, 0, 3, 12)
                };

                flowQuestions.Controls.Add(questionLabel);
                flowQuestions.Controls.Add(rating);
            }


            flowQuestions.ResumeLayout();
            questionsLoaded = true;
        }

        private DataTable GetAlignmentScores(int learnerID, int sessionID)
        {
            string sql = @"
        SELECT
            dp.ProgrammeName,
            SUM(cat.Total * dim.Weight) AS Score
        FROM dbo.DegreeInterestMapping dim
        JOIN dbo.DegreeProgramme dp
            ON dp.DegreeProgrammeID = dim.DegreeProgrammeID
        JOIN
        (
            SELECT
                q.InterestCategoryID,
                SUM(r.ResponseValue) AS Total
            FROM dbo.LearnerInterestResponse r
            JOIN dbo.InterestQuestion q
                ON q.InterestQuestionID = r.InterestQuestionID
            WHERE r.LearnerID = @LearnerID
              AND r.AdvisorySessionID = @SessionID
            GROUP BY q.InterestCategoryID
        ) cat
            ON cat.InterestCategoryID = dim.InterestCategoryID
        WHERE dp.IsActive = 1
        GROUP BY dp.ProgrammeName
        ORDER BY Score DESC;";

            DataTable results = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConnStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@LearnerID", learnerID);
                cmd.Parameters.AddWithValue("@SessionID", sessionID);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(results);
                }
            }

            return results;
        }

        private int currentLearnerID;
        private int currentSessionID;

        private int SaveLearner(Learner learner)
        {
            string digits = new string(
                learner.Grade.Where(char.IsDigit).ToArray());

            int grade = int.Parse(digits);

            const string sql = @"
        INSERT INTO dbo.Learner
            (FirstName, LastName, Grade, School, Province, Email)
        OUTPUT INSERTED.LearnerID
        VALUES
            (@First, @Last, @Grade, @School, @Province, @Email);";

            using (var conn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@First", learner.FirstName);
                cmd.Parameters.AddWithValue("@Last", learner.LastName);
                cmd.Parameters.AddWithValue("@Grade", grade);
                cmd.Parameters.AddWithValue("@School", learner.SchoolName);
                cmd.Parameters.AddWithValue("@Province", learner.Province);
                cmd.Parameters.AddWithValue(
                    "@Email",
                    string.IsNullOrWhiteSpace(learner.Email)
                        ? (object)DBNull.Value
                        : learner.Email.Trim());

                conn.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        

        }
        #endregion

        private bool TryGetMark(string markText, out int mark)
        {
            mark = 0;

            if (!int.TryParse(markText.Trim(), out mark))
                return false;

            return mark >= 0 && mark <= 100;
        }

        private void SaveSubjectMarks(int learnerID, int sessionID)
        {
            using (SqlConnection connection = new SqlConnection(ConnStr))
            {
                connection.Open();

                string sql = @"
            INSERT INTO dbo.LearnerSubject
                (LearnerID, SubjectID, AdvisorySessionID, Mark)
            VALUES
                (@LearnerID, @SubjectID, @SessionID, @Mark)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@LearnerID", SqlDbType.Int);
                    cmd.Parameters.Add("@SubjectID", SqlDbType.Int);
                    cmd.Parameters.Add("@SessionID", SqlDbType.Int);
                    cmd.Parameters.Add("@Mark", SqlDbType.Int);

                    SaveOneSubject(cmd, learnerID, sessionID,
                        cmbHomeLanguage.Text, txtMarkHL.Text);

                    SaveOneSubject(cmd, learnerID, sessionID,
                        cmbFAL.Text, txtMarkFAL.Text);

                    SaveOneSubject(cmd, learnerID, sessionID,
                        cmbMaths.Text, txtMarkMaths.Text);

                    SaveOneSubject(cmd, learnerID, sessionID,
                        txtLO.Text, txtMarkLO.Text);

                    SaveOneSubject(cmd, learnerID, sessionID,
                        cmbSubject1.Text, txtMark1.Text);

                    SaveOneSubject(cmd, learnerID, sessionID,
                        cmbSubject2.Text, txtMark2.Text);

                    SaveOneSubject(cmd, learnerID, sessionID,
                        cmbSubject3.Text, txtMark3.Text);
                }
            }
        }

        private void SaveOneSubject(
            SqlCommand cmd, int learnerID, int sessionID,
            string subjectName, string markText)
        {
            // Ignore rows that have not been selected or entered.
            if (string.IsNullOrWhiteSpace(subjectName) ||
                string.IsNullOrWhiteSpace(markText))
                return;

            if (!int.TryParse(markText, out int mark) ||
                mark < 0 || mark > 100)
            {
                throw new ArgumentException(
                    "Enter a valid mark between 0 and 100 for "
                    + subjectName + ".");
            }

            int subjectID = GetSubjectID(subjectName);

            cmd.Parameters["@LearnerID"].Value = learnerID;
            cmd.Parameters["@SubjectID"].Value = subjectID;
            cmd.Parameters["@SessionID"].Value = sessionID;
            cmd.Parameters["@Mark"].Value = mark;

            cmd.ExecuteNonQuery();
        }

        private int GetSubjectID(string subjectName)
        {
            string dbSubjectName = subjectName.Trim();

            if (dbSubjectName.EndsWith(" HL"))
            {
                dbSubjectName =
                    dbSubjectName.Substring(0, dbSubjectName.Length - 3)
                    + " Home Language";
            }
            else if (dbSubjectName.EndsWith(" FAL"))
            {
                dbSubjectName =
                    dbSubjectName.Substring(0, dbSubjectName.Length - 4)
                    + " First Additional Language";
            }

            using (SqlConnection connection = new SqlConnection(ConnStr))
            {
                connection.Open();

                string sql = @"
            SELECT SubjectID
            FROM dbo.Subject
            WHERE SubjectName = @SubjectName";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@SubjectName", SqlDbType.VarChar, 100)
                        .Value = dbSubjectName;

                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        throw new ArgumentException(
                            "This subject is not configured in the database: "
                            + subjectName);
                    }

                    return Convert.ToInt32(result);
                }
            }
        }


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

        private void FuturePathTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FuturePathTabControl.SelectedTab == tabQuestionnaire)
                LoadQuestions();
        }


        private void btnSubmitQuestions_Click(object sender, EventArgs e)
        {
            if (currentLearnerID <= 0 || currentSessionID <= 0)
            {
                MessageBox.Show(
                    "Please submit the learner information first.");
                return;
            }

            if (cmbFaculty.SelectedIndex == -1 ||
                cmbQualification.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a faculty and qualification first.");
                return;
            }

            var responses = new List<LearnerInterestResponse>();

            foreach (Control control in flowQuestions.Controls)
            {
                if (control is NumericUpDown rating && rating.Tag != null)
                {
                    responses.Add(new LearnerInterestResponse
                    {
                        LearnerID = currentLearnerID,
                        InterestQuestionID = Convert.ToInt32(rating.Tag),
                        ResponseValue = (int)rating.Value
                    });
                }
            }

            if (responses.Count == 0)
            {
                questionsLoaded = false;
                LoadQuestions();

                MessageBox.Show(
                    "No answers found. Please answer the questions on the questionnaire tab.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                var dataAccess = new AdvisorySessionDataAccess();

                // Save responses against the current advisory session.
                dataAccess.SaveResponses(
                    currentLearnerID,
                    currentSessionID,
                    responses);

                // Calculate programme matches.
                DataTable scores = GetAlignmentScores(
                    currentLearnerID,
                    currentSessionID);

                string resultText = "Your best matches:\n";

                for (int i = 0; i < Math.Min(3, scores.Rows.Count); i++)
                {
                    resultText += (i + 1) + ". " +
                        scores.Rows[i]["ProgrammeName"] + "\n";
                }

                if (scores.Rows.Count == 0)
                {
                    resultText +=
                        "No matches were found. Please check the interest mappings.";
                }

                MessageBox.Show(resultText, "Interest Results");

                MessageBox.Show(
                    "Questionnaire submitted successfully.\nSession ID: "
                    + currentSessionID,
                    "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not submit the questionnaire:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateLearner())
                return;

            Learner learner = new Learner(
                txtLearnerName.Text,
                txtLearnerSurname.Text,
                cmbGrade.Text,
                txtSchool.Text,
                cmbProvince.Text,
                txtEmail.Text
            );

            try
            {
                // 1. Save the learner.
                learnerManager.AddLearner(learner);
                currentLearnerID = SaveLearner(learner);

                // 2. Create one advisory session.
                AdvisorySessionDataAccess dataAccess =
                    new AdvisorySessionDataAccess();

                currentSessionID = dataAccess.SaveSession(currentLearnerID);

                // 3. Save the learner's subjects and marks.
                SaveSubjectMarks(currentLearnerID, currentSessionID);

                MessageBox.Show(
                    "Learner and subject marks saved successfully!");

                // 4. Continue to the questionnaire.
                FuturePathTabControl.SelectedTab = tabQuestionnaire;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not save the learner information:\n" + ex.Message
                );
            }
        }
        


        private int GetSelectedDegreeProgrammeID()
        {
            string qualification = cmbQualification.Text.Trim();

            string programmeName = null;

            if (qualification.Contains("Bachelor of Commerce"))
                programmeName = "Bachelor of Commerce";
            else if (qualification.Contains("Bachelor of Business Science") ||
                     qualification.StartsWith("BBusSci") ||
                     qualification.StartsWith("BCom"))
                programmeName = "Bachelor of Business Science";
            else if (qualification.Contains("Bachelor of Social Science") ||
                     qualification.StartsWith("BSocSci"))
                programmeName = "Bachelor of Social Science";
            else if (qualification.Contains("Bachelor of Arts") ||
                     qualification.StartsWith("BA in"))
                programmeName = "Bachelor of Arts";
            else if (qualification.Contains("BSc Engineering") ||
                     qualification.Contains("BSc Construction Studies") ||
                     qualification.Contains("BSc Property Studies") ||
                     qualification.Contains("BSc Architectural Studies") ||
                     qualification.Contains("BSc Geomatics"))
                programmeName = "Bachelor of Science in Engineering";
            else if (qualification.Contains("Bachelor of Sciences"))
                programmeName = "Bachelor of Science";
            else if (qualification.Contains("Physiotherapy") ||
                     qualification.Contains("Occupational Therapy") ||
                     qualification.Contains("Audiology") ||
                     qualification.Contains("Speech-Language Pathology") ||
                     qualification.Contains("MBChB"))
                programmeName = "Bachelor of Health Sciences";

            if (programmeName == null)
                return 0;

            const string sql = @"
        SELECT DegreeProgrammeID
        FROM dbo.DegreeProgramme
        WHERE ProgrammeName = @ProgrammeName
          AND IsActive = 1;";

            using (var conn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ProgrammeName", programmeName);
                conn.Open();

                object result = cmd.ExecuteScalar();

                return result == null || result == DBNull.Value
                    ? 0
                    : Convert.ToInt32(result);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

        

    }
}
