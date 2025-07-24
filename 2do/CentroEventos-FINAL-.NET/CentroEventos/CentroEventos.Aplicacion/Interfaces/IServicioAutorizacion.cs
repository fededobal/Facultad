using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IServicioAutorizacion
{
    bool PoseeElPermiso(Usuario u, Permiso permiso);
}