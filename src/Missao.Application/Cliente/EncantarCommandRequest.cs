using MediatR;
using System;

namespace Missaol.Application.Cliente
{
    public sealed class EncantarCommandRequest : IRequest
    {
        public Guid? Cliente { get; set; }
        public Guid? Produto { get; set; }
        public Guid? Atendimento { get; set; }
    }
}
