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
    public class IndexModel : PageModel
    {
        private readonly IConsleClient _consoleClient;

        public IndexModel(IConsleClient context)
        {
            _consoleClient = context;
        }

        public IList<GameConsole> GameConsole { get;set; } = default!;

        public async Task OnGetAsync()
        {
            GameConsole = (await _consoleClient.GameConsolesAllAsync()).ToList();
        }
    }
}
