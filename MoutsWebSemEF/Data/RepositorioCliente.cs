using Microsoft.Data.SqlClient;
using MoutsWebSemEF.Models;

namespace MoutsWebSemEF.Data
{
    public class RepositorioCliente
    {
        private List<Cliente> clienteList = new List<Cliente>();
        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=AulaDb;Trusted_Connection=True;Integrated Security=true;TrustServerCertificate=True";
        public void Delete(Cliente entity)
        {
            string deleteQuery = "DELETE FROM Cliente WHERE Id = @Id";
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

        public Cliente Get(int id)
        {
            Cliente cliente = null;
            var selectQuery = "SELECT * FROM Cliente WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cliente = new Cliente
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nome = reader.GetString(reader.GetOrdinal("Nome")),
                            cpf = reader.GetString(reader.GetOrdinal("Cpf")),
                            Telefone = reader.GetString(reader.GetOrdinal("Telefone")),
                            Endereco = reader.GetString(reader.GetOrdinal("Endereco")),
                            Pontuacao = reader.GetInt32(reader.GetOrdinal("Pontuacao"))
                        };
                    }
                }
            }

            return cliente;
        }

        public List<Cliente> GetAll()
        {
            clienteList.Clear();
            var selectQuery = "SELECT * FROM Cliente";

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
                            clienteList.Add(new Cliente
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nome = reader.GetString(reader.GetOrdinal("Name")),
                                cpf = reader.GetString(reader.GetOrdinal("Cpf")),
                                Telefone = reader.GetString(reader.GetOrdinal("Fone")),
                                Endereco = reader.GetString(reader.GetOrdinal("Endereco")),
                                Pontuacao = reader.GetInt32(reader.GetOrdinal("Pontuacao"))
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return clienteList;
        }

        public Cliente Save(Cliente entity)
        {
            /*entity.Id = ClienteList.Count + 1;
            ClienteList.Add(entity);*/
            var insertQuery = "INSERT INTO Cliente (Nome, Cpf, Telefone, Endereco, Pontuacao) VALUES (@Nome, @Cpf, @Telefone, @Endereco, @Pontuacao); " +
                "SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
            {
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@Cpf", entity.cpf);
                cmd.Parameters.AddWithValue("@Telefone", entity.Telefone);
                cmd.Parameters.AddWithValue("@Endereco", entity.Endereco);
                cmd.Parameters.AddWithValue("@Pontuacao", entity.Pontuacao);

                conn.Open();
                entity.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return entity;
        }

        public bool Update(Cliente entity)
        {
            var updateQuery = "UPDATE Cliente SET Nome = @Nome, Cpf = @cpf, Telefone = @Telefone, Endereco = @Endereco, Pontuacao = @Pontuacao WHERE Id = @Id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@Cpf", entity.cpf);
                cmd.Parameters.AddWithValue("@Telefone", entity.Telefone);
                cmd.Parameters.AddWithValue("@Endereco", entity.Endereco);
                cmd.Parameters.AddWithValue("@Pontuacao", entity.Pontuacao);
                cmd.Parameters.AddWithValue("@Id", entity.Id);

                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }

            return false;
        }
    }
}
