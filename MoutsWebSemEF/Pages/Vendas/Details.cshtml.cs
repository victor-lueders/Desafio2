using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoutsWebSemEF.Models;
using MoutsWebSemEF.Services;

namespace MoutsWebSemEF.Pages.Vendas
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public Venda Venda { get; set; }

        private readonly VendaService _service = new VendaService();

        public void OnGet(int id)
        {
           Venda = _service.Get(id);
        }
    }
}
