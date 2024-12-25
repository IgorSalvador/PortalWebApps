using PortalWebApps.WebApp.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PortalWebApps.WebApp.Models.ViewModels
{
    public class ApplicationViewModel
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "O campo {0} deve conter entre 3 e 250 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Url")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Url(ErrorMessage = "Campo {0} inválido!")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "O campo {0} deve conter entre 100 e 500 caracteres.")]
        public string Uri { get; set; } = string.Empty;

        [DisplayName("Nome do Responsável")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "O campo {0} deve conter entre 3 e 500 caracteres.")]
        public string KeyUserName { get; set; } = string.Empty;

        [DisplayName("E-mail do Responsável")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [EmailAddress(ErrorMessage = "Campo {0} inválido!")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "O campo {0} deve conter entre 5 e 500 caracteres.")]
        public string KeyUserMail { get; set; } = string.Empty;

        [DisplayName("Criado Em")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [DisplayName("Status")]
        public bool Status { get; set; } = false;

        public ApplicationViewModel()
        {
            
        }

        public ApplicationViewModel(Application application)
        {
            Name = application.Name;
            Uri = application.Uri;
            KeyUserName = application.KeyUserName;
            KeyUserMail = application.KeyUserMail;
            CreatedOn = application.CreatedOn;
            Status = application.Status;
        }
    }
}
