using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalWebApps.WebApp.Data.Models
{
    public class SystemConfiguration
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Description { get; set; } = string.Empty;

        [DisplayName("Valor")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Value { get; set; } = string.Empty;
    }
}
