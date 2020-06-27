using FluentValidation;
using FluentValidation.Results;
using System;

namespace DesafioBackEndDevIII.Domain.Clientes
{
    public class Cliente : AbstractValidator<Cliente>
    {
        public Cliente(string nome,
                       string cpf, 
                       int idade, 
                       Endereco endereco)
        {
            ClienteId = Guid.NewGuid();
            Nome = nome;
            Cpf = cpf;
            Idade = idade;
            Endereco = endereco;
        }

        public Cliente()
        {
        }

        public Guid ClienteId { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public int Idade { get; private set; }
        public Endereco Endereco { get; set; }
        public ValidationResult ValidationResult { get; protected set; }

        #region Validações
        public bool EhValido()
        {
            ValidarCliente();
            return ValidationResult.IsValid;
        }

        private void ValidarCliente()
        {
            ValidarNome();
            ValidarCpf();
            ValidarDataNascimento();
            ValidationResult = Validate(this);

            ValidarEndereco();
        }

        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome do Cliente é obrigatório")
                .MaximumLength(30).WithMessage("Limite de 30 caracteres");
        }

        private void ValidarCpf()
        {
            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Length(11).WithMessage("O CPF deve ter onze digitos");
        }

        private void ValidarDataNascimento()
        {
            RuleFor(c => c.Idade)
                .NotEmpty().WithMessage("A idade é obrigatório");
        }

        private void ValidarEndereco()
        {
            if (Endereco.EhValido()) return;

            foreach (var error in Endereco.ValidationResult.Errors)
            {
                ValidationResult.Errors.Add(error);
            }
        }
        #endregion

    }
}
