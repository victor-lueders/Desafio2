namespace MoutsWebSemEF.Models
{
    public class ProdutoVenda
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int VendaId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public ProdutoVenda(Produto produto, int quantidade)
        {
            this.Produto = produto;
            this.Quantidade = quantidade;
        }

        public ProdutoVenda() { }
    }
}
