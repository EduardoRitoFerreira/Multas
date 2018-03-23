using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace multas.Models
{
    public class Condutores
    {
        public Condutores()
        {
            ListaDeMultas = new HashSet<Multas>();
        }
        [Key]           
        public int ID { get; set; } //chave primária
        //dados proprios do condutor
        public string Nome { get; set; }
        public string BI { get; set; }
        public string Telemovel { get; set; }
        //dados da carta do condutor
        public DateTime DataNascimento { get; set; }
        public string NumCartaConducao { get; set; }
        public string LocalEmissao { get; set; } 
        public DateTime DataValidadeCarta { get; set; }
        //complementar a informação entre o relacionamento
        public virtual ICollection<Multas> ListaDeMultas { get; set; }

    }  
}