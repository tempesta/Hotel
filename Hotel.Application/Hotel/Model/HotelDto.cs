using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Hotel.Application.Comodidade.Model;
using Hotel.Domain.Entities;

namespace Hotel.Application.Hotel.Model
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Avaliacao { get; set; }
        public string Endereco { get; set; }
        public List<ComodidadeDto> Comodidades { get; set; }

        public HotelDto()
        {
            
        }

        public HotelDto(HotelEntity hotelEnitity)
        {
            Id = hotelEnitity.Id;
            Nome = hotelEnitity.Nome;
            Descricao = hotelEnitity.Descricao;
            Avaliacao = hotelEnitity.Avaliacao;
            Endereco = hotelEnitity.Endereco;
            Comodidades = hotelEnitity.Comodidades.Select(comodidadeEntity => new ComodidadeDto(comodidadeEntity)).ToList();
        }
    }
}
