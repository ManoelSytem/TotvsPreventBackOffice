using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TotvsPreventBackOffice.Models
{
    public class Empresa
    {
        [Key]
        public int ID { get; set; }
        [StringLength(150)]
        public string Nome { get; set; }
        public string CodEmpresa { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
