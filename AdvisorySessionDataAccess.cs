using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace project2
{
    public class AdvisorySessionDataAccess
    {
        private readonly DatabaseHelper databaseHelper = new DatabaseHelper();

        public int SaveSession(int learnerID, List<LearnerInterestResponse> responses)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    int sessionID;
                    using (var cmd = new SqlCommand(
                        "INSERT INTO dbo.AdvisorySession (LearnerID, SessionDate) " +
                        "OUTPUT INSERTED.AdvisorySessionID VALUES (@LearnerID, GETDATE())",
                        connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@LearnerID", learnerID);
                        sessionID = (int)cmd.ExecuteScalar();
                    }

                    foreach (var response in responses)
                    {
                        using (var cmd = new SqlCommand(
                            "INSERT INTO dbo.LearnerInterestResponse " +
                            "(LearnerID, InterestQuestionID, AdvisorySessionID, ResponseValue) " +
                            "VALUES (@L, @Q, @S, @V);", connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@L", learnerID);
                            cmd.Parameters.AddWithValue("Q", response.InterestQuestionID);
                            cmd.Parameters.AddWithValue("@S", sessionID);
                            cmd.Parameters.AddWithValue("@V", response.ResponseValue);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                    return sessionID;
                }
            }
        }
    }
}
