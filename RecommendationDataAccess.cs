
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace project2
{
    public class RecommendationDataAccess
    {
        private readonly DatabaseHelper databaseHelper;

        public RecommendationDataAccess()
        {
            databaseHelper = new DatabaseHelper();
        }

        public List<Recommendation> GetRecommendationsBySession(
            int advisorySessionID)
        {
            List<Recommendation> recommendations =
                new List<Recommendation>();

            string query = @"
                SELECT
                    rr.RecommendationResultID,
                    rr.AdvisorySessionID,
                    dp.ProgrammeName,
                    rr.SubjectMatchScore,
                    rr.MarkMatchScore,
                    rr.InterestMatchScore,
                    rr.FacultyPreferenceScore,
                    rr.OverallScore,
                    rr.IsAlternative,
                    rr.GapExplanation
                FROM dbo.RecommendationResult AS rr
                INNER JOIN dbo.DegreeProgramme AS dp
                    ON dp.DegreeProgrammeID = rr.DegreeProgrammeID
                WHERE rr.AdvisorySessionID = @AdvisorySessionID
                ORDER BY rr.OverallScore DESC;";

            using (SqlConnection connection =
                   databaseHelper.GetConnection())
            using (SqlCommand command =
                   new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue(
                    "@AdvisorySessionID", advisorySessionID);

                connection.Open();

                using (SqlDataReader reader =
                       command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Recommendation recommendation =
                            new Recommendation
                            {
                                RecommendationResultID =
                                    Convert.ToInt32(reader["RecommendationResultID"]),

                                AdvisorySessionID =
                                    Convert.ToInt32(reader["AdvisorySessionID"]),

                                ProgrammeName =
                                    reader["ProgrammeName"].ToString(),

                                SubjectMatchScore =
                                    Convert.ToInt32(reader["SubjectMatchScore"]),

                                MarkMatchScore =
                                    Convert.ToInt32(reader["MarkMatchScore"]),

                                InterestMatchScore =
                                    Convert.ToInt32(reader["InterestMatchScore"]),

                                FacultyPreferenceScore =
                                    Convert.ToInt32(reader["FacultyPreferenceScore"]),

                                OverallScore =
                                    Convert.ToInt32(reader["OverallScore"]),

                                IsAlternative =
                                    Convert.ToBoolean(reader["IsAlternative"]),

                                GapExplanation =
                                    reader["GapExplanation"] == DBNull.Value
                                    ? ""
                                    : reader["GapExplanation"].ToString()
                            };

                        recommendations.Add(recommendation);
                    }
                }
            }

            return recommendations;
        }
    }
}
