using Alura.ByteBank.Dominio.Entidades;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class AgenciaRepositorioTestes
    {
        [Fact]
        public void TestaAdicionarAgenciaMock()
        {
            var agencia = new Agencia()
            {
                Nome = "Agencia Amaral",
                Identificador = Guid.NewGuid(),
                Id = 4,
                Endereco = "Rua Artur Costa",
                Numero = 9497
            };

            var repositorio = new ByteBankRepositorio();

            var adicionado = repositorio.AdicionarAgencia(agencia);

            Assert.True(adicionado);
        }

        [Fact]
        public void TestaObterAgenciasMock()
        {
            var bytebankRepositorioMock = new Mock<IByteBankRepositorio>();
            var mock = bytebankRepositorioMock.Object;

            //Act
            var lista = mock.BuscarAgencias();

            //Assert
            bytebankRepositorioMock.Verify(b => b.BuscarAgencias());

        }

    }
}
