namespace CentroEventos.Aplicacion.Validators.Usuario;

public class UsuarioAltaCampos
{
    public bool ValidarUsuario(Entities.Usuario usuario, out string msg)
    {
        msg = "";
        if (string.IsNullOrWhiteSpace(usuario.Nombre))
            msg += "El nombre no debe estar vacío\n";
        if (string.IsNullOrWhiteSpace(usuario.Apellido))
            msg += "El apellido no debe estar vacío\n";
        if (string.IsNullOrWhiteSpace(usuario.Email))
            msg += "El email no debe estar vacío\n";
        if (string.IsNullOrWhiteSpace(usuario.Contraseña))
            msg += "La contraseña no debe estar vacía";
        return msg == "";
    }
}