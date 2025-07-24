using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.UseCases.Usuario;

public class UsuarioModificarUseCase(IServicioAutorizacion auth, IRepositorioUsuario repoU)
{
    public void Ejecutar(Entities.Usuario usuarioAModificar, Entities.Usuario usuario)
    {
        if(!auth.PoseeElPermiso(usuario,Permiso.UsuarioModificacion))
            throw new FalloAutorizacionException("No posee el permiso para modificar usuarios.");
        if (string.IsNullOrWhiteSpace(usuarioAModificar.Email) || string.IsNullOrWhiteSpace(usuarioAModificar.Nombre) ||
            string.IsNullOrWhiteSpace(usuarioAModificar.Apellido))
            throw new ValidacionException("Los campos modificados no deben estar vacíos.");
        repoU.ModificarUsuario(usuarioAModificar);
    }
}