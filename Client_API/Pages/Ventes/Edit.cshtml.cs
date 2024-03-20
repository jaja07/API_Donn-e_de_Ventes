using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Client_API.API;

namespace Client_API.Pages.Ventes
{
    public class EditModel : PageModel
    {
        //private readonly Projet_API.Data.Projet_APIContext _context;
        private readonly IConsoleClient _venteClient;
        public EditModel(IConsoleClient context)
        {
            _venteClient = context;
        }

        [BindProperty]
        public Vente Vente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vente =  await _venteClient.VentesGETAsync(id.Value);
            if (vente == null)
            {
                return NotFound();
            }
            Vente = vente;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(Vente).State = EntityState.Modified;

            try
            {
                await _venteClient.VentesPUTAsync(Vente.Id, Vente);
            }
            /*catch (DbUpdateConcurrencyException)
            {
                if (!VenteExists(Vente.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }*/
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }


            return RedirectToPage("./Index");
        }

        /*
         private bool VenteExists(int id)
        {
            return _context.Vente.Any(e => e.Id == id);
        }*/
    }
}
