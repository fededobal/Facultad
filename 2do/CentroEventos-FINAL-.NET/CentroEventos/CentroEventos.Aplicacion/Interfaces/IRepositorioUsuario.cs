using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioUsuario
{
    void AltaUsuario(Usuario u);
    void BajaUsuario(int id);
    void ModificarUsuario(Usuario u);
    List<Usuario> ListarUsuarios();
    Usuario ObtenerUsuarioPorId(int id);
    bool EsAdministrador(Usuario? u);
}