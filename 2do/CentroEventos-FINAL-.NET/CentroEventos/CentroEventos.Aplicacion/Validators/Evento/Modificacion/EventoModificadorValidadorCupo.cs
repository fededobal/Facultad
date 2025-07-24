using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validators.Evento.Modificacion;

public class EventoModificadorValidadorCupo
{
    public bool ValidarEventoModificacionCupoMax (EventoDeportivo unEvento, IRepositorioReserva unRepo, out string msg)
    {
        msg = "";
        if (unRepo.ContarReserva(unEvento.Id) >= unEvento.CupoMaximo)
        {
            msg += "El cupo máximo no puede ser menor al anterior.\n";
        }
        return msg == "";
    }
}