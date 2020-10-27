using System.ComponentModel.DataAnnotations;

namespace ApiRestCore.Models
{
    public class Client
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o nome.")]
        [MinLength(3, ErrorMessage = "O nome deve ter um tamanho mínimo de 3 caracteres.")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o telefone.")]
        [Phone(ErrorMessage = "Informe um telefone válido.")]
        public string Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o e-mail.")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        public string Email { get; set; }

        /// <summary>
        /// Campo para observações em geral
        /// </summary>
        public string Comments { get; set; }
    }
}
