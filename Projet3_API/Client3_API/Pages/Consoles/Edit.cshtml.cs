using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
using Client3_API.API;

namespace Client3_API.Pages.Consoles
{
    public class EditModel : PageModel
    {
        // private readonly Projet3_API.Data.Projet3_APIContext _context;
        private readonly IConsleClient _consoleClient;
        public EditModel(IConsleClient context)
        {
            _consoleClient = context;
        }

        [BindProperty]
        public GameConsole GameConsole { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var gameconsole =  await _context.GameConsole.FirstOrDefaultAsync(m => m.Id == id);
            var gameconsole = await _consoleClient.GameConsolesGETAsync(id.Value);

            if (gameconsole == null)
            {
                return NotFound();
            }
            GameConsole = gameconsole;
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

           // _context.Attach(GameConsole).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
                await _consoleClient.GameConsolesPUTAsync(GameConsole.Id, GameConsole);

            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }
            /*catch (DbUpdateConcurrencyException)
            {
                if (!GameConsoleExists(GameConsole.Id))
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

        /*private bool GameConsoleExists(int id)
        {
            return _context.GameConsole.Any(e => e.Id == id);
        }*/
    }
}
