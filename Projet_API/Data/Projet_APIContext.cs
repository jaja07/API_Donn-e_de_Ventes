using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projet_API.Models;

namespace Projet_API.Data
{
    public class Projet_APIContext : DbContext
    {
        public Projet_APIContext (DbContextOptions<Projet_APIContext> options)
            : base(options)
        {
        }

        public DbSet<Projet_API.Models.Vente> Vente { get; set; } = default!;
        public DbSet<Projet_API.Models.GameConsole> GameConsole { get; set; } = default!;
        /*protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Projet_APIContext-fd8f4e47-0139-40c2-b4de-fb71a44f86c9;Trusted_Connection=True;MultipleActiveResultSets=true");*/
    }
}
