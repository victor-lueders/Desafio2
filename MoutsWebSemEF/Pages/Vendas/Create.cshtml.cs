using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoutsWebSemEF.Data;
using MoutsWebSemEF.Models;
using MoutsWebSemEF.Services;

namespace MoutsWebSemEF.Pages.Vendas
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Venda Venda { get; set; }

        private readonly VendaService _service = new VendaService();

        public void OnGet()
        {
        }

        public void OnPost(string action)
        {
            if (action == "Create")
            {
                // Chama a função quando o botão é clicado
                Create();
            }
        }

        private IActionResult Create()
        {
            Venda.ValorTotal = 0;

            _service.Save(Venda);
            return RedirectToPage("Index");
        }
    }
}
