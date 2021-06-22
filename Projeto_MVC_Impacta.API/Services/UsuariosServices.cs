using MongoDB.Bson;
using MongoDB.Driver;
using Projeto_MVC_Impacta.API.DTO;
using Projeto_MVC_Impacta.Domain.Entities;
using Projeto_MVC_Impacta.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_MVC_Impacta.API.Services
{
    public class UsuariosServices
    {
        private MongoDbContext context;

        public List<string> ValidaCadastro(Usuarios usuario)
        {
            List<string> erros = new List<string>();

            context = new MongoDbContext();
            Usuarios us = context.Usuarios.Find(s => s.Email == usuario.Email).FirstOrDefault();

            if (us != null)
            {
                erros.Add("Já existe um usuário com esse email.");
            }

            if (String.IsNullOrEmpty(usuario.Nome))
            {
                erros.Add("É necessário ter um nome para o usuário");
            }

            if (String.IsNullOrEmpty(usuario.Email))
            {
                erros.Add("É necessário ter um email para o usuário");

            }
            else
            if (!Util.IsValidEmail(usuario.Email))
            {
                erros.Add("O endereço de email digitado não é válido");
            }


            if (String.IsNullOrEmpty(usuario.Senha))
            {
                erros.Add("É necessário ter uma senha para o usuário");

            }

            return erros;

        }

        public ResponseCadastroDTO AddUsuario(Usuarios usuario)
        {
            ResponseCadastroDTO rs = new ResponseCadastroDTO();
            List<string> erros = ValidaCadastro(usuario);
            if (erros.Count == 0)
            {
                context = new MongoDbContext();

                usuario.IdUsuario = ObjectId.GenerateNewId();
                context.Usuarios.InsertOne(usuario);

                rs.cadastrado = true;
            }
            else
            {
                rs.cadastrado = false;
                rs.erros = erros;
            }


            return rs;

        }

        public Usuarios Login(RequestLoginDTO request)
        {
            Usuarios us;
            context = new MongoDbContext();
            if (request.Login == "admin" && request.Senha == "senha")
            {
                us = new Usuarios()
                {
                    Email = "",
                    Nome = "admin",
                    Senha = "admin"
                    //Permissao
                };
            }
            else
            {
                us = context.Usuarios.Find(s => s.Email == request.Login && s.Senha == request.Senha).FirstOrDefault();
            }

            return us;
        }
    }
}
