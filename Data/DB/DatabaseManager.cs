using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Project_BlueLock.Data.DB
{
    public class DatabaseManager
    {
        private readonly string connectionString;

        public DatabaseManager()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BlueLockDB"].ConnectionString;
        }

        public void InsertUser(string name, string surname, string username, string passwordHash)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string add_data = "INSERT INTO [dbo].Users (Name, Surname, Username, PasswordHash) VALUES (@Name, @Surname, @Username, @PasswordHash)";
                    SqlCommand cmd = new SqlCommand(add_data, con);

                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Surname", surname);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting user into the database: " + ex.Message, ex);
            }
        }

        public bool CheckUserCredentials(string username, string passwordHash)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string check_user = "SELECT COUNT(*) FROM [dbo].Users WHERE Username = @Username AND PasswordHash = @PasswordHash";
                    SqlCommand cmd = new SqlCommand(check_user, con);

                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                    int userCount = (int)cmd.ExecuteScalar();

                    return userCount > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking user credentials: " + ex.Message, ex);
            }
        }
    }
}
