namespace MoutsWeb.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public IEnumerable<ProdutoVenda> Produtos { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public string Pagamento { get; set; }
        public double ValorTotal { get; set; }

        public Venda() { }

        public Venda(Cliente cliente, string pagamento, IEnumerable<ProdutoVenda> produtos)
        {
            this.Cliente = cliente;
            this.Pagamento = pagamento;
            this.Produtos = produtos;
            this.ValorTotal = 0;

            foreach (var produto in produtos)
            {
                ValorTotal += (produto.Produto.Valor * produto.Quantidade);
            }
        }

        public Venda(string pagamento, IEnumerable<ProdutoVenda> produtos)
        {
            this.Pagamento = pagamento;
            this.Produtos = produtos;
            this.ValorTotal = 0;

            foreach (var produto in produtos)
            {
                ValorTotal += (produto.Produto.Valor * produto.Quantidade);
            }
        }
    }
}
