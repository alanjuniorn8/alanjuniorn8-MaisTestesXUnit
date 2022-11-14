using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Infraestrutura.Testes.DTO;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ContaCorrenteRepositorioTestes
    {

        private readonly IContaCorrenteRepositorio _repositorio;

        public ContaCorrenteRepositorioTestes()
        {
            var service = new ServiceCollection();
            service.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();
            var provider = service.BuildServiceProvider();
            _repositorio = provider.GetService<IContaCorrenteRepositorio>();
        }


        [Fact]
        public void TestaObterTodosContaCorrentes()
        {   
            List<ContaCorrente> ContaCorrentes = _repositorio.ObterTodos();

            Assert.NotNull(ContaCorrentes);
            Assert.Equal(2, ContaCorrentes.Count);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestaObterContaCorrentePorId(int id)
        {
            var ContaCorrente = _repositorio.ObterPorId(id);

            Assert.NotNull(ContaCorrente);
        }

        [Fact]
        public void TestaAtualizaSaldoContaCorrente()
        {
            var conta = _repositorio.ObterPorId(1);
            double saldoNovo = 15;
            conta.Saldo = saldoNovo;

            var atualizado = _repositorio.Atualizar(1, conta);

            Assert.True(atualizado);
        }

        [Fact]
        public void TestaInsereNovaContaCorrente()
        {

            var conta = new ContaCorrente()
            {
                Saldo = 10,
                Identificador = Guid.NewGuid(),
                Cliente = new Cliente()
                {
                    Nome = "Joe Doe",
                    CPF = "486.074.980-45",
                    Identificador = Guid.NewGuid(),
                    Profissao = "Bancário",
                    Id = 1
                },
                Agencia = new Agencia()
                {
                    Nome = "Agencia Central",
                    Identificador = Guid.NewGuid(),
                    Id = 1,
                    Endereco = "Rua das Flores, 123",
                    Numero = 147
                }

            };

            var inserido = _repositorio.Adicionar(conta);

            Assert.True(inserido);  
        }

        [Fact]
        public void TestaConsultaPix()
        {
            var guid = new Guid("0f63ff06-1e83-4086-aacb-72f17f572993");
            var pix = new PixDTO() { Chave = guid, Saldo = 10};

            var pixRepositorioMock = new Mock<IPixRepositorio>();   
            pixRepositorioMock.Setup(x => x.consultaPix(It.IsAny<Guid>())).Returns(pix);

            var mock = pixRepositorioMock.Object;

            var saldo = mock.consultaPix(guid).Saldo;

            Assert.Equal(10, saldo);
        }
      
    }
}
