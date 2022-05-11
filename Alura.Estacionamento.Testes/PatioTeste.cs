using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTeste
    {
        // para testar metodos sem parâmetros
        [Fact]
        public void ValidaFaturamento()
        {
            
            Veiculo veiculo = new Veiculo();
            veiculo.Proprietario = "Andre Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            Patio estacionamento = new Patio();
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
        public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange

            Veiculo veiculo = new Veiculo {
                Proprietario = proprietario,
                Tipo = TipoVeiculo.Automovel,
                Cor = cor,
                Modelo = modelo,
                Placa = placa
            };

            Patio estacionamento = new Patio();
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
    }
}
