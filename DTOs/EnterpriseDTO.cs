using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class EnterpriseDTO : BaseDTO
    {
        public string Name { get; set; }
        public string CpfCnpj { get; set; }
        public string PhoneNumber { get; set; }
        public string State { get; set; }
        public string City { get; set; } 
        public string street { get; set; }
        public string Number { get; set; }
        public string Cep { get; set; }
        public string Plan { get; set; }
    }
}
