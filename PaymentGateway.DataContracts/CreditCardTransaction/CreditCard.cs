using PaymentGateway.DataContracts.Adress;
using PaymentGateway.DataContracts.EnumTypes;
using System;

namespace PaymentGateway.DataContracts.CreditCardTransaction
{
    public class CreditCard {
        public string CreditCardNumber { get; set; }
        public string HolderName { get; set; }
        public string SecurityCode { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        #region CreditCardBrand

        private string CreditCardBrandField {
            get {
                if (CreditCardBrand == null) { return null; }
                return this.CreditCardBrand.Value.ToString();
            }
            set {
                if (value == null) {
                    this.CreditCardBrand = null;
                }
                else {
                    this.CreditCardBrand = (CreditCardBrandEnum)Enum.Parse(typeof(CreditCardBrandEnum), value);
                }
            }
        }

        public Nullable<CreditCardBrandEnum> CreditCardBrand { get; set; }

        #endregion

        public BillingAddress BillingAddress { get; set; }
    }
}