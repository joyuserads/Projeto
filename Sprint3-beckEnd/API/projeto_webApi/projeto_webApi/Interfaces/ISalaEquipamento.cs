using projeto_webApi.Domains;

namespace projeto_webApi.Interfaces
{
    public interface ISalaEquipamento
    {
        List<SalaEquipamento> ListarTodos();

        void Cadastrar(SalaEquipamento novaSalaEquipamento);

        void Atualizar(int id, SalaEquipamento salaEquipamentoAtualizada);

        void Deletar(int id);
    }
}
