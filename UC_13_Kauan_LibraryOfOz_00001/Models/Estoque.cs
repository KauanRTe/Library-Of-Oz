namespace UC_13_Kauan_LibraryOfOz_00001.Models
{
    public class Estoque
    {
        public int EstoqueId { get; set; }

        public string? NomeLivro { get; set; }

        public string? Preco { get; set; }

        public int? Quantidade { get; set; }

        public string? Disponibilidade { get; set; }

        public virtual ICollection<Aluguel>? Aluguel { get; set; }
    }
}
