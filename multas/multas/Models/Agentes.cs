using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace multas.Models
{
    public class Agentes
    {
        public Agentes() {
            ListaDeMultas = new HashSet<Multas>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//impede que um novo agente tenha um id automatico
        public int ID { get; set; }
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatorio")]//preenchimento obrigatorio
        [RegularExpression("[A-ZÂÍ][a-záéíóúãõàèìòâêîôûäëïöüç]+(( | de | da| dos | d' |-)[A-ZÂÍ][a-záéíóúãõàèìòâêîôûäëïöüç]+){1,3}", ErrorMessage = "O nome e invaido, ver FAQ para saber como escrever um melhor.")]
        [StringLength(40)]
        public string Nome { get; set; }
        //[Required(ErrorMessage = "A {0} é de preenchimento obrigatorio")]
        public string Fotografia { get; set; }
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatorio")]
        [RegularExpression("[A-Za-záéíóúãõàèìòâêîôûäëïöüç 0-9-]+", ErrorMessage = "burro")]
        public string Esquadra { get; set; }

        //compementar a informacao sobre o relcionamento
        //de um agente com as multas por ele passadas

        public virtual ICollection<Multas> ListaDeMultas { get; set; }


    }
}