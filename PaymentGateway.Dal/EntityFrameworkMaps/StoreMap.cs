using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentGateway.DataContracts.LocalDb;

namespace PaymentGateway.Dal.EntityFrameworkMaps
{
    public class StoreMap 
    {
        public StoreMap(EntityTypeBuilder<Store> entityBuilder)
        {
            entityBuilder.HasKey(l => l.Id);
            entityBuilder.Property(l => l.Id).UseSqlServerIdentityColumn();
            entityBuilder.Property(l => l.Id).IsRequired();
            entityBuilder.Property(l => l.Name).HasMaxLength(50);
            entityBuilder.Property(l => l.FlAntiFraud);
        }
    }
}
