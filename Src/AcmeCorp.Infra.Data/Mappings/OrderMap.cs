using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeCorp.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorp.Infra.Data.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            // builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
