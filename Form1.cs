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
using System.Diagnostics.Eventing.Reader;

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
        //check if the learner has physics
        private bool HasPhysicalSciences()
        {
            return cmbSubject1.Text.Contains("Physical") ||
                   cmbSubject2.Text.Contains("Physical") ||
                   cmbSubject3.Text.Contains("Physical");
        }
        //check if learner has life sciences
        private bool HasLifeScience()
        {
            return cmbSubject1.Text.Contains("Life") ||
                   cmbSubject2.Text.Contains("Life") ||
                   cmbSubject3.Text.Contains("Life");
        }
        //check if learner has mathematics
        private bool HasMathematics()
        {
            return cmbMaths.Text == "Mathematics";
        }
        //get physics mark
        private int GetPhysicalScienceMark()
        {
            if (cmbSubject1.Text.Contains("Physical"))
            {
                return Convert.ToInt32(txtMark1.Text);
            }
            if (cmbSubject2.Text.Contains("Physical"))
            {
                return Convert.ToInt32(txtMark2.Text);
            }
            if (cmbSubject3.Text.Contains("Physical"))
            {
                return Convert.ToInt32(txtMark3.Text);
            }
            return 0;
        }
        //get life science mark
        private int GetLifeScienceMark()
        {
            if (cmbSubject1.Text.Contains("Life"))
                return Convert.ToInt32(txtMark1.Text);
            if (cmbSubject2.Text.Contains("Life"))
                return Convert.ToInt32(txtMark2.Text);
            if (cmbSubject3.Text.Contains("Life"))
                return Convert.ToInt32(txtMark3.Text);
            return 0;
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

            // Convert Home Language abbreviations.
            if (dbSubjectName.EndsWith(" HL"))
            {
                dbSubjectName =
                    dbSubjectName.Substring(0, dbSubjectName.Length - 3)
                    + " Home Language";
            }
            // Convert First Additional Language abbreviations.
            else if (dbSubjectName.EndsWith(" FAL"))
            {
                dbSubjectName =
                    dbSubjectName.Substring(0, dbSubjectName.Length - 4)
                    + " First Additional Language";
            }

            // Match abbreviated names used in the subject dropdowns.
            switch (dbSubjectName)
            {
                case "Computer Applications Technology (CAT)":
                    dbSubjectName = "Computer Applications Technology";
                    break;

                case "Information Technology (IT)":
                    dbSubjectName = "Information Technology";
                    break;

                case "Engineering Graphics and Design (EGD)":
                    dbSubjectName = "Engineering Graphics and Design";
                    break;
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
                            + dbSubjectName);
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
                MessageBox.Show("Please enter First Name", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLearnerName.Focus();
                return false;
               
            }
            if (txtLearnerName.Text.Any(char.IsDigit))
            {
                MessageBox.Show("First name cannot contain digits", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLearnerName.Focus();
                return false;
            }
            if (txtLearnerSurname.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your Last Name", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLearnerSurname.Focus();
                return false;
            }
            if(txtLearnerSurname.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Last Name cannot contain digits", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLearnerSurname.Focus();
                return false;
            }
            if (cmbGrade.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a grade", "Missing info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGrade.Focus();
                return false;
            }
            
            if (txtSchool.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a School", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSchool.Focus();
                return false;
            }
            if (txtSchool.Text.Any(char.IsDigit))
            {
                MessageBox.Show("School Name cannot contain digits","Validation Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSchool.Focus();
                return false;
            }
            if (cmbProvince.Text == "")
            {
                MessageBox.Show("Please select a Province", "Missing info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProvince.Focus();
                return false;
            }
            if (txtEmail.Text != "" && !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Please enter a valid email address", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            //validate faculty
            if (cmbFaculty.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Faculty");
                cmbFaculty.Focus();
                cmbFaculty.Focus();
                return false;
            }
            //validate marks info
            if (!ValidateSubject(cmbHomeLanguage, "Home Language"))
            {
                return false;
            }
            if (!ValidateMark(txtMarkHL, "Home language"))
            {
                return false;
            }
            if (!ValidateSubject(cmbFAL, "First Additional Language"))
            {
                return false;
            }
            if (!ValidateMark(txtMarkFAL, "First Additional language"))
            {
                return false;
            }
            if (!ValidateSubject(cmbMaths, "Mathematics"))
            {
                return false;
            }
            if (!ValidateMark(txtMarkMaths, "Mathematics"))
            {
                return false;
            }
            if (!ValidateMark(txtMarkLO, "Life Orientation"))
            {
                return false;
            }
            if (!ValidateSubject(cmbSubject1, "Subject 1"))
            {
                return false;
            }
            if (!ValidateMark(txtMark1, "Subject 1"))
            {
                return false;
            }
            if (!ValidateSubject(cmbSubject2,"Subject 2"))
            {
                return false;
            }
            if (!ValidateMark(txtMark2, "Subject 2"))
            {
                return false;
            }
            if (!ValidateSubject(cmbSubject3, "Subject 3"))
            {
                return false;
            }
            if (!ValidateMark(txtMark3, "Subject 3"))
            {
                return false;
            }
            //adding duplicate checks
            if (!ValidateDuplicateSubjects())
            {
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
        //valdate mark textboxes
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
            int physicalScienceMark = GetPhysicalScienceMark();
            int lifeScienceMark = GetLifeScienceMark();
            //show the qualification selected by the learner
            txtQualifications.Text = cmbQualification.Text;

            //get qualification and marks
            string faculty = cmbFaculty.Text;

            //get the type of maths that was selected
            string mathsType = cmbMaths.Text;

            //get learner marks
            int mathsMark = Convert.ToInt32(txtMarkMaths.Text);
            int homeLanguageMark = Convert.ToInt32(txtMarkHL.Text);

            //calculate learner average (aps)
            int average = (
                Convert.ToInt32(txtMarkHL.Text) +
                Convert.ToInt32(txtMarkFAL.Text) +
                Convert.ToInt32(txtMarkMaths.Text) +
                Convert.ToInt32(txtMarkLO.Text) +
                Convert.ToInt32(txtMark1.Text) +
                Convert.ToInt32(txtMark2.Text) +
                Convert.ToInt32(txtMark3.Text)
                ) / 7;

            //display average in Interest alignment box
            txtInterestAlign.Text = "Overall Average: " + average + " %";



            //check qualification requirements
            
                //Engineering Faculty

                if (faculty.Contains("Engineering"))
                {
                //engineering reguires Mathematics
                if (mathsType != "Mathematics")
                {
                    txtEligibilityResult.Text = "Not Currently Eligible";
                    txtReason.Text = "Engineering programmes require Mathematics.";
                    txtIdentifiedGaps.Text = "Mathematical Literacy or Technical Mathematics is not accepted";
                }
                //physics subject is missing
                else if (!HasPhysicalSciences())
                {
                    txtEligibilityResult.Text = "Possible Match";
                    txtReason.Text = "Physical Sciences is recommended for Engineering.";
                    txtIdentifiedGaps.Text = "Physical Sciences subject is required.";
                }
                //physics mark is below what is needed
                else if (physicalScienceMark < 60)
                {
                    txtEligibilityResult.Text = "Possible Match";
                    txtReason.Text = "Physical Sciences mark is below the recommended level.";
                    txtIdentifiedGaps.Text = " Improve Physical Sciences performnce.";
                }
                //strong match
                    else if (mathsMark >= 70 && average >= 60)
                    {
                        txtEligibilityResult.Text = "Strong Match";
                        txtReason.Text = "Mathematics requirements have been met.";
                        txtIdentifiedGaps.Text = "No major academic gaps identified.";
                    }
                //math mark too low
                    else if (mathsMark >= 50)
                    {
                        txtEligibilityResult.Text = "Possible Match";
                        txtReason.Text = "Mathematics is below the preffered Engineering requirement.";
                        txtIdentifiedGaps.Text = "Improve Mathematics performance.";
                    }

                 //maths mark is too low
                    else
                    {
                        txtEligibilityResult.Text = "Not currently eligible";
                        txtReason.Text = "Engineering requires strong Mathematics result.";
                        txtIdentifiedGaps.Text = "Mathematics mark needs improvement.";

                    }


                }
                //Commerce Faculty
                else if (faculty.Contains("Commerce"))
                {
                    if (mathsMark >= 50)
                    {
                        txtEligibilityResult.Text = "Strong Match";
                        txtReason.Text = "Commerce requirements have been met.";
                        txtIdentifiedGaps.Text = "No major gaps identified.";
                    }
                    else
                    {
                        txtEligibilityResult.Text = "Possible Match";
                        txtReason.Text = "Commerce programmes recommend stronger Mathematics results.";
                        txtIdentifiedGaps.Text = "Improve Mathematics performance.";

                    }
                }
                //Humanities Faculty
                else if (faculty.Contains("Humanities"))
                {
                    if (homeLanguageMark >= 50)
                    {
                        txtEligibilityResult.Text = "Strong Match";
                        txtReason.Text = "Language Requirement has been met.";
                        txtIdentifiedGaps.Text = "No major gaps identified";
                    }
                    else
                    {
                        txtEligibilityResult.Text = "Possible Match";
                        txtReason.Text = "Home Language mark is below the requirement.";
                        txtIdentifiedGaps.Text = "Improve Home Language.";
                    }
                }
                // Science Faculty

                else if (faculty.Contains("Science"))
                {
                    //Science requires Mathematics
                    if (!HasMathematics())
                    {
                        txtEligibilityResult.Text = "Not Currently Eligible";
                        txtReason.Text = "Science programmes require Mathematics.";
                        txtIdentifiedGaps.Text = "Mathematics subject is required.";
                    }
                    //Physics is recommended
                    else if (!HasPhysicalSciences())
                    {
                        txtEligibilityResult.Text = "Possible Match";
                        txtReason.Text = "Physical Sciences is required for Science programmes.";
                        txtIdentifiedGaps.Text = "Physical Sciences is a required subject.";
                    }
                    //subjects exist but mark is below needed criteria
                    else if (physicalScienceMark < 60)
                    {
                        txtEligibilityResult.Text = "Possible Match";
                        txtReason.Text = "Physical Sciences mark is below the recommended level.";
                        txtIdentifiedGaps.Text = "Improve Physical Sciences performance.";
                    }
                    //strong match
                    else if (mathsMark >= 60 && average >= 55)
                    {
                        txtEligibilityResult.Text = "Strong Match";
                        txtReason.Text = "Science requirements have been met.";
                        txtIdentifiedGaps.Text = "No major academic gaps identified.";

                    }
                    else
                    {
                        txtEligibilityResult.Text = "Possible Match";
                        txtReason.Text = "Science programmes requires stronger mathematics.";
                        txtIdentifiedGaps.Text = "Improve Mathematic Performance.";
                    }
                }
                //Health Science Faculty


                else if (faculty.Contains("Health"))
                {
                //Life Sciences Missing
                if (!HasLifeScience())
                {
                    txtEligibilityResult.Text = "Possible Match";
                    txtReason.Text = " Health Sciences generally requires Life Sciences.";
                    txtIdentifiedGaps.Text = "Life Science subject missing";

                }
                else if (!HasMathematics())
                {
                    txtEligibilityResult.Text = "Possible Match";
                    txtReason.Text = " Health Sciences generally requires Mathematics.";
                    txtIdentifiedGaps.Text = "Mathematics subject is needed";
                }
                //Life Science mark below what is needed
                else if (lifeScienceMark < 60)
                {
                    txtEligibilityResult.Text = "Possible Match";
                    txtReason.Text = " Life Sciences mark is below the recommended level.";
                    txtIdentifiedGaps.Text = "Improve Life Science performance.";
                }
                //math mark below what is needed
                else if (mathsMark < 60)
                {
                    txtEligibilityResult.Text = "Possible Match";
                    txtReason.Text = "Mathematics is below recommended level.";
                    txtIdentifiedGaps.Text = "Improve Mathematics performance.";
                }
                //strong match
                else if (mathsMark >= 60 && homeLanguageMark >= 50 && average >= 60)
                {
                    txtEligibilityResult.Text = "Strong Match";
                    txtReason.Text = "Health Science requirement have been met.";
                    txtIdentifiedGaps.Text = "No major academic gaps identified.";
                }
                //anything else
                else 
                {
                    txtEligibilityResult.Text = "Possible Match";
                    txtReason.Text = "Some Health Science requirements need improvement .";
                    txtIdentifiedGaps.Text = "Improve Mathematics and Language performance.";
                }
                }
                //Law faculty
                else if (faculty.Contains("Law"))
                {
                    if (homeLanguageMark >= 60)
                    {
                        txtEligibilityResult.Text = "Strong Match";
                        txtReason.Text = "Language requirement for Law has been met.";
                        txtIdentifiedGaps.Text = "No major academic gaps identified.";
                    }
                    else
                    {
                        txtEligibilityResult.Text = "Possible Match";
                        txtReason.Text = "Law programmes require strong language performace.";
                        txtIdentifiedGaps.Text = "Improve Home Language.";
                    }
                }
                //Default outcome
                else
                {
                    txtEligibilityResult.Text = "More information needed";
                    txtReason.Text = "Faculty requirements could not be determined.";
                    txtIdentifiedGaps.Text = "Please select a faculty.";
                }
            }



      

        

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
            else if (radAdministrator.Checked)
            {
                using (Administrator adminForm = new Administrator())
                {
                    adminForm.ShowDialog();
                }
            }
            else if (radCareerAdvisor.Checked)
            {
                MessageBox.Show(
                    "Career Advisor login will be implemented later.",
                    "Coming Soon",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a role first.");
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
                learnerManager.AddLearner(learner);
                currentLearnerID = SaveLearner(learner);

                AdvisorySessionDataAccess dataAccess =
                    new AdvisorySessionDataAccess();

                currentSessionID = dataAccess.SaveSession(currentLearnerID);

                SaveSubjectMarks(currentLearnerID, currentSessionID);

                MessageBox.Show("Learner and subject marks saved successfully!");

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

        private void FuturePathTabControl_SelectedIndexChanged(
    object sender, EventArgs e)
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

        private void btnViewRecs_Click(object sender, EventArgs e)
        {
            //display Advisory Information
            DisplayAdvisoryOutcome();
        }

        private void btnBack1_Click(object sender, EventArgs e)
        {
            //Return to questionnaire tab
            FuturePathTabControl.SelectedTab = tabQuestionnaire;
        }
    }
    }

