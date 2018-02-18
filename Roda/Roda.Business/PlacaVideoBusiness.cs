using Roda.Business.Conversor;
using Roda.DataAccess;
using Roda.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roda.Business
{
    public class PlacaVideoBusiness
    {
        private PlacaVideoDataAccess _placaVideoDataAccess;
        private PlacaVideoDataAccess PlacaVideoDataAccess
        {
            get
            {
                if (_placaVideoDataAccess == null)
                    _placaVideoDataAccess = new PlacaVideoDataAccess();
                return _placaVideoDataAccess;
            }
        }
        
        public List<PlacaVideoEntity> ListarPlacasVideoCadastradas()
        {
            List<PlacaVideo> placasVideo = PlacaVideoDataAccess.ListarPlacasVideo();
            return ConversorModelEntity.ConverterPlacaVideoModelParaPlacaVideoEntity(placasVideo);
        }

        public PlacaVideoEntity ObterPlacaVideo(int idPlaca)
        {
            PlacaVideo placa = PlacaVideoDataAccess.ObterPlacaVideo(idPlaca);
            return ConversorModelEntity.ConverterPlacaVideoModelParaPlacaVideoEntity(placa);
        }

        public bool VerificarSePlacaVideoEhMelhorOuEquivalente(int iDPlacaVideoUsuario, PlacaVideo placa)
        {
            PlacaVideo placaUsuario = PlacaVideoDataAccess.ObterPlacaVideo(iDPlacaVideoUsuario);
            return placaUsuario.ID == placa.IDPlacaEquivalente || placaUsuario.Potencia >= placa.Potencia;
        }
    }
}
