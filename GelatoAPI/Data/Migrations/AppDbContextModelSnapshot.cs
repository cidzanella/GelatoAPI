﻿// <auto-generated />
using System;
using GelatoAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GelatoAPI.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("GelatoAPI.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsAdmin = true,
                            UserName = "Lucas"
                        },
                        new
                        {
                            Id = 2,
                            IsAdmin = true,
                            UserName = "Cid"
                        },
                        new
                        {
                            Id = 3,
                            IsAdmin = true,
                            UserName = "Suélen"
                        });
                });

            modelBuilder.Entity("GelatoAPI.Models.RawMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.HasIndex("TypeId");

                    b.ToTable("RawMaterials");
                });

            modelBuilder.Entity("GelatoAPI.Models.RawMaterialSupplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RawMaterialSuppliers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Outro"
                        },
                        new
                        {
                            Id = 2,
                            Name = "MEC3"
                        },
                        new
                        {
                            Id = 3,
                            Name = "PreGel"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Fabbri"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Callebaut"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Lactobom"
                        },
                        new
                        {
                            Id = 7,
                            Name = "LAR Supermercado"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Shopping do Sorveteiro"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Destro"
                        },
                        new
                        {
                            Id = 10,
                            Name = "SanCor"
                        },
                        new
                        {
                            Id = 11,
                            Name = "LeiteSol La Serenissima"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Apice Sul"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Grings"
                        },
                        new
                        {
                            Id = 14,
                            Name = "PopHouse"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Mayers"
                        },
                        new
                        {
                            Id = 16,
                            Name = "CeleroNacional"
                        });
                });

            modelBuilder.Entity("GelatoAPI.Models.RawMaterialType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RawMaterialTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Pasta"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Variegato"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Pasta / Variegato"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Basica"
                        },
                        new
                        {
                            Id = 5,
                            Type = "Basica / Variegato"
                        },
                        new
                        {
                            Id = 6,
                            Type = "Fruta"
                        });
                });

            modelBuilder.Entity("GelatoAPI.Models.RawMaterial", b =>
                {
                    b.HasOne("GelatoAPI.Models.RawMaterialSupplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId");

                    b.HasOne("GelatoAPI.Models.RawMaterialType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.Navigation("Supplier");

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}
