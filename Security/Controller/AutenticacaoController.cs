using Microsoft.AspNetCore.Mvc;
using testeiel.Data;
using testeiel.Models;
using testeiel.Repository;
using testeiel.Security.DTOs;
using testeiel.Security.jwt;


namespace testeiel.Controllers;

[ApiController]
[Route("auth")]
public class AutenticacaoController : Controller
{

    private readonly AppDbContext _appDbContext;

    private readonly JwtService _jwtService;

    private readonly IUsuarioRepository _usuarioRepository;
    
    private readonly IUsuarioAutenticadoService _usuarioAutenticadoService;


    public AutenticacaoController(IUsuarioAutenticadoService usuarioAutenticadoService, AppDbContext appDbContext, JwtService jwtService, IUsuarioRepository usuarioRepository)
    {   
        _usuarioAutenticadoService = usuarioAutenticadoService;
        _appDbContext = appDbContext;
        _usuarioRepository = usuarioRepository;
        _jwtService = jwtService;
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar([FromBody] CadastroDto cadastroDto)
    {

        var usuarioModel = new Usuario
        {

            Nome = cadastroDto.Nome,

            Email = cadastroDto.Email,

            Senha = BCrypt.Net.BCrypt.HashPassword(cadastroDto.Senha),

            Cpf = cadastroDto.Cpf,

            Endereco = cadastroDto.Endereco,

            Cidade = cadastroDto.Cidade,

            Estado = cadastroDto.Estado,

            DataCriacao = cadastroDto.DataCriacao,
            
            Cep = cadastroDto.Cep

        };

        var criarUsuarioUsuario = _usuarioRepository.Criar(usuarioModel);

        if (criarUsuarioUsuario == null)
        {
            return BadRequest(new { message = "Falha ao criar usuário" });
        }

        return Created("success", new { criarUsuarioUsuario });
    }


    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        
        if (_usuarioAutenticadoService.VerificarUsuarioAutenticado())
        {
            var verificarEmailRegistrado = _usuarioRepository.BuscarEmail(loginDto.Email);

            var verificarSenhaRegistrado = verificarEmailRegistrado.Senha;

            if (verificarEmailRegistrado != null && verificarSenhaRegistrado != null)
            {

                var criarJwtToken = _jwtService.GerarJwt(verificarEmailRegistrado.Id, verificarEmailRegistrado.Nome);

                Response.Cookies.Append("jwt", criarJwtToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None
                });
                
                return Ok(new { message = "Usuário Logado", criarJwtToken });

            } 
            else
            {
                return BadRequest(new { message = "Email ou Senha Incorreta" });
            }
        }

        else
        {
            return BadRequest(new { message = " Usuário Já Existe" });
        }
    }



}
