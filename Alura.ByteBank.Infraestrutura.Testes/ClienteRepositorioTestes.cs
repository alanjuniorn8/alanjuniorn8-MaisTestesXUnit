using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Net.WebSockets;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ClienteRepositorioTestes
    {

        private readonly IClienteRepositorio _repositorio;

        public ClienteRepositorioTestes()
        {
            var service = new ServiceCollection();
            service.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            var provider = service.BuildServiceProvider();
            _repositorio = provider.GetService<IClienteRepositorio>();
        }


        [Fact]
        public void TestaObterTodosClientes()
        {   
            List<Cliente> clientes = _repositorio.ObterTodos();

            Assert.NotNull(clientes);
            Assert.Equal(3, clientes.Count);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestaObterClientPorId(int id)
        {
            var cliente = _repositorio.ObterPorId(id);

            Assert.NotNull(cliente);
        }

    }
}
