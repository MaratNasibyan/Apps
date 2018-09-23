﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RESTful.Catalog.API.Infrastructure;

namespace RESTful.Catalog.API.Infrastructure.Migrations
{
    [DbContext(typeof(CatalogContext))]
    partial class CatalogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.catalog_hilo", "'catalog_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.catalog_type_hilo", "'catalog_type_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RESTful.Catalog.API.Infrastructure.Models.CatalogItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "catalog_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("CatalogTypeId");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PictureFileName");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CatalogTypeId");

                    b.ToTable("CatalogItem");

                    b.HasData(
                        new { Id = 1, CatalogTypeId = 2, Description = ".NET Bot Black Hoodie", Name = ".NET Bot Black Hoodie", PictureFileName = "1.png", Price = 19.5m },
                        new { Id = 2, CatalogTypeId = 1, Description = ".NET Black & White Mug", Name = ".NET Black & White Mug", PictureFileName = "2.png", Price = 8.50m },
                        new { Id = 3, CatalogTypeId = 2, Description = "Prism White T-Shirt", Name = "Prism White T-Shirt", PictureFileName = "3.png", Price = 12m },
                        new { Id = 4, CatalogTypeId = 2, Description = ".NET Foundation T-shirt", Name = ".NET Foundation T-shirt", PictureFileName = "4.png", Price = 12m },
                        new { Id = 5, CatalogTypeId = 3, Description = "Roslyn Red Sheet", Name = "Roslyn Red Sheet", PictureFileName = "5.png", Price = 8.5m },
                        new { Id = 6, CatalogTypeId = 2, Description = ".NET Blue Hoodie", Name = ".NET Blue Hoodie", PictureFileName = "6.png", Price = 12m },
                        new { Id = 7, CatalogTypeId = 2, Description = "Roslyn Red T-Shirt", Name = "Roslyn Red T-Shirt", PictureFileName = "7.png", Price = 12m },
                        new { Id = 8, CatalogTypeId = 2, Description = "Kudu Purple Hoodie", Name = "Kudu Purple Hoodie", PictureFileName = "8.png", Price = 8.5m },
                        new { Id = 9, CatalogTypeId = 1, Description = "Cup<T> White Mug", Name = "Cup<T> White Mug", PictureFileName = "9.png", Price = 12m },
                        new { Id = 10, CatalogTypeId = 3, Description = ".NET Foundation Sheet", Name = ".NET Foundation Sheet", PictureFileName = "10.png", Price = 12m },
                        new { Id = 11, CatalogTypeId = 3, Description = "Cup<T> Sheet", Name = "Cup<T> Sheet", PictureFileName = "11.png", Price = 8.5m },
                        new { Id = 12, CatalogTypeId = 2, Description = "Prism White TShirt", Name = "Prism White TShirt", PictureFileName = "12.png", Price = 12m }
                    );
                });

            modelBuilder.Entity("RESTful.Catalog.API.Infrastructure.Models.CatalogType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "catalog_type_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("CatalogType");

                    b.HasData(
                        new { Id = 1, Type = "Mug" },
                        new { Id = 2, Type = "T-Shirt" },
                        new { Id = 3, Type = "Sheet" },
                        new { Id = 4, Type = "USB Memory Stick" }
                    );
                });

            modelBuilder.Entity("RESTful.Catalog.API.Infrastructure.Models.CatalogItem", b =>
                {
                    b.HasOne("RESTful.Catalog.API.Infrastructure.Models.CatalogType", "CatalogType")
                        .WithMany("CatalogItems")
                        .HasForeignKey("CatalogTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
