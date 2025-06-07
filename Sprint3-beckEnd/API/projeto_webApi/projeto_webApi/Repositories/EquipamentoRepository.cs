using projeto_webApi.Domains;
using projeto_webApi.Interfaces;

namespace projeto_webApi.Repositories
{
    public class EquipamentoRepository : IEquipamento
    {
        /// <summary>
        /// Classe responsável por implementar as operações de CRUD para a entidade Equipamento.Repositório Equipamentos
        /// faz conexão com o banco de dados e executa as operações de CRUD (Create, Read, Update, Delete) para a entidade Equipamento.
        /// através do pacote Sytem.Data.SqlClient
        /// </summary>
        public EquipamentoRepository() { }


        public void Atualizar(int id, Equipamento equipamentoAtualizado)
        {
            throw new NotImplementedException();
        }

        public Equipamento BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Equipamento novoEquipamento)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Equipamento> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }

}
