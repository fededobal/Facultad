using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validators.Persona.Alta;

public class PersonaValidador
{
    public bool ValidarPersona(Entities.Persona persona, IRepositorioPersona repo, out string msg)
    {
        msg = "";
        if (string.IsNullOrWhiteSpace(persona.Nombre))
            msg += "El nombre no debe estar vacio\n";
        if (string.IsNullOrWhiteSpace(persona.Apellido))
            msg += "El apellido no debe estar vacio\n";
        if (string.IsNullOrWhiteSpace(persona.Email))
            msg += "El email no debe estar vacio\n";
        if (string.IsNullOrWhiteSpace(persona.Dni))
            msg += "El dni no debe estar vacio";
        return msg == "";

    }



}   
