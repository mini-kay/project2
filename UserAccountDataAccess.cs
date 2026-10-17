
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



            catch (SqlException ex)
            {
                if (ex.Number == 2601 || ex.Number == 2627)
                {
                    throw new InvalidOperationException(
                        "An account with this username already exists. " +
                        "Please choose another username.", ex);
                }

                throw;
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


        public DataTable GetAccounts()
        {
            string query = @"
        SELECT UserAccountID, Username, Role, IsActive
        FROM dbo.UserAccount
        ORDER BY Username;";

            DataTable table = new DataTable();

            using (SqlConnection connection = databaseHelper.GetConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(table);
            }

            return table;
        }

        public bool SetAccountActive(int userAccountID, bool isActive)
        {
            string query = @"
        UPDATE dbo.UserAccount
        SET IsActive = @IsActive
        WHERE UserAccountID = @UserAccountID;";

            using (SqlConnection connection = databaseHelper.GetConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@IsActive", SqlDbType.Bit)
                    .Value = isActive;

                command.Parameters.Add("@UserAccountID", SqlDbType.Int)
                    .Value = userAccountID;

                connection.Open();

                return command.ExecuteNonQuery() == 1;
            }
        }

    }
}
