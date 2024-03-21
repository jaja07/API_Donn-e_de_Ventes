using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;
using Client3_API.API;

namespace Client3_API.Pages.Ventes
{
    public class IndexModel : PageModel
    {
        //private readonly Projet3_API.Data.Projet3_APIContext _context;
        private readonly IConsleClient _venteClient;
        public IndexModel(IConsleClient context)
        {
            _venteClient = context;
        }

        public IList<(Vente vente, string ConsoleNom)> VenteWithConsoleNom { get; set; } = default!;
        //public IList<Vente> Vente { get;set; } = default!;

        public async Task OnGetAsync()
        {

            var ventes = await _venteClient.VentesAllAsync();
            VenteWithConsoleNom = new List<(Vente, string)>();

            foreach (var vente in ventes)
            {
                var console = await _venteClient.GameConsolesGETAsync(vente.ConsoleId ?? 0);
                VenteWithConsoleNom.Add((vente, console?.Nom ?? "Unknown"));
            }
            /* Vente = await _context.Vente
                 .Include(v => v.Console).ToListAsync();*/
            //Vente = (await _venteClient.VentesAllAsync()).ToList();


        }
    }
}
