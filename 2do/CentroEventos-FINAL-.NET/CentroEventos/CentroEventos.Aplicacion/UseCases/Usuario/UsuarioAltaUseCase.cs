using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators.Usuario;

namespace CentroEventos.Aplicacion.UseCases.Usuario;

public class UsuarioAltaUseCase(IRepositorioUsuario repoU)
{
    public void Ejecutar(Entities.Usuario u, UsuarioAltaCampos validador)
    {
        string msg;
        if (!validador.ValidarUsuario(u, out msg))
            throw new ValidacionException(msg);
        repoU.AltaUsuario(u);
    }
}