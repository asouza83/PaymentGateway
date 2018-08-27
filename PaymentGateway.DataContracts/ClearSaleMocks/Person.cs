using System;
using System.Collections.Generic;

namespace PaymentGateway.DataContracts.ClearSaleMocks
{
    public class Person
    {
        public string ID { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public IList<Phone> Phones { get; set; }
    }
}
