using System.ComponentModel.DataAnnotations;

namespace sca.Models.Request
{
    public class AuthRequest
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Contrasenia { get; set; }

    }
}
