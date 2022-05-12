using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTeste : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper _outputHelper;


        public VeiculoTeste(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _outputHelper.WriteLine("Construtor invocado.");
            this.veiculo = new Veiculo();
        }

        /* 
         * Arrange = preparação do cenário necessário para invocar o metodo para testar
         * Act = momento de executar o teste
         * Assert = Verificação do resultado obtido da execução daquele metodo 
         */

        // Trait = é como um agrupamento. Fica visivel no 'Test Explorer'

        [Fact(DisplayName = "Teste nº 1")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            // o que é esperado... que seja 100
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste nº 2")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrearComParametro10()
        {
            //var veiculo = new Veiculo();
            veiculo.Frear(10);

            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void DadosVeiculo()
        {
            //Arrange
            Veiculo veiculo = new Veiculo
            {
                Proprietario = "José Silva",
                Cor = "Verde",
                Modelo = "Opala",
                Placa = "ZXC-8524",
                Tipo = TipoVeiculo.Automovel
            };

            //act 
            string dados = veiculo.ToString();

            //assert
            Assert.Contains("Tipo do Veículo: Automovel", dados);
        }


        //[Fact]
        //public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        //{
        //    //arrange
        //    string nomeProprietario = "Ab";

        //    // assert
        //    Assert.Throws<System.FormatException>(
        //        //act
        //        () => new Veiculo(nomeProprietario)
        //    );
        //}

        [Fact]
        public void TestaMensagemExcecaoDoQuartoCaractereDaPlaca()
        {
            //arrange
            string placa = "asadf868";

            // assert
            var mensagem = Assert.Throws<System.FormatException>(
                //act
                () => new Veiculo().Placa = placa
            );

            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }

        public void Dispose()
        {
            _outputHelper.WriteLine("Dispose invocado.");
        }
    }
}
