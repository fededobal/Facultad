namespace CentroEventos.Aplicacion.Services;

public class UsuarioActual
{
    public string? NombreUsuario { get; set; }
    public bool EstaAutenticado => !string.IsNullOrEmpty(NombreUsuario);
}