
using System;
using System.Data;
using System.Data.SqlClient;

namespace project2
{
    public class UserAccountDataAccess
    {
        private readonly DatabaseHelper databaseHelper;

        public UserAccountDataAccess()
        {
            databaseHelper = new DatabaseHelper();
        }

        public bool CreateAccount(
            string username, string password, string role)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
                return false;

            if (role != "Learner" &&
                role != "Career Advisor" &&
                role != "Administrator")
                return false;

            string passwordHash =
                PasswordHasher.HashPassword(password);

            string query = @"
                INSERT INTO dbo.UserAccount
                    (Username, PasswordHash, Role, IsActive)
                VALUES
                    (@Username, @PasswordHash, @Role, 1);";

            try
            {
                using (SqlConnection connection =
                    databaseHelper.GetConnection())
                using (SqlCommand command =
                    new SqlCommand(query, connection))
                {
                    command.Parameters.Add(
                        "@Username", SqlDbType.VarChar, 100
                    ).Value = username.Trim();

                    command.Parameters.Add(
                        "@PasswordHash", SqlDbType.VarChar, 255
                    ).Value = passwordHash;

                    command.Parameters.Add(
                        "@Role", SqlDbType.VarChar, 30
                    ).Value = role;

                    connection.Open();

                    return command.ExecuteNonQuery() == 1;
                }
            }
            catch (SqlException)
            {
                // For example, the username may already exist.
                return false;
            }
        }

        public bool VerifyLogin(
            string username, string password, out string role)
        {
            role = null;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrEmpty(password))
                return false;

            string query = @"
                SELECT PasswordHash, Role
                FROM dbo.UserAccount
                WHERE Username = @Username
                  AND IsActive = 1;";

            using (SqlConnection connection =
                databaseHelper.GetConnection())
            using (SqlCommand command =
                new SqlCommand(query, connection))
            {
                command.Parameters.Add(
                    "@Username", SqlDbType.VarChar, 100
                ).Value = username.Trim();

                connection.Open();

                using (SqlDataReader reader =
                    command.ExecuteReader())
                {
                    if (!reader.Read())
                        return false;

                    string storedHash =
                        reader["PasswordHash"].ToString();

                    string storedRole =
                        reader["Role"].ToString();

                    if (!PasswordHasher.VerifyPassword(
                        password, storedHash))
                        return false;

                    role = storedRole;
                    return true;
                }
            }
        }
    }
}
