using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motoStore.Models
{
    class Bike
    {
        public int Id { get; set; }
        public string Brand_name { get; set; }
        public string Model_name { get; set; }
        public string Color_name { get; set; }
        public string Complectation_name { get; set; }
        public string Max_speed { get; set; }
        public string Power { get; set; }
        public string Torque { get; set; }
        public string Transmis_type { get; set; }
        public string Availability { get; set; }
        public decimal Price { get; set; }

    }
}
