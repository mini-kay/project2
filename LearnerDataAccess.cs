
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace project2
{
    public class LearnerDataAccess
    {
        private readonly DatabaseHelper databaseHelper;

        public LearnerDataAccess()
        {
            databaseHelper = new DatabaseHelper();
        }

        public List<Learner> GetAllLearners()
        {
            List<Learner> learners = new List<Learner>();

            string query = @"
                SELECT FirstName, LastName, Grade,
                       School, Province
                FROM dbo.Learner
                ORDER BY LastName, FirstName;";

            using (SqlConnection connection =
                   databaseHelper.GetConnection())
            using (SqlCommand command =
                   new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Learner learner = new Learner
                        {
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Grade = reader["Grade"].ToString(),
                            SchoolName = reader["School"].ToString(),
                            Province = reader["Province"].ToString()
                        };

                        learners.Add(learner);
                    }
                }
            }

            return learners;
        }
    }
}
