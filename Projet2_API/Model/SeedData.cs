using Microsoft.EntityFrameworkCore;
using Projet2_API.Data;

namespace Projet2_API.Model
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Projet2_APIContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Projet2_APIContext>>()))
            {
                //context.Database.Migrate();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // Look for any movies.
                /*if (context.Film.Any())
                {
                    return;   // DB has been seeded
                }
                context.Film.AddRange(
                    new Film
                    {
                        Title = "Ghostbusters"
                    }
                );*/
                context.SaveChanges();
            }
        }
    }
}
