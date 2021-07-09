using CurrencyConverter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Infra.Data.Mappings
{
    public abstract class BaseMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.CreateDate).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(p => p.Active).IsRequired();

            ConfigureProperties(builder);
        }

        public abstract void ConfigureProperties(EntityTypeBuilder<TEntity> builder);
    }
}
