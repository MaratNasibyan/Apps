﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RESTful.Catalog.API.Infrastructure.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTful.Catalog.API.Infrastructure.EntityConfigurations
{
    public  class CatalogItemEntityTypeConfiguration : IEntityTypeConfiguration<CatalogItem>
    {
        public void Configure(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("CatalogItem");

            builder.HasKey(ci => ci.Id);                 
                
            builder.Property(ci => ci.Id)
                .ValueGeneratedOnAdd()
                .ForSqlServerUseSequenceHiLo("catalog_hilo")
                .IsRequired();

            builder.Property(ci => ci.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(ci => ci.Price)
                .IsRequired(true);

            builder.Property(ci => ci.PictureFileName)
                .IsRequired(false);

            builder.Ignore(ci => ci.PictureUri);

            builder.HasOne(ci => ci.CatalogType)
                .WithMany(ci => ci.CatalogItems)
                .HasForeignKey(ci => ci.CatalogTypeId);
        }
    }
}
