using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators.Reserva.Baja;

namespace CentroEventos.Aplicacion.UseCases.Reserva;

public class ReservaBajaUseCase(IServicioAutorizacion auth, IRepositorioReserva repoR, ReservaValidadorBajaExistencia validador)
{
    public void Ejecutar(int idReserva, int idUser)
    {
        if (!auth.PoseeElPermiso(idUser, Permiso.ReservaBaja)) throw new FalloAutorizacionException("No posee los permisos para hacer baja de una reserva.");
        if (!validador.Validar(idReserva, repoR, out string msg)) throw new EntidadNotFoundException(msg);
        
        repoR.BajaReserva(idReserva);
    }
}