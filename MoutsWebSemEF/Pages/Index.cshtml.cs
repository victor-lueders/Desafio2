using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoutsWebSemEF.Data;
using MoutsWebSemEF.Models;
using MoutsWebSemEF.Services;

namespace MoutsWebSemEF.Pages
{
    public class IndexModel : PageModel
    {
        private readonly VendaService _service = new VendaService();
        public List<Venda> Vendas;
        public void OnGet()
        {
            Vendas = _service.GetAll();
        }
    }
}
