using FluentValidation;
using System.Linq;

namespace Missaol.Application.Cliente
{
    public sealed class EncantarCommandValidation : AbstractValidator<EncantarCommandRequest>
    {
        public EncantarCommandValidation(IDataAccess db)
        {
            RuleFor(request => request)
            .Must(request => !request.Cliente.HasValue)
            .WithName("Cliente")
            .WithMessage("Obrigatório")
            .DependentRules(() =>
            {
                RuleFor(request => request)
                .Must(request => db.Clientes.Any(cliente => cliente.Code == request.Cliente))
                .WithName("Cliente")
                .WithMessage("Não encontrado");
            });

            RuleFor(request => request)
            .Must(request => !request.Produto.HasValue)
            .WithName("Produto")
            .WithMessage("Obrigatório")
            .DependentRules(() =>
            {
                RuleFor(request => request)
                .Must(request => db.Produtos.Any(cliente => cliente.Code == request.Produto))
                .WithName("Produto")
                .WithMessage("Não encontrado");
            });

            RuleFor(request => request)
            .Must(request => !request.Atendimento.HasValue)
            .WithName("Atendimento")
            .WithMessage("Obrigatório");

            RuleFor(request => request)
            .Must(request => !request.Ambiente.HasValue)
            .WithName("Ambiente")
            .WithMessage("Obrigatório");
        }
    }
}
