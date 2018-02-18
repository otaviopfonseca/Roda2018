using Roda.DataAccess;
using Roda.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roda.Business.Conversor
{
    public class ConversorModelEntity
    {
        public static List<JogoEntity> ConverterJogoModelParaJogoEntity(ICollection<Jogo> jogo)
        {
            return jogo.Select(_jogo => ConverterJogoModelParaJogoEntity(_jogo)).ToList();
        }

        public static JogoEntity ConverterJogoModelParaJogoEntity(Jogo jogo)
        {
            JogoEntity jogoEntity = new JogoEntity();
            jogoEntity.ID = jogo.ID;
            jogoEntity.Nome = jogo.Nome;
            jogoEntity.Descricao = jogo.Descricao;
            jogoEntity.NomeEmpresa = jogo.NomeEmpresa;
            jogoEntity.MinimoHD = jogo.MinimoHD;
            jogoEntity.MinimoMemoria = jogo.MinimoMemoria;
            jogoEntity.DescricaoRequisitos = jogo.DescricaoRequisitos;
            jogoEntity.UrlImagem = jogo.UrlImagem;

            if (jogo.ProcessadoresCompativeis != null && jogo.ProcessadoresCompativeis.Any())
                jogoEntity.ProcessadoresCompativeis = ConverterProcessadorModelParaProcessadorEntity(jogo.ProcessadoresCompativeis);

            if (jogo.PlacasCompativeis != null && jogo.PlacasCompativeis.Any())
                jogoEntity.PlacasCompativeis = ConverterPlacaVideoModelParaPlacaVideoEntity(jogo.PlacasCompativeis);

            return jogoEntity;
        }

        public static List<PlacaVideoEntity> ConverterPlacaVideoModelParaPlacaVideoEntity(ICollection<PlacaVideo> placaVideoModel)
        {
            return placaVideoModel.Select(_placa => ConverterPlacaVideoModelParaPlacaVideoEntity(_placa)).ToList();
        }

        public static PlacaVideoEntity ConverterPlacaVideoModelParaPlacaVideoEntity(PlacaVideo placaVideoModel)
        {
            PlacaVideoEntity placaVideo = new PlacaVideoEntity();
            placaVideo.Clock = placaVideoModel.Clock;
            placaVideo.Descricao = placaVideoModel.Descricao;
            placaVideo.ID = placaVideoModel.ID;
            placaVideo.IDPlacaEquivalente = placaVideoModel.IDPlacaEquivalente;
            placaVideo.Potencia = placaVideoModel.Potencia;
            return placaVideo;
        }

        public static List<ProcessadorEntity> ConverterProcessadorModelParaProcessadorEntity(ICollection<Processador> processadorModel)
        {
            return processadorModel.Select(_processador => ConverterProcessadorModelParaProcessadorEntity(_processador)).ToList();
        }

        public static ProcessadorEntity ConverterProcessadorModelParaProcessadorEntity(Processador processadorModel)
        {
            ProcessadorEntity processadorEntity = new ProcessadorEntity();
            processadorEntity.Clock = processadorModel.Clock;
            processadorEntity.Descricao = processadorModel.Descricao;
            processadorEntity.ID = processadorModel.ID;
            processadorEntity.IDProcessadorEquivalente = processadorModel.IDProcessadorEquivalente;
            processadorEntity.Potencia = processadorModel.Potencia;            
            return processadorEntity;
        }
    }
}
