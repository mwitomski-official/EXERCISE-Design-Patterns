using DesignPatterns.Strategy.Attributes;
using DesignPatterns.Strategy.Enums;
using DesignPatterns.Strategy.Models;
using System.Text.Json;

namespace DesignPatterns.Strategy.Strategy.UserOutputStrategy
{
    [UserFormatterName(FormatType.Json)]
    public class UserJsonOutput : IUserOutputStrategy
    {
        public string ConvertUserToString(User user)
            => JsonSerializer.Serialize(user);
    }
}
