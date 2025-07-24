using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validators.Evento.Alta;

public class EventoAltaValidadorResponsable
{
    public bool ValidarEventoAltaResponsable(EventoDeportivo actividad,IRepositorioPersona unRepo, out string msg)
    {
        msg = "";
        if (unRepo.ObtenerPersona(actividad.ResponsableId) == null) 
        {
            msg += "Responsable no existente.\n";
        }
        return msg == "";
    }
}