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

            //RuleFor(t => t.Status)
            //    .NotEmpty().WithMessage("O status da tarefa é obrigatório.")
            //    .Must(status => new[] { "Pendente", "Em Andamento", "Concluída" }.Contains(status))
            //    .WithMessage("O status da tarefa deve ser 'Pendente', 'Em Andamento' ou 'Concluída'.");

            //RuleFor(t => t.Prioridade)
            //    .NotEmpty().WithMessage("A prioridade da tarefa é obrigatória.")
            //    .Must(prioridade => new[] { "Baixa", "Média", "Alta" }.Contains(prioridade))
            //    .WithMessage("A prioridade da tarefa deve ser 'Baixa', 'Média' ou 'Alta'.");

            //RuleFor(t => t.DataCriacao)
            //    .NotEmpty().WithMessage("A data de criação da tarefa é obrigatória.")
            //    .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de criação não pode ser no futuro.");

            //When(t => t.Status == "Concluída", () =>
            //{
            //    RuleFor(t => t.DataConclusao)
            //        .NotEmpty().WithMessage("A data de conclusão é obrigatória quando a tarefa está concluída.")
            //        .GreaterThan(t => t.DataCriacao).WithMessage("A data de conclusão deve ser posterior à data de criação.");
            //});
            //RuleFor(t => t.ProjetoId)
            //    .NotEmpty().WithMessage("O ID do projeto é obrigatório.");

            RuleFor(t => t.UsuarioId)
                .NotEmpty().WithMessage("O ID do usuário responsável é obrigatório.");
        }
    }
}
