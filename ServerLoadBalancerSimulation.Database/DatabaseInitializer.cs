using Microsoft.Extensions.DependencyInjection;
using ServerLoadBalancerSimulation.Database.Entities;

namespace ServerLoadBalancerSimulation.Database;

public static class DatabaseInitializer
{
    public static void SeedDatabase(IServiceProvider services)
    {
        using (var scope = services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Ensure the database is created
            dbContext.Database.EnsureCreated();

            // Seed data only if the table is empty
            if (!dbContext.CSETeamOS.Any())
            {
                dbContext.CSETeamOS.AddRange(new[]
                {
                    new CSETeamOS { Id = 232661, Name = "Mohamed Yasser", Group = "B",CourseName = "Operating System" },
                });

                dbContext.SaveChanges();
            }
        }
    }
}
