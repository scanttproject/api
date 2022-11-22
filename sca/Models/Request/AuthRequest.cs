using System.ComponentModel.DataAnnotations;

namespace sca.Models.Request
{
    public class AuthRequest
    {
        [Required]
<<<<<<< HEAD
        public string nombreusuario { get; set; }
        [Required]
        public string contrasenia { get; set; }
=======
        public string Nombre { get; set; }
        [Required]
        public string Contrasenia { get; set; }
>>>>>>> 5905e1518cdf0522d24825d7fbc96ab90115c8c3

    }
}
