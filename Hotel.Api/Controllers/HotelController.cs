using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Application.Comodidade.Model;
using Hotel.Application.Hotel;
using Hotel.Application.Hotel.Model;
using Hotel.Domain.Entities;
using Hotel.Persistence.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers
{
    public class HotelController : Controller
    {
        private UnitOfWork unitOfWork;

        public HotelController()
        {
                unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        public IActionResult Salvar(int num)
        {
            var hotelDto = new HotelDto
            {
                Nome = "Nome",
                Descricao = "Descricao",
                Avaliacao = 5,
                Endereco = "Endereço",
                Comodidades = new List<ComodidadeDto>() { new ComodidadeDto{ Id = 1, Nome = "Comododade1"}}
            };
            new ServiceHotel(new Repository<HotelEntity>(unitOfWork), unitOfWork).Salvar(hotelDto);

            return Ok("Sucesso");
        }
    }
}
