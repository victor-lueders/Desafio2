using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoutsWebSemEF.Data;
using MoutsWebSemEF.Models;

namespace MoutsWebSemEF.Pages.Vendas
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Venda Venda { get; set; }

        RepositorioVenda _repo = new RepositorioVenda();

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

            _repo.Save(Venda);
            return RedirectToPage("Index");
        }
    }
}
