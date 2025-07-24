

using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators.Persona.Alta;

namespace CentroEventos.Aplicacion.UseCases.Persona;

public class AltaPersonaUseCase(IServicioAutorizacion auth, IRepositorioPersona repo,PersonaValidador validadorPersona,EmailValidador validarEmail,DniValidador validarDni ) 

{  
    public void Ejecutar(Entities.Persona persona, int unId)
    {
        if (!auth.PoseeElPermiso(unId, Permiso.UsuarioAlta)) throw new FalloAutorizacionException("No posee el permiso para hacer alta de Persona.");
        string msg;
        if (!validadorPersona.ValidarPersona(persona, repo, out  msg))
            throw new ValidacionException(msg);
        if (!validarEmail.ValidarEmail(persona.Email, repo, out msg))
            throw new DuplicadoException(msg);
        if (!validarDni.Validar(persona.Dni, repo, out msg))
            throw new DuplicadoException(msg);

        repo.AltaPersona(persona);
    }
}

