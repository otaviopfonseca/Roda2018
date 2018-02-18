using Roda.Component;
using Roda.Entities;
using Roda.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roda.Web.Utils
{
    public class Utilidades
    {
        public static List<SelectListItem> obterSelectListProcessadores(int idSelecionado)
        {
            List<SelectListItem> listItens = new List<SelectListItem>();
            listItens.Add(new SelectListItem());
            List<ProcessadorEntity> processadores = ProcessadorComponent.Get().ListarProcessadoresCadastrados();
            processadores.ForEach(proc => listItens.Add(new SelectListItem() { Text = proc.Descricao + " " + proc.Clock + "Ghz", Value = proc.ID.ToString(), Selected = proc.ID == idSelecionado }));
            
            return listItens;
        }

        public static List<SelectListItem> obterSelectListPlacasVideo(int idSelecionado)
        {
            List<SelectListItem> listItens = new List<SelectListItem>();
            listItens.Add(new SelectListItem());
            List<PlacaVideoEntity> processadores = PlacaVideoComponent.Get().ListarPlacasVideoCadastradas();
            processadores.ForEach(proc => listItens.Add(new SelectListItem() { Text = proc.Descricao + " " + proc.Clock + "Ghz", Value = proc.ID.ToString(), Selected = proc.ID == idSelecionado }));
            return listItens;
        }

        public static void adicionarCookieRequisitos(int processador, int placaVideo, double memoria, double hd)
        {
            HttpCookie cookie = new HttpCookie("MaquinaUsuario");
            cookie.Value = (new CookieRoda(processador, placaVideo, memoria, hd)).ToString();
            cookie.Expires = DateTime.Now.AddDays(30);
            if (HttpContext.Current.Request.Cookies["MaquinaUsuario"] != null)
                HttpContext.Current.Request.Cookies.Remove("MaquinaUsuario");
            HttpContext.Current.Response.SetCookie(cookie);
        }

        public static CookieRoda obterCookieRoda()
        {
            if (HttpContext.Current.Request.Cookies["MaquinaUsuario"] != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["MaquinaUsuario"];
                string valor = cookie.Value;
                return new CookieRoda(valor);
            }
            return null;
        }        
    }
}