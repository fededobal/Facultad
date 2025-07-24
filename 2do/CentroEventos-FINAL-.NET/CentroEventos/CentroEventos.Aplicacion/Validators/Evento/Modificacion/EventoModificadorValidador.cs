using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validators.Evento.Modificacion;

public class EventoModificadorValidadorFecha
{
    public bool ValidarEventoModificacionFecha (EventoDeportivo unEvento, IRepositorioEventoDeportivo unRepo, out string msg)
    {
        msg = "";
        if (unEvento.FechaHoraInicio < DateTime.Now)
        {
            msg += "No puede modificarse un evento anterior a la fecha de hoy.\n";
        }
        return msg == "";
    }
}
 