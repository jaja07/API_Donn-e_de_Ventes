using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Client_API.API;

namespace Client_API.Pages.Ventes
{
    public class DetailsModel : PageModel
    {
        //private readonly Projet_API.Data.Projet_APIContext _context;
        private readonly IConsoleClient _venteClient;
        public DetailsModel(IConsoleClient context)
        {
            _venteClient = context;
        }

        public Vente Vente { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var vente = await _context.Vente.FirstOrDefaultAsync(m => m.Id == id);
            Vente = await _venteClient.VentesGETAsync(id.Value);
            if (Vente == null)
            {
                return NotFound();
            }
            /*else
            {
                Vente = vente;
            }*/
            return Page();
        }
    }
}
