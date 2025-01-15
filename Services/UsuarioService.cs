using AutoMapper;
using testeiel.Data;
using testeiel.Models;
using testeiel.Repository;

namespace testeiel.Services
{
    public class UsuarioService : IUsuarioRepository
    {
        private readonly AppDbContext _appDbContext;

        private readonly IApiCepRepository _apiCepRepository;

        private readonly IMapper _mapper;

        public UsuarioService(IApiCepRepository apiCepRepository, AppDbContext appDbContext, IMapper mapper)
        {
            _apiCepRepository = apiCepRepository;
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public Usuario BuscarPeloNome(string nome)
        {
            var Usuario = new Usuario();

            using (var contexto = _appDbContext)
            {
                Usuario = contexto.usuario.FirstOrDefault(m => m.Nome == nome);

            }
            return Usuario;
        }


        public async Task<Usuario> Criar(Usuario usuario)
        {
            if (usuario != null)
            {
                using (var contexto = _appDbContext)
                {
                    var apiBuscarEnderecoPeloCep = await _apiCepRepository.BuscarEnderecoPeloCep(usuario.Cep);
                   
                    usuario.Cidade = apiBuscarEnderecoPeloCep.city;
                    usuario.Endereco = apiBuscarEnderecoPeloCep.neighborhood;
                    usuario.Estado = apiBuscarEnderecoPeloCep.state;

                    await contexto.usuario.AddAsync(usuario);
                    await _appDbContext.SaveChangesAsync();

                    return usuario;
                }
            }

            return null;
        }

        public Usuario BuscarEmail(string email)
        {
            var emailUsuario = new Usuario();

            using (var contexto = _appDbContext)
            {
                emailUsuario = contexto.usuario.FirstOrDefault(m => m.Email == email);

            }
            return emailUsuario;
        }

    }
}