using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators.Reserva.Modificar;

namespace CentroEventos.Aplicacion.UseCases.Reserva;

public class ReservaModificarUseCase(IServicioAutorizacion auth,IRepositorioReserva repoR, IRepositorioEventoDeportivo repoE, IRepositorioPersona repoP, ReservaValidadorModificarExistentes existentes)
{
    public void Ejecutar(Entities.Reserva reserva, int idUser)
    {
        if (!auth.PoseeElPermiso(idUser, Permiso.ReservaModificacion)) throw new FalloAutorizacionException("No posee los permisos para modificar una reserva.");
        if (!existentes.Validar(reserva, repoR, repoE, repoP, out string msg)) throw new EntidadNotFoundException(msg);
        
        repoR.ModificarReserva(reserva);
    }
}