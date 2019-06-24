using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class ContaReceberRepository : IContaReceberRepository
    {
        private Conexao conexao;

        public ContaReceberRepository()
        {
            conexao = new Conexao();
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = "DELETE FROM contas_receber WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public bool Atualizar(ContaReceber contaReceber)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = "UPDATE contas_receber SET nome = @NOME, valor = @VALOR, tipo = @TIPO, descricao = @DESCRICAO, status = @STATUS WHERE id = @ID";
            comando.Parameters.AddWithValue("@NOME", contaReceber.Nome);
            comando.Parameters.AddWithValue("@VALOR", contaReceber.Valor);
            comando.Parameters.AddWithValue("@TIPO", contaReceber.Tipo);
            comando.Parameters.AddWithValue("@DESCRICAO", contaReceber.Descricao);
            comando.Parameters.AddWithValue("@STATUS", contaReceber.Status);
            comando.Parameters.AddWithValue("@ID", contaReceber.Id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public int Inserir(ContaReceber contaReceber)
        {
            SqlCommand comando = conexao.conectar();
            comando.CommandText = "INSERT INTO contas_Receber (nome, valor, tipo, descricao, status) OUTPUT INSERTED.ID VALUES (@NOME, @VALOR, @TIPO, @DESCRICAO, @STATUS)";
            comando.Parameters.AddWithValue("@NOME", contaReceber.Nome);
            comando.Parameters.AddWithValue("@VALOR", contaReceber.Valor);
            comando.Parameters.AddWithValue("@TIPO", contaReceber.Tipo);
            comando.Parameters.AddWithValue("@DESCRICAO", contaReceber.Descricao);
            comando.Parameters.AddWithValue("@STATUS", contaReceber.Status);
            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();

            return id;
        }

        public ContaReceber ObterPeloId(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContaReceber> ObterTodos(string busca)
        {
            throw new NotImplementedException();
        }
    }
}
