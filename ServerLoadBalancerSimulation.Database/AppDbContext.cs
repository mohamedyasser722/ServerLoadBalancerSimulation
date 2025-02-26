using Microsoft.EntityFrameworkCore;
using ServerLoadBalancerSimulation.Database.Entities;

namespace ServerLoadBalancerSimulation.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<CSETeamOS> CSETeamOS { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CSETeamOSConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}