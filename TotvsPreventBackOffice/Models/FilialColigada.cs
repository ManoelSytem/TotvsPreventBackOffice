using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TotvsPreventBackOffice.Models
{
    public class FilialColigada
    {
        [Key]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CodigoFilialColigada { get; set; }
        public virtual Empresa Empresa { get; set; }

    }
}
