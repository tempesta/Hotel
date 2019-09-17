using FluentNHibernate.Mapping;
using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Persistence.Mapeamento
{
    public class ComodidadeMap : ClassMap<ComodidadeEntity>
    {
        public ComodidadeMap()
        {
            Table("comodidade");
            Id(x => x.Id).GeneratedBy.Sequence("seq_comodidade_id").Not.Nullable();
            Map(x => x.Nome).Not.Nullable();
        }
    }
}
