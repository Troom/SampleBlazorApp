using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            var naviagtion = builder.Metadata.FindNavigation(nameof(Order.OrderLines));
            naviagtion.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.HasKey(c => c.OrderId);
            builder.HasMany(c => c.OrderLines)
                .WithOne(e => e.Order)
                .HasForeignKey(d => d.OrderLineId);
        }


    }
}
