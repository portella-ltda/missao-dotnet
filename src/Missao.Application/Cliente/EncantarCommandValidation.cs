using FluentValidation;
using System.Linq;
using System.Text;

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
                .Must(request =>
                {
                    request.ProdutoDTO = db.Produtos.SingleOrDefault(produto => produto.Code == request.Produto);
                    return request.ProdutoDTO != default;
                })
                .WithName("Produto")
                .WithMessage("Não encontrado")
                .DependentRules(() =>
                {
                    RuleFor(request => request)
                    .Must(request => request.ProdutoDTO.Qualidade != null)
                    .WithName("Qualidade para o produto")
                    .WithMessage("Não encontrado");
                });
            });

            RuleFor(request => request)
            .Must(request => !request.Atendimento.HasValue)
            .WithName("Atendimento")
            .WithMessage("Obrigatório")
            .DependentRules(() =>
            {
                RuleFor(request => request)
                .Must(request => db.Atendimentos.Any(atendimento => atendimento.Code == request.Atendimento))
                .WithName("Atendimento")
                .WithMessage("Não encontrado");
            });

            RuleFor(request => request)
            .Must(request => !request.Ambiente.HasValue)
            .WithName("Ambiente")
            .WithMessage("Obrigatório")
            .DependentRules(() =>
            {
                RuleFor(request => request)
                .Must(request => db.Ambientes.Any(ambiente => ambiente.Code == request.Ambiente))
                .WithName("Ambiente")
                .WithMessage("Não encontrado");
            });
        }
    }
}
