using Microsoft.EntityFrameworkCore;
using PaymentGateway.DataContracts.LocalDb;
using PaymentGateway.Interfaces;
using PaymentGateway.Unity;
using System.IO;

namespace PaymentGateway.Dal
{
    public class PaymentDal: AbstractDal, IPaymentDal
    {
        private readonly DbContextOptionsBuilder<PaymentGatewayContext> _optionsBuilder;
        public PaymentDal(IContainerIoc container)
    : base(container)
        {
            _optionsBuilder = new DbContextOptionsBuilder<PaymentGatewayContext>();
        }

        public void SaveTransaction(Transaction pTransaction)
        {
            string path;
            string connectionString;

            if (pTransaction.IsTest)
            {
                path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
                connectionString = string.Format("Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;AttachDbFileName={0}\\PaymentGateway.Dal\\Database\\PaymentGateway.mdf;Database=PaymantGateway;Trusted_Connection=Yes;", path);
            }
            else
            {
                path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
                connectionString = string.Format("Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;AttachDbFileName={0}\\PaymentGatewayApi\\PaymentGateway.Dal\\Database\\PaymentGateway.mdf;Database=PaymantGateway;Trusted_Connection=Yes;", path);
            }

            _optionsBuilder.UseSqlServer(connectionString);

            using (var paymentGatewayContext = new PaymentGatewayContext(_optionsBuilder.Options))
            {
                paymentGatewayContext.Transactions.Add(pTransaction);
                paymentGatewayContext.SaveChanges();
            }
        }
    }
}
