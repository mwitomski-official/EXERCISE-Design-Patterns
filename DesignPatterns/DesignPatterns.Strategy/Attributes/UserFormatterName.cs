using DesignPatterns.Strategy.Enums;

namespace DesignPatterns.Strategy.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class UserFormatterName : Attribute
    {
        public UserFormatterName(FormatType displayName)
        {
            DisplayName = displayName;
        }

        public FormatType DisplayName { get; }
    }
}
