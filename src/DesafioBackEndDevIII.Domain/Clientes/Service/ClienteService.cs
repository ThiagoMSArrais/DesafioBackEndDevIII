using DesafioBackEndDevIII.Domain.Clientes.Interfaces;
using System;
using System.Collections.Generic;

namespace DesafioBackEndDevIII.Domain.Clientes.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void AdicionarCliente(Cliente cliente)
        {
            if (cliente.EhValido())
            {
                _clienteRepository.AdicionarCliente(cliente);
            }
        }

        public void AtualizarCliente(Cliente cliente)
        {
            if (cliente.EhValido())
            {
                _clienteRepository.AtualizarCliente(cliente);
            }
        }

        public Cliente ObterClientePorId(Guid clienteId)
        {
            return _clienteRepository.ObterClientePorId(clienteId);
        }

        public IEnumerable<Cliente> ObterClientes()
        {
            return _clienteRepository.ObterClientes();
        }

        public void RemoverCliente(Guid clienteId)
        {
            _clienteRepository.RemoverCliente(clienteId);
        }
    }
}
