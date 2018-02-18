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
    public class JogoBusiness
    {
        private JogoDataAccess _jogoDataAcess;
        private JogoDataAccess JogoDataAccess
        {
            get
            {
                if (_jogoDataAcess == null)
                    _jogoDataAcess = new JogoDataAccess();
                return _jogoDataAcess;
            }
        }

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

        private ProcessadorBusiness _processadorBusiness;
        private ProcessadorBusiness ProcessadorBusiness
        {
            get
            {
                if (_processadorBusiness == null)
                    _processadorBusiness = new ProcessadorBusiness();
                return _processadorBusiness;
            }
        }

        public List<JogoEntity> ListarJogosCadastrados()
        {
            List<Jogo> jogos = JogoDataAccess.ListarJogos();
            return ConversorModelEntity.ConverterJogoModelParaJogoEntity(jogos);
        }

        public JogoEntity ObterJogo(int idJogo)
        {
            Jogo jogoSelecionado = JogoDataAccess.ObterJogo(idJogo);
            return ConversorModelEntity.ConverterJogoModelParaJogoEntity(jogoSelecionado);
        }

        public void SalvarJogo(JogoEntity jogo)
        {
            Jogo jogoSalvar = ConversorEntityModel.ConverterJogoEntityEmJogo(jogo);
            JogoDataAccess.SalvarJogo(jogoSalvar, jogo.IDProcessador, jogo.IDPlaca);

        }

        public bool VerificarSeJogoEhCompativel(int idJogo, int iDPlacaVideo, int iDProcessador, double memoria, double hD)
        {
            Jogo jogoSelecionado = JogoDataAccess.ObterJogoComRequisitos(idJogo);
            if(jogoSelecionado.MinimoHD <= hD && jogoSelecionado.MinimoMemoria <= memoria)
            {
                PlacaVideo placaJogo = jogoSelecionado.PlacasCompativeis.FirstOrDefault();
                Processador processadorJogo = jogoSelecionado.ProcessadoresCompativeis.FirstOrDefault();

                if (placaJogo.ID == iDPlacaVideo && processadorJogo.ID == iDProcessador)
                    return true;

                return PlacaVideoBusiness.VerificarSePlacaVideoEhMelhorOuEquivalente(iDPlacaVideo, placaJogo) &&
                    ProcessadorBusiness.VerificarSeProcessadorEhMelhorOuEquivalente(iDProcessador, processadorJogo);
            }
            return false;
        }
    }
}
