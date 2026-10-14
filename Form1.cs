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

namespace project2
{
    public partial class FuturePathForm : Form
    {
        LearnerManager learnerManager = new LearnerManager();

        public FuturePathForm()
        {
            InitializeComponent();
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
            MessageBox.Show("Learner Added Successfully!!");





        }
    }
}
