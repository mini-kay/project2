using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2
{
    public class Learner
    {
     
        private string _firstName;
        private string _lastName;
        private string _grade;
        private string _schoolName;
        private string _province;

        public string _email;
        private string _faculty;
        private string _qualification;
    

       
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }
        public string SchoolName
        {
            get { return _schoolName; }
            set { _schoolName = value; }
        }
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Faculty
        {
            get { return _faculty; }
            set { _faculty = value; }
        }
        public string Qualification
        {
            get { return _qualification; }
            set { _qualification = value; }
        }

        public Learner()
        { 
            _firstName = string.Empty;
            _lastName = string.Empty;
            _grade = string.Empty;
            _schoolName = string.Empty;
            _province = string.Empty;
            _email = string.Empty;
            _faculty = string.Empty;
            _qualification = string.Empty;

        }
        public  Learner(string firstName, string lastName,string grade, string schoolName, string province ,string email,
                         string faculty, string qualification)
        {
            
            _firstName = firstName;
            _lastName = lastName;
            _grade = grade;
            _schoolName = schoolName;
            _province = province;
            _email = email;
            _faculty = faculty;
            _qualification = qualification;
            

        }

        public override string ToString()
        {
            return $"First Name: {_firstName}\n" + $"Last Name: {_lastName}\n" +
                    $"Grade: {_grade}\n" + $"School Name: {_schoolName}\n" +
                    $"Province: {_province}\n" + $"Email: {_email}\n" +
                    $"Faculty: {_faculty}\n" + $"Qualification: {_qualification}\n";
        }
    }
}
