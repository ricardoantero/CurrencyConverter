using CurrencyConverter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Infra.Data.Mappings
{
    public class UsersMap : BaseMap<Users>
    {
        public override void ConfigureProperties(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users");

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Password).HasMaxLength(8).IsRequired();
        }
    }
}
