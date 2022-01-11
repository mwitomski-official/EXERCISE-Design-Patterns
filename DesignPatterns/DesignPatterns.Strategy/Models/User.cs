using DesignPatterns.Strategy.Strategy.UserOutputStrategy;

namespace DesignPatterns.Strategy.Models
{
    public class User
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }

        public static User CreateNew(string userName, string password, string email)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
                throw new ArgumentException("Incorrect data");

            return new User()
            {
                UserName = userName,
                Password = password,
                Email = email
            };
        }

        public string GenerateOutput(IUserOutputStrategy strategy)
            => strategy.ConvertUserToString(this); 
    }
}
