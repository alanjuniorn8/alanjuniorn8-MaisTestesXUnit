using Alura.ByteBank.Dados.Contexto;
using System;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ByteBankContextoTestes
    {
        [Fact]
        public void TestaConexaoContextoComBDMySQL()
        {

            var contexto = new ByteBankContexto();
            bool conectado;

            try
            {
                conectado = contexto.Database.CanConnect();
            }
            catch
            {
                throw new Exception("Teste de conexão falhou.");
            }

            Assert.True(conectado);
        }
    }
}
