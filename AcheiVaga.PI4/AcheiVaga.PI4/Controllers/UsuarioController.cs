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
        public string PostNovoUsuario(string NomeUsuario, string Senha, string PlacaCarro, string pontuacao,string rua,string numero,string cep,string bairro,string complemento)
        {
            


            Models.Usuario.Usuario usuario = new Models.Usuario.Usuario(NomeUsuario, Senha, PlacaCarro, pontuacao);
            usuario.Endereco.Rua = rua;
            usuario.Endereco.numero = numero;
            usuario.Endereco.cep = cep;
            usuario.Endereco.bairro = bairro;
            usuario.Endereco.complemento = complemento;
            usuario.cudasuamae = "cu mesmo da sua mae";


            usuario.InserirUsuario(usuario);
            return "Usuario Cadastrado";

        }

        /*
        [HttpGet]
        public List<Usuario> GetUsuarios()
        {
            Usuario usuario = new Usuario();
           return usuario.ListaCadastro();

        }
        */

        [HttpGet]
        public string GetLogin(string placa, string senha)
        {
            Usuario usuario = new Usuario();
           return usuario.GetLogin(placa,senha);
        }
    }
}
