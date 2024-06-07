

using System.ComponentModel;

namespace Inherit.Enums
{
    /// <summary>
    /// Enum SolicitudEstado
    /// </summary>
    public enum SolicitudEstado
    {
        PendienteDeEnvio = 1,
        PendienteDeGestionar = 2,
        Aceptada = 3,
        Cerrada = 4,
        Cancelada = 5
    }

    public enum SolicitudEstadoTarjeta
    {
        [Description("Tarjetas Generadas")]
        TarjetasGeneradas = 11,

        [Description("Aceptada")]
        Aceptada = 12,

        [Description("Cancelada")]
        Cancelada = 13,

        [Description("Generada")]
        Generada = 14
    }

    public enum SolicitudEstadoTarjetaSeguridad
    {
        [Description("Pendiente de Enviar")]
        PendienteDeEnvio = 1,
        [Description("Pendiente de Gestionar Tarjetas")]
        PendienteDeGestionarTarjetas = 2
    }

    public enum SolicitudesTipo
    {
        [Description("Solicitud de Tarjeta de Contrata")]
        SolicitudTarjeta = 1,
        [Description("Solicitud de Modificacion")]
        SolicitudModificacion = 2,
        [Description("Solicitud de Ampliacion")]
        SolicitudAmpliacion = 3,
        [Description("Solicitud de Notificacion")]
        SolicitudNotificacion = 4,

    }

}
