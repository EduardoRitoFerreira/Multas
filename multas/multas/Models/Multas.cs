using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace multas.Models
{
    public class Multas
    {
        [Key]
        public int ID { get; set; } //chave primária
        //atributos da multa
        public string Infracao { get; set; }
        public string LocalDaMulta { get; set; }
        public decimal ValorMulta { get; set; }
        public DateTime DataDaMulta { get; set; }
        //construção das chaves forasteiras
        //foreign key agents
        [ForeignKey("Agente")]
        public int AgenteFK { get; set; }   
        public virtual Agentes Agente { get; set; }
        //foreign key condutores
        [ForeignKey("Condutor")]
        public int CondutorFK { get; set; }
        public virtual Condutores Condutor { get; set; }
        //foreign key viaturas
        [ForeignKey("Viatura")]
        public int ViaturaFK { get; set; }
        public virtual Viaturas Viatura { get; set; }   

    }
}