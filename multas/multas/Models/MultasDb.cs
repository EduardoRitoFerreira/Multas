using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace multas.Models
{
    public class MultasDb : DbContext{
        //contrutor da classe
        public MultasDb() : base("MultasDbConnectionString")
        {
            
        }

        //identificar as tabelas de bases de dados
        public virtual DbSet<Multas> Multas { get; set; }
        public virtual DbSet<Condutores> Condutores { get; set; }
        public virtual DbSet<Viaturas> Viaturas { get; set; }
        public virtual DbSet<Agentes> Agentes{ get; set; }
        /// <summary>
        /// configura a forma como as tabelas sao criadas
        /// </summary>
        /// <param name="modelBuilder">referencia o objecto gerador da base de dados</param>

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

    }
}