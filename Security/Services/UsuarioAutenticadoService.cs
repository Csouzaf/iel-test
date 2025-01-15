

using testeiel.Repository;

namespace testeiel.Security.Services
{


    public class UsuarioAutenticadoService : IUsuarioAutenticadoService
    {
        private readonly IUsuarioAutenticadoService _usuarioAutenticadoServiceRepository;    
        private readonly IHttpContextAccessor _httpContextAccessor;
       public UsuarioAutenticadoService(IHttpContextAccessor httpContextAccessor, IUsuarioAutenticadoService usuarioAutenticadoServiceRepository)
       {    
            _httpContextAccessor = httpContextAccessor;
            _usuarioAutenticadoServiceRepository = usuarioAutenticadoServiceRepository;
       }

       public bool VerificarUsuarioAutenticado()
       {
            var httpContext = _httpContextAccessor.HttpContext.User;

            if(httpContext.Identity.IsAuthenticated)
            {
                return true;
            }
            return false;
       }
    }
}