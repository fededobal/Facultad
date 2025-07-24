using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validators.Reserva.Alta;

public class ReservaValidadorAltaExistencias
{
    public bool Validar(Entities.Reserva reserva, IRepositorioPersona repoPersona, IRepositorioEventoDeportivo repoEvento, out string msg)
    {
        msg = "";
        
        if(repoPersona.ObtenerPersona(reserva.PersonaId) == null || repoEvento.ObtenerEvento(reserva.EventoDeportivoId) == null)
            msg += "Persona y/o Evento Deportivo no existente(s).\n";

        return msg == "";
    }
}