using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MoutsWebSemEF.Models;

namespace MoutsWebSemEF.Data
{
    public class RepositorioVenda
    {
        List<Venda> vendaList = new List<Venda>();
        Venda venda = null;

        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=AulaDb;Trusted_Connection=True;Integrated Security=true;TrustServerCertificate=True";
        public void Delete(Venda entity)
        {
            string deleteQuery = "DELETE FROM Venda WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", entity.Id);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public Venda Get(int id)
        {
            try
            {
                var selectQuery = "SELECT * FROM Venda WHERE Id = @Id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            venda = new Venda
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                ClienteId = reader.GetInt32(reader.GetOrdinal("ClienteId")),
                                ValorTotal = reader.GetDouble(reader.GetOrdinal("ValorTotal")),
                                Pagamento = reader.GetString(reader.GetOrdinal("Pagamento"))
                            };
                        }
                    }
                }

                return venda;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Venda> GetAll()
        {
            vendaList.Clear();
            var selectQuery = "SELECT * FROM Venda";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vendaList.Add(new Venda
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                ClienteId = reader.GetInt32(reader.GetOrdinal("ClienteId")),
                                ValorTotal = reader.GetDouble(reader.GetOrdinal("ValorTotal")),
                                Pagamento = reader.GetString(reader.GetOrdinal("Pagamento"))
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return vendaList;
        }

        public Venda Save(Venda entity)
        {
            try
            {

                /*entity.Id = VendaList.Count + 1;
                VendaList.Add(entity);*/
                var insertQuery = "INSERT INTO Venda (ClienteId, Pagamento, ValorTotal) VALUES (@ClienteId, @Pagamento, @ValorTotal); " +
                    "SELECT SCOPE_IDENTITY();";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ClienteId", entity.ClienteId);
                    cmd.Parameters.AddWithValue("@Pagamento", entity.Pagamento);
                    cmd.Parameters.AddWithValue("@ValorTotal", entity.ValorTotal);

                    conn.Open();
                    entity.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(Venda entity)
        {
            try
            {
                var updateQuery = "UPDATE Venda SET Pagamento = @Pagamento, ValorTotal = @ValorTotal WHERE Id = @Id";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Pagamento", entity.Pagamento);
                    cmd.Parameters.AddWithValue("@ValorTotal", entity.ValorTotal);
                    cmd.Parameters.AddWithValue("@Id", entity.Id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<ProdutoVenda> ObterProdutos(int compraId)
        {
            try
            {
                var produtos = new List<ProdutoVenda>();
                var select = "SELECT * FROM ProdutoVenda WHERE VendaId = " + compraId;

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(select, conn))
                {

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            produtos.Add(new ProdutoVenda()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                ProdutoId = reader.GetInt32(reader.GetOrdinal("ProdutoId")),
                                Quantidade = reader.GetInt32(reader.GetOrdinal("Quantidade")),
                            });
                        }
                    }
                }

                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Produto GetProduto(int id)
        {
            try
            {
                var select = "SELECT * FROM Produto WHERE Id = " + id;

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(select, conn))
                {

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Produto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Descricao = reader.GetString(reader.GetOrdinal("Descricao")),
                                Valor = reader.GetDouble(reader.GetOrdinal("Valor"))
                            };
                        }
                    }
                }

                return new Produto();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool SaveProduto(int produtoId, int quantidade, int vendaId)
        {
            try
            {
                var insertQuery = "INSERT INTO ProdutoVenda (ProdutoId, VendaId, Quantidade) VALUES (@ProdutoId, @VendaId, @Quantidade);";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ProdutoId", produtoId);
                    cmd.Parameters.AddWithValue("@VendaId", vendaId);
                    cmd.Parameters.AddWithValue("@Quantidade", quantidade);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                CalcularValor(vendaId, produtoId, quantidade);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CalcularValor(int vendaId, int produtoId, int quantidade)
        {
            var produto = GetProduto(produtoId);
            var valor = produto.Valor * quantidade;

            var venda = Get(vendaId);
            venda.ValorTotal += valor;

            Update(venda);
        }
    }
}
