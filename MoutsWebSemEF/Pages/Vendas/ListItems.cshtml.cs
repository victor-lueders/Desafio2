using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoutsWebSemEF.Data;
using MoutsWebSemEF.Models;

namespace MoutsWebSemEF.Pages.Vendas
{
    public class ListItemsModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }

        RepositorioVenda _repo = new RepositorioVenda();
        public List<ListItem> Itens;
        private List<ProdutoVenda> produtos;
        public void OnGet()
        {
            produtos = _repo.ObterProdutos(Id);
            
            foreach (var produto in produtos)
            {
                var item = _repo.GetProduto(produto.ProdutoId);

                Itens.Add(new ListItem { Id = produto.Id, Descricao = item.Descricao, Quantidade = produto.Quantidade });
            }
        }


    }

    public class ListItem
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
    }
}
