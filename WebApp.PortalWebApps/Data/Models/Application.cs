using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PortalWebApps.WebApp.Data.Models
{
    public class Application
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Url")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Url(ErrorMessage = "Campo {0} inválido!")]
        public string Uri { get; set; } = string.Empty;

        [DisplayName("Nome do Responsável")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string KeyUserName { get; set; } = string.Empty;

        [DisplayName("E-mail do Responsável")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [EmailAddress(ErrorMessage = "Campo {0} inválido!")]
        public string KeyUserMail { get; set; } = string.Empty;

        [DisplayName("Criado Em")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [DisplayName("Status")]
        public bool Status { get; set; } = false;

        public Application()
        {
            
        }
    }
}
