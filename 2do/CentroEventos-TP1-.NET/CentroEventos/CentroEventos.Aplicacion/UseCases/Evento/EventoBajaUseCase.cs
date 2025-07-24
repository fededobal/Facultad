using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators.Evento.Baja;

namespace CentroEventos.Aplicacion.UseCases.Evento;

public class EventoBajaUseCase(IServicioAutorizacion auth,IRepositorioEventoDeportivo repoEventos,
                                IRepositorioReserva repoReservas, EventoBajaValidadorReservasAsociadas validadorReservasAsociadas)
{
    public void Ejecutar(int eventoId, int userId) //
    {
        string msg;
        if (!auth.PoseeElPermiso(userId, Permiso.EventoBaja)) 
            throw new FalloAutorizacionException("No posee los permisos para dar de baja un evento.");
        if (!validadorReservasAsociadas.Validar(eventoId,repoReservas,out msg)) throw new OperacionInvalidaException(msg);
        repoEventos.EventoBaja(eventoId); 
    }
}