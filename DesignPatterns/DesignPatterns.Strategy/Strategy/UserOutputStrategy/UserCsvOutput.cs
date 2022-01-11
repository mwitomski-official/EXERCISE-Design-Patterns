using DesignPatterns.Strategy.Attributes;
using DesignPatterns.Strategy.Enums;
using DesignPatterns.Strategy.Models;

namespace DesignPatterns.Strategy.Strategy.UserOutputStrategy
{
    [UserFormatterName(FormatType.CSV)]
    public class UserCsvOutput : IUserOutputStrategy
    {
        public string ConvertUserToString(User user)
            => $"{user.UserName};{user.Password};{user.Email}";
    }
}
