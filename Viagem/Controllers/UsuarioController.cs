using System.Collections.Generic;
using Viagem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace Viagem.Controllers
{
    public class UsuarioController : Controller
    {

        public IActionResult Cadastro()
        {
             if(HttpContext.Session.GetInt32("idUsuario")== null || HttpContext.Session.GetInt32("TipoUsuario") != 0)
                return RedirectToAction("Login");
            return View();
        }
         public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(Usuario novoUsuario)
        {
            
            UsuarioBanco user = new UsuarioBanco();
            user.Inserir(novoUsuario);
            ViewBag.Mensagem = "Cadastro concluido comn sucesso";
            return View();
        }
        public IActionResult Lista()
        {
            if(HttpContext.Session.GetInt32("idUsuario")== null || HttpContext.Session.GetInt32("TipoUsuario") != 0)
                return RedirectToAction("Login","Usuario");

            UsuarioBanco user = new UsuarioBanco();
            List<Usuario> lista = user.BuscarTodos();
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
                HttpContext.Session.SetInt32("TipoUsuario", usuarioSessao.Tipo);
                return Redirect("Cadastro");
            }else
            {
                ViewBag.Mensagem = " Falha no login";
                return View();
            }
        }
        public IActionResult Editar(int Id)
        {
            UsuarioBanco user = new UsuarioBanco();
            Usuario usuario = user.ConsultaPorId(Id);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Gravar(Usuario usuario)
        {
            UsuarioBanco user = new UsuarioBanco();
            user.Atualizar(usuario);
            return RedirectToAction("Lista");
        }
        public IActionResult Remover(int Id)
        {
            UsuarioBanco user = new UsuarioBanco();
            user.Remover(Id);
            return RedirectToAction("Lista");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
        
    }
}