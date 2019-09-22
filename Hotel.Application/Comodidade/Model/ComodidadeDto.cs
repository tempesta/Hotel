using System;
using System.Collections.Generic;
using System.Text;
using Hotel.Domain.Entities;

namespace Hotel.Application.Comodidade.Model
{
    public class ComodidadeDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ComodidadeDto()
        {
            
        }

        public ComodidadeDto(ComodidadeEntity comodidadeEntity)
        {
            Id = comodidadeEntity.Id;
            Nome = comodidadeEntity.Nome;
        }
    }
}
