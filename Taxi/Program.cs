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
                if (key == 1)
                {
                    Console.Clear();
                    Screen.ShowDistrict(center);
                    Screen.ShowCabs(center);
                }
                else if (key == 2)
                {
                    Console.Clear();
                    Console.WriteLine("PODAJ NUMER DZIELNICY DO KTÓREJ CHCESZ WEZWAĆ TAKSÓWKĘ:");
                    int selecteddistrict = Convert.ToInt32(Console.ReadLine());
                    int distanceselecteddistrict = center.Districts[selecteddistrict - 1].DistanceFromCentrum;
                    //Console.WriteLine(distanceselecteddistrict);
                    //Console.WriteLine("");
                    foreach (Cab cab in center.Cabs)
                    {
                        int time = distanceselecteddistrict - center.Cabs[cab.Id - 1].CurrentDistrict.DistanceFromCentrum;
                        int absolutetime = Math.Abs(time);
                        center.Cabs[cab.Id - 1].TravelTime = absolutetime;
                        if (center.Cabs[cab.Id - 1].TravelTime == 0)
                        {
                            center.Cabs[cab.Id - 1].TravelTime = 4;
                            if (center.Cabs[cab.Id - 1].IsAvailable == false)
                            {
                                center.Cabs[cab.Id - 1].TravelTime = center.Cabs[cab.Id - 1].TravelTime + 12;
                            }
                        }
                        else if (center.Cabs[cab.Id - 1].TravelTime != 0)
                        {
                            center.Cabs[cab.Id - 1].TravelTime = center.Cabs[cab.Id - 1].TravelTime * 5;
                            if (center.Cabs[cab.Id - 1].IsAvailable == false)
                            {
                                center.Cabs[cab.Id - 1].TravelTime = center.Cabs[cab.Id - 1].TravelTime + 12;
                            }
                        }
                    }
                    int mintime = 999;
                    foreach (Cab cab in center.Cabs)
                    {
                        if (center.Cabs[cab.Id - 1].TravelTime < mintime)
                        {
                            mintime = center.Cabs[cab.Id - 1].TravelTime;
                        }
                    }

                    foreach (Cab cab in center.Cabs)
                    {
                        if (mintime == center.Cabs[cab.Id - 1].TravelTime)
                        {
                            Console.WriteLine($"{center.Cabs[cab.Id - 1].TravelTime} | {center.Cabs[cab.Id - 1].Car}");
                            center.Cabs[cab.Id - 1].IsAvailable = false;
                        }
                        Console.WriteLine("");
                        Console.WriteLine($"{center.Cabs[cab.Id - 1].TravelTime} Czas");
                    }
                    /*
                        Console.WriteLine("");
                    foreach (District district in center.Districts)
                        //center.Districts[district.Number - 1].Number
                        Console.WriteLine($"{center.Districts[district.Number - 1].Number} | {center.Districts[district.Number - 1].Name} | 1 ");
                    Console.WriteLine("");
                    foreach (Cab cab in center.Cabs)
                        Console.WriteLine($"{center.Cabs[cab.Id - 1].Car} | {center.Cabs[cab.Id - 1].Status} | {center.Cabs[cab.Id - 1].CurrentDistrict.Name}");
                    */
                }
                else if (key == 3)
                {
                    Console.Clear();
                    finished = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Błędny Klawisz");
                    Console.WriteLine("");
                }
            } while (!finished);
        }
    }
}