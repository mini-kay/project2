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


        public int SaveSession(int learnerID)
        {
            if (learnerID <= 0)
                throw new ArgumentException("A valid learner ID is required.");

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                connection.Open();

                const string sql = @"
            INSERT INTO dbo.AdvisorySession
                (LearnerID, DegreeProgrammeID, SessionDate)
            OUTPUT INSERTED.AdvisorySessionID
            VALUES
                (@LearnerID, NULL, GETDATE());";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@LearnerID", learnerID);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void SaveResponses(
    int learnerID,
    List<LearnerInterestResponse> responses)
        {
            if (learnerID <= 0)
                throw new ArgumentException("A valid learner ID is required.");

            if (responses == null || responses.Count == 0)
                throw new ArgumentException("At least one response is required.");

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var response in responses)
                        {
                            const string sql = @"
                        INSERT INTO dbo.LearnerInterestResponse
                            (LearnerID, InterestQuestionID,
                             AdvisorySessionID, ResponseValue)
                        VALUES
                            (@LearnerID, @QuestionID, NULL, @ResponseValue);";

                            using (var cmd = new SqlCommand(
                                sql, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@LearnerID", learnerID);
                                cmd.Parameters.AddWithValue(
                                    "@QuestionID", response.InterestQuestionID);
                                cmd.Parameters.AddWithValue(
                                    "@ResponseValue", response.ResponseValue);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void LinkResponsesToSession(int learnerID, int sessionID)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                connection.Open();

                const string sql = @"
            UPDATE dbo.LearnerInterestResponse
            SET AdvisorySessionID = @SessionID
            WHERE LearnerID = @LearnerID
              AND AdvisorySessionID IS NULL;";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@LearnerID", learnerID);
                    cmd.Parameters.AddWithValue("@SessionID", sessionID);

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
