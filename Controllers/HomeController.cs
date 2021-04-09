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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("id_usuarios") == null)
            return RedirectToAction("Login");
            
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario u)
        {
            
            UsuarioService us = new UsuarioService();
            Usuario usuario = us.Login(u);

            if(usuario != null){

            HttpContext.Session.SetInt32("id_usuarios", usuario.Id);
            HttpContext.Session.SetString("login", usuario.Login);
            HttpContext.Session.SetString("senha", usuario.Senha);
            
            ViewData["Login"] = "Login realizado com sucesso!";
            
            } else {
              
             ViewData["Login"] = "Falha ao realizar o login!"; 
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
