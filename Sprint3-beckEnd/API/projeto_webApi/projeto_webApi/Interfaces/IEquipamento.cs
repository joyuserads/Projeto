using projeto_webApi.Domains;

namespace projeto_webApi.Interfaces
{
    public interface IEquipamento
    {
        List<Equipamento> ListarTodos();

        void Cadastrar(Equipamento novoEquipamento);

        void Atualizar(int id, Equipamento equipamentoAtualizado);

        void Deletar(int id);

        Equipamento BuscarPorId(int id);


    }
}
