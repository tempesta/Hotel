using System;
using System.Collections.Generic;
using System.Linq;
using Hotel.Application.Hotel.Model;
using Hotel.Application.Interface.Infrastructure;
using Hotel.Application.Interface.Hotel;
using Hotel.Domain.Entities;

namespace Hotel.Application.Hotel
{
    public class ServiceHotel : ServiceBase<HotelEntity>, IHotel
    {
        public ServiceHotel(IRepository<HotelEntity> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public void Salvar(HotelDto hotelDto)
        {
            var hotel = new HotelEntity();

            hotel.Nome = hotelDto.Nome;
            hotel.Descricao = hotelDto.Descricao;
            hotel.Avaliacao = hotelDto.Avaliacao;
            hotel.Endereco = hotelDto.Endereco;

            hotelDto.Comodidades.ForEach((item) =>
            {
                hotel.Comodidades.Add(new ComodidadeEntity
                {
                    Id = 1,
                    Nome = item.Nome
                });
            });

            Transaction(() =>
            {
                Repository.Create(hotel);
            });
        }

        public void Alterar(HotelDto hotelDto)
        {
            if (hotelDto.Id <= 0)
                throw new ApplicationException("Operação inválida.");

            var toUpdateHotel = Repository.Load(hotelDto.Id);

            if (toUpdateHotel == null)
                throw new ApplicationException("O hotel em edição não foi encontrado na base de dados.");

            toUpdateHotel.Nome = hotelDto.Nome;
            toUpdateHotel.Descricao = hotelDto.Descricao;
            toUpdateHotel.Avaliacao = hotelDto.Avaliacao;
            toUpdateHotel.Endereco = hotelDto.Endereco;
            toUpdateHotel.Comodidades.Clear();

            var comodidadesEntity = new List<ComodidadeEntity>();
            comodidadesEntity = hotelDto.Comodidades.Select(comodidade => new ComodidadeEntity
            {
                Id = comodidade.Id,
                Nome = comodidade.Nome
            }).ToList();

            toUpdateHotel.Comodidades.Concat(comodidadesEntity);

            Repository.Update(toUpdateHotel);
        }

        public void Excluir(HotelDto hotelDto)
        {
            if (hotelDto.Id <= 0)
                throw new ArgumentException("Operação inválida");

            var hotelEntity = Repository.Load(hotelDto.Id);
            if(hotelEntity == null)
                throw new ArgumentException("Operação inválida");

            Repository.Delete(hotelEntity);
        }

        public List<HotelDto> Pesquisar(Dictionary<string, string> filtro, int itensPorPagina)
        {
            var query = Repository.Query();

            if (filtro == null)
                return query.Select(hotelEntity => new HotelDto(hotelEntity)).ToList();

            if(filtro.ContainsKey("Nome") && string.IsNullOrEmpty(filtro["Nome"]))
            {
                query = query.Where(x => x.Nome == filtro["Nome"].ToString());
            }

            if (filtro.ContainsKey("Comodidades") && string.IsNullOrEmpty(filtro["Comodidades"]))
            {
                var comodidadesConsulta = filtro["Comodidades"].Split(",").Select(x => Convert.ToInt32(x));
                query = comodidadesConsulta.Aggregate(query, (current, comodidadeId) => current.Where(x => x.Comodidades.Any(c => c.Id == comodidadeId)));
            }

            if (filtro.ContainsKey("Pagina") && string.IsNullOrEmpty(filtro["Pagina"]))
            {
                var pagina = Convert.ToInt32(filtro["Pagina"]);
                if (pagina > 0)
                    query = query.Skip((pagina - 1) * itensPorPagina).Take(itensPorPagina);
            }

            return query.Select(hotelEntity => new HotelDto(hotelEntity)).ToList();
        }
    }
}
