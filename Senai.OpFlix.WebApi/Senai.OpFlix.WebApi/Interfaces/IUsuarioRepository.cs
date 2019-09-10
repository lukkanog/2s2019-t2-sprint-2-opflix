using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        //string StringConexao { get; set; }

        Usuarios BuscarPorEmailESenha(LoginViewModel login);
        void Cadastrar(Usuarios usuario);
    }
}
