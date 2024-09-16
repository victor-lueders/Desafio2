using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoutsWeb.Data;
using MoutsWeb.Models;

namespace MoutsWeb.Pages.Vendas
{
    public class CreateModel : PageModel
    {
        private readonly MoutsWeb.Data.AulaDb _context;

        public CreateModel(MoutsWeb.Data.AulaDb context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Venda Venda { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Venda.Add(Venda);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
