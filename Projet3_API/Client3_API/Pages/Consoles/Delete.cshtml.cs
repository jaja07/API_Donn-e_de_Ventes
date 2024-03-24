using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;
using Client3_API.API;


namespace Client3_API.Pages.Consoles
{
    public class DeleteModel : PageModel
    {
        //private readonly Projet3_API.Data.Projet3_APIContext _context;
        private readonly IConsleClient _consoleClient;

        public DeleteModel(IConsleClient context)
        {
            _consoleClient = context;
        }

        [BindProperty]
        public GameConsole GameConsole { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var gameconsole = await _context.GameConsole.FirstOrDefaultAsync(m => m.Id == id);
            GameConsole = await _consoleClient.GameConsolesGETAsync(id.Value);

            if (GameConsole == null)
            {
                return NotFound();
            }
            /*else
            {
                GameConsole = gameconsole;
            }*/
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            //var ventes = await _consoleClient.VentesAllAsync();
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                await _consoleClient.GameConsolesDELETEAsync(id.Value);
                //await _consoleClient.VentesDELETEAsync(id.Value);

                
                //VenteWithConsoleNom = new List<(Vente, string)>();

                /*foreach (var vente in ventes)
                {
                    if(vente.ConsoleId == id.Value)
                    {
                        await _consoleClient.VentesDELETEAsync(vente.Id);
                    }
                    //var console = await _venteClient.GameConsolesGETAsync(vente.ConsoleId ?? 0);
                    
                }*/
            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }
            /* var gameconsole = await _context.GameConsole.FindAsync(id);
             if (gameconsole != null)
             {
                 GameConsole = gameconsole;
                 _context.GameConsole.Remove(GameConsole);
                 await _context.SaveChangesAsync();
             }*/

            return RedirectToPage("./Index");
            
        }
    }
}
