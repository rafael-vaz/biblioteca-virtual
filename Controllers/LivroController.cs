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
    public class LivroController : Controller
    {
        public IActionResult Cadastro()
        {   
            if(HttpContext.Session.GetString("login") == null)
            return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Livro l)
        {
            LivroService livroService = new LivroService();

            if(l.Id == 0)
            {
                livroService.Inserir(l);
            }
            else
            {
                livroService.Atualizar(l);
            }
            

            return RedirectToAction("Listagem");
        }
        
        
        [HttpGet]
        public IActionResult Listagem(int p = 1){

            int quantidadePorPagina = 10;

            LivroService ls = new LivroService();

             ICollection<Livro> livros = ls.Listar(p, quantidadePorPagina);

            int quantidadeRegistros = ls.CountLivros();

            ViewData["Paginas"] = (int)Math.Ceiling((double)quantidadeRegistros / quantidadePorPagina);


            return View(livros);
        }


        [HttpPost]
        public IActionResult Listagem(string tipoFiltro, string filtro)
        {
            Autenticacao.CheckLogin(this);
            FiltrosLivros objFiltro = null;
            if(!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosLivros();
                objFiltro.Filtro = filtro;
                objFiltro.TipoFiltro = tipoFiltro;
            }
            LivroService livroService = new LivroService();
            ICollection<Livro> livros = livroService.ListarTodos(objFiltro);

            if(livros.Count == 0) {
             ViewData["Mensagem01"] = "Nenhum registro encontrado";
            }
            return View(livros);
        }
        
        [HttpGet]
        public IActionResult Edicao(int id)
        {
            Autenticacao.CheckLogin(this);
            LivroService ls = new LivroService();
            Livro l = ls.ObterPorId(id);
            return View(l);
        }

        [HttpPost]
        public IActionResult Edicao(Livro l)
        {
            LivroService ls = new LivroService();
            ls.Atualizar(l);
            return RedirectToAction("Listagem");
        }
    }
}