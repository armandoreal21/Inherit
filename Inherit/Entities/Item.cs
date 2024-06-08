using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit.Entities
{
    public class Item
    {
        public string? Nombre { get; set; }
        public string? Cantidad { get; set; }
        public string? Porcentaje { get; set; }
        public string? Total { get; set; }
        public Entidad Entidad { get; set; }

    }
}
