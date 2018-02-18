using Roda.Component;
using Roda.Entities;
using Roda.Web.Models;
using Roda.Web.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roda.Web.Controllers
{
    public class JogosController : Controller
    {      

        // GET: Jogos
        public ActionResult Sobre()
        {
            return View("~/Views/Roda/Sobre.cshtml");
        }

        public ActionResult Roda()
        {
            return View("~/Views/Roda/Roda.cshtml");
        }

        public ActionResult NaoRoda()
        {
            return View("~/Views/Roda/NaoRoda.cshtml");
        }

        public ActionResult Home()
        {
            CookieRoda cookie = Utilidades.obterCookieRoda();
            return View("~/Views/Roda/Home.cshtml", cookie);
        }

        public ActionResult VerificarJogos(int Processador, int PlacaVideo, double QuantidadeMemoria, double QuantidadeHD)
        {
            Utilidades.adicionarCookieRequisitos(Processador, PlacaVideo, QuantidadeMemoria, QuantidadeHD);
            List<JogoEntity> jogosCadastrados = JogoComponent.Get().ListarJogosCadastrados();
            return View("~/Views/Roda/Jogos.cshtml", jogosCadastrados);
        }

        public ActionResult Jogos()
        {
            List<JogoEntity> jogosCadastrados = JogoComponent.Get().ListarJogosCadastrados();
            return View("~/Views/Roda/Jogos.cshtml", jogosCadastrados);
        }

        public ActionResult DetalhesJogo(int idJogo)
        {
            JogoEntity jogo = JogoComponent.Get().ObterJogo(idJogo);
            return View("~/Views/Roda/DetalheJogo.cshtml", jogo);
        }

        public ActionResult VerificarCompativel(int idJogo)
        {
            CookieRoda cookie = Utilidades.obterCookieRoda();
            if (cookie == null)
                return RedirectToAction("Home");
            if (JogoComponent.Get().VerificarSeJogoEhCompativel(idJogo, cookie.IDPlacaVideo, cookie.IDProcessador, cookie.Memoria, cookie.HD))
                return View("~/Views/Roda/Roda.cshtml");
            return View("~/Views/Roda/NaoRoda.cshtml");
        }
        
        public ActionResult NovoJogo()
        {
            return View("~/Views/Roda/FormularioJogo.cshtml");
        }

        public ActionResult SalvarJogo(JogoEntity jogo)
        {
            JogoComponent.Get().SalvarJogo(jogo);
            return RedirectToAction("Jogos");
        }

        public ActionResult EditarJogo(int idJogo)
        {
            JogoEntity jogo = JogoComponent.Get().ObterJogo(idJogo);
            return View("~/Views/Roda/FormularioJogo.cshtml", jogo);
        }

        public ActionResult ExcluirJogo (int idJogo)
        {
            JogoComponent.Get().ExcluirJogo(idJogo);
            return RedirectToAction("Jogos");
        }
    }
}