using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Project_BlueLock.Data
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
    }
}
