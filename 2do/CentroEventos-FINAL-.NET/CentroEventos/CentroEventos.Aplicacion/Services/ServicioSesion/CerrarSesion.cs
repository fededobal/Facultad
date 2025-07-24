using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Services.ServicioSesion;


public class CerrarSesion(IServicioSesion sesion)
{
    public void Ejecutar(Usuario u)
    {
        sesion.IniciarSesion(u);
    }
}