using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoutsWebSemEF.Data;
using MoutsWebSemEF.Models;
using MoutsWebSemEF.Services;

namespace MoutsWebSemEF.Pages.Vendas
{
    public class ListItemsModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public List<ListItem> Itens { get; set; }

        private readonly VendaService _service = new VendaService();
        private List<ProdutoVenda> produtos;
        public void OnGet(int id)
        {
            Id = id;
            Itens = new List<ListItem>();
            produtos = _service.ObterProdutos(Id);

            
            foreach (var produto in produtos)
            {
                var item = _service.GetProduto(produto.ProdutoId);

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
