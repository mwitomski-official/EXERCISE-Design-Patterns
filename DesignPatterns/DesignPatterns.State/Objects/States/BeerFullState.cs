namespace DesignPatterns.State.Objects.States
{
    public class BeerFullState : BeerState
    {
        public BeerFullState()
        {
            Console.WriteLine("[BeerFullState][Ctor] Beer is in FullState");
        }

        public override void Drink(Beer beer)
        {
            Console.WriteLine("[BeerState][Drink] Drink -> Drinking");
            beer.State = new BeerEmptyState();
        }
    }
}