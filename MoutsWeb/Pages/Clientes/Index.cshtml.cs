using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoutsWeb.Data;
using MoutsWeb.Models;

namespace MoutsWeb.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly MoutsWeb.Data.AulaDb _context;

        public IndexModel(MoutsWeb.Data.AulaDb context)
        {
            _context = context;
        }

        public IList<Cliente> Cliente { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Cliente = await _context.Cliente.ToListAsync();
        }
    }
}
