using System;

namespace Taxi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaxiCenter center = new TaxiCenter();
            var cab = center.Cabs[0];

            Screen.ShowDistrict(center);
            Screen.ShowCabs(center);
        }
    }
}