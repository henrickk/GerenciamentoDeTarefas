using FluentValidation;

namespace Gerenciamento.Business.Models.Validations
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O nome do usuário é obrigatório.")
                .Length(3, 100).WithMessage("O nome do usuário deve ter entre 3 e 100 caracteres.");
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O email do usuário é obrigatório.")
                .EmailAddress().WithMessage("O email do usuário deve ser um endereço de email válido.")
                .Length(5, 200).WithMessage("O email do usuário deve ter entre 5 e 200 caracteres.");
            RuleFor(u => u.SenhaHash)
                .NotEmpty().WithMessage("A senha do usuário é obrigatória.")
                .MinimumLength(6).WithMessage("A senha do usuário deve ter no mínimo 6 caracteres.");
            RuleFor(u => u.DataCadastro)
                .NotEmpty().WithMessage("A data de cadastro do usuário é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de cadastro não pode ser no futuro.");
        }
    }
}
