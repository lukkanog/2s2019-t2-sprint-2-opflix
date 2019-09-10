using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_OpFlix; User Id=sa;Pwd=132";


        
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                var usuario = ctx.Usuarios.Include(x => x.IdTipoUsuarioNavigation).FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (usuario == null)
                    return null;

                return usuario;

            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }
    }//#########################################################################################################################
}
