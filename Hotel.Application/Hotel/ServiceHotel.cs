using System;
using System.Collections.Generic;
using System.Linq;
using Hotel.Application.Comodidade;
using Hotel.Application.Hotel.Model;
using Hotel.Application.Interface.Infrastructure;
using Hotel.Application.Interface.Hotel;
using Hotel.Domain.Entities;
using Newtonsoft.Json.Linq;

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
                hotel.Comodidades.Add(Repository.Query<ComodidadeEntity>().FirstOrDefault(c => c.Id == item.Id));
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

            hotelDto.Comodidades.ForEach(comodidade =>
            {
                toUpdateHotel.Comodidades.Add(Repository.Query<ComodidadeEntity>().FirstOrDefault(c => c.Id == comodidade.Id));
            });

            Transaction(() =>
            {
                Repository.Update(toUpdateHotel);
            });
        }

        public void Excluir(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Operação inválida");

            var hotelEntity = Repository.Load(id);
            if(hotelEntity == null)
                throw new ArgumentException("Operação inválida");

            Transaction(() =>
            {
                Repository.Delete(hotelEntity);
            });
        }

        public HotelDto Buscar(int id)
        {
            if(id <= 0)
                throw  new Exception("Consulta inválida");

            return new HotelDto(Repository.Load(id));
        }

        public List<HotelDto> Pesquisar(Dictionary<string, object> filtro, int itensPorPagina)
        {
            var query = Repository.Query();

            if (filtro == null)
                return query.Select(hotelEntity => new HotelDto(hotelEntity)).ToList();

            if(filtro.ContainsKey("Nome") && !string.IsNullOrEmpty(filtro["Nome"] as string))
            {
                var nome = (filtro["Nome"] as string).ToLower();
                query = query.Where(x => x.Nome.ToLower().Contains(nome));
            }

            
            if (filtro.ContainsKey("Comodidades") )
            {
                var comodidades = (filtro["Comodidades"] as JArray)?.Select(c => Convert.ToInt32(c));
                query = comodidades.Aggregate(query, (current, comodidadeId) => current.Where(x => x.Comodidades.Any(c => c.Id == comodidadeId)));
            }

            if (filtro.ContainsKey("Pagina") && Convert.ToInt32(filtro["Pagina"]) > 0)
            {
                var pagina = Convert.ToInt32(filtro["Pagina"]);
                if (pagina > 0)
                    query = query.Skip((pagina - 1) * itensPorPagina).Take(itensPorPagina);
            }

            return query.Select(hotelEntity => new HotelDto(hotelEntity)).ToList();
        }
    }
}
