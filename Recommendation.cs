using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace project2
{
    public class Recommendation
    {
        public int RecommendationResultID { get; set; }

        public int AdvisorySessionID { get; set; }

        public string ProgrammeName { get; set; }

        public int SubjectMatchScore { get; set; }

        public int MarkMatchScore { get; set; }

        public int InterestMatchScore { get; set; }

        public int FacultyPreferenceScore { get; set; }

        public int OverallScore { get; set; }

        public bool IsAlternative { get; set; }

        public string GapExplanation { get; set; }
    }
}
