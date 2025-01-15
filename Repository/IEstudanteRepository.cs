using testeiel.Models;

namespace testeiel.Repository
{
    public interface IEstudanteRepository
    {
        List<Estudante> ListarTodos();

        Estudante Criar(Estudante estudante);

        bool Deletar(int id);

      
    }
}