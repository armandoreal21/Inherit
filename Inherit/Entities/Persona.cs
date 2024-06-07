using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit.Entities
{
    public class PersonaExcel
    {
        public int ID { get; set; }
        public string? NombreCompleto { get; set; }
        public bool? Fallecido { get; set; } = false;

        [NoCopiar]
        public bool? IsSelected { get; set; } = false;

    }
}
