using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Services;

public class ServicioAutorizacion : IServicioAutorizacion
{
    public bool PoseeElPermiso(Usuario u, Permiso permisoRequerido)
    {
        foreach (Permiso p in u.Permisos)
            if (p.Equals(permisoRequerido))
                return true;
        return false;
    }
}