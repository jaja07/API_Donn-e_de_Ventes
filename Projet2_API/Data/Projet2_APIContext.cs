using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projet2_API.Model;

namespace Projet2_API.Data
{
    public class Projet2_APIContext : DbContext
    {
        public Projet2_APIContext (DbContextOptions<Projet2_APIContext> options)
            : base(options)
        {
        }

        public DbSet<Projet2_API.Model.GameConsole> GameConsole { get; set; } = default!;
        public DbSet<Projet2_API.Model.Vente> Vente { get; set; } = default!;

        /*protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Projet2_APIContext-05f37be6-1478-4682-b481-c9cb321a6a8f;Trusted_Connection=True;MultipleActiveResultSets=true");
            */
    }
}
