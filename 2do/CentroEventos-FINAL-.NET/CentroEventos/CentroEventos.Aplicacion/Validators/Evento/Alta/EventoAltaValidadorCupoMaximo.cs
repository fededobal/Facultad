using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.Validators.Evento.Alta;
public class EventoAltaValidadorCupoMaximo
{
    public bool ValidarEventoAltaCupoMaximo(EventoDeportivo actividad, out string msg)
    {
        msg = ""; 
        bool aux = true;
        if (actividad.CupoMaximo <= 0)
        {
            msg += "El Cupo maximo debe que ser mayor que 0.\n";
            aux = false;
        }
        return aux;
    }
}