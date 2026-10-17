using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2.Business
{//handles recommendation and advisory logic
    internal class RecommendationManager
    {
        //check if the learner has physics
        public bool HasPhysicalSciences(string subject1, string subject2, string subject3)
        {
            return subject1.Contains("Physical") ||
                   subject2.Contains("Physical") ||
                   subject3.Contains("Physical");
        }
        //check if learner has life sciences
        public bool HasLifeScience(string subject1, string subject2, string subject3)
        {
            return subject1.Contains("Life") ||
                   subject2.Contains("Life") ||
                   subject3.Contains("Life");
        }
        //check if learner has mathematics
        public bool HasMathematics(string mathsType)
        {
            return mathsType == "Mathematics";
        }
        //get physics mark
        private int GetPhysicalScienceMark(string subject1, string subject2, string subject3, string mark1,
                                           string mark2, string mark3)

        {
            if (subject1.Contains("Physical"))
            {
                return Convert.ToInt32(mark1);
            }
            if (subject2.Contains("Physical"))
            {
                return Convert.ToInt32(mark2);
            }
            if (subject3.Contains("Physical"))
            {
                return Convert.ToInt32(mark3);
            }
            return 0;
        }

        private int GetLifeScienceMark(string subject1, string subject2, string subject3, string mark1,
                                           string mark2, string mark3)
        {
            if (subject1.Contains("Life"))
                return Convert.ToInt32(mark1);

            if (subject2.Contains("Life"))
                return Convert.ToInt32(mark2);

            if (subject3.Contains("Life"))
                return Convert.ToInt32(mark3);

            return 0;
        }


        //Engineering
        public AdvisoryResult GenerateEngineeringOutcome(string mathsType, bool hasPhysicalScience, int physicalScienceMark, int mathsMark, double average)
        {
            AdvisoryResult result = new AdvisoryResult();
            //Mathematics is required
            if (mathsType != "Mathematics")
            {
                result.EligibilityResult = "Not Currently Eligible";
                result.Reason = "Engineering programmes require Mathematics";
                result.IdentifiedGaps = "Mathematical Literacy or Technical Mathematics is not accepted";

            }
            //physics subject 
            else if (!hasPhysicalScience)
            {
                result.EligibilityResult = "Possible Match";
                result.Reason = "Physical Sciences is required for Engineering.";
                result.IdentifiedGaps = "Physical Sciences subject is required.";
            }
            //physics mark is below what is needed
            else if (physicalScienceMark < 60)
            {
                result.EligibilityResult = "Possible Match";
                result.Reason = "Physical Sciences mark is below the recommended level.";
                result.IdentifiedGaps = " Improve Physical Sciences performnce.";
            }
            else if (mathsMark >= 70 && average >= 60)
            {
                result.EligibilityResult = "Strong Match";
                result.Reason = " Engineering requirments have been met.";
                result.IdentifiedGaps = " No major academic gaps identified.";
            }
            else
            {
                result.EligibilityResult = "Not Currently Eligible";
                result.Reason = "Engineering requires strong Mathematics.";
                result.IdentifiedGaps = " Improve Mathematic performance.";
            }
            return result;


        }
        //Commerce
        public AdvisoryResult GenerateCommerceOutcome(int mathsMark)
        {
            AdvisoryResult result = new AdvisoryResult();
            if (mathsMark >= 50)
            {
                result.EligibilityResult = "Strong Match";
                result.Reason = "Commerce requirements have been met.";
                result.IdentifiedGaps = " No major gaps identified.";
            }
            else
            {
                result.EligibilityResult = "Possible Match";
                result.Reason = "Commerce programmes recommend stronger Mathematics results.";
                result.IdentifiedGaps = " Improve Mathematics performance.";
            }
            return result;
        }
        //Humanities
        public AdvisoryResult GenerateHumanitiesOutcome(int homeLanguageMark)
        {
            AdvisoryResult result = new AdvisoryResult();
            if (homeLanguageMark >= 50)
            {
                result.EligibilityResult = "Strong Match";
                result.Reason = "Language Requirement has been met.";
                result.IdentifiedGaps = " No major gaps identified.";
            }
            else
            {
                result.EligibilityResult = "Possible Match";
                result.Reason = "Home Language mark is below the requirement.";
                result.IdentifiedGaps = " Improve Home Language.";
            }
            return result;

        }
        //Science
        public AdvisoryResult GenerateScienceOutcome(bool hasMathematics, bool hasPhysicalScience, int physicalScienceMark, int mathsMark, int average)
        {
            AdvisoryResult result = new AdvisoryResult();
            {
                //Mathematics required
                if (!hasMathematics)
                {
                    result.EligibilityResult = "Not Currently Eligible";
                    result.Reason = "Science programmes require Mathematics.";
                    result.IdentifiedGaps = "Mathematics subject is required.";
                }
                //Physics required
                else if (!hasPhysicalScience)
                {
                    result.EligibilityResult = "Possible Match";
                    result.Reason = "Physical Sciences is required for Science programmes.";
                    result.IdentifiedGaps = "Physical Sciences is a required subject.";
                }
                //subjects exist but mark is below needed criteria
                else if (physicalScienceMark < 60)
                {
                    result.EligibilityResult = "Possible Match";
                    result.Reason = "Physical Sciences mark is below the recommended level.";
                    result.IdentifiedGaps = "Improve Physical Sciences performance.";
                }
                //strong match
                else if (mathsMark >= 60 && average >= 55)
                {
                    result.EligibilityResult = "Strong Match";
                    result.Reason = "Science requirements have been met.";
                    result.IdentifiedGaps = "No major academic gaps identified.";
                }
                else
                {
                    result.EligibilityResult = "Possible Match";
                    result.Reason = "Science programmes requires stronger mathematics.";
                    result.IdentifiedGaps = "Improve Mathematic Performance.";
                }
                return result;
            }
        }
        //Health Science Faculty
        public AdvisoryResult GenerateHealthOutcome(bool hasMathematics, bool hasLifeScience, int lifeScienceMark, int mathsMark, int homeLanguageMark, int average)
        {
            AdvisoryResult result = new AdvisoryResult();
            //Life Sciences Missing
            if (!hasLifeScience)
            {
                result.EligibilityResult = "Possible Match";
                result.Reason = " Health Sciences generally requires Life Sciences.";
                result.IdentifiedGaps = "Life Science subject missing";
            }
            //maths is missing
            else if (!hasMathematics)
            {
                result.EligibilityResult = "Possible Match";
                result.Reason = " Health Sciences generally requires Mathematics.";
                result.IdentifiedGaps = "Mathematics subject is needed";
            }
            //Life Science mark below what is needed
            else if (lifeScienceMark < 60)
            {
                result.EligibilityResult = "Possible Match";
                result.Reason = " Life Sciences mark is below the recommended level.";
                result.IdentifiedGaps = "Improve Life Science performance.";
            }
            //math mark below what is needed
            else if (mathsMark < 60)
            {
                result.EligibilityResult = "Possible Match";
                result.Reason = "Mathematics is below recommended level.";
                result.IdentifiedGaps = "Improve Mathematics performance.";
            }
            //strong match
            else if (mathsMark >= 60 && homeLanguageMark >= 50 && average >= 60)
            {
                result.EligibilityResult = "Strong Match";
                result.Reason = "Health Science requirement have been met.";
                result.IdentifiedGaps = "No major academic gaps identified.";
            }
            //anything else
            else
            {
                result.EligibilityResult = "Possible Match";
                result.Reason = "Some Health Science requirements need improvement .";
                result.IdentifiedGaps = "Improve Mathematics and Language performance.";
            }
            return result;
        }
        public AdvisoryResult GenerateLawOutcome(int homeLanguageMark)
        {
            AdvisoryResult result = new AdvisoryResult();
            if (homeLanguageMark >= 60)
            {
                result.EligibilityResult = "Strong Match";
                result.Reason = "Language requirement for Law has been met.";
                result.IdentifiedGaps = "No major academic gaps identified.";
            }
            else
            {
                result.EligibilityResult = "Possible Match";
                result.Reason = "Law programmes require strong language performace.";
                result.IdentifiedGaps = "Improve Home Language.";
            }
            return result;
        }
    }
}

                

    




       
        
        
           



                
                
                
                
                
     
 


            



        
