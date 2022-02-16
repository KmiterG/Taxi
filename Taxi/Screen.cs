using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public static class Screen
    {
        public static void ShowDistrict(TaxiCenter taxicenter)
        {
            Console.WriteLine("LISTA DZIELNIC");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("NUMER | NAZWA | ILOŚĆ TAKSÓWEK");
            foreach (District district in taxicenter.Districts)
                Console.WriteLine($"{taxicenter.Districts[district.Number - 1].Number} | {taxicenter.Districts[district.Number - 1].Name} | 1 ");
        }
        public static void ShowCabs(TaxiCenter taxicenter)
        {
            Console.WriteLine("");
            Console.WriteLine("LISTA TAKSÓWEK");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("SAMOCHÓD | STATUS | AKTUALNA LOKALIZACJA");
            foreach (Cab cab in taxicenter.Cabs)
                Console.WriteLine($"{taxicenter.Cabs[cab.Id - 1].Car} | {taxicenter.Cabs[cab.Id - 1].Status} | {taxicenter.Cabs[cab.Id - 1].CurrentDistrict}.");
        }
    }
}
