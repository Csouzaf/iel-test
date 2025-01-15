using testeiel.Models;

namespace testeiel.Repository
{
    public interface IUsuarioRepository
    {
        Usuario BuscarPeloNome(string nome);

        Task<Usuario> Criar(Usuario usuario);

        Usuario BuscarEmail(string email);
    }
}