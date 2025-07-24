using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.UseCases.Evento;

public class EventoListarUseCase(IRepositorioEventoDeportivo repo)
{
    public List<EventoDeportivo> Ejecutar()
    {
        return repo.ListarEventos();
    }
}