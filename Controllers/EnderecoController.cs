using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using testeiel.Models;
using testeiel.Services;

namespace testeiel.Controllers;

[ApiController]
[Route("cep")]
public class EnderecoController : Controller
{

    private readonly ApiCepService apiCepService;


    [HttpGet("{cep}")]
    public async Task<List<Endereco>> BuscarPeloCep([FromRoute] string cep)
    {
        return await apiCepService.BuscarEnderecoPeloCep(cep);
    }
}
