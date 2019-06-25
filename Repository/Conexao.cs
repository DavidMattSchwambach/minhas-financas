using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Conexao
    {
        public SqlCommand conectar()
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\david\Documents\BancoDados03.mdf;Integrated Security=True;Connect Timeout=30";
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            return comando;
        }
    }
}
