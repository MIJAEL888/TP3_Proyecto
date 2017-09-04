

namespace ClinicaUtil
{
    public enum EstadoTurno : int
    {
        Libre = 1,
        Asignado = 2
    }

    public enum EstadoCita : int
    {
        Pendiente = 1,
        Anulado = 2,
        Finalizado = 3
    }

    public enum EstadoSolicitud : int
    {
        Pendiente = 1,
        Aprobado = 2,
        Rechazado = 3
    }

    public enum EstadoCama : int
    {
        Disponible = 1,
        Ocupado = 2,
        Mantenimiento = 3,
        MalEstado = 4,
        DeBaja = 5
    }

    public enum EstadoRegistroIngreso : int
    {
        Activado = 1,
        DesActivado = 2
    }

}
