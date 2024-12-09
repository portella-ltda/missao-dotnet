using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Cliente
{
    public sealed class EncantarRequestHandler : IRequestHandler<EncantarRequest>
    {
        IMediator Mediator { get; }
        public EncantarRequestHandler(IMediator mediator)
        {
            Mediator = mediator;
        }
        public async Task Handle(EncantarRequest request, CancellationToken cancellationToken)
        {
            var maximo = RequsitosEnumerar(request).Count();
            var atingido = RequsitosEnumerar(request).Where(success => success).Count();
            
            if ((atingido / maximo) < 50)
            {
                await Mediator.Publish(new EncantadoNegativoNotification(), cancellationToken);
                return;
            }

            if ((atingido / maximo) < 100)
            {
                await Mediator.Publish(new EncantadoParcialmenteNotification(), cancellationToken);
                return;
            }

            await Mediator.Publish(new EncantadoNotification(), cancellationToken);
        }

        private static IEnumerable<bool> RequsitosEnumerar(EncantarRequest request)
        {
            yield return request.ProdutoNota >= request.ProdutoDTO.Qualidade.Minima;
            yield return request.AtendimentoNota >= request.AtendimentoDTO.Nivel.Minimo;
            yield return request.AmbienteNota >= request.AmbienteDTO.Agrado.Minimo;
        }
    }
}
