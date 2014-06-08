using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCC_ACE.Models;

namespace TCC_ACE.Persistence
{

    public class UsuarioDB
    {

        private ContextEntities context { get; set; }

        public UsuarioDB(ContextEntities context)
        {
            this.context = context;
        }


        public IQueryable<Usuario> getAll()
        {
            IQueryable<Usuario> usuarios = context.Usuario;

            return usuarios;
        }

        public bool editarUsuario(ModelUsuario usuario)
        {

            var user = context.Usuario.Find(usuario.codigo);
            user.codigo = usuario.codigo;
            user.login = usuario.login;

            if (!string.IsNullOrEmpty(usuario.senha))
            {
                user.senha = usuario.senha;
            }

            user.titulo = usuario.titulo;
            user.GrupoRecurso_codigo = usuario.grupo.codigo;

            context.SaveChanges();

            return true;
        }

        public bool SalvarUsuario(ModelUsuario usuario)
        {
            Usuario user = new Usuario();
            user.codigo = usuario.codigo;
            user.login = usuario.login;
            user.senha = usuario.senha;
            user.titulo = usuario.titulo;
            user.GrupoRecurso_codigo = usuario.grupo.codigo;

            context.Usuario.Add(user);

            context.SaveChanges();

            return true;
        }

        public Usuario GetByCod(int codigo)
        {
            Usuario usuario = context.Usuario.FirstOrDefault(c => c.codigo == codigo);
            return usuario;
        }
    }
}