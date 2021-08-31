using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Threading.Tasks;
using LojaUtilidades.Model;
using System.Data;


namespace LojaUtilidades.Control
{
    class Produto
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }

        public string Menssagem;
        private SqlCeCommand comm;

        public Produto()
        {
            
            comm = new SqlCeCommand();
            
            comm.Connection = BancoDB.GetConnection();
            BancoDB.CriarBanco();
            
        }

        public void Cadastrar(string nome, double valor, int quantidade)
        {
            string sqlCommand = "INSERT INTO Produtos (produto, Valor, Quantidade) VALUES(@Produto, @Valor, @Quantidade)";
           
            try
            {
                BancoDB.GetConnection().Open();
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Produto", nome);
                comm.Parameters.AddWithValue("@Valor", valor);
                comm.Parameters.AddWithValue("@Quantidade", quantidade);
                comm.CommandText = sqlCommand;
                if(comm.ExecuteNonQuery() > 0)
                {
                    Menssagem = "Cadastro Realizado com Sucesso !";
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {

                BancoDB.GetConnection().Close();
                               
            }
            
        }
        
        public void Editar(int id, string nome, double valor, int quantidade)
        {
          
            string query = "UPDATE Produtos SET produto = @Nome, valor = @Valor , quantidade = @Quantidade WHERE Id LIKE  @Id ";

            try
            {
                BancoDB.GetConnection().Open();
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Nome", nome);
                comm.Parameters.AddWithValue("@Valor", valor);
                comm.Parameters.AddWithValue("@Quantidade", quantidade);
                comm.Parameters.AddWithValue("@Id", id);
                comm.CommandText = query;
                comm.ExecuteNonQuery();
               

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BancoDB.GetConnection().Close();
                
            }
        }
        public void EditarQuantidade(string nome, int quantidade)
        {
            string query = "UPDATE Produtos SET quantidade = quantidade - @Quantidade WHERE produto LIKE @Nome";
            try
            {
                BancoDB.GetConnection().Open();
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Nome", nome);
                comm.Parameters.AddWithValue("@Quantidade", quantidade);
                comm.CommandText = query;
                comm.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                BancoDB.GetConnection().Close();
            }
        }

        public  void Deletar(int id)
        {
            string query = "DELETE FROM Produtos WHERE Id = @Id";
            try
            {
                BancoDB.GetConnection().Open();
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Id", id);
                comm.CommandText = query;
                if (comm.ExecuteNonQuery() > 0)
                {
                    Menssagem = "Produto Excluido com Sucesso !";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BancoDB.GetConnection().Close();
               
            }
        }

        public DataTable Consultar()
        { 
            try
            {
                string query = "SELECT * FROM Produtos;";
                comm.CommandText = query;
                DataTable dados = new DataTable(); 
                BancoDB.GetConnection().Open();
                SqlCeDataAdapter adapter = new SqlCeDataAdapter(comm);
               
                adapter.Fill(dados);
                return dados;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                BancoDB.GetConnection().Close();
                
            }
        }

        public DataTable ConsultarProdutoPorNome(string nome)
        {
            
            string query = "SELECT *  FROM Produtos WHERE  produto LIKE @PRODUTO";
            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@PRODUTO", nome);
            try
            {
                comm.CommandText = query;
                DataTable dados = new DataTable();
                BancoDB.GetConnection().Open();
                SqlCeDataAdapter adapter = new SqlCeDataAdapter(comm);
                adapter.Fill(dados);
                return dados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BancoDB.GetConnection().Close();
            }
           
        }

        public DataTable ConsultaVenda(string nome)
        {

            {

                string query = "SELECT produto, valor  FROM Produtos WHERE  produto LIKE @PRODUTO";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@PRODUTO", nome);
                try
                {
                    comm.CommandText = query;
                    DataTable dados = new DataTable();
                    BancoDB.GetConnection().Open();
                    SqlCeDataAdapter adapter = new SqlCeDataAdapter(comm);
                    adapter.Fill(dados);
                    return dados;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    BancoDB.GetConnection().Close();
                }

            }
        }
    }
}
