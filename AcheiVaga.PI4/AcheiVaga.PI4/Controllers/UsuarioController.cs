using AcheiVaga.PI4.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using MongoDB.Driver;


namespace AcheiVaga.PI4.Controllers
{
    public class UsuarioController : ApiController
    {
       [HttpPost]
        public string PostNovoUsuario(string usuario)
        {


            try
            {
                var JsonPessoa = JsonConvert.DeserializeObject<Usuario>(usuario);
                JsonPessoa.InserirUsuario(JsonPessoa);
                return "Usuario Cadastrado";

            }
            catch (MongoException e)
            {

                return e.ToString();

            }

                   


          


        }

        /*
        [HttpGet]
        public List<Usuario> GetUsuarios()
        {
            Usuario usuario = new Usuario();
           return usuario.ListaCadastro();

        }
        */

        //[HttpGet]
        //public string GetLogin(string placa, string senha)
        //{
        //    Usuario usuario = new Usuario();
        //   return usuario.GetLogin(placa,senha);
        //}
    }
}
