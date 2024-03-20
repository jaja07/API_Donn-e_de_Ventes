using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Client_2_API.API;

namespace Client_2_API.Pages.Ventes
{
    public class DeleteModel : PageModel
    {
        //private readonly Projet2_API.Data.Projet2_APIContext _context;
        private readonly IConsoleClient _venteClient;
        public DeleteModel(IConsoleClient context)
        {
            _venteClient = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var vente = await _context.Vente.FindAsync(id);
            if (vente != null)
            {
                Vente = vente;
                _context.Vente.Remove(Vente);
                await _context.SaveChangesAsync();
            }*/
            try
            {
                await _venteClient.VentesDELETEAsync(id.Value);
            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }
    }
}
