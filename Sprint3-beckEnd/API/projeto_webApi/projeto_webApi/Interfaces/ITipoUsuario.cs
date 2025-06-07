using projeto_webApi.Domains;

namespace projeto_webApi.Interfaces
{
    public interface ITipoUsuario
    {
        List<TipoUsuario> ListarTodos();

        void Cadastrar(TipoUsuario novoTipo);

        void Atualizar(int id, TipoUsuario tiposUsuarioAtualizado);

        void Deletar(int id);
    }
}
