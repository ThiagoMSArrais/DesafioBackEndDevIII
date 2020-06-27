using System;
using System.Collections.Generic;

namespace DesafioBackEndDevIII.Domain.Clientes.Interfaces
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> ObterClientes();
        Cliente ObterClientePorId(Guid clienteId);
        void AdicionarCliente(Cliente cliente);
        void AtualizarCliente(Cliente cliente);
        void RemoverCliente(Guid clienteId);
    }
}
