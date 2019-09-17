using System;
using System.Collections.Generic;
using System.Text;
using Hotel.Application.Interface;
using Hotel.Domain.Entities;

namespace Hotel.Application.Services
{
    public class HotelService : ServiceBase<HotelEntity>
    {
        public HotelService(IRepository<HotelEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public void Salvar(HotelEntity hotel)
        {
            Repository.Create(hotel);
        }

        public void Alterar(HotelEntity hotel)
        {
            Repository.Update(hotel);
        }

        public void Excluir(HotelEntity hotel)
        {
            Repository.Delete(hotel);
        }
    }
}
