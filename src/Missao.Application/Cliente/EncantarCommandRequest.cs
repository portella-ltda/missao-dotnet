using MediatR;
using System;

namespace Missaol.Application.Cliente
{
    public sealed class EncantarCommandRequest : IRequest
    {
        public Guid? Cliente { get; set; }
    }
}
