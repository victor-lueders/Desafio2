using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoutsWebSemEF.Data;
using MoutsWebSemEF.Services;

namespace MoutsWebSemEF.Pages.Vendas
{
    public class AddItemModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public int ProdutoId { get; set; }
        [BindProperty]
        public int Quantidade { get; set; }

        private readonly VendaService _service = new VendaService();

        public void OnGet(int id)
        {
            Id = id;
        }

        public void OnPost(string action)
        {
            if(action == "Create")
            {
                Add();
            }
        }

        public IActionResult Add()
        {
            _service.SaveProduto(ProdutoId, Quantidade, Id);

            return RedirectToPage("./Vendas/ListItems");
        }
    }
}
