using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validators.Usuario;

public class UsuarioBajaQueNoSeaAdmin
{
    public bool Validar(int idUsuario, IRepositorioUsuario repo, out string msg)
    {
        msg = "";
        if (repo.ListarUsuarios().Min(u => (int?)u.Id).Equals(idUsuario)) // si es el admin (primer usuario de la tabla)
            msg += "No se puede eliminar este usuario.";
        return msg == "";
    }
}