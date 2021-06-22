using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_MVC_Impacta.Domain.Entities
{
    public class Tarefas
    {
        public Guid? Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime DtCriacao { get; set; }
        public bool? Fixado { get; set; }
        public DateTime? DtFixado { get; set; }
        public bool? Feito { get; set; }
    }
}
