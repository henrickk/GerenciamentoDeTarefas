using FluentValidation;

namespace Gerenciamento.Business.Models.Validations
{
    public class TarefaValidation : AbstractValidator<Tarefa>
    {                               
        public TarefaValidation()
        {
            RuleFor(t => t.Titulo)
                .NotEmpty().WithMessage("O título da tarefa é obrigatório.")
                .Length(3, 100).WithMessage("O título da tarefa deve ter entre 3 e 100 caracteres.");

            RuleFor(t => t.Descricao)
                .NotEmpty().WithMessage("A descrição da tarefa é obrigatória.")
                .Length(5, 500).WithMessage("A descrição da tarefa deve ter entre 5 e 500 caracteres.");

            RuleFor(t => t.UsuarioId)
                .NotEmpty().WithMessage("O ID do usuário responsável é obrigatório.");
        }
    }
}
