using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validators.Usuario;

namespace CentroEventos.Aplicacion.UseCases.Usuario;

public class UsuarioBajaUseCase(IServicioAutorizacion auth, IRepositorioUsuario repoU, UsuarioBajaQueNoSeaAdmin validador)
{
    public void Ejecutar(int idUsuario, Entities.Usuario u)
    {
        if(!auth.PoseeElPermiso(u, Permiso.UsuarioBaja))
            throw new FalloAutorizacionException("No posee el permiso para hacer baja de usuarios.");
        if(!validador.Validar(idUsuario,repoU,out string msg))
            throw new ValidacionException(msg);
        repoU.BajaUsuario(idUsuario);
    }
}