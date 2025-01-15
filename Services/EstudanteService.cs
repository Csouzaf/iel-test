using AutoMapper;
using testeiel.Data;
using testeiel.Models;
using testeiel.Repository;

namespace testeiel.Services
{
    public class EstudanteService : IEstudanteRepository
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

        public Estudante BuscarPeloNome(string nome)
        {
            var estudante = new Estudante();

            using (var contexto = _appDbContext)
            {
                estudante = contexto.estudante.FirstOrDefault(m => m.Nome == nome);

            }
            return estudante;
        }

        
    }
}