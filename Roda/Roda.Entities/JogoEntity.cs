using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roda.Entities
{
    public class JogoEntity
    {
        public JogoEntity()
        {
            this.PlacasCompativeis = new HashSet<PlacaVideoEntity>();
            this.ProcessadoresCompativeis = new HashSet<ProcessadorEntity>();
        }

        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlImagem { get; set; }
        public string NomeEmpresa { get; set; }
        public string DescricaoRequisitos { get; set; }
        public Nullable<int> MinimoMemoria { get; set; }
        public Nullable<int> MinimoHD { get; set; }
        public int IDPlaca { get; set; }
        public int IDProcessador { get; set; }

        public virtual ICollection<PlacaVideoEntity> PlacasCompativeis { get; set; }        
        public virtual ICollection<ProcessadorEntity> ProcessadoresCompativeis { get; set; }
    }
}
