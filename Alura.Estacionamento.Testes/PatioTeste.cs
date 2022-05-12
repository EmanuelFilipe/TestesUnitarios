using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTeste : IDisposable
    {
        private Veiculo veiculo;
        private Operador operador;
        public ITestOutputHelper _outputHelper;


        public PatioTeste(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _outputHelper.WriteLine("Construtor invocado.");
            operador = new Operador { Nome = "José Silva" };
            this.veiculo = new Veiculo();
        }

        // para testar metodos sem parâmetros
        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            
            //Veiculo veiculo = new Veiculo();
            veiculo.Proprietario = "Andre Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            Patio estacionamento = new Patio();

            estacionamento.OperadorPatio = operador;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //act
            double faturamento = estacionamento.TotalFaturado();

            Assert.Equal(2, faturamento);
        }

        // Permite trabalhar com um conjunto maior de dados
        // método com parametros
        [Theory]
        [InlineData("Andre Silva", "ASD-1498", "Preto", "Gol")]
        [InlineData("Jose Silva", "POL-9242", "Cinza", "Fusca")]
        [InlineData("Maria Silva", "GDR-6524", "Azul", "Opala")]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange

            veiculo = new Veiculo {
                Proprietario = proprietario,
                Tipo = TipoVeiculo.Automovel,
                Cor = cor,
                Modelo = modelo,
                Placa = placa
            };

            Patio estacionamento = new Patio();
            estacionamento.OperadorPatio = operador;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //act
            double faturamento = estacionamento.TotalFaturado();

            Assert.Equal(2, faturamento);

        }

        // Ignorar, pular este teste
        [Fact(Skip = "Teste ainda não implemetado. Ignorar")]
        public void ValidaNomeProprietario()
        {

        }

        [Theory]
        [InlineData("Andre Silva", "ASD-1498", "Preto", "Gol")]
        public void LocalizaVeiculoNoPatioComBaseNoTicket(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            Veiculo veiculo = new Veiculo
            {
                Proprietario = proprietario,
                Cor = cor,
                Modelo = modelo,
                Placa = placa
            };

            Patio estacionamento = new Patio();
            estacionamento.OperadorPatio = operador;
            estacionamento.RegistrarEntradaVeiculo(veiculo);


            //act
            var consultado = estacionamento.PesquisaVeiculoPorTicket(veiculo.IdTicket);

            Assert.Contains("Ticket Estacionamento Alura", consultado.Ticket);
        }

        //TDD
        // cria primeiro o metodo de teste e depois a funcionalidade
        [Fact]
        public void AlterarDadosDoProprioVeiculo()
        {
            //Arrange
            Veiculo veiculo = new Veiculo
            {
                Proprietario = "José Silva",
                Cor = "Verde",
                Modelo = "Opala",
                Placa = "ZXC-8524"
            };
            
            Patio estacionamento = new Patio();
            estacionamento.OperadorPatio = operador;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo()
            {
                Proprietario = "José Silva",
                Cor = "Preto",
                Modelo = "Opala",
                Placa = "ZXC-8524",
                IdTicket = veiculo.IdTicket,
                Ticket = veiculo.Ticket
            };

            //act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            _outputHelper.WriteLine("Dispose invocado.");
        }
    }
}
