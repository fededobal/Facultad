using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.UseCases.Usuario;

public class ObtenerUsuarioPorEmail(IRepositorioUsuario repoU)
{
    public Entities.Usuario? Ejecutar(string email)
    {
        return repoU.ListarUsuarios().SingleOrDefault(u => u.Email.ToLower().Equals(email.ToLower()));
    }
}