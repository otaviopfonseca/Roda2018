using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roda.Entities
{
    public class PlacaVideoEntity
    {        
        public PlacaVideoEntity()
        {
            this.PlacasEquivalentes = new HashSet<PlacaVideoEntity>();
            this.Jogos = new HashSet<JogoEntity>();
        }

        public int ID { get; set; }
        public string Descricao { get; set; }
        public Nullable<double> Clock { get; set; }
        public Nullable<int> Potencia { get; set; }
        public Nullable<int> IDPlacaEquivalente { get; set; }

       
        public virtual ICollection<PlacaVideoEntity> PlacasEquivalentes { get; set; }       
        public virtual ICollection<JogoEntity> Jogos { get; set; }
    }
}
