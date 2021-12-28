using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motoStore.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Post { get; set; }
        public string Empphonenumber { get; set; }
        public string Empaddress { get; set; }
        public string Emppassport { get; set; }
        public string Account { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salary { get; set; }
        public int Motoshop_code { get; set; }


    }
}
