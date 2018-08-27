using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace PaymentGateway.DataContracts.LocalDb
{
    [DataContract]
    public class Transaction
    {

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Authorization { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string AuthAmountInCents { get; set; }
        [DataMember]
        public string CardNumber { get; set; }
        [DataMember]
        public string CardName { get; set; }
        [DataMember]
        public string CardExpiration { get; set; }
        [DataMember]
        public string CardSecurityCode { get; set; }
        [DataMember]
        public string MerchanteKey { get; set; }
        [NotMapped]
        public bool IsTest { get; set; }
    }
}
