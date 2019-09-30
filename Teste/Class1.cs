using System;
using System.Collections.Generic;
using System.Linq;
using Hotel.Application.Comodidade.Model;
using Hotel.Application.Hotel;
using Hotel.Application.Hotel.Model;
using Hotel.Application.Interface.Infrastructure;
using Hotel.Domain.Entities;
using Hotel.Persistence.Infrastructure;
using NUnit.Framework;

namespace Teste
{
    [TestFixture]
    public class HotelTest
    {
        private Dictionary<string, string> filtroPorNome;
        private Dictionary<string, string> filtroPorComodidade;
        private List<ComodidadeDto> comodidades;

        [SetUp]
        public void Setup()
        {
            var estacionamento = new ComodidadeDto
            {
                Id = 1
            };
            var piscina = new ComodidadeDto
            {
                Id = 2
            };
            var sauna = new ComodidadeDto
            {
                Id = 3
            };
            var wifi = new ComodidadeDto
            {
                Id = 4
            };
            var restaurante = new ComodidadeDto
            {
                Id = 5

            };
            var bar = new ComodidadeDto
            {
                Id = 6

            };

            comodidades.Add(estacionamento);
            comodidades.Add(piscina);
            comodidades.Add(sauna);
            comodidades.Add(wifi);
            comodidades.Add(restaurante);
            comodidades.Add(bar);
        }

        [Test]
        public void Cadastrar()
        {
            var idsComodidade = new List<int>() { 1, 2, 3 };
            var hotelDto = new HotelDto
            {
                Avaliacao = 5,
                Comodidades = comodidades.Where(c => idsComodidade.Contains(c.Id)).ToList(),
                Descricao = "Teste",
                Endereco = "Rua do teste",
                Nome = "Hotel Teste"
            };

            var unitOfWork = new UnitOfWork();
            new ServiceHotel(new Repository<HotelEntity>(unitOfWork), unitOfWork).Salvar(hotelDto);
        }

        [Test]
        public void Alterar()
        {
            var idsComodidade = new List<int>() { 1 };
            var hotelDto = new HotelDto
            {
                Id = 1,
                Avaliacao = 5,
                Comodidades = comodidades.Where(c => idsComodidade.Contains(c.Id)).ToList(),
                Descricao = "Teste alterar",
                Endereco = "Rua do teste alterar",
                Nome = "Hotel Teste"
            };

            var unitOfWork = new UnitOfWork();
            new ServiceHotel(new Repository<HotelEntity>(unitOfWork), unitOfWork).Alterar(hotelDto);
        }

        [Test]
        public void Excluir()
        {
            var unitOfWork = new UnitOfWork();
            new ServiceHotel(new Repository<HotelEntity>(unitOfWork), unitOfWork).Excluir(1);
        }

        [Test]
        public void Pesquisar()
        {
            Cadastrar();

            var filtro = new Dictionary<string, object>();
            filtro.Add("Nome", "Teste");
            filtro.Add("Comodidades", new Array[1, 2]);

            var unitOfWork = new UnitOfWork();
            var serviceHotel = new ServiceHotel(new Repository<HotelEntity>(unitOfWork), unitOfWork);
            var resultado1 = serviceHotel.Pesquisar(filtro, 15);

            filtro["Comodidades"] = new Array[1, 2, 5];
            var resultado2 = serviceHotel.Pesquisar(filtro, 15);

            Assert.AreEqual(resultado2.Count, 0);
            Assert.AreNotEqual(resultado2.Count, 1);
            Assert.AreEqual(resultado1.Count, 1);
        }
    }
}
