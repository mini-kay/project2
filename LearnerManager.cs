using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2
{

    public class LearnerManager 
    {
        private List<Learner> learners;
        public LearnerManager()
        {
            learners = new List<Learner>();
        }
        public void AddLearner(Learner learner)
        {
            learners.Add(learner);
        }
        public string DisplayLearners()
        {
            string output = " ";
            foreach (Learner learner in learners)
            {
                output += learner.ToString() + "\n\n";
            }
            return output;
        }
    }
}
