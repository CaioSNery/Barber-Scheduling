using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barber.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Barber.Maps
{
    public class ServiceMap : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");

            builder.Property(s => s.TypeService)
            .IsRequired();

            builder.Property(s => s.PriceService)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        }
    }
}