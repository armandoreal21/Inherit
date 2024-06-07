using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit.Entities
{
    public class RelacionComponentePersonaExcel
    {
        public int ID { get; set; }
        public int IDCOMPONENTE { get; set; }
        public int IDPERSONA { get; set; }
        public double? Cantidad { get; set; }
        public double? Porcentaje { get; set; }

        public string? NombreComponente { get; set; }
        public string? NombrePersona { get; set; }
    }
}
