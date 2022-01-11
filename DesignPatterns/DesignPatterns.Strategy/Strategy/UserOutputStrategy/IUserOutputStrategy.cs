using DesignPatterns.Strategy.Models;

namespace DesignPatterns.Strategy.Strategy.UserOutputStrategy
{
    public interface IUserOutputStrategy
    {
        string ConvertUserToString(User user);
    }
}
