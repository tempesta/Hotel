using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Domain.Entities
{
    public class HotelEntity
    {
        public HotelEntity()
        {
            Comodidades = new List<ComodidadeEntity>();
        }

        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual int Avaliacao { get; set; }
        public virtual string Endereco { get; set; }
        public virtual IList<ComodidadeEntity> Comodidades { get; set; }
    }
}
