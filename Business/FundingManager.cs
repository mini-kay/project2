using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace project2.Business
{
    internal class FundingManager
    {
        private const string ConnStr =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FuturePathDB;
            Integrated Security=True";

        private const string SelectPart = @"
            SELECT DISTINCT fo.FundingOptionID, fo.FundingName, fo.FundingType,
            fo.EligibilityDescription, fo.ClosingDate, fo.RequiredDocuments,
            fo.ContactInfo, fo.FundingBasis, fa.FacultyName
            FROM dbo.FundingOption fo
            JOIN dbo.FundingFaculty ff ON ff.FundingOptionID = fo.FundingOptionID
            JOIN dbo.Faculty fa ON fa.FacultyID = ff.FacultyID
            WHERE fo.IsActive = 1
                AND (fo.ClosingDate IS NULL OR TRY_CONVERT(date, fo.ClosingDate) >= CAST(GETDATE() AS DATE))";

        //Indicating the faculty that the learner chose
        public List<FundingOption> GetFundingForFaculty(string facultyName)
        {
            string sql = SelectPart + " AND fa.FacultyName LIKE @name + '%' ORDER BY fo.FundingName;";
            return Run(sql, new SqlParameter("@name", facultyName));
        }

        //Funding tied to one specific degree
        public List<FundingOption> GetFundingForDegree(int degreeProgrammeID)
        {
            const string sql = @"
                SELECT DISTINCT fo.FundingOptionID, fo.FundingName, fo.FundingType,
                fo.EligibilityDescription, fo.ClosingDate, fo.RequiredDocuments, fo.ContactInfo,
                fo.FundingBasis, fa.FacultyName
                FROM dbo.FundingOption fo
                JOIN dbo.DegreeProgramme dp ON dp.DegreeProgrammeID = @degreeID
                JOIN dbo.Faculty fa ON fa.FacultyID = dp.FacultyID
                LEFT JOIN dbo.FundingFaculty ff ON ff.FundingOptionID = fo.FundingOptionID
                LEFT JOIN dbo.FundingProgramme fp ON fp.FundingOptionID = fo.FundingOptionID
                WHERE fo.IsActive = 1
                    AND (fo.ClosingDate IS NULL OE TRY_CONVERT(date, fo.ClosingDate) >= CAST(GETDATE() AS DATE))
                    AND (ff.FacultyID = dp.FacultyID OR fp.DegreeProgrammeID = dp.DegreeProgrammeID)
                    ORDER BY fo.FundingName;";
            return Run(sql, new SqlParameter("@degreeID", degreeProgrammeID));
        }

        private List<FundingOption> Run(string sql, params SqlParameter[] parameters)
        {
            var results = new List<FundingOption>();
            using (var conn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(parameters);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        results.Add(new FundingOption
                        {
                            FundingOptionID = r.GetInt32(0),
                            FundingName = r.GetString(1),
                            FundingType = r.GetString(2),
                            EligibilityDescription = r.IsDBNull(3) ? "" : r.GetString(3),
                            ClosingDate = r.IsDBNull(4) ? "" : r.GetString(4),
                            RequiredDocuments = r.IsDBNull(5) ? "" : r.GetString(5),
                            ContactInfo = r.IsDBNull(6) ? "" : r.GetString(6),
                            FundingBasis = r.IsDBNull(7) ? "" : r.GetString(7),
                            LinkedFaculty = r.GetString(8)
                        });
                    }
                }
            }
            return results;
        }
    }
}
