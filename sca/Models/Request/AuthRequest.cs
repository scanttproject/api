using System.ComponentModel.DataAnnotations;

namespace sca.Models.Request
{
    public class AuthRequest
    {
        [Required]
        public string nombreusuario { get; set; }
        [Required]
        public string contrasenia { get; set; }
       

    }
}
