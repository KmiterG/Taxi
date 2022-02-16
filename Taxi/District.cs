using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public class District
    {
        public District(int number, string name, int distance)
        {
            Number = number;
            Name = name;
            DistanceFromCentrum = distance;
            NumberOfCabs = 0;
        }
        public int Number { get; set; }
        public string Name { get; set; }
        public int DistanceFromCentrum { get; set; }
        public int NumberOfCabs { get; set; }
    }
}
