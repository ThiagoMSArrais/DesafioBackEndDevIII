using FluentValidation;
using FluentValidation.Results;
using System;

namespace DesafioBackEndDevIII.Domain.Clientes
{
    public class Endereco : AbstractValidator<Endereco>
    {
        public Endereco(string logradouro,
                        string bairro, 
                        string cidade, 
                        string estado)
        {
            EnderecoId = Guid.NewGuid();
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        public Endereco()
        {

        }

        public Guid EnderecoId { get; private set; }
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public ValidationResult ValidationResult { get; protected set; }


        #region Validações
        public bool EhValido()
        {
            ValidarEndereco();
            return ValidationResult.IsValid;
        }

        private void ValidarEndereco()
        {
            ValidarLogradouro();
            ValidarBairro();
            ValidarCidade();
            ValidarEstado();
            ValidationResult = Validate(this);
        }

        private void ValidarLogradouro()
        {
            RuleFor(c => c.Logradouro)
                .NotEmpty().WithMessage("Logradouro Obrigatório")
                .MaximumLength(50).WithMessage("Limite de 50 caracteres");
        }

        private void ValidarBairro()
        {
            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("Bairro Obrigatório")
                .MaximumLength(40).WithMessage("Limite de 40 caracteres");
        }

        private void ValidarCidade()
        {
            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("Cidade Obrigatório")
                .MaximumLength(40).WithMessage("Limite de 40 caracteres");
        }

        private void ValidarEstado()
        {
            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage("Estado Obrigatório")
                .MaximumLength(40).WithMessage("Limite de 40 caracteres");
        }
        #endregion

    }
}
