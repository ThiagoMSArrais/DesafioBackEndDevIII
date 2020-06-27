using DesafioBackEndDevIII.Domain.Clientes;
using System;
using Xunit;

namespace DesafioBackEndDevIII.Teste
{
    public class ClienteTesteUnitario
    {
        [Fact]
        public void ClienteAptoParaSerCadastro()
        {
            Cliente cliente = new Cliente("Thiago Arrais", "29660264054", 35, new Endereco("Rua Dr. Palvaro, 321", "Itaipu", "Niterói", "Rio de Janeiro"));

            Assert.True(cliente.EhValido());
        }

        [Fact]
        public void ClienteNaoAptoParaSerCadastro()
        {
            Cliente cliente = new Cliente("Thiago Arrais", "296602640542", 35, new Endereco("Rua Dr. Palvaro, 321", "Itaipu", "Niterói", "Rio de Janeiro"));

            Assert.False(cliente.EhValido());
        }
    }
}
