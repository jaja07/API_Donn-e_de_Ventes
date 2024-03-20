using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Client_API.API;

namespace Client_API.Pages.Ventes
{
    public class CreateModel : PageModel
    {
        //private readonly Projet_API.Data.Projet_APIContext _context;
        private readonly IConsoleClient _venteClient;
        public CreateModel(IConsoleClient context)
        {
            _venteClient = context;
        }

        public IActionResult OnGet()
        {
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
            return RedirectToPage("./Index");

            /*_context.Vente.Add(Vente);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");*/
        }
    }
}
