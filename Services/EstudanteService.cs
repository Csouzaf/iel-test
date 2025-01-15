using AutoMapper;
using testeiel.Data;
using testeiel.Models;
using testeiel.Repository;
using testeiel.Security.Services;

namespace testeiel.Services
{
    public class EstudanteService : IEstudanteRepository
    {
        private readonly AppDbContext _appDbContext;

        private readonly UsuarioAutenticadoService _usuarioAutenticadoService;

        private readonly IMapper _mapper;

        public EstudanteService(UsuarioAutenticadoService usuarioAutenticadoService, AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _usuarioAutenticadoService = usuarioAutenticadoService;
        }

        public List<Estudante> ListarTodos()
        {
            return _appDbContext.estudante.ToList();
        }

        public Estudante Criar(Estudante estudante)
        {
            if (_usuarioAutenticadoService.VerificarUsuarioAutenticado())
            {
                using (var contexto = _appDbContext)
                {
                    _appDbContext.estudante.Add(estudante);
                    _appDbContext.SaveChanges();
                   
                    return estudante;
                }
                
            }

            return null;

        }

        public bool Deletar(int id)
        {
            if (_usuarioAutenticadoService.VerificarUsuarioAutenticado())
            {
                
                using (var contexto = _appDbContext)
                {
                    Estudante buscarEstudante = _appDbContext.estudante.Find(id);
                    
                    if (buscarEstudante != null) 
                    {
                        _appDbContext.estudante.Remove(buscarEstudante);
                        _appDbContext.SaveChanges();
                       return true;
                   
                    }
                 
                    return false;
                }
                
            }

            return false;

        }


    }
}