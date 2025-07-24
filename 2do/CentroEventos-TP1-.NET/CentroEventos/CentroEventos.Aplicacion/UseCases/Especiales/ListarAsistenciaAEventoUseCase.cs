using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.UseCases.Especiales;
public class ListarAsistenciaAEventoUseCase (IRepositorioReserva unRepoR, IRepositorioPersona per) {
    public List<Entities.Persona> Ejecutar(EventoDeportivo unEvento) {
        var listaP = new List<Entities.Persona>();
        if (unEvento.FechaHoraInicio < DateTime.Now)
        {
            var listaPresentes = new List<Entities.Reserva>();
            foreach (Entities.Reserva r in unRepoR.ListarReservas())
            {
                if (r.EventoDeportivoId == unEvento.Id && r.EstadoAsistencia == Asistencia.Presente) 
                {           
                    listaPresentes.Add(r);
                }
            }
            foreach (Entities.Reserva r in listaPresentes) 
            {
                Entities.Persona? p = per.ObtenerPersona(r.PersonaId); 
                if (p != null)
                {
                    listaP.Add(p); 
                }
            }
        }
        return listaP; 
    }
}