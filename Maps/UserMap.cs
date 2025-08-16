using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barber.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Barber.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(30);

            builder.Property(u => u.Telephone)
            .IsRequired();



        }
    }
}
