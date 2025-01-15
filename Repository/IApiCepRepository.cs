using testeiel.Models;

namespace testeiel.Repository
{
    public interface IApiCepRepository
    {
        Task<Endereco> BuscarEnderecoPeloCep(string cep);
    }
}