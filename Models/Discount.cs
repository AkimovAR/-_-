using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motoStore.Models
{
    class Discount
    {
        public int Id { get; set; }
        public DateTime DateDiscount { get; set; }
        public int SizeDiscount { get; set; }
    }
}
