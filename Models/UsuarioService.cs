using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Biblioteca.Models
{
    public class UsuarioService
    {

         public void Cadastrar(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuario.Add(u);
                bc.SaveChanges();
            }
        }


         public Usuario ObterPorId(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuario.Find(id);
            }
        }


        public ICollection<Usuario> Listar()
        {

            using(BibliotecaContext bc = new BibliotecaContext())
            {

                IQueryable<Usuario> query = bc.Usuario;

                return query.OrderBy(u => u.Id).ToList();
            }
        }

        public void Remover(Usuario u){

        using(BibliotecaContext bc = new BibliotecaContext())
        {    
            bc.Usuario.Remove(u);
            bc.SaveChanges();
        }
        }


        public Usuario Login(Usuario user)
        {
           using(BibliotecaContext bc = new BibliotecaContext())
           {
               Usuario usuario = bc.Usuario.Single(u => u.Login.Contains(user.Login));

               if(usuario.Login == user.Login && usuario.Senha == user.Senha){

                   user.Login = usuario.Login;
                   user.Senha = usuario.Senha;
                   user.Id = usuario.Id;
               }

               else {

                   user = null;
               }

               return user;
           }
        }
        
    }
}