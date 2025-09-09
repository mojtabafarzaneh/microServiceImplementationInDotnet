using PlatformService.Models;

namespace PlatformService.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>()!);
        }
    }

    private static void SeedData(AppDbContext context)
    {
        if (!context.Platforms.Any())
        {
            Console.WriteLine("--> seeding data");

            context.Platforms.AddRange(
                new Platform()
                {
                    Name = "dotnet",
                    Publisher = "microsoft",
                    Cost = "free"
                },
                new Platform()
                {
                    Name = "kuberNetes",
                    Publisher = "Cloud Native Computation",
                    Cost = "free"
                }
            );
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("--> we already have data");
        }
    }
}