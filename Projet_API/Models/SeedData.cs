using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Projet_API.Data;
using System;
using System.Linq;



namespace Projet_API.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Projet_APIContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Projet_APIContext>>()))
            {
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
