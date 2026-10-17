using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2
{
    internal class AdvisorySession
    {
        public int AdvisorySessionID { get; set; }
        public int LearnerID { get; set; }
        public int DegreeProgrammeID { get; set; }
        public DateTime SessionDate { get; set; }
        public string OverallOutcome { get; set; }
    }
}
