using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace testeiel.Models
{
 
    public class Estudante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        [StringLength(100)]
        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? Cpf { get; set; }

        [StringLength(200)]
        [Required]
        public string? Endereco { get; set; }

        [Required]
        public string? Cidade { get; set; }

        [Required]
        public string? Estado { get; set; }

        [Required]
        public List<string> InstituicaoEnsino { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataConclusao { get; set; }
        
        [StringLength(100)]
        [Required]
        public string? NomeCurso { get; set; }

    }
}