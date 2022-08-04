using Microblink.Library.DAL.ModelConfiguration;
using Microblink.Library.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microblink.Library.DAL.Context
{
	public class LibraryContext : DbContext
	{
		public virtual DbSet<User> Users => Set<User>();
		public virtual DbSet<UserContact> UserContacts => Set<UserContact>();
		public virtual DbSet<ContactType> ContactTypes => Set<ContactType>();
		public virtual DbSet<Book> Books => Set<Book>();
		public virtual DbSet<Reservation> Reservations => Set<Reservation>();

		public LibraryContext()
		{
		}

		public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("dbo");

			modelBuilder.ApplyConfiguration(new ContactTypeConfiguration());
			modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new UserContactConfiguration());
			modelBuilder.ApplyConfiguration(new BookConfiguration());
			modelBuilder.ApplyConfiguration(new ReservationConfiguration());
		}
	}
}
