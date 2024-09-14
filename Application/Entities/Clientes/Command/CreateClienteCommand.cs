
using Core.Entities;
using MediatR;

namespace Application.Entities.Clientes.Command
{
    public class CreateClienteCommand : IRequest<Cliente>
    {

        public string Nombre { get; set; } = null!;

        public string? Correo { get; set; }

        public string? NumeroTelefono { get; set; }
    }
    public class CreateClienteHandler : IRequestHandler<CreateClienteCommand, Cliente>
    {
        public Task<Cliente> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
