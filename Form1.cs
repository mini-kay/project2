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

        private Learner learner;
        private RecommendationManager recommendationManager = new RecommendationManager();
        private FundingManager fundingManager = new FundingManager();


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

            radLearner.Checked = false;
            radCareerAdvisor.Checked = false;
            radAdministrator.Checked = false;
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

        //check that a subject has been selected
        private bool ValidateSubject(ComboBox cmbSubject, string subjectName)
        {
            if (cmbSubject.SelectedIndex == -1)
            {
                MessageBox.Show("Please select " + subjectName, "Missing info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSubject.Focus();
                return false;
            }
            return true;
        }
        //prevents duplicates
        private bool ValidateDuplicateSubjects()
        {
            List<string> subjects = new List<string>()
            {
                cmbHomeLanguage.Text,
                cmbFAL.Text,
                cmbMaths.Text,
                cmbSubject1.Text,
                cmbSubject2.Text,
                cmbSubject3.Text
            };
            subjects = subjects.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            if (subjects.Count != subjects.Distinct().Count())
            {
                MessageBox.Show("Duplicate subjects are not allowed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        //validate mark textboxes
        private bool ValidateMark(TextBox txtMark, string subject)
        {
            int mark;
            if (string.IsNullOrWhiteSpace(txtMark.Text))
            {
                MessageBox.Show("Please enter a mark for " + subject, "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMark.Focus();
                return false;

            }
            if (!int.TryParse(txtMark.Text, out mark))
            {
                MessageBox.Show("Mark must be a number " ,"Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMark.Focus();
                return false;
            }
            if (mark < 0 || mark > 100)
            {
                MessageBox.Show("Mark must be between 0 and 100 ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMark.Focus();
                return false;

            }
            return true;
        }
        //Display learner advisory outcomes
        //method populates the advisory outcome tab
        //using the learner's qualification and marks
        private void DisplayAdvisoryOutcome()
        {
            int physicalScienceMark = recommendationManager.GetPhysicalScienceMark(
                                      cmbSubject1.Text,
                                      cmbSubject2.Text,
                                      cmbSubject3.Text,
                                      txtMark1.Text,
                                      txtMark2.Text,
                                      txtMark3.Text);
            int lifeScienceMark = recommendationManager.GetLifeScienceMark(
                                      cmbSubject1.Text,
                                      cmbSubject2.Text,
                                      cmbSubject3.Text,
                                      txtMark1.Text,
                                      txtMark2.Text,
                                      txtMark3.Text);
            //show the qualification selected by the learner
            txtQualifications.Text = learner.Qualification;

            //get qualification and marks
            string faculty = learner.Faculty;

            //get the type of maths that was selected
            string mathsType = cmbMaths.Text;

            //get learner marks
            int mathsMark = Convert.ToInt32(txtMarkMaths.Text);
            int homeLanguageMark = Convert.ToInt32(txtMarkHL.Text);

            //calculate learner average 
            int average = recommendationManager.CalculateAverage(Convert.ToInt32(txtMarkHL.Text),
                                                                 Convert.ToInt32(txtMarkFAL.Text),
                                                                 Convert.ToInt32(txtMarkMaths.Text),
                                                                 Convert.ToInt32(txtMarkLO.Text),
                                                                 Convert.ToInt32(txtMark1.Text),
                                                                 Convert.ToInt32(txtMark2.Text),
                                                                 Convert.ToInt32(txtMark3.Text));
                                                                 
                                                                 

            //display average in Interest alignment box
            txtInterestAlign.Text = "Overall Average: " + average + " %";



            //check qualification requirements

            //Engineering Faculty

            if (faculty.Contains("Engineering"))
            {
                AdvisoryResult result = recommendationManager.GenerateEngineeringOutcome(
                                        mathsType,
                                        recommendationManager.HasPhysicalSciences(cmbSubject1.Text, cmbSubject2.Text,
                                        cmbSubject3.Text),
                                        physicalScienceMark,
                                        mathsMark,
                                        average);
                txtEligibilityResult.Text = result.EligibilityResult;
                txtReason.Text = result.Reason;
                txtIdentifiedGaps.Text = result.IdentifiedGaps;
            }
            //Commerce Faculty
            else if (faculty.Contains("Commerce"))
            {
                AdvisoryResult result = recommendationManager.GenerateCommerceOutcome(mathsMark);
                txtEligibilityResult.Text = result.EligibilityResult;
                txtReason.Text = result.Reason;
                txtIdentifiedGaps.Text = result.IdentifiedGaps;
            }

            //Humanities Faculty
            else if (faculty.Contains("Humanities"))
            {
                AdvisoryResult result = recommendationManager.GenerateHumanitiesOutcome(homeLanguageMark);
                txtEligibilityResult.Text = result.EligibilityResult;
                txtReason.Text = result.Reason;
                txtIdentifiedGaps.Text = result.IdentifiedGaps;

            }

            //Health Science Faculty
            else if (faculty.Contains("Health"))
            {
                AdvisoryResult result = recommendationManager.GenerateHealthOutcome(
                                        HasMathematics(),
                                        HasLifeScience(),
                                        lifeScienceMark,
                                        mathsMark,
                                        homeLanguageMark,
                                        average);
                txtEligibilityResult.Text = result.EligibilityResult;
                txtReason.Text = result.Reason;
                txtIdentifiedGaps.Text = result.IdentifiedGaps;
            }

            // Science Faculty

            else if (faculty.Contains("Science"))
            {
                AdvisoryResult result = recommendationManager.GenerateScienceOutcome(
                                        HasMathematics(),
                                        HasPhysicalSciences(),
                                        physicalScienceMark,
                                        mathsMark,
                                        average);
                txtEligibilityResult.Text = result.EligibilityResult;
                txtReason.Text = result.Reason;
                txtIdentifiedGaps.Text = result.IdentifiedGaps;

            }

            //Law faculty
            else if (faculty.Contains("Law"))
            {
                AdvisoryResult result = recommendationManager.GenerateLawOutcome(
                                        homeLanguageMark);
                txtEligibilityResult.Text = result.EligibilityResult;
                txtReason.Text = result.Reason;
                txtIdentifiedGaps.Text = result.IdentifiedGaps;
            }

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

            else if (radCareerAdvisor.Checked)
            {
                Career_Advisor careerAdvisorForm = new Career_Advisor();
                careerAdvisorForm.Show();
                this.Hide();
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


        private void FuturePathTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FuturePathTabControl.SelectedTab == tabQuestionnaire)
            {
                LoadQuestions();
            }
        }

        private void btnSubmitQuestions_Click(object sender, EventArgs e)
        {
            if (currentLearnerID <= 0 || currentSessionID <= 0)
            {
                MessageBox.Show(
                    "Please submit the learner information first.");
                return;
            }

            if (cmbFaculty.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a faculty first.");
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
                MessageBox.Show(
                    "Please complete the interest questionnaire.");
                return;
            }

            try
            {
                var dataAccess = new AdvisorySessionDataAccess();

                // 1. Save the questionnaire responses.
                dataAccess.SaveResponses(
                    currentLearnerID,
                    currentSessionID,
                    responses);

                // 2. Calculate programme matches.
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

                //filling in advisory results then immediately showing tab
                DisplayAdvisoryOutcome();
                FuturePathTabControl.SelectedTab = tabAdvisoryOutcome;
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

        private void tabLearnerInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
        }
            private void btnClearAll_Click(object sender, EventArgs e)
        {
            // Learner information
            txtLearnerName.Clear();
            txtLearnerSurname.Clear();
            txtSchool.Clear();
            txtEmail.Clear();

            // ComboBoxes
            cmbGrade.SelectedIndex = -1;
            cmbProvince.SelectedIndex = -1;
            cmbFaculty.SelectedIndex = -1;
            cmbQualification.SelectedIndex = -1;

            cmbHomeLanguage.SelectedIndex = -1;
            cmbFAL.SelectedIndex = -1;
            cmbMaths.SelectedIndex = -1;

            cmbSubject1.SelectedIndex = -1;
            cmbSubject2.SelectedIndex = -1;
            cmbSubject3.SelectedIndex = -1;

            // Marks
            txtMarkHL.Clear();
            txtMarkFAL.Clear();
            txtMarkMaths.Clear();
            txtMarkLO.Clear();
            txtMark1.Clear();
            txtMark2.Clear();
            txtMark3.Clear();

            // Put cursor back in first textbox
            txtLearnerName.Focus();
        }

        

        private void btnBack1_Click(object sender, EventArgs e)
        {
            //Return to questionnaire tab
            FuturePathTabControl.SelectedTab = tabQuestionnaire;
        }
        #region Faculty Linking
        private string GetFundingFacultyKeyword()
        {
            string faculty = learner.Faculty;
            if (faculty.Contains("Engineering")) return "Engineering and the Built Environment";
            if (faculty.Contains("Commerce")) return "Commerce";
            if (faculty.Contains("Humanities")) return "Humanities";
            if (faculty.Contains("Health")) return "Health Sciences";
            if (faculty.Contains("Science")) return "Science";
            if (faculty.Contains("Law")) return "Law";
            return faculty;
        }
        #endregion
        private void rdbYes_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdbYes.Checked) return;

            lbFundingType.DataSource = null;
            txtFundingDetails.Clear();
            var options = fundingManager.GetFundingForFaculty(GetFundingFacultyKeyword());

            if (options.Count == 0)
            {
                txtFundingDetails.Text = "No funding options are curently open for this faculty.";
                return;
            }
            lbFundingType.DataSource = options;
            lbFundingType.DisplayMember = "FundingName";
        }

        private void rdbNo_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdbNo.Checked) return;
            lbFundingType.DataSource = null;
            txtFundingDetails.Clear();
        }

        private void lbFundingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var f  = lbFundingType.SelectedItem as FundingOption;
            if (f == null) return;

            txtFundingDetails.Text =
                "Type: " + f.FundingType + "\r\n" +
                "Faculty: " + f.LinkedFaculty + "\r\n" +
                "Based on: " + f.FundingBasis + "\r\n" +
                "Eligibility: " + f.EligibilityDescription + "\r\n" +
                "Required documents: " + f.RequiredDocuments + "\r\n" +
                "Closing date: " + (string.IsNullOrEmpty(f.ClosingDate) ? "Not specified" :
                f.ClosingDate) + "\r\n" +
                "Contact: " + f.ContactInfo;
        }

        private void btnContinueToFunding_Click(object sender, EventArgs e)
        {
            //Reset the funding screen so that it starts fresh each time
            rdbYes.Checked = false;
            rdbNo.Checked = false;
            lbFundingType.DataSource = null;
            txtFundingDetails.Clear();

            FuturePathTabControl.SelectedTab = tabFundingInfo;
        }

        private void btnBackFunding_Click(object sender, EventArgs e)
        {
            FuturePathTabControl.SelectedTab = tabAdvisoryOutcome;
        }
        private void radCareerAdvisor_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
