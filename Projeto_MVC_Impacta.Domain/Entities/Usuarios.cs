using MongoDB.Bson;
using Projeto_MVC_Impacta.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_MVC_Impacta.Domain.Entities
{
    public class Usuarios
    {
        public ObjectId? IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Permissoes Permissao { get; set; }
    }
}
