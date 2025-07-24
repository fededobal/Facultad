using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validators.Reserva.Baja;

public class ReservaValidadorBajaExistencia
{
    public bool Validar(int idABajar, IRepositorioReserva repoReserva, out string msg)
    {
        msg = "";
        
        repoReserva.ObtenerReserva(idABajar, out var i);
        if (i == -1)
            msg += $"La reserva con ID {idABajar} no existe.\n";

        return msg == "";
    }
}