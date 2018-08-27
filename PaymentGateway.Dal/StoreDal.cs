using Microsoft.EntityFrameworkCore;
using PaymentGateway.DataContracts.LocalDb;
using PaymentGateway.Interfaces;
using PaymentGateway.Unity;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PaymentGateway.Dal
{
    public class StoreDal : AbstractDal, IStoreDal
    {
        private readonly DbContextOptionsBuilder<PaymentGatewayContext> _optionsBuilder;
        public StoreDal(IContainerIoc container)
            : base(container)
        {
            _optionsBuilder = new DbContextOptionsBuilder<PaymentGatewayContext>(); 
        }

        public Store GetStoreById(GetStore pGetStore)
        {
            string path;
            string connectionString;

            if (pGetStore.IsTest)
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
                return paymentGatewayContext.Stores.Include(store => store.RelStoreAcquirer)
                      .ThenInclude(relStoreAcquirer => relStoreAcquirer.Acquirer).Where(s => s.Id.Equals(pGetStore.Id)).FirstOrDefault();
            }
        }
    }
}
