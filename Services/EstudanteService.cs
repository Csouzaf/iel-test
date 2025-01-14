using AutoMapper;
using testeiel.Data;
using testeiel.Models;

namespace testeiel.Services
{
    public class EstudanteService : EstudanteRepository
    {
        private readonly AppDbContext _appDbContext;

        private readonly IMapper _mapper;
        
        public EstudanteService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public List<Estudante> ListarTodos()
        {
            return _appDbContext.estudante.ToList();
        }

        
    }
}