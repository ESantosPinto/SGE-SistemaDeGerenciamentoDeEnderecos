using System;
using System.ComponentModel.DataAnnotations;

namespace SGE.Aplicacao.DTOs
{
    public class EnderecoDTO
    {
        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O CEP deve estar no formato 00000-000.")]
        public string Cep { get; private set; } = string.Empty;

        [Required(ErrorMessage = "O logradouro é obrigatório.")]
        [StringLength(100, ErrorMessage = "O logradouro deve ter no máximo 100 caracteres.")]
        public string Logradouro { get; private set; } = string.Empty;

        [StringLength(100, ErrorMessage = "O complemento deve ter no máximo 100 caracteres.")]
        public string Complemento { get; private set; } = string.Empty;

        [Required(ErrorMessage = "O bairro é obrigatório.")]
        [StringLength(50, ErrorMessage = "O bairro deve ter no máximo 50 caracteres.")]
        public string Bairro { get; private set; } = string.Empty;

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [StringLength(50, ErrorMessage = "A cidade deve ter no máximo 50 caracteres.")]
        public string Cidade { get; private set; } = string.Empty;

        [Required(ErrorMessage = "A UF é obrigatória.")]
        [StringLength(2, ErrorMessage = "A UF deve ter exatamente 2 caracteres.")]
        public string Uf { get; private set; } = string.Empty;

        [Required(ErrorMessage = "O número é obrigatório.")]
        [StringLength(10, ErrorMessage = "O número deve ter no máximo 10 caracteres.")]
        public string Numero { get; private set; } = string.Empty;
    }
}
