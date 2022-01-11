using DesignPatterns.Common.Interfaces;
using DesignPatterns.State.Objects;

namespace DesignPatterns.State
{
    public class StateExample : ILauncher
    {
        public void Run()
        {
            var beer = new Beer();

            beer.Drink();
            beer.Fill();
            
            //First error missing beer
            beer.Drink();
            beer.Drink();

            //Second Error we have beer
            beer.Fill();
            beer.Fill();
        }
    }
}