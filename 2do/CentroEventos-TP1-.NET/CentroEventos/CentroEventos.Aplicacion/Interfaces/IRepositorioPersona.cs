using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioPersona
{
    void AltaPersona(Persona persona);
    void BajaPersona(int id);
    void ModificarPersona(Persona p);
    int ObtenerIdPorIndice(int index);
    Persona? ObtenerPersona(int id);
    List<Persona> ListarPersonas();
    bool BuscarPorDni(string? dni);
    bool BuscarPorEmail(string? email);
}