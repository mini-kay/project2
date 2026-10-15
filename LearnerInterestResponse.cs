using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2
{
    public class LearnerInterestResponse
    {
        public int LearnerInterestResponseID { get; set; }
        public int LearnerID { get; set; }
        public int InterestQuestionID { get; set; }
        public int AdvisorySessionID { get; set; }
        public int ResponseValue { get; set; }
    }
}
