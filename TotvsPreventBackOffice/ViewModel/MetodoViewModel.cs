using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotvsPreventBackOffice.Models;

namespace TotvsPreventBackOffice.ViewModel
{
    public class MetodoViewModel
    {
        public string Metodo { get; set; }
        public Servidor Servidor { get; set; }
        public Modulo Modulo { get; set; }
    }
}
