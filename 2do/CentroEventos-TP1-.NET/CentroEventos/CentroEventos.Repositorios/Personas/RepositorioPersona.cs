using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Repositorios.Personas;

public class RepositorioPersona : IRepositorioPersona
{
    private readonly string _nombreArch = "../../../../CentroEventos.Repositorios/Personas/RepositorioPersona.txt";
    public void AltaPersona(Persona persona)
    {
        int id = RepositorioIdPersona.ObtenerId();     
        persona.Id = id;
        using StreamWriter sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine($"{persona.Id} | {persona.Dni} | {persona.Nombre} | {persona.Apellido} | {persona.Telefono} | {persona.Email}");
    }
    public void BajaPersona(int id)
    {
        List<Persona> personas = ListarPersonas();
        Persona? p = personas.Find(persona => persona.Id == id);
        if (p != null)
        {
            personas.Remove(p);
            SobreEscribirPersonas(personas);
        }
        else throw new EntidadNotFoundException("Persona no existente");
    }

    private void SobreEscribirPersonas(List<Persona> lista)
    {
        using StreamWriter sw = new StreamWriter(_nombreArch, false);  
        foreach (Persona p in lista)
        {
            sw.WriteLine($"{p.Id} | {p.Dni} | {p.Nombre} | {p.Apellido} | {p.Telefono} | {p.Email}");
        }
    }
    public void ModificarPersona(Persona persona)
    {

        List<Persona> listaPersona = ListarPersonas();

        Persona? personaBuscada = listaPersona.Find(p => p.Id == persona.Id);

        if (personaBuscada != null)
        {
            personaBuscada.Dni = persona.Dni;
            personaBuscada.Nombre = persona.Nombre;
            personaBuscada.Apellido = persona.Apellido;
            personaBuscada.Telefono = persona.Telefono;
            personaBuscada.Email = persona.Email;
            
            SobreEscribirPersonas(listaPersona);  
        }
        else
        {
            throw new EntidadNotFoundException("La persona no esta en la lista");

        }
    }
    public Persona? ObtenerPersona(int id)
    {   
        var lista = ListarPersonas();
        var p = lista.Find(persona => id == persona.Id);
        return p;
    }
    public int ObtenerIdPorIndice(int index)
    {
        Persona p = ListarPersonas()[index];
        if (p == null) throw new EntidadNotFoundException("Selección de persona inválida.");
        return p.Id;
    }
    public  List<Persona> ListarPersonas()
    {

        List<Persona> resultado = new List<Persona>();  
        using StreamReader sr = new StreamReader(_nombreArch);

        while (!sr.EndOfStream) 
        {
            var persona = new Persona();
            var st = sr.ReadLine() ?? "";
            var split = st.Split(" | ");
            persona.Id = int.Parse(split[0]);
            persona.Dni = split[1];
            persona.Nombre = split[2];
            persona.Apellido = split[3];
            persona.Telefono = long.Parse(split[4]);
            persona.Email = split[5];
            resultado.Add(persona);
        }
        return resultado;
    }
    public  bool BuscarPorDni(string? dni)
    {
        List<Persona> l = ListarPersonas();

        Persona? p = l.Find(persona => persona.Dni == dni);

        if (p != null)
        {
            if (p.Dni == dni) return true;
        }
        return false;
    }

    public  bool BuscarPorEmail(string? email)
    {
        List<Persona> l = ListarPersonas();

        Persona? p = l.Find(persona => persona.Email == email);

        if (p != null)
        {
            if (p.Email == email) return true;
        }
        return false;
    }
}














