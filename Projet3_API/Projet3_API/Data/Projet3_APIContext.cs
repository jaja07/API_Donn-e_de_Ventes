using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projet3_API.Models;

namespace Projet3_API.Data
{
    public class Projet3_APIContext : DbContext
    {
        public Projet3_APIContext (DbContextOptions<Projet3_APIContext> options)
            : base(options)
        {
        }

        public DbSet<Projet3_API.Models.GameConsole> GameConsole { get; set; } = default!;
        public DbSet<Projet3_API.Models.Vente> Vente { get; set; } = default!;
        /*protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Projet3_APIContext-f2fc0bd1-6246-45d8-b4ee-637538812e93;Trusted_Connection=True;MultipleActiveResultSets=true");
         */   
    }
}
