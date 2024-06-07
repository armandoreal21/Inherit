using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFNetFramework.Enum
{
    public enum TipoTarjetaEnum
    {
        [Description("Agente")]
        Agente = 1,

        [Description("Provisional de Agente")]
        ProvisionalAgente = 2,

        [Description("Contrata")]
        Contrata = 3,

        [Description("Estudiante")]
        Estudiante = 4,

        [Description("Rondas")]
        Rondas = 5,

        [Description("Visita")]
        Visita = 6,

        [Description("Visita Externa")]
        VisitaExterna = 7,

        [Description("Rondas Personalizada")]
        RondasPersonalizada = 8
    }
}
