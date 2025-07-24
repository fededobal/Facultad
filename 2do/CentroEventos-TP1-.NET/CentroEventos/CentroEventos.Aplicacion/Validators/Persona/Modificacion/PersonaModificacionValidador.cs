using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validators.Persona.Modificacion;

public class PersonaModificacionValidador 
{
    public bool Validar(Entities.Persona p, IRepositorioPersona repo, out string msg)
    {
        msg = " ";
        Entities.Persona? p1 = repo.ListarPersonas().Find(persona => persona.Id == p.Id);
        if (p1 == null) msg += "No se encontro la persona";
        return msg == " ";
    }
}
