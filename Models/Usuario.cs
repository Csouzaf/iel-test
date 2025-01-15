using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace testeiel.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public string? Nome { get; set; }

        public string? Cpf { get; set; }

        public string? Endereco { get; set; }

        public string? Cidade { get; set; }

        [Required]
        public string? Estado { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataCriacao{ get; set; }
        
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Senha { get; set; }
        
        public string? Cep { get; set; }

    }
}