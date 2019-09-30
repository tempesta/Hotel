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
        void Excluir(int id);
        HotelDto Buscar(int id);
        List<HotelDto> Pesquisar(Dictionary<string, object> filtro, int itensPorPagina);
    }
}
