using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestUnit
{
    [TestFixture]
    public class HotelTest
    {
        private Dictionary<string, string> filtroPorNome;
        private Dictionary<string, string> filtroPorComodidade;

        [SetUp]
        public void Setup()
        {
            filtroPorNome = new Dictionary<string, string>();
            filtroPorNome.Add("Nome", "teste");

            filtroPorComodidade = new Dictionary<string, string>();
            filtroPorComodidade.Add("Comodidades", "1,2");
        }

        [Test]
        public void Pesquisa(Dictionary<string, string> filtro)
        {

        }
    }
}
