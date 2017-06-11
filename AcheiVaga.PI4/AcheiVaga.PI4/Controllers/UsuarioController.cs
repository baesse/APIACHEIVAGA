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
        public string PostNovoUsuario(String nome, String email, String senha, String placacarro)
        {
            Usuario user = new Usuario();
            return user.InserirUsuario(nome, email, senha, placacarro);
        }

        [HttpGet]
        public string GetUsuarios(string email, string senha)
        {
            Usuario usuario = new Usuario();
            return usuario.LogarUsuario(email, senha);

        }

        [HttpPut]
        public string UpdateNome(string email, string senha, string novonome)
        {
            try
            {


                Usuario.AlterarNome(email, senha, novonome);

                return "Nome alterado";

            }
            catch (MongoException e)
            {
                return e.ToString();

            }

        }

        [HttpPut]
        public string UpdateEmail(string email, string senha, string novoemail)
        {
            try
            {


                Usuario.AlterarEmail(email, senha, novoemail);

                return "Nome alterado";

            }
            catch (MongoException e)
            {
                return e.ToString();

            }

        }

        [HttpPut]
        public string Updatesenha(string email, string senha, string novoemail1)
        {
            try
            {


                if (Usuario.AlterarEmail(email, senha, novoemail1))
                {
                    return "Senha alterada";

                }
                else
                {
                    return "Nome alterado";
                }



            }
            catch (MongoException e)
            {
                return e.ToString();

            }

        }

    }
}
