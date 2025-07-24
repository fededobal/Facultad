using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators.Persona.Baja;

namespace CentroEventos.Aplicacion.UseCases.Persona;

public class BajaPersonaUseCase(IServicioAutorizacion auth, IRepositorioPersona repo,IRepositorioEventoDeportivo repoEventoDeportivo,IRepositorioReserva repoReserva,PersonaBajaValidador validador)
{
    public void Ejecutar(int personaId, int unId)
    {
        if (!auth.PoseeElPermiso(unId, Permiso.UsuarioBaja))
            throw new FalloAutorizacionException("No posee el permiso para dar de baja una Persona");
        if (!validador.Validar(personaId,repoEventoDeportivo,repoReserva,out string msg))
            throw new ValidacionException(msg);
        repo.BajaPersona(personaId);
    }
}   