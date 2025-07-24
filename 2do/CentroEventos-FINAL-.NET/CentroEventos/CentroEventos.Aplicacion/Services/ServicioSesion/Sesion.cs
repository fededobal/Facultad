using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;
namespace CentroEventos.Aplicacion.Services.ServicioSesion;

public class Sesion : IServicioSesion
{
    public Usuario? SesionActual { get; private set; }

    public void IniciarSesion(Usuario? u)
    {
        this.SesionActual = u;
    }

    public void CerrarSesion()
    {
        this.SesionActual = null;
    }

    public bool HaySesion() => SesionActual != null;

    public Usuario? GetSesion()
    {
        return SesionActual;
    }
}