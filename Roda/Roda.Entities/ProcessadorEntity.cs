using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roda.Entities
{
    public class ProcessadorEntity
    {        
        public ProcessadorEntity()
        {
            this.ProcessadoresEquivalentes = new HashSet<ProcessadorEntity>();
            this.Jogos = new HashSet<JogoEntity>();
        }

        public int ID { get; set; }
        public string Descricao { get; set; }
        public Nullable<double> Clock { get; set; }
        public Nullable<int> IDProcessadorEquivalente { get; set; }
        public Nullable<int> Potencia { get; set; }

        
        public virtual ICollection<ProcessadorEntity> ProcessadoresEquivalentes { get; set; }        
        public virtual ICollection<JogoEntity> Jogos { get; set; }
    }
}
