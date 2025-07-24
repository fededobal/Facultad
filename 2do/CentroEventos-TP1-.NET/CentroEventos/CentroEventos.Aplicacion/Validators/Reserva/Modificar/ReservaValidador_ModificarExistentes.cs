using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validators.Reserva.Modificar;

public class ReservaValidadorModificarExistentes
{
    public bool Validar(Entities.Reserva reserva, IRepositorioReserva repoReserva, IRepositorioEventoDeportivo repoEvento, IRepositorioPersona repoPersona,out string msg)
    {
        msg = "";
        
        repoReserva.ObtenerReserva(reserva.Id, out var i);
        if (i == -1)
            msg += $"La reserva con ID {reserva.Id} no existe.\n";

        if(repoPersona.ObtenerPersona(reserva.PersonaId) == null || repoEvento.ObtenerEvento(reserva.EventoDeportivoId) == null)
            msg += "Persona y/o Evento Deportivo no existentes.\n";
        
        return msg == "";
    }
}