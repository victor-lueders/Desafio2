using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoutsWebSemEF.Data;
using MoutsWebSemEF.Models;

namespace MoutsWebSemEF.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RepositorioVenda _repositorio = new RepositorioVenda();
        public List<Venda> Vendas;
        public void OnGet()
        {
            Vendas = _repositorio.GetAll();
        }

        public void ListClick(object sender, EventArgs e)
        {

        }
    }
}
