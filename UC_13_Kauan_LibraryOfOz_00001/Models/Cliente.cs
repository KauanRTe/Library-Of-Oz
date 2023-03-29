using System.ComponentModel.DataAnnotations;

namespace UC_13_Kauan_LibraryOfOz_00001.Models
{
    public class Cliente
    {
            public int ClienteId { get; set; }

            [Required]
            [MaxLength(50)]
            public string? NomeCliente { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime DataNascimento { get; set; }

            [Required]
            [MaxLength(14)]
            public string? Telefone { get; set; }

            [Required]
            [MaxLength(100)]
            public string? Email { get; set; }

            [Required]
            [MinLength(6)]
            public string? Senha { get; set; }

            [Required]
            [MaxLength(10)]
            public string? Rg { get; set; }

            [Required]
            [MaxLength(150)]
            public string? Endereco { get; set; }

            public virtual ICollection<Aluguel>? Aluguel { get; set; }

        }
}
