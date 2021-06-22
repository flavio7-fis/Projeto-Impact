using Projeto_MVC_Impacta.Domain.Entities;
using Projeto_MVC_Impacta.Repository.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_MVC_Impacta.API.DTO;

namespace Projeto_MVC_Impacta.API.Services
{
    public class TarefasService
    {
        private MongoDbContext context;

        public List<string> ValidaDados(Tarefas tarefa)
        {
            List<string> erros = new List<string>();
            if (String.IsNullOrEmpty(tarefa.Titulo))
            {
                erros.Add("É necssário possuir um titulo para a tarefa");
            }

            if (String.IsNullOrEmpty(tarefa.Conteudo))
            {
                erros.Add("É necssário possuir um Conteudo para a tarefa");
            }
            return erros;
        }


        public List<Tarefas> GetTarefas()
        {
            context = new MongoDbContext();

            return context.Tarefas.Find(s => true).ToList();
        }


        public Tarefas GetTarefasById(Guid Id)
        {
            context = new MongoDbContext();

            return context.Tarefas.Find(s => s.Id == Id).FirstOrDefault();
        }

        public bool UpdateTarefa(Tarefas tarefas)
        {
            try
            {
                context = new MongoDbContext();
                context.Tarefas.ReplaceOne(s => s.Id == tarefas.Id, tarefas);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoveTarefasById(Guid Id)
        {
            try
            {
                context = new MongoDbContext();
                context.Tarefas.DeleteOne(s => s.Id == Id);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public ResponseCadastroDTO AddTarefas(Tarefas tarefas)
        {
            ResponseCadastroDTO response = new ResponseCadastroDTO();
            List<string> erros = ValidaDados(tarefas);
            if (erros.Count == 0)
            {
                try
                {
                    context = new MongoDbContext();
                    tarefas.Id = Guid.NewGuid();
                    context.Tarefas.InsertOne(tarefas);
                    response.cadastrado = true;

                }
                catch (Exception e)
                {

                    response.erros = new List<string>();
                    response.cadastrado = false;
                    response.erros.Add("Ocorreu um erro ao se conectar ao banco de dados, por favor tente novamente.");
                }
            }
            else
            {
                response.cadastrado = false;
                response.erros = erros;
            }

            return response;
        }
    }
}
