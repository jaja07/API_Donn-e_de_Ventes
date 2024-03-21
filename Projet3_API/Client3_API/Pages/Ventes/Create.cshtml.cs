using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Client3_API.API;

namespace Client3_API.Pages.Ventes
{
    public class CreateModel : PageModel
    {
        //private readonly Projet3_API.Data.Projet3_APIContext _context;
        private readonly IConsleClient _venteClient;


        public CreateModel(IConsleClient context)
        {
            _venteClient = context;
        }

        public IActionResult OnGet()
        {
        //ViewData["ConsoleId"] = new SelectList(_context.GameConsole, "Id", "Fabricant");
            return Page();
        }

        [BindProperty]
        public Vente Vente { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _venteClient.VentesPOSTAsync(Vente);
            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }

           /* _context.Vente.Add(Vente);
            await _context.SaveChangesAsync();*/

            return RedirectToPage("./Index");
        }
    }
}
