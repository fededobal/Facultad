using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.Validators.Evento.Alta;

public class EventoAltaValidadorDuracion
{
    public bool ValidarEventoAltaDuracion(EventoDeportivo actividad, out string msg)
    {
        msg = "";
        bool aux = true;
        if (actividad.DuracionHoras == 0)
        {
            msg += "La actividad debe tener una duracion mayor a 0.\n";
            aux = false;
        }
        return aux;
    }
}