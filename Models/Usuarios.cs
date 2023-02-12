using System.ComponentModel.DataAnnotations;

namespace BookNexus.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        public string? ApellidoPat { get; set; }
        public string? ApellidoMat { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNac { get; set; }
        public string? Genre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? NombreUsuario { get; set; }
        public string? password { get; set; }
    }
}
