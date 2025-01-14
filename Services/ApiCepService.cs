using System.Text.Json;
using AutoMapper;
using testeiel.Data;
using testeiel.Models;

namespace testeiel.Services
{
    public class ApiCepService : ApiCepRepository
    {
        private readonly AppDbContext _appDbContext;

        private readonly IMapper _mapper;
        
        public ApiCepService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<List<Endereco>> BuscarEnderecoPeloCep(string cep)
        {
            List<Endereco> enderecos = new List<Endereco>();

            var requisicao = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/{cep}");

            using (var client = new HttpClient())
            {
                var respostaBrasilApi = await client.SendAsync(requisicao);
                var conteudoResposta = await respostaBrasilApi.Content.ReadAsStringAsync();
                var objResposta = JsonSerializer.Deserialize<Endereco>(conteudoResposta);

                if(objResposta != null) 
                {
                    enderecos.Add(objResposta);

                    return enderecos;
                }

                else 
                {
                    return null;
                }
            }

          
        }
    
    }
}