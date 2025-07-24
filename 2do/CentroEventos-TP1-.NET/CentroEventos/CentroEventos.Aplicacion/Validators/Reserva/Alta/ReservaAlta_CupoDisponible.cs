using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validators.Reserva.Alta;

public class ReservaAltaCupoDisponible
{
    public bool Validar(Entities.Reserva reserva, IRepositorioReserva repoReserva, IRepositorioEventoDeportivo repoEvento, out string msg)
    {
        msg = "";
        
        if (repoReserva.ContarReserva(reserva.EventoDeportivoId) == repoEvento.ObtenerEvento(reserva.EventoDeportivoId)?.CupoMaximo)
            msg += "No hay cupo disponible para el evento que se desea reservar.\n";

        return msg == "";
    }
}