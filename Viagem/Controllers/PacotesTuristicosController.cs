using System.Collections.Generic;
using Viagem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Viagem.Controllers
{
    public class PacotesTuristicosController : Controller
    {
        public IActionResult Cadastro()
        {
             if(HttpContext.Session.GetInt32("idUsuario")== null)
                return RedirectToAction("Login","Usuario");
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(PacotesTuristicos novo)
        {   
            if(HttpContext.Session.GetInt32("idUsuario") == null)
                return RedirectToAction("Login", "Usuario");
            PacotesTuristicosBanco pacoteBanco = new PacotesTuristicosBanco();
            int id = (int)HttpContext.Session.GetInt32("idUsuario");
            pacoteBanco.Inserir(novo,id );
            ViewBag.Mensagem = "Cadastro concluido com sucesso";
            return View();
        }
        public IActionResult Lista()
        {
          
            PacotesTuristicosBanco pacote = new PacotesTuristicosBanco();
            List<PacotesTuristicos> lista = pacote.BuscarTodos();
            return View(lista);
        }
       
        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            UsuarioBanco usuarioBanco = new UsuarioBanco();
            Usuario usuarioSessao = usuarioBanco.BuscaUsuario(usuario);

            if(usuarioSessao != null)
            {
                ViewBag.Mensagem = "Voce esta logado!";
                HttpContext.Session.SetInt32("idUsuario", usuarioSessao.Id);
                HttpContext.Session.SetString("nomeUsuario", usuarioSessao.Nome);
                return View();
            }else
            {
                ViewBag.Mensagem = " Falha no login";
                return View();
            }

        }
        
        
    }
}