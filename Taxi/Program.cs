using System;

namespace Taxi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaxiCenter service = new TaxiCenter();
            var cab = service.Cabs[0];
        }
    }
}