using Microsoft.VisualBasic.ApplicationServices;
using Project_BlueLock.Domain.Models;
using Project_BlueLock.Models;
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

        public void InsertPlayer(string height, string weight, string country, string birthday, string gender, string shooting, string dribbling, string passing, string physical, string touch, string pace)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string add_data = "INSERT INTO [dbo].Player (Height, Weight, Country, Birthday, Gender, Shooting, Dribbling, Passing, Physical, Touch, Pace) VALUES (@Height, @Weight, @Country, @Birthday, @Gender, @Shooting, @Dribbling, @Passing, @Physical, @Touch, @Pace)";
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

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting player into the database: " + ex.Message, ex);
            }
        }

        //public int ValidateCredentialsAndGetUserId(string username, string password)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(connectionString))
        //        {
        //            con.Open();
        //            string query = "SELECT UserID FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash";
        //            SqlCommand cmd = new SqlCommand(query, con);

        //            cmd.Parameters.AddWithValue("@Username", username);
        //            cmd.Parameters.AddWithValue("@PasswordHash", password);

        //            SqlDataReader reader = cmd.ExecuteReader();

        //            if (reader.Read())
        //            {
        //                return (int)reader["UserID"];
        //            }

        //            return -1; // Invalid credentials
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error validating user credentials: " + ex.Message, ex);
        //    }
        //}

        //public UserModel GetUserById(int userId)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(connectionString))
        //        {
        //            con.Open();
        //            string query = "SELECT * FROM Users WHERE UserID = @UserID";
        //            SqlCommand cmd = new SqlCommand(query, con);

        //            cmd.Parameters.AddWithValue("@UserID", userId);

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    // Assuming User is a class that represents user information
        //                    UserModel user = new UserModel
        //                    {
        //                        UserID = (int)reader["UserID"],
        //                        Name = (string)reader["Name"],
        //                        Surname = (string)reader["Surname"],
        //                        Username = (string)reader["Username"],
        //                        PasswordHash = (string)reader["PasswordHash"]
        //                        // Add other properties as needed
        //                    };

        //                    return user;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error retrieving user by ID from the database: " + ex.Message, ex);
        //    }

        //    return null; // Return null if user with given ID is not found
        //}

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
