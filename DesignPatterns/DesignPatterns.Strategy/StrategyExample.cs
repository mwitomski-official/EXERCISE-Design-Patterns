using DesignPatterns.Strategy.Enums;
using DesignPatterns.Strategy.Models;
using System.Reflection;
using System.Linq;
using DesignPatterns.Strategy.Strategy.UserOutputStrategy;
using DesignPatterns.Strategy.Attributes;
using DesignPatterns.Common.Interfaces;

namespace DesignPatterns.Strategy
{
    public class StrategyExample : ILauncher
    {
        private readonly Dictionary<FormatType, Type> _formatterTypes;
        public StrategyExample()
        {
            // Dynamic type searching and dictionary building
            _formatterTypes = Assembly
                .GetExecutingAssembly()
                .GetExportedTypes()
                .Where(type => type.GetInterfaces().Contains(typeof(IUserOutputStrategy)))
                .ToDictionary(keySelector: type => type.GetCustomAttribute<UserFormatterName>().DisplayName);

            Console.WriteLine($"{string.Join(",", (_formatterTypes.Select(x => $"\n{x.Key} - {x.Value}").ToList()))}\n");
        }

        public void Run()
        {
            string csv = Print(User.CreateNew("Mateusz", "admin1", "T@"), FormatType.CSV);
            string json = Print(User.CreateNew("Mateusz", "admin1", "T@"), FormatType.Json);
            string plainText = Print(User.CreateNew("Mateusz", "admin1", "T@"), FormatType.PlainText);

            Console.WriteLine($"CSV Strategy:\n{csv}");
            Console.WriteLine($"\nJson Strategy:\n{json}");
            Console.WriteLine($"\nPlainText Strategy:\n{plainText}");
        }

        private string Print(User user, FormatType formatType)
        {
            Type selectedFormatter = _formatterTypes[formatType];

            // Creating instances of the [Strategy]

            if (Activator.CreateInstance(selectedFormatter) is not IUserOutputStrategy userOutputStrategy)
                throw new InvalidOperationException("No valid formatter selected");

            // Execute [Strategy]
            return userOutputStrategy.ConvertUserToString(user);
        }
    }
}