using Microsoft.EntityFrameworkCore;
using NotificationDataLibrary.Data;
using NotificationDataLibrary.Models;
using NotificationDataLibrary.Models.Companies;

namespace NotificationDataLibrary.Data
{
	public class NotifContext : DbContext
	{
		public DbSet<Company> Companies { get; set; }

		public DbSet<Notification> Notifications { get; set; }

		public NotifContext(DbContextOptions<NotifContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Company>().ToTable("Company");
			modelBuilder.Entity<DenmarkCompany>().ToTable("Company");
			modelBuilder.Entity<FinlandCompany>().ToTable("Company");
			modelBuilder.Entity<NorwayCompany>().ToTable("Company");
			modelBuilder.Entity<SwedenCompany>().ToTable("Company");
			modelBuilder.Entity<Notification>().ToTable("Notification");
		}
	}

}
