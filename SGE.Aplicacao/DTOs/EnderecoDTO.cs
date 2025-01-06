using System;
using System.ComponentModel.DataAnnotations;

namespace SGE.Aplicacao.DTOs
{
    public class EnderecoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O CEP deve estar no formato 00000-000.")]
        public string Cep { get; set; } = string.Empty;

        [Required(ErrorMessage = "O logradouro é obrigatório.")]
        [StringLength(100, ErrorMessage = "O logradouro deve ter no máximo 100 caracteres.")]
        public string Logradouro { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "O complemento deve ter no máximo 100 caracteres.")]
        public string Complemento { get; set; } = string.Empty;

        [Required(ErrorMessage = "O bairro é obrigatório.")]
        [StringLength(50, ErrorMessage = "O bairro deve ter no máximo 50 caracteres.")]
        public string Bairro { get; set; } = string.Empty;

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [StringLength(50, ErrorMessage = "A cidade deve ter no máximo 50 caracteres.")]
        public string Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "A UF é obrigatória.")]
        [StringLength(2, ErrorMessage = "A UF deve ter exatamente 2 caracteres.")]
        public string Uf { get; set; } = string.Empty;

        [Required(ErrorMessage = "O número é obrigatório.")]
        [StringLength(10, ErrorMessage = "O número deve ter no máximo 10 caracteres.")]
        public string Numero { get; set; } = string.Empty;
        public string UsuarioLogin{ get; set; }
        public int UsuarioId { get; set; }
    }
}
