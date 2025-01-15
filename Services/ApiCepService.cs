using System.Text.Json;
using AutoMapper;
using testeiel.Data;
using testeiel.Models;
using testeiel.Repository;

namespace testeiel.Services
{
    public class ApiCepService : IApiCepRepository
    {
        private readonly AppDbContext _appDbContext;

        private readonly IMapper _mapper;
        
        public ApiCepService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<Endereco> BuscarEnderecoPeloCep(string cep)
        {

            var requisicao = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/{cep}");

            using (var client = new HttpClient())
            {
                var respostaBrasilApi = await client.SendAsync(requisicao);
                var conteudoResposta = await respostaBrasilApi.Content.ReadAsStringAsync();
                var objResposta = JsonSerializer.Deserialize<Endereco>(conteudoResposta);

                if(objResposta != null) 
                {
                  
                    return objResposta;
                }

                else 
                {
                    return null;
                }
            }

          
        }
    
    }
}