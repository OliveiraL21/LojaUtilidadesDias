using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.IO;

namespace LojaUtilidades.Model
{
    public static class BancoDB
    {
        private static SqlCeConnection connection;
        private static string DataBase = @"C:\Users\lucas\source\repos\LojaUtilidades\LojaUtilidades\bin\Debug\LojaDB\loja_utilidades.sdf";
        private static string strCon = @"Datasource= " + DataBase + "; Password= 'AC@2701'";
        public static SqlCeConnection GetConnection()
        {

            if (connection == null)
            {
                connection = new SqlCeConnection();
                connection.ConnectionString = strCon;

            }
            return connection;
        }
        public static void CriarBanco()
        {
            SqlCeEngine db = new SqlCeEngine(strCon);
            if (!File.Exists(DataBase))
            {
                db.CreateDatabase();
            }
            db.Dispose();
        }

        public static void CriarTabela()
        {
            connection = new SqlCeConnection(strCon);
            SqlCeCommand comando = new SqlCeCommand();
            comando.Connection = connection;

            try
            {
                connection.Open();
                comando.CommandText = "CREATE TABLE Produtos (Id INT NOT NULL PRIMARY KEY IDENTITY, produto NVARCHAR(50), valor FLOAT, quantidade INT)";
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }


        }
    }
}
