namespace Project_BlueLock.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
    }
}
