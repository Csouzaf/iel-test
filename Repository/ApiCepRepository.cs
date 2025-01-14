using testeiel.Models;

namespace testeiel.Services
{
    public interface ApiCepRepository
    {
        Task<List<Endereco>> BuscarEnderecoPeloCep(string cep);
    }
}