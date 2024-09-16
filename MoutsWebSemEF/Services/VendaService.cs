using Microsoft.CodeAnalysis.Operations;
using MoutsWebSemEF.Data;
using MoutsWebSemEF.Models;

namespace MoutsWebSemEF.Services
{
    public class VendaService
    {
        RepositorioVenda _repo;
        public VendaService(RepositorioVenda repo)
        {
            _repo = repo;
        }
        public Venda Save(Venda v)
        {
            if (v.ValorTotal < 0)
            {
                throw new Exception("O valor da compra não pode ser menor que zero");
            }
            if (v.Pagamento.Equals(""))
            {
                throw new Exception("Insira uma forma de pagamento válida");
            }
            if (v.ClienteId < 0)
            {
                throw new Exception("Id do cliente invalido");
            }
            return _repo.Save(v);
            
        }
        public Venda Get(int id)
        {
            if (id< 0)
            {
                throw new Exception("Id Invalido");
            }
            return _repo.Get(id);
        }
        public void Delete(Venda entity)
        {
            if (entity.Id< 0)
            {
                throw new Exception("Id Invalido");
            }
            _repo.Delete(entity);
        }
        public List<Venda> GetAll()
        {
            return _repo.GetAll();
        }
        public  bool Update(Venda entity)
        {
            if (entity.ValorTotal < 0)
            {
                throw new Exception("O valor da compra não pode ser menor que zero");
            }
            if (entity.Pagamento.Equals(""))
            {
                throw new Exception("Insira uma forma de pagamento válida");
            }
            if (entity.ClienteId < 0)
            {
                throw new Exception("Id do cliente invalido");
            }
            return _repo.Update(entity);
            
        }
        
        public Produto GetProduto(int id)
        {
            if (id< 0)
            {
                throw new Exception("Id invalido");
           }
            return (_repo.GetProduto(id));
            
        }
        public List<ProdutoVenda>  ObterProdutos(int compraId)
        {
            if (compraId < 0)
            {
                throw new Exception("Id da compra Invalido");
            }
            
            return _repo.ObterProdutos(compraId);
        }
    }
}
