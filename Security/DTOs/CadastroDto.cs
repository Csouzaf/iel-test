using System.ComponentModel.DataAnnotations;

namespace testeiel.Security.DTOs
{
    public class CadastroDto
    {
        public string Email { get; set; }

        public string Senha { get; set; }

        public string? Nome { get; set; }
       
        public string? Cpf { get; set; }

        public string? Endereco { get; set; }
       
        public string? Cidade { get; set; }
       
        public string? Estado { get; set; }

        public DateTime? DataCriacao { get; set; } = DateTime.Now;
    

        public string? Cep { get; set; }

    }
}