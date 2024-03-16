using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Client.API;

namespace Client.Pages.Consoles
{
    public class DetailsModel : PageModel
    {
        private readonly IConsoleClient _context;

        public DetailsModel(IConsoleClient context)
        {
            _context = context;
        }

        public GameConsole GameConsole { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var ameconsole = await _context.GameConsole.FirstOrDefaultAsync(m => m.Id == id);
            GameConsole = await _context.GameConsolesGETAsync(id.Value);
            if (GameConsole == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
