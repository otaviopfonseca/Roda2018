using Roda.Business;
using Roda.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roda.Component
{
    public class JogoComponent
    {


        private JogoBusiness _jogoBusiness;
        private JogoBusiness JogoBusiness
        {
            get
            {
                if (_jogoBusiness == null)
                    _jogoBusiness = new JogoBusiness();
                return _jogoBusiness;
            }
        }

        private JogoComponent() { }

        public static JogoComponent Get()
        {
            return new JogoComponent();
        }

        public List<JogoEntity> ListarJogosCadastrados()
        {
            return JogoBusiness.ListarJogosCadastrados();
        }

        public JogoEntity ObterJogo(int idJogo)
        {
            return JogoBusiness.ObterJogo(idJogo);
        }

        public void ExcluirJogo(int idJogo)
        {
            JogoBusiness.ExcluirJogo(idJogo);
        }

        public void SalvarJogo(JogoEntity jogo)
        {
            JogoBusiness.SalvarJogo(jogo);
        }

        public bool VerificarSeJogoEhCompativel(int idJogo, int iDPlacaVideo, int iDProcessador, double memoria, double hD)
        {
            return JogoBusiness.VerificarSeJogoEhCompativel(idJogo, iDPlacaVideo, iDProcessador, memoria, hD);
        }
    }
}
