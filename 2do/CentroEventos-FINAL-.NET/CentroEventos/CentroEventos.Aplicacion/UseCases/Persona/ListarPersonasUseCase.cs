using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.UseCases.Persona;

public class ListarPersonasUseCase(IRepositorioPersona repo)
{
    public List<Entities.Persona> Ejecutar()
    {
        return repo.ListarPersonas(); 
    }
}