using AuthenticationApi.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationApi.Db;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Offer>? Offers { get; set; }
    public DbSet<Vehicle_Type> Vehicle_Types { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<User_Vehicle> user_vehicles { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Service_Offer> Service_offers { get; set; }





    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>(e =>
        {
            e.HasMany(p => p.Offers)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.userid); 
        });
        builder.Entity<Vehicle_Type>(e =>
        {
            e.HasMany(p => p.Vehicles)
            .WithOne(p => p.vehicle_type)
            .HasForeignKey(p => p.vehicle_typeid);
        });
        builder.Entity<Client>(e =>
        {
            e.HasMany(p => p.Vehicles)
            .WithOne(p => p.client)
            .HasForeignKey(p => p.clientid);
        });
        builder.Entity<Client>(e =>
        {
            e.HasMany(p => p.Offers)
            .WithOne(p => p.client)
            .HasForeignKey(p => p.clientid);
        });

        builder.Entity<User_Vehicle>()
        .HasKey(bc => new { bc.userid, bc.vehicleid });
        builder.Entity<User_Vehicle>()
            .HasOne(bc => bc.user)
            .WithMany(b => b.user_vehicle)
            .HasForeignKey(bc => bc.userid);
        builder.Entity<User_Vehicle>()
            .HasOne(bc => bc.vehicle)
            .WithMany(c => c.user_vehicle)
            .HasForeignKey(bc => bc.vehicleid);

        builder.Entity<Service_Offer>()
        .HasKey(bc => new { bc.offerid, bc.serviceid });
        builder.Entity<Service_Offer>()
            .HasOne(bc => bc.offer)
            .WithMany(b => b.service_offer)
            .HasForeignKey(bc => bc.offerid);
        builder.Entity<Service_Offer>()
            .HasOne(bc => bc.service)
            .WithMany(c => c.service_offer)
            .HasForeignKey(bc => bc.serviceid);

    }
    
}

