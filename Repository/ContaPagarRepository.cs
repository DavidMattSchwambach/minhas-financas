using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class ContaPagarRepository : IRepository
    {
        private Conexao conexao;

        public ContaPagarRepository()
        {
            conexao = new Conexao();
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = "DELETE FROM contas_pagar WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public bool Atualizar(ContaPagar contapagar)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = "UPDATE contas_pagar SET nome = @NOME, valor = @VALOR, tipo = @TIPO, descricao = @DESCRICAO, status = @STATUS WHERE id = @ID";
            comando.Parameters.AddWithValue("@NOME", contapagar.Nome);
            comando.Parameters.AddWithValue("@VALOR", contapagar.Valor);
            comando.Parameters.AddWithValue("@TIPO", contapagar.Tipo);
            comando.Parameters.AddWithValue("@DESCRICAO", contapagar.Descricao);
            comando.Parameters.AddWithValue("@STATUS", contapagar.Status);
            comando.Parameters.AddWithValue("@ID", contapagar.Id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public int Inserir(ContaPagar contapagar)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = "INSERT INTO contas_pagar (nome, valor, tipo, descricao, status) OUTPUT INSERTED.ID VALUES (@NOME, @VALOR, @TIPO, @DESCRICAO, @STATUS)";
            comando.Parameters.AddWithValue("@NOME", contapagar.Nome);
            comando.Parameters.AddWithValue("@VALOR", contapagar.Valor);
            comando.Parameters.AddWithValue("@TIPO", contapagar.Tipo);
            comando.Parameters.AddWithValue("@DESCRICAO", contapagar.Descricao);
            comando.Parameters.AddWithValue("@STATUS", contapagar.Status);
            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;
        }

        public ContaPagar ObterPeloId(int id)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = "SELECT * FROM contas_pagar WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();
            if (tabela.Rows.Count == 0)
            {
                return null;
            }

            DataRow linha = tabela.Rows[0];
            ContaPagar contaPagar = new ContaPagar();
            contaPagar.Id = Convert.ToInt32(linha["id"]);
            contaPagar.Nome = linha["nome"].ToString();
            contaPagar.Valor = Convert.ToDecimal(linha["valor"]);
            contaPagar.Tipo = linha["tipo"].ToString();
            contaPagar.Descricao = linha["descricao"].ToString();
            contaPagar.Status = linha["status"].ToString();
            return contaPagar;

        }

        public List<ContaPagar> ObterTodos(string busca)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = "SELECT * FROM contas_pagar WHERE nome LIKE @NOME";
            busca = $"%{busca}%";
            comando.Parameters.AddWithValue("@NOME", busca);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();
            List<ContaPagar> contas_pagar = new List<ContaPagar>();
            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow linha = tabela.Rows[i];
                ContaPagar contaPagar = new ContaPagar();
                contaPagar.Id = Convert.ToInt32(linha["id"]);
                contaPagar.Nome = linha["nome"].ToString();
                contaPagar.Valor = Convert.ToDecimal(linha["valor"]);
                contaPagar.Tipo = linha["tipo"].ToString();
                contaPagar.Descricao = linha["descricao"].ToString();
                contaPagar.Status = linha["status"].ToString();
                contas_pagar.Add(contaPagar);

            }

            return contas_pagar;

        }
    }
}
