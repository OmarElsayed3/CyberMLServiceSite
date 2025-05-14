using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CyberMLServiceSite.Core.Models;


namespace CyberMLServiceSite.Data
{
    public class ApplicationDbContext : IdentityDbContext<Applicationuser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{ }
		public DbSet<ClientInfo> ClientInfos { get; set; }
		public DbSet<ServiceRequest> serviceRequests { get; set; }
	}
}
