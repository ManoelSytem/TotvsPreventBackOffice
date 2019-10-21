using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TotvsPreventBackOffice.Models
{
    public class Modulo
    {
        [Key]
        public int Id { get; set; }
        public string descricao { get; set; }

    }
}
