using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.Validators.Evento.Alta;

public class EventoAltaValidadorFecha
{
    public bool ValidarEventoAltaFecha(EventoDeportivo actividad, out string msg)
    {
        msg = "";
        if (actividad.FechaHoraInicio < DateTime.Now)
            msg += "La fecha ingresada debe ser igual o posterior a la fecha.\n";
        return msg == "";
    }
}