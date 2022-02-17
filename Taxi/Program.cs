using System;

namespace Taxi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaxiCenter center = new TaxiCenter();
            bool finished = false;
            do
            {
                Screen.Menu();
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        Console.Clear();
                        Screen.ShowDistrict(center);
                        Screen.ShowCabs(center);
                        break;
                    case 2:
                        Console.Clear();
                        Calculate.Manage(center);
                        break;
                    case 3:
                        Console.Clear();
                        finished = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Błędny Klawisz");
                        Console.WriteLine("");
                        break;
                }
            } while (!finished);
        }
    }
}