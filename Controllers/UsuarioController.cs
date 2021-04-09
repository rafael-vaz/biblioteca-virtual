using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Cadastro()
        {    
            if(HttpContext.Session.GetString("login") != "admin")
            return RedirectToAction("Index", "Home");
            return View();
        } 

        [HttpPost]
        public IActionResult Cadastro(Usuario u)
        {  

            UsuarioService us = new UsuarioService();

            us.Cadastrar(u);

            return RedirectToAction("Listagem");
        }

        public IActionResult Listagem()
        {
            ICollection<Usuario> usuarios;

            UsuarioService us = new UsuarioService();

            usuarios = us.Listar();

             if(HttpContext.Session.GetString("login") != "admin")
            return RedirectToAction("Index", "Home");

            return View(usuarios);
            
        } 

        
        [HttpGet]
        public IActionResult Editar(int id)
        {

            UsuarioService us = new UsuarioService();

            Usuario user = new Usuario();

            user = us.ObterPorId(id);

            return View(user);

        }

        [HttpPost]

        public IActionResult Editar(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario user = bc.Usuario.Find(u.Id);
                user.Login = u.Login;
                user.Senha = u.Senha;

                bc.SaveChanges();

                return RedirectToAction("Listagem");
            }
        }

        public IActionResult Remover(int id)
        {
            Usuario user = new Usuario();
            UsuarioService us = new UsuarioService();
            user = us.ObterPorId(id);
            us.Remover(user);

            return RedirectToAction("Listagem");
        }
    }
}