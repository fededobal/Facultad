using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.UseCases.Reserva;

public class ReservaListarUseCase(IRepositorioReserva repoR)
{
    public List<Entities.Reserva> Ejecutar()
    {
        return repoR.ListarReservas();
    }
}