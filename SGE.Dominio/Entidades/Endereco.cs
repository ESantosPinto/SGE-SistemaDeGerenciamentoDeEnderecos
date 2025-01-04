using SGE.Dominio.Entities;
using SGE.Dominio;
using System;
using System.Text.RegularExpressions;

namespace Catalogo.Domain.Entities
{
    public sealed class Endereco : Identity
    {
        public string Cep { get; private set; } = string.Empty;
        public string Logradouro { get; private set; } = string.Empty;
        public string Complemento { get; private set; } = string.Empty;
        public string Bairro { get; private set; } = string.Empty;
        public string Cidade { get; private set; } = string.Empty;
        public string Uf { get; private set; } = string.Empty;
        public string Numero { get; private set; } = string.Empty;
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public Endereco(string cep, string logradouro, string complemento, string bairro, string cidade, string uf, string numero)
        {
            ValidateDomain(cep, logradouro, complemento, bairro, cidade, uf, numero);
        }

        private void ValidateDomain(string cep, string logradouro, string complemento, string bairro, string cidade, string uf, string numero)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(cep) || !Regex.IsMatch(cep, @"^\d{5}-\d{3}$"),
                "CEP inválido. O CEP é obrigatório e deve estar no formato 00000-000");

            DomainExceptionValidation.When(string.IsNullOrEmpty(logradouro),
                "Logradouro inválido. O logradouro é obrigatório");

            DomainExceptionValidation.When(string.IsNullOrEmpty(bairro),
                "Bairro inválido. O bairro é obrigatório");

            DomainExceptionValidation.When(string.IsNullOrEmpty(cidade),
                "Cidade inválida. A cidade é obrigatória");

            DomainExceptionValidation.When(string.IsNullOrEmpty(uf) || uf.Length != 2,
                "UF inválida. A UF é obrigatória e deve ter 2 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(numero),
                "Número inválido. O número é obrigatório");

            Cep = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            Numero = numero;
        }

        public void Update(string cep, string logradouro, string complemento, string bairro, string cidade, string uf, string numero)
        {
            ValidateDomain(cep, logradouro, complemento, bairro, cidade, uf, numero);
        }
    }
}

