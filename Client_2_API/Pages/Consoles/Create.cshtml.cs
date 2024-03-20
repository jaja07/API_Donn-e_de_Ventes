using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Client_2_API.API;

namespace Client_2_API.Pages.Consoles
{
    public class CreateModel : PageModel
    {
        //private readonly Projet2_API.Data.Projet2_APIContext _context;
        private readonly IConsoleClient _consoleClient;

        public CreateModel(IConsoleClient context)
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

            //_context.GameConsole.Add(GameConsole);
           // await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
