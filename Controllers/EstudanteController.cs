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

    [HttpGet]
    public ActionResult<List<Estudante>> Listar()
    {
        var buscarTodosEstudante = _estudanteRepository.ListarTodos();
        if ( buscarTodosEstudante != null)
        {
            return Ok(_estudanteRepository.ListarTodos());
        }
        return BadRequest("Erro ao buscar todos estudantes");
       
    }

    [HttpPost]
    public ActionResult<Estudante> Criar([FromBody] Estudante estudante)
    {
        var buscarEstudante = _estudanteRepository.Criar(estudante);
        if ( buscarEstudante != null)
        {
            return Created("Sucesso", _estudanteRepository.Criar(estudante));
        }
        return BadRequest("Erro ao criar estudante");
    }

    [HttpDelete("{id}")]
    public ActionResult Deletar([FromRoute] int id)
    {
        var buscarEstudante = _estudanteRepository.Deletar(id);
        if (buscarEstudante) 
        {
            return NoContent();
        }

         return BadRequest("Erro ao deletar estudante");
    }

    

}
