using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TotvsPreventBackOffice.Models
{
    public class Servidor
    {
        [Key]
        public int Id { get; set; }
        public string Endereco { get; set; }
        public string Porta { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
