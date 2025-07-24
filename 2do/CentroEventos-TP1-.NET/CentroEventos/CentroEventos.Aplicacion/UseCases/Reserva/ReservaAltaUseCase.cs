using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators.Reserva.Alta;

namespace CentroEventos.Aplicacion.UseCases.Reserva;
public class ReservaAltaUseCase(IServicioAutorizacion auth, 
    IRepositorioReserva repoR, IRepositorioEventoDeportivo repoE, 
    IRepositorioPersona repoP, ReservaValidadorAltaExistencias vExistencias, 
    ReservaValidadorAltaDuplicado vDuplicados, ReservaAltaCupoDisponible vCupo)
{
    public void Ejecutar(Entities.Reserva reserva, int idUser)
    {
        string msg;
        
        if (!auth.PoseeElPermiso(idUser, Permiso.ReservaAlta)) 
            throw new FalloAutorizacionException("No posee los permisos para hacer alta de una reserva.");
        if (!vExistencias.Validar(reserva, repoP, repoE, out msg)) throw new EntidadNotFoundException(msg);
        if(!vDuplicados.Validar(reserva, repoR, out msg)) throw new DuplicadoException(msg);
        if (!vCupo.Validar(reserva, repoR, repoE, out msg)) throw new CupoExcedidoException(msg);
        
        repoR.AltaReserva(reserva);
    }
}