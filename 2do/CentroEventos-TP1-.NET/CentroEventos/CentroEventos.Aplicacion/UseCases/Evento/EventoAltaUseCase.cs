
using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators.Evento.Alta;

namespace CentroEventos.Aplicacion.UseCases.Evento;

public class EventoAltaUseCase(IServicioAutorizacion auth,
 IRepositorioEventoDeportivo repoAct, IRepositorioPersona repoPer,
 EventoAltaValidadorNombre vNom, EventoAltaValidadorCupoMaximo vCupo,
 EventoAltaValidadorFecha vFec, EventoAltaValidadorResponsable vRes, 
 EventoAltaValidadorDesc vDesc, EventoAltaValidadorDuracion vDur)
{
    public void Ejecutar(EventoDeportivo evento, int userId) 
    {
        if (!auth.PoseeElPermiso(userId, Permiso.EventoAlta))
        {
            throw new FalloAutorizacionException("No posee los permisos para realizar operacion");
        }
        else
        {
            if (!vNom.ValidarEventoAltaNombre(evento, out string msg0)) 
            { 
                throw new ValidacionException(msg0);
            }
            if (!vDesc.ValidarEventoAltaDesc(evento, out string msg5)) 
            {
                throw new ValidacionException(msg5);
            }
            if (!vCupo.ValidarEventoAltaCupoMaximo(evento, out string msg2)) 
            { 
                throw new ValidacionException(msg2);
            }
            if (!vFec.ValidarEventoAltaFecha(evento, out string msg3)) 
            {
                throw new ValidacionException(msg3);
            }
            if (!vRes.ValidarEventoAltaResponsable(evento, repoPer, out string msg4)) 
            {
                throw new ValidacionException(msg4);
            }
            if (!vDur.ValidarEventoAltaDuracion(evento, out string msg1)) 
            { 
                throw new ValidacionException(msg1);
            }
            repoAct.EventoAlta(evento); 
        }
    }
}