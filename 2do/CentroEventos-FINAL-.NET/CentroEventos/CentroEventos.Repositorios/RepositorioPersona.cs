using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios.DB;

namespace CentroEventos.Repositorios;

public class RepositorioPersona : IRepositorioPersona
{
    public void AltaPersona(Persona? persona)
    {
        using var context = new CentroEventosContext();
        context.Add(persona);
        context.SaveChanges();
    }

    public void BajaPersona(int id)
    {
        using var context = new CentroEventosContext();
        var persona = context.Personas.SingleOrDefault(per => per.Id.Equals(id));
        if (persona == null) throw new EntidadNotFoundException("No se encontro la persona");
        context.Remove(persona);
        context.SaveChanges();
    }

    public bool BuscarPorDni(string? dni)
    {
        using var context = new CentroEventosContext();
        var persona = context.Personas.SingleOrDefault(per => per.Dni != null && per.Dni.Equals(dni));
        if (persona == null)
        {
            return false;
        }
        return true;
    }

    public bool BuscarPorEmail(string? email)
    {
        using var context = new CentroEventosContext();
        var persona = context.Personas.SingleOrDefault(per => per.Email != null && per.Email.Equals(email));
        if (persona == null)
        {
            return false;
        }
        return true;
    }

    public List<Persona> ListarPersonas()
    {
        List<Persona> listaP = new List<Persona>();

        using var context = new CentroEventosContext();
        {
            foreach (Persona per in context.Personas.ToList())
            {
                listaP.Add(Clonar(per));
            }

        }
        return listaP;
    }

    public void ModificarPersona(Persona? p)
    {
        using var context = new CentroEventosContext();
        var persona = context.Personas.SingleOrDefault(per => per.Id.Equals(p.Id));
        if (persona == null) throw new EntidadNotFoundException("No se encontro la persona");
        persona.Apellido = p.Apellido;
        persona.Dni = p.Dni;
        persona.Email = p.Email;
        persona.Nombre = p.Nombre;
        persona.Telefono = p.Telefono;
        context.SaveChanges();
    }

    public Persona ObtenerPersona(int id)
    {
        using var context = new CentroEventosContext();
        var persona = context.Personas.SingleOrDefault(per => per.Id.Equals(id));
        if (persona == null) throw new EntidadNotFoundException("No se encontro la persona");
        return persona;

    }
    private Persona Clonar(Persona persona)
    {
        var personaCopia = new Persona();
        personaCopia.Id = persona.Id;
        personaCopia.Nombre = persona.Nombre;
        personaCopia.Apellido = persona.Apellido;
        personaCopia.Email = persona.Email;
        personaCopia.Dni = persona.Dni;
        personaCopia.Telefono = persona.Telefono;
        return personaCopia;
    }
    
}
