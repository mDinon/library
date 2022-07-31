using Microblink.Library.DAL.ModelConfiguration;
using Microblink.Library.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microblink.Library.DAL.Context
{
	public class LibraryContext : DbContext
	{
		public DbSet<User> Users => Set<User>();
		public DbSet<UserContact> UserContacts => Set<UserContact>();
		public DbSet<ContactType> ContactTypes => Set<ContactType>();
		public DbSet<Book> Books => Set<Book>();
		public DbSet<Reservation> Reservations => Set<Reservation>();

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
