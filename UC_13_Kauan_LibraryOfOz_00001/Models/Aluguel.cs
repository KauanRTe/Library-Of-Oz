using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UC_13_Kauan_LibraryOfOz_00001.Models
{
    public class Aluguel
    {

        public int AluguelId { get; set; }


        public virtual Estoque? NomeLivro { get; set; }
        public int EstoqueId { get; set; }

        public virtual Cliente? NomeCliente { get; set; }
        public int ClienteId { get ; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataDevolucao { get; set; }
    }
}