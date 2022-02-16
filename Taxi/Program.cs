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
                            center.Cabs[cab.Id - 1].CurrentDistrict = center.Districts[selecteddistrict - 1];
                            center.Cabs[cab.Id - 1].IsAvailable = false;
                            mintime = mintime + 9999;
                            if (center.Districts[cab.Id - 1].NumberOfCabs != 0)
                            {
                                if (center.Cabs[cab.Id - 1].CurrentDistrict.Number == center.Districts[selecteddistrict - 1].Number)
                                {
                                    center.Districts[selecteddistrict - 1].NumberOfCabs = center.Districts[selecteddistrict - 1].NumberOfCabs + 1;
                                    center.Districts[cab.Id - 1].NumberOfCabs = center.Districts[cab.Id - 1].NumberOfCabs - 1;
                                }
                            }
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"ZLECENIE REALIZUJE: {center.Cabs[cab.Id - 1].Car}");
                            Console.WriteLine($"CZAS DOJAZDU: {center.Cabs[cab.Id - 1].TravelTime} min.");
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }

                    Console.WriteLine("LISTA DZIELNIC");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("NUMER | NAZWA | ILOŚĆ TAKSÓWEK");
                    foreach (District district in center.Districts)
                        Console.WriteLine($"{center.Districts[district.Number - 1].Number} | {center.Districts[district.Number - 1].Name} | {center.Districts[district.Number - 1].NumberOfCabs} ");
                    Console.WriteLine("");
                    Console.WriteLine("LISTA TAKSÓWEK");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("SAMOCHÓD | STATUS | AKTUALNA LOKALIZACJA | Czas Dojazdu");
                    foreach (Cab cab in center.Cabs)
                        Console.WriteLine($"{center.Cabs[cab.Id - 1].Car} | {center.Cabs[cab.Id - 1].Status} | {center.Cabs[cab.Id - 1].CurrentDistrict.Name} | ({center.Cabs[cab.Id - 1].TravelTime} min.)");
                    Console.WriteLine("");
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