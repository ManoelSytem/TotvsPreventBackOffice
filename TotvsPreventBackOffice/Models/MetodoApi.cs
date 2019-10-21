using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TotvsPreventBackOffice.Models
{
    public class MetodoApi
    {
        [Key]
        public int ID { get; set; }
        public string Metodo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public virtual Servidor Servidor { get; set; }
        public int ModuloId  { get; set; }

    }
}
