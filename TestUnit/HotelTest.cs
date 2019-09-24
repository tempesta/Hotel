using System;
using System.Collections.Generic;
using Hotel.Application.Interface.Infrastructure;
using Hotel.Domain.Entities;
using Moq;
using NUnit.Framework;

namespace TestUnit
{
    [TestFixture]
    public class HotelTest
    {
        private Dictionary<string, string> filtroPorNome;
        private Dictionary<string, string> filtroPorComodidade;

        private Mock<IRepository<HotelEntity>> mockRepositoryHotel;

        [SetUp]
        public void Setup()
        {
            filtroPorNome = new Dictionary<string, string>();
            filtroPorNome.Add("Nome", "teste");

            filtroPorComodidade = new Dictionary<string, string>();
            filtroPorComodidade.Add("Comodidades", "1,2");

            mockRepositoryHotel = new Mock<IRepository<HotelEntity>>();
        }

        [Test]
        public void Pesquisa(Dictionary<string, string> filtro)
        {
            mockRepositoryHotel.Setup((hotelRepository) => hotelRepository.Query(null)).Returns();
        }
    }
}
