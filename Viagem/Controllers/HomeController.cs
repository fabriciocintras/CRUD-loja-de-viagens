using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Viagem.Models;

namespace Viagem.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            
            PacotesTuristicosBanco pacote = new PacotesTuristicosBanco();
            List<PacotesTuristicos> lista = pacote.BuscarTodos();
            return View(lista);
        }
        public IActionResult QuemSomos()
        {
            return View();
        }
        public IActionResult FaleConosco()
        {
            return View();
        }
         [HttpPost]
        public IActionResult FaleConosco(Mensagem novaMensagem)
        {
            
            MensagemBanco us = new MensagemBanco();
            us.Inserir(novaMensagem);
            ViewBag.Mensagem = "Mensagem enviada!";
            return View();
        }
         public IActionResult Lista()
        {
            if(HttpContext.Session.GetInt32("idUsuario")== null || HttpContext.Session.GetInt32("TipoUsuario") != 0)
                return RedirectToAction("Login","Usuario");

            MensagemBanco us = new MensagemBanco();
            List<Mensagem> lista = us.Buscar();
            return View(lista);
        }

        
      

    }
}
