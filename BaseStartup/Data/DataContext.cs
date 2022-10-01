using BaseStartup.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPIHouses.Entities;

namespace BaseStartup.Data;

public class DataContext : IdentityDbContext<AppUser>
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
  
    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<House> Houses => Set<House>();
    public DbSet<Landlord> Landlords => Set<Landlord>();
    public DbSet<Agreement> Agreements => Set<Agreement>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }
}
