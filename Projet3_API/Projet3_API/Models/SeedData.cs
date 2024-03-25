using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Projet3_API.Data;
using System;
using System.Linq;
namespace Projet3_API.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Projet3_APIContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Projet3_APIContext>>()))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // Look for any movies.
               /* if (context.Film.Any())
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
