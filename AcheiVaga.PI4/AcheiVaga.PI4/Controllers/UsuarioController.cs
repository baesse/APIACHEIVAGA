using AcheiVaga.PI4.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AcheiVaga.PI4.Controllers
{
    public class UsuarioController : ApiController
    {
        [HttpPost]
        public string PostNovoUsuario(string NomeUsuario, string Senha, string PlacaCarro, string pontuacao)
        {
            Models.Usuario.Usuario usuario = new Models.Usuario.Usuario(NomeUsuario, Senha, PlacaCarro, pontuacao);
            usuario.InserirUsuario(usuario);
            return "Usuario Cadastrado";

        }

        [HttpGet]
        public string GetUsuarios()
        {
            Usuario usuario = new Usuario();
           return usuario.ListaCadastro();

        }
    }
}
