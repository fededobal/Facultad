using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioEventoDeportivo
{
    void EventoAlta(EventoDeportivo actividad);
    void EventoBaja(int id);
    void EventoModificacion(EventoDeportivo actividad);
    EventoDeportivo ObtenerEvento(int id);
    List<EventoDeportivo> ListarEventosFuturos();
    List<EventoDeportivo> ListarEventos();
    
}