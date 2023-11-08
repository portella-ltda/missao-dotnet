using FluentValidation;

namespace Missaol.Application.Cliente
{
    public sealed class EncantarCommandValidation : AbstractValidator<EncantarCommandRequest>
    {
        public EncantarCommandValidation()
        {
            RuleFor(request => request)
            .Must(request => !request.Cliente.HasValue)
            .WithName("Cliente")
            .WithMessage("Obrigatório");

            RuleFor(request => request)
            .Must(request => !request.Produto.HasValue)
            .WithName("Produto")
            .WithMessage("Obrigatório");

            RuleFor(request => request)
            .Must(request => !request.Atendimento.HasValue)
            .WithName("Atendimento")
            .WithMessage("Obrigatório");
        }
    }
}
