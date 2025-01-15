using testeiel.Models;

namespace testeiel.Repository
{
    public interface IEstudanteRepository
    {
        List<Estudante> ListarTodos();

        Estudante BuscarPeloNome(string nome);
    }
}