using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public class Cab
    {
        public Cab(int id, string car, District district)
        {
            Id = id;
            Car = car;
            CurrentDistrict = district;
            IsAvailable = true;
        }
        public int Id { get; set; }
        public string Car { get; set; }
        public bool IsAvailable { get; set; }
        public District CurrentDistrict { get; set; }
    }
}
