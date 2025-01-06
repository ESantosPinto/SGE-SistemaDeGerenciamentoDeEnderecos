using System.ComponentModel.DataAnnotations;

namespace SGE.Aplicacao.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome do usuário é obrigatório.")]        
        public string Nome { get; set; }

        [Required(ErrorMessage = "O login do usuário é obrigatório.")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "O login do usuário deve ter entre 6 e 10 caracteres.")]
        public string UsuarioLogin { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 10 caracteres.")]
        public string Senha { get; set; } = string.Empty;
    }
}
