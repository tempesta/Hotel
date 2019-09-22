using FluentNHibernate.Mapping;
using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Hotel.Persistence.Mapeamento
{
    public class HotelMap : ClassMap<HotelEntity>
    {
        public HotelMap()
        {
            Table("hotel");
            Id(x => x.Id).GeneratedBy.Sequence("seq_hotel_id").Not.Nullable();
            Map(x => x.Nome).Not.Nullable();
            Map(x => x.Descricao).Not.Nullable();
            Map(x => x.Avaliacao).Not.Nullable();
            Map(x => x.Endereco).Not.Nullable();
            HasManyToMany(x => x.Comodidades).Table("rel_hotel_comodidade").Cascade.AllDeleteOrphan();
        }
    }
}
