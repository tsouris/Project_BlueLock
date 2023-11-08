using Project_BlueLock.Domain.Models;
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

        public void InsertPlayer(string height, string weight, string country, string birthday, string gender, string shooting, string dribbling, string passing, string physical, string touch, string pace, byte[] imagePath)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string add_data = "INSERT INTO [dbo].Player (Height, Weight, Country, Birthday, Gender, Shooting, Dribbling, Passing, Physical, Touch, Pace, ImagePath) VALUES (@Height, @Weight, @Country, @Birthday, @Gender, @Shooting, @Dribbling, @Passing, @Physical, @Touch, @Pace, @ImagePath)";
                    SqlCommand cmd = new SqlCommand(add_data, con);

                    cmd.Parameters.AddWithValue("@Height", height);
                    cmd.Parameters.AddWithValue("@Weight", weight);
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.Parameters.AddWithValue("@Birthday", birthday);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Shooting", shooting);
                    cmd.Parameters.AddWithValue("@Dribbling", dribbling);
                    cmd.Parameters.AddWithValue("@Passing", passing);
                    cmd.Parameters.AddWithValue("@Physical", physical);
                    cmd.Parameters.AddWithValue("@Touch", touch);
                    cmd.Parameters.AddWithValue("@Pace", pace);
                    cmd.Parameters.AddWithValue("@ImagePath", imagePath);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting player into the database: " + ex.Message, ex);
            }
        }

        public bool ValidateCredentials(string username, string password)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@PasswordHash", password);

                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error validating user credentials: " + ex.Message, ex);
            }
        }
    }
}
