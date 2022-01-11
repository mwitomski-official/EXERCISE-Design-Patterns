using DesignPatterns.Strategy.Attributes;
using DesignPatterns.Strategy.Enums;
using DesignPatterns.Strategy.Models;

namespace DesignPatterns.Strategy.Strategy.UserOutputStrategy
{
    [UserFormatterName(FormatType.PlainText)]
    public class UserPlainTextOutput : IUserOutputStrategy
    {
        public string ConvertUserToString(User user)
            => $"{user.UserName}{Environment.NewLine}" +
            $"{user.Password}{Environment.NewLine}" +
            $"{user.Email}{Environment.NewLine}";
    }
}
