using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.Validators.Evento.Alta;
public class EventoAltaValidadorNombre {
    public bool ValidarEventoAltaNombre(EventoDeportivo actividad, out string msg) {
        msg = "";
        bool aux = true;
        if (string.IsNullOrWhiteSpace(actividad.Nombre))
        {
            msg = "El nombre no puede estar vacío.\n";
            aux = false;
        }
        return aux;
    }
}