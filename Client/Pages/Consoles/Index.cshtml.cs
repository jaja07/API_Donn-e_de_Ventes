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
    public class IndexModel : PageModel
    {
        private readonly IConsoleClient _context;

        public IndexModel(IConsoleClient context)
        {
            _context = context;
        }

        public IList<GameConsole> GameConsole { get;set; } = default!;

        public async Task OnGetAsync()
        {
            GameConsole = (await _context.GameConsolesAllAsync()).ToList();
        }
    }
}
