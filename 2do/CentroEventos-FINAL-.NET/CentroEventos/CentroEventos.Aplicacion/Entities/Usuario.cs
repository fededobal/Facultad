using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.Entities;

public class Usuario
{
    public int Id { get; set; }
    public String Nombre { get; set; } = "";
    public String Apellido { get; set; } = "";
    public String Email { get; set; } = "";
    public String Contraseña { get; set; } = "";
    public List<Permiso> Permisos { get; set; } = new();
  
    public Usuario () {}
    
    
}