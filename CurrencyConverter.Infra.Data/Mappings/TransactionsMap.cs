using CurrencyConverter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Infra.Data.Mappings
{
    public class TransactionsMap : BaseMap<Transactions>
    {
        public override void ConfigureProperties(EntityTypeBuilder<Transactions> builder)
        {
            builder.ToTable("Transactions");

            builder.Property(p => p.OriginCurrency).HasMaxLength(8).IsRequired();
            builder.Property(p => p.OriginValue).HasPrecision(18, 6).IsRequired();

            builder.Property(p => p.DestinationCurrency).HasMaxLength(8).IsRequired();
            builder.Property(p => p.DestinationValue).HasPrecision(18,6).IsRequired();

            builder.Property(p => p.ConversionRate).HasPrecision(18,6).IsRequired();
        }
    }
}
