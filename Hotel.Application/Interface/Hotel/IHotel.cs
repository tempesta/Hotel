using System;
using System.Collections.Generic;
using System.Text;
using Hotel.Application.Hotel.Model;
using Hotel.Domain.Entities;

namespace Hotel.Application.Interface.Hotel
{
    public interface IHotel
    {
        void Salvar(HotelDto hotel);
        void Alterar(HotelDto hotel);
        void Excluir(HotelDto hotel);
        List<HotelDto> Pesquisar(Dictionary<string, string> filtro, int itensPorPagina);
    }
}
