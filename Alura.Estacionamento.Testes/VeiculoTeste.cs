using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTeste
    {

        /* 
         * Arrange = prepara��o do cen�rio necess�rio para invocar o metodo para testar
         * Act = momento de executar o teste
         * Assert = Verifica��o do resultado obtido da execu��o daquele metodo 
         */

        // Trait = � como um agrupamento. Fica visivel no 'Test Explorer'

        [Fact(DisplayName = "Teste n� 1")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            // o que � esperado... que seja 100
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste n� 2")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {
            var veiculo = new Veiculo();
            veiculo.Frear(10);

            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Theory]
        [ClassData(typeof(Veiculo))]
        public void TestaVeiculoClass(Veiculo modelo)
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //Assert
            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }

    }
}
