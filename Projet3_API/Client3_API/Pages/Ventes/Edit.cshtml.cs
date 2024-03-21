using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
using Client3_API.API;

namespace Client3_API.Pages.Ventes
{
    public class EditModel : PageModel
    {
        //private readonly Projet3_API.Data.Projet3_APIContext _context;
        private readonly IConsleClient _venteClient;


        public EditModel(IConsleClient context)
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

            //var vente =  await _context.Vente.FirstOrDefaultAsync(m => m.Id == id);
            var vente = await _venteClient.VentesGETAsync(id.Value);

            if (vente == null)
            {
                return NotFound();
            }
            Vente = vente;
           //ViewData["ConsoleId"] = new SelectList(_context.GameConsole, "Id", "Fabricant");
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
                //await _context.SaveChangesAsync();
                await _venteClient.VentesPUTAsync(Vente.Id, Vente);

            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
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

            return RedirectToPage("./Index");
        }

        /*private bool VenteExists(int id)
        {
            return _context.Vente.Any(e => e.Id == id);
        }*/
    }
}
