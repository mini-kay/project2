using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace project2
{
    public class InterestQuestionDataAccess
    {
        private readonly DatabaseHelper databaseHelper = new DatabaseHelper();

        public List<InterestQuestion> GetAllQuestions()
        {
            var questions = new List<InterestQuestion>();

            const string query = @"
                SELECT InterestQuestionID, InterestCategoryID, QuestionText
                FROM dbo.InterestQuestion
                WHERE IsActive = 1
                ORDER BY InterestQuestionID;";


            using (SqlConnection  connection = databaseHelper.GetConnection())
            using (SqlCommand command = new SqlCommand (query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        questions.Add(new InterestQuestion
                        {
                            InterestQuestionID = (int)reader["InterestQuestionID"],
                            InterestCategoryID = (int)reader["InterestCategoryID"],
                            QuestionText = reader["QuestionText"].ToString()
                        });
                    }
                }
            }
            return questions;
        }
    }
}
