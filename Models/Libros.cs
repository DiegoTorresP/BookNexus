using System.ComponentModel.DataAnnotations;

namespace BookNexus.Models
{
    public class Libros
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Portada { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }

        public string? Autor { get; set; }
    }
}
