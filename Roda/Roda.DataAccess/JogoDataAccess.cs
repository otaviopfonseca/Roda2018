using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roda.DataAccess
{
    public class JogoDataAccess
    {
        public List<Roda.DataAccess.Jogo> ListarJogos()
        {
            using (RodaContext contexto = new RodaContext())
            {                
                return contexto.rod_jogo.OrderBy(jogo => jogo.Nome).ToList();
            }
        }

        public Jogo ObterJogo(int idJogo)
        {
            using (RodaContext contexto = new RodaContext())
            {
                return (from jogo in contexto.rod_jogo
                        where jogo.ID == idJogo
                        select jogo).FirstOrDefault();
            }
        }

        public Jogo ObterJogoComRequisitos(int idJogo)
        {
            using (RodaContext contexto = new RodaContext())
            {
                return (from jogo in contexto.rod_jogo.Include("PlacasCompativeis").Include("ProcessadoresCompativeis")
                               where jogo.ID == idJogo
                               select jogo).FirstOrDefault();
            }
        }


        public void SalvarJogo(Jogo jogo, int idProcessador, int idPlaca)
        {
            using (RodaContext contexto = new RodaContext())
            {
                PlacaVideo placa = contexto.rod_placa_video.FirstOrDefault(plac => plac.ID == idPlaca);
                Processador processador = contexto.rod_processador.FirstOrDefault(proc => proc.ID == idProcessador);
                jogo.ProcessadoresCompativeis.Add(processador);
                jogo.PlacasCompativeis.Add(placa);
                contexto.rod_jogo.Add(jogo);
                contexto.SaveChanges();
            }
        }
    }
}
