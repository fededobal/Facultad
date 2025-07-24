using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.UseCases.Especiales;

public class ListarEventosConCupoDisponibleUseCase(IRepositorioEventoDeportivo repoEventos,IRepositorioReserva repoReservas)
{
    public List<EventoDeportivo> Ejecutar () {
        List<EventoDeportivo> cuposDisp = new List<EventoDeportivo>();
        foreach (EventoDeportivo e in repoEventos.ListarEventosFuturos()) { 
            if (repoReservas.ContarReserva(e.Id) < e.CupoMaximo) { 
                cuposDisp.Add(e); 
            }
        }
        return cuposDisp; 
    }
}