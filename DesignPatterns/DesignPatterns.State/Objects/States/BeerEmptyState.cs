namespace DesignPatterns.State.Objects.States
{
    public class BeerEmptyState : BeerState
    {
        public BeerEmptyState()
        {
            Console.WriteLine("[BeerEmptyState][Ctor] Beer is in EmptyState");
        }

        public override void Fill(Beer beer)
        {
            Console.WriteLine("[BeerEmptyState][Fill] Fill -> Pouring beer");
            beer.State = new BeerFullState();
        }
    }
}
