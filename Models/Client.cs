using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motoStore.Models
{
    class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Cliphonenumber { get; set; } 
        public string Cliaddress { get; set; }
        public string Clipassport { get; set; }
        public int Clidiscount { get; set; }

    }
}
