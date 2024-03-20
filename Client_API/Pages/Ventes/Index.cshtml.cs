using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Client_API.API;

namespace Client_API.Pages.Ventes
{
    public class IndexModel : PageModel
    {
        //private readonly Projet_API.Data.Projet_APIContext _context;
        private readonly IConsoleClient _venteClient;

        public IndexModel(IConsoleClient context)
        {
            _venteClient = context;
        }

        public IList<Vente> Vente { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Vente = (await _venteClient.VentesAllAsync()).ToList();
        }
    }
}


