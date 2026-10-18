using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2.Business
{
    //generate programme recommendations
    internal class AlternativeProgrammeManager
    {
        public AlternativeProgrammeResult
              GetAlternativeProgrammeResult(
                            string faculty,
                            string eligibiltyResult)
        {
            AlternativeProgrammeResult result =
                new AlternativeProgrammeResult();
            //engineering alternatives
            if (faculty.Contains("Engineering") && eligibiltyResult != "Strong Match")
            {
                result.RecommendedProgrammes = "Bachelor of Commerce\n" + "Bachelor of Arts";
                result.Explanation = "Engineering requirements were not met.";
            }
            //science alternatives
            else if (faculty.Contains("Science") && eligibiltyResult != "Strong Match")
            {
                result.RecommendedProgrammes = "Bachelor of Commerce\n" + "Bachelor of Arts";
                result.Explanation = "Science requirements were not fully met.";
            }
            //Health Science alternative
            else if (faculty.Contains("Health") && eligibiltyResult != "Strong Match")
            {
                result.RecommendedProgrammes = "Bachelor of Science\n" + "Bachelor of Arts";
                result.Explanation = "Health Science requirements were not fully met.";

            }
            //Law alternative
            else if (faculty.Contains("Law") && eligibiltyResult != "Strong Match")
            {
                result.RecommendedProgrammes = "Bachelor of Arts";
                result.Explanation = "Humanities-related programmes are recommended.";
            }
            //No alternative required
            else
            {
                result.RecommendedProgrammes = "No alternative programme required";
                result.Explanation = "Requirement for selected faculty have been met.";

            }
            return result;
       
            



        }

    }
}
