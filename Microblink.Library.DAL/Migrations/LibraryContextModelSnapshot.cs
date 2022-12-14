// <auto-generated />
using System;
using Microblink.Library.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Microblink.Library.DAL.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microblink.Library.Model.Entities.Book", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("TotalCopies")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Books", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "J. K. Rowling",
                            DateCreated = new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Title = "Harry Potter and the Philosopher's Stone",
                            TotalCopies = 10
                        },
                        new
                        {
                            Id = 2,
                            Author = "Frank Herbert",
                            DateCreated = new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Title = "Dune",
                            TotalCopies = 3
                        },
                        new
                        {
                            Id = 3,
                            Author = "J. R. R. Tolkien",
                            DateCreated = new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Title = "The Lord of the Rings",
                            TotalCopies = 13
                        });
                });

            modelBuilder.Entity("Microblink.Library.Model.Entities.ContactType", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ContactTypes", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Email"
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Mobile"
                        },
                        new
                        {
                            Id = 3,
                            DateCreated = new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Telephone"
                        });
                });

            modelBuilder.Entity("Microblink.Library.Model.Entities.Reservation", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReservationActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ReservationDateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReservationDateStart")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReservationDueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 2,
                            DateCreated = new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            IsReservationActive = true,
                            ReservationDateStart = new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationDueDate = new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BookId = 3,
                            DateCreated = new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            IsReservationActive = false,
                            ReservationDateEnd = new DateTime(2022, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationDateStart = new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationDueDate = new DateTime(2022, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            BookId = 1,
                            DateCreated = new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            IsReservationActive = true,
                            ReservationDateStart = new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationDueDate = new DateTime(2022, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Microblink.Library.Model.Entities.User", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Users", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Test",
                            IsDeleted = false,
                            LastName = "Testić"
                        });
                });

            modelBuilder.Entity("Microblink.Library.Model.Entities.UserContact", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<int>("ContactTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("ContactTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserContacts", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContactTypeId = 1,
                            DateCreated = new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            UserId = 1,
                            Value = "test.test@test.test"
                        },
                        new
                        {
                            Id = 2,
                            ContactTypeId = 2,
                            DateCreated = new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            UserId = 1,
                            Value = "+385987456123"
                        },
                        new
                        {
                            Id = 3,
                            ContactTypeId = 3,
                            DateCreated = new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            UserId = 1,
                            Value = "011234567"
                        });
                });

            modelBuilder.Entity("Microblink.Library.Model.Entities.Reservation", b =>
                {
                    b.HasOne("Microblink.Library.Model.Entities.Book", "Book")
                        .WithMany("Reservations")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microblink.Library.Model.Entities.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microblink.Library.Model.Entities.UserContact", b =>
                {
                    b.HasOne("Microblink.Library.Model.Entities.ContactType", "ContactType")
                        .WithMany()
                        .HasForeignKey("ContactTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microblink.Library.Model.Entities.User", "User")
                        .WithMany("UserContacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microblink.Library.Model.Entities.Book", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Microblink.Library.Model.Entities.User", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("UserContacts");
                });
#pragma warning restore 612, 618
        }
    }
}
