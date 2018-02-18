using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roda.Entities;

namespace Roda.DataAccess
{
    public class PlacaVideoDataAccess
    {
        public List<PlacaVideo> ListarPlacasVideo()
        {
            using (RodaContext contexto = new RodaContext())
            {
                return contexto.rod_placa_video.ToList();
            }
        }

        public PlacaVideo ObterPlacaVideo(int idPlaca)
        {
            using (RodaContext contexto = new RodaContext())
            {
                return (from placa in contexto.rod_placa_video
                        where placa.ID == idPlaca
                        select placa
                        ).FirstOrDefault();
            }
        }
    }
}
