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

        /// <summary>
        /// Cadastrar
        /// </summary>
        /// <param name="hotelDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar([FromBody] HotelDto hotelDto)
        {
            new ServiceHotel(new Repository<HotelEntity>(unitOfWork), unitOfWork).Salvar(hotelDto);
            return Ok("Sucesso");
        }

        [HttpPost]
        public IActionResult Alterar([FromBody] HotelDto hotelDto)
        {
            new ServiceHotel(new Repository<HotelEntity>(unitOfWork), unitOfWork).Alterar(hotelDto);
            return Ok("Sucesso");
        }


        /// <summary>
        /// Pesquisar
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Pesquisar([FromBody] Dictionary<string,object> filtro)
        {
            var hoteis = new ServiceHotel(new Repository<HotelEntity>(unitOfWork), unitOfWork).Pesquisar(filtro, 15);
            return Ok(hoteis);
        }

        /// <summary>
        /// Excluir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Excluir([FromBody] int id)
        {
            new ServiceHotel(new Repository<HotelEntity>(unitOfWork), unitOfWork).Excluir(id);
            return Ok("Hotel excluído com sucesso");
        }

        /// <summary>
        /// Carregar hotel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Buscar(int id)
        {
            var hotel = new ServiceHotel(new Repository<HotelEntity>(unitOfWork), unitOfWork).Buscar(id);
            return Ok(hotel);
        }
    }
}
