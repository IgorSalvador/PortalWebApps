using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PortalWebApps.WebApp.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [EmailAddress(ErrorMessage = "O campo {0} não está valido.")]
        public string Email { get; set; } = string.Empty;


        [DisplayName("CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Cpf { get; set; } = string.Empty;

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public DateTime BirthDate { get; set; } = DateTime.Now;

        [DisplayName("Perfil")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} inválido, selecione uma opção valida!")]
        public int Profile { get; set; } = 0;

        [DisplayName("Senha")]
        public string Password { get; set; }

        [DisplayName("Criado Em")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [DisplayName("Alterado Em")]
        public DateTime? ChangedOn { get; set; } = DateTime.Now;

        [DisplayName("Status")]
        public bool Status { get; set; } = false;

        public ICollection<SystemSettingHistory> SystemsSettingsHistory { get; set; }
        public ICollection<Application> Applications { get; set; }

        public User()
        {
            
        }
    }
}
