namespace DesignPatterns.State.Objects.States
{
    public class BeerState
    {
        public virtual void Fill(Beer beer)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[BeerState] Can't drink");
            Console.ResetColor();
        }
        public virtual void Drink(Beer beer)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[BeerState] Can't fill");
            Console.ResetColor();
        }
    }
}
