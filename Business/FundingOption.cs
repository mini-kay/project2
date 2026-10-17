using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2
{
    public class FundingOption
    {
        public int FundingOptionID { get; set; }
        public string FundingName { get; set; }
        public string FundingType { get; set; }
        public string EligibilityDescription { get; set; }
        public string ClosingDate { get; set; } //this is stored as a varchar
        public string RequiredDocuments { get; set; }
        public string ContactInfo { get; set; }
        public string FundingBasis { get; set; }
        public string LinkedFaculty { get; set; }
        public override string ToString() { return FundingName; }
    }
}