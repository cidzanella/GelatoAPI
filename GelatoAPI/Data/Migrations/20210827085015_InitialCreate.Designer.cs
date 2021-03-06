// <auto-generated />
using GelatoAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GelatoAPI.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210827085015_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
#pragma warning restore 612, 618
        }
    }
}
