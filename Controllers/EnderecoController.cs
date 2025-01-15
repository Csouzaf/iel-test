using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using testeiel.Models;
using testeiel.Repository;
using testeiel.Services;

namespace testeiel.Controllers;

[ApiController]
[Route("endereco")]
public class EnderecoController : Controller
{

    private readonly IApiCepRepository _apiCepService;

    public EnderecoController(IApiCepRepository apiCepRepository)
    {
        _apiCepService = apiCepRepository;
    }

    [HttpGet("{cep}")]
    public async Task<ActionResult<Endereco>> BuscarPeloCep([FromRoute] string cep)
    {
        return Ok(await _apiCepService.BuscarEnderecoPeloCep(cep));
    }
  
   
}
