using Roda.Business;
using Roda.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roda.Component
{
    public class PlacaVideoComponent
    {
        private PlacaVideoBusiness _placaVideoBusiness;
        private PlacaVideoBusiness PlacaVideoBusiness
        {
            get
            {
                if (_placaVideoBusiness == null)
                    _placaVideoBusiness = new PlacaVideoBusiness();
                return _placaVideoBusiness;
            }
        }

        private PlacaVideoComponent() { }

        public static PlacaVideoComponent Get()
        {
            return new PlacaVideoComponent();
        }

        public List<PlacaVideoEntity> ListarPlacasVideoCadastradas()
        {
            return PlacaVideoBusiness.ListarPlacasVideoCadastradas();
        }
    }
}
