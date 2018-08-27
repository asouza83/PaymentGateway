using System;
using System.Collections.Generic;

namespace PaymentGateway.DataContracts.ClearSaleMocks
{
    public class Order
    {
        public string ID { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public decimal TotalShipping { get; set; }
        public decimal TotalItems { get; set; }
        public decimal TotalOrder { get; set; }
        public string IP { get; set; }
        public string Obs { get; set; }
        public string OrderCurrency { get; set; }
        public string Status { get; set; }
        public IList<Payment> Payments { get; set; }
        public Person ShippingData { get; set; }
        public Person BillingData { get; set; }
        public IList<Item> Items { get; set; }
        public IList<CustomFields> CustomFields { get; set; }
        public bool Reanalysis { get; set; }
        public string Origin { get; set; }
    }
}
