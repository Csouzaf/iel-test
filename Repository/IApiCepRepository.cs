using testeiel.Models;

namespace testeiel.Repository
{
    public interface IApiCepRepository
    {
        Task<List<Endereco>> BuscarEnderecoPeloCep(string cep);
    }
}