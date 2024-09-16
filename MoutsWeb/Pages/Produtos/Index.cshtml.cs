using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoutsWeb.Data;
using MoutsWeb.Models;

namespace MoutsWeb.Pages.Produtos
{
    public class IndexModel : PageModel
    {
        private readonly MoutsWeb.Data.AulaDb _context;

        public IndexModel(MoutsWeb.Data.AulaDb context)
        {
            _context = context;
        }

        public IList<Produto> Produto { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Produto = await _context.Produto.ToListAsync();
        }
    }
}
