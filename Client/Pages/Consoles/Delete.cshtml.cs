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
    public class DeleteModel : PageModel
    {
        private readonly IConsoleClient _context;

        public DeleteModel(IConsoleClient context)
        {
            _context = context;
        }

        [BindProperty]
        public GameConsole GameConsole { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //GameConsole = await _context.GameConsolesGETAsync.FirstOrDefaultAsync(m => m.Id == id);
            GameConsole = await _context.GameConsolesGETAsync(id.Value);


            if (GameConsole == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _context.GameConsolesDELETEAsync(id.Value);
            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }
    }
    }

