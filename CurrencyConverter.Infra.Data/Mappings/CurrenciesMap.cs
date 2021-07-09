using CurrencyConverter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Infra.Data.Mappings
{
    public class CurrenciesMap : BaseMap<Currencies>
    {
        public override void ConfigureProperties(EntityTypeBuilder<Currencies> builder)
        {
            builder.ToTable("Currencies");

            builder.Property(p => p.Currency).HasMaxLength(30).IsRequired();
            builder.Property(p => p.CurrencyCode).HasMaxLength(8).IsRequired();
        }
    }
}
