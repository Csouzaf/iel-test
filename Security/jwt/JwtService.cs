using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using testeiel.Repository;

namespace testeiel.Security.jwt
{
    public class JwtService
    {
       private readonly IUsuarioRepository _usuarioRepository;

       public JwtService(IUsuarioRepository usuarioRepository)
       {
            _usuarioRepository = usuarioRepository;
       }

        private string chaveMestre = "66bfde1acdd9b8c228a8b8d66100c5734188d64d917dd5c5bfbbd92b39b5a0cc";

        public string GerarJwt(Guid guid, string name)
        {
            var converterStringHex = Convert.FromHexString(chaveMestre);
            var verificarSimetriaBytes = new SymmetricSecurityKey(converterStringHex);
            var garantirAssinaturaBytes = new SigningCredentials(verificarSimetriaBytes, SecurityAlgorithms.HmacSha256Signature);

            var pegarNome = _usuarioRepository.BuscarPeloNome(name);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, guid.ToString()),
                new Claim("guid", guid.ToString()),
                new Claim("name", pegarNome.Nome), 
              
            };

            var header = new JwtHeader(garantirAssinaturaBytes);

            var payload = new JwtPayload(null, null, claims, DateTime.UtcNow, DateTime.UtcNow.AddHours(2));

            var securityToken = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        
        
        
        
        }
    }
}