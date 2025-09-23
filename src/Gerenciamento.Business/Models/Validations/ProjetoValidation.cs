using FluentValidation;

namespace Gerenciamento.Business.Models.Validations
{
    public class ProjetoValidation : AbstractValidator<Projeto>
    {
        public ProjetoValidation()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome do projeto é obrigatório.")
                .Length(3, 100).WithMessage("O nome do projeto deve ter entre 3 e 100 caracteres.");
            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("A descrição do projeto é obrigatória.")
                .Length(5, 500).WithMessage("A descrição do projeto deve ter entre 5 e 500 caracteres.");
            RuleFor(p => p.DataInicio)
                .NotEmpty().WithMessage("A data de início do projeto é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de início não pode ser no futuro.");
            RuleFor(p => p.DataFim)
                .NotEmpty().WithMessage("A data de fim do projeto é obrigatória.")
                .GreaterThan(p => p.DataInicio).WithMessage("A data de fim deve ser posterior à data de início.");
        }
    }
}
