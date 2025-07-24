using CentroEventos.Aplicacion.Entities;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IServicioSesion
{
    void IniciarSesion(Usuario? u);
    void CerrarSesion();
    bool HaySesion();
    Usuario? GetSesion();
}