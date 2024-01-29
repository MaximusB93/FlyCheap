﻿// <auto-generated />
using FlyCheap.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FlyCheap.Migrations
{
    [DbContext(typeof(AirDbContext))]
    [Migration("20240129170209_RemoveNameTranslations")]
    partial class RemoveNameTranslations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FlyCheap.Models.Db.Airlines", b =>
                {
                    b.Property<string>("code")
                        .HasColumnType("text");

                    b.Property<string>("is_lowcost")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name_translations")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("code");

                    b.ToTable("Airlines");
                });

            modelBuilder.Entity("FlyCheap.Models.Db.Airports", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("city_code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.Property<string>("country_code")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.Property<bool>("flightable")
                        .HasMaxLength(255)
                        .HasColumnType("boolean");

                    b.Property<string>("iata_type")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<float>("lat")
                        .HasColumnType("real");

                    b.Property<float>("lon")
                        .HasColumnType("real");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name_translations")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("time_zone")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("FlyCheap.Models.Db.Cities", b =>
                {
                    b.Property<string>("code")
                        .HasColumnType("text");

                    b.Property<string>("country_code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("lat")
                        .HasColumnType("double precision");

                    b.Property<double>("lon")
                        .HasColumnType("double precision");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("time_zone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("code");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("FlyCheap.Models.Db.Countries", b =>
                {
                    b.Property<string>("code")
                        .HasColumnType("text");

                    b.Property<string>("currency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name_translations")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("code");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("FlyCheap.Models.Utils.Cases", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("da")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("pr")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("su")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("tv")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("vi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("FlyCheap.Models.Utils.Coordinates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("lat")
                        .HasColumnType("real");

                    b.Property<float>("lon")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Coordinates");
                });

            modelBuilder.Entity("FlyCheap.Models.Utils.NameTranslations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("en")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("NameTranslations");
                });
#pragma warning restore 612, 618
        }
    }
}
