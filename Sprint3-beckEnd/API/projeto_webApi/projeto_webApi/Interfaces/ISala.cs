namespace projeto_webApi.Interfaces
{
    public interface ISala
    {
        List<ISala> ListarTodos(int id);

        List<ISala> Listar();

        void Cadastrar(ISala novaSala);

        void Atualizar(int id, ISala salaAtualizada);

        void Deletar(int id);



    }
}
