using Roda.DataAccess;
using Roda.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roda.Business.Conversor
{
    public class ConversorEntityModel
    {
        public static Jogo ConverterJogoEntityEmJogo(JogoEntity jogo)
        {
            return new Jogo()
            {
                Descricao = jogo.Descricao,
                MinimoHD = jogo.MinimoHD,
                MinimoMemoria = jogo.MinimoMemoria,
                DescricaoRequisitos = jogo.DescricaoRequisitos,
                Nome = jogo.Nome,
                ID = jogo.ID,
                NomeEmpresa = jogo.NomeEmpresa,
                UrlImagem = jogo.UrlImagem
            };
        }
    }
}
