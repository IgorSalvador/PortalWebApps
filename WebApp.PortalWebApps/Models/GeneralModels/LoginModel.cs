using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PortalWebApps.WebApp.Models.GeneralModels
{
    public class LoginModel
    {
        [DisplayName("Username")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "O campo {0} contém entre 3 e 255 carácteres!")]
        [EmailAddress(ErrorMessage = "O campo {0} é inválido.")]
        public string Username { get; set; } = string.Empty;

        [DisplayName("Password")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "O campo {0} contém entre 8 e 255 carácteres!")]
        public string Password { get; set; } = string.Empty;
    }
}
