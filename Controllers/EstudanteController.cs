using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using testeiel.Models;
using testeiel.Repository;

namespace testeiel.Controllers;

[ApiController]
[Route("estudante")]
public class EstudanteController : Controller
{
    private readonly IEstudanteRepository _estudanteRepository;

    public EstudanteController(IEstudanteRepository estudanteRepository)
    {
        _estudanteRepository = estudanteRepository;
    }

    [HttpPost]
    public ActionResult<Estudante> Criar([FromBody] Estudante estudante)
    {
        return Created("Sucesso", _estudanteRepository.Criar(estudante));
    }

    [HttpDelete("{id}")]
    public ActionResult Deletar([FromRoute] int id)
    {
        var buscarEstudante = _estudanteRepository.Deletar(id);
        return NoContent();
    }

    

}
