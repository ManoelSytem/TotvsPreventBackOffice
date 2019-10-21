using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TotvsPreventBackOffice.Models
{
    public class UserModuloPerfil
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(450)]
        public string IdUser { get; set; }
        public int CodModulo { get; set; }

    }
}
