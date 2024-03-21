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
    public class DetailsModel : PageModel
    {
        //private readonly Projet3_API.Data.Projet3_APIContext _context;
        private readonly IConsleClient _consoleClient;
        public DetailsModel(IConsleClient context)
        {
            _consoleClient = context;
        }

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
    }
}
