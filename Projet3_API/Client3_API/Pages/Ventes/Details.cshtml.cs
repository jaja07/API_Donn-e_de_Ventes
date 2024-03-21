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
    public class DetailsModel : PageModel
    {
        //private readonly Projet3_API.Data.Projet3_APIContext _context;
        private readonly IConsleClient _venteClient;

        public DetailsModel(IConsleClient context)
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
            }/*
            else
            {
                Vente = vente;
            }*/
            return Page();
        }
    }
}
