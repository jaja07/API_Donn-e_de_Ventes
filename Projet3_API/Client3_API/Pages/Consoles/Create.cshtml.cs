using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Client3_API.API;

namespace Client3_API.Pages.Consoles
{
    public class CreateModel : PageModel
    {
        //private readonly Projet3_API.Data.Projet3_APIContext _context;
        private readonly IConsleClient _consoleClient;

        public CreateModel(IConsleClient context)
        {
            _consoleClient = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GameConsole GameConsole { get; set; } 

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _consoleClient.GameConsolesPOSTAsync(GameConsole);
            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }
            /*
            _context.GameConsole.Add(GameConsole);
            await _context.SaveChangesAsync();*/

            return RedirectToPage("./Index");
        }
    }
}
