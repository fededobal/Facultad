using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioReserva
{
    void AltaReserva(Reserva reserva);
    void BajaReserva(int id);
    void ModificarReserva(Reserva reserva);
    Reserva ObtenerReserva(int id);
    Reserva ObtenerReserva(int id, out int i);
    int ObtenerIdPorIndice(int index);
    List<Reserva> ListarReservas();
    int ContarReserva(int eventoId);
}