using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validators.Evento.Modificacion;

public class EventoModificadorValidadorIdResponsable
{
    public bool ValidarEventoModificacionIdResponsable (EventoDeportivo unEvento, IRepositorioPersona unRepo, out string msg)
    {
        msg = "";
        if (unRepo.ObtenerPersona(unEvento.ResponsableId) == null)
        {
            msg += "No existe la persona ingresada.\n";
        }
        return msg == "";
    }
}