using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using System.Security.Cryptography;
using System.Text;
using CentroEventos.Repositorios.DB;

namespace CentroEventos.Repositorios;

public class RepositorioUsuario : IRepositorioUsuario
{
    public void AltaUsuario(Usuario u)
    {
        if (ValidarUsuario(u))
        {
            using var context = new CentroEventosContext();
            if (ListarUsuarios().Count == 0) // si soy el primer usuario, debo ser admin
                foreach (Permiso p in Enum.GetValues(typeof(Permiso)))
                    u.Permisos.Add(p);

            u.Contraseña = HashContraseña(u);
            context.Add(u);
            context.SaveChanges();
        }
    }

    private bool ValidarUsuario(Usuario u)
    {
        if (ObtenerUsuarioPorEmail(u.Email) != null)
            throw new ValidacionException("Email no disponible.");
        return true;
    }
    private String HashContraseña(Usuario usuario)
    {
        var contraAct = usuario.Contraseña;
        using (SHA256 mySha256 = SHA256.Create())   
        {
            byte[] bytes = mySha256.ComputeHash(Encoding.UTF8.GetBytes(contraAct));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
                builder.Append(bytes[i].ToString("x2"));
            
            return builder.ToString();
        }
    }

    public void BajaUsuario(int id)
    {
        using var context = new CentroEventosContext();
        var usuario = context.Usuarios.SingleOrDefault(u => u.Id.Equals(id)) ?? throw new EntidadNotFoundException("No se encuentra el usuario a eliminar.");
        context.Remove(usuario);
        context.SaveChanges();
    }

    public void ModificarUsuario(Usuario usuarioAModificar)
    {
        using var context = new CentroEventosContext();
        var usuario = context.Usuarios.SingleOrDefault(u => u.Id.Equals(usuarioAModificar.Id)) 
                      ?? throw new EntidadNotFoundException("No se encuentra el usuario a modificar.");
        
        if (!usuarioAModificar.Email.Equals(usuario.Email)) // si se modificó el Email
        {
            ValidarUsuario(usuarioAModificar);
            usuario.Email = usuarioAModificar.Email;
        }

        usuario.Nombre = usuarioAModificar.Nombre;
        usuario.Apellido = usuarioAModificar.Apellido;
        
        if (!string.IsNullOrWhiteSpace(usuarioAModificar.Contraseña))
        {
            usuario.Contraseña = HashContraseña(usuarioAModificar);
        }

        usuario.Permisos.Clear();
        context.SaveChanges();
        
        foreach (var permiso in usuarioAModificar.Permisos)
        {
            usuario.Permisos.Add(permiso);
        }
        
        context.SaveChanges();
    }

    public List<Usuario> ListarUsuarios()
    {
        using var context = new CentroEventosContext();
        return context.Usuarios.ToList().Select(u => Clonar(u)).ToList();
    }

    public Usuario? ObtenerUsuarioPorId(int id)
    {
        using var context = new CentroEventosContext();
        Usuario? usuario = context.Usuarios.SingleOrDefault(u => u.Id.Equals(id));
        context.SaveChanges();
        return usuario;
    }
    
    public Usuario? ObtenerUsuarioPorEmail(String email)
    {
        using var context = new CentroEventosContext();
        Usuario? usuario = context.Usuarios.SingleOrDefault(u => u.Email.Equals(email));
        context.SaveChanges();
        return usuario;
    }

    private Usuario Clonar(Usuario u)
    {
        return new Usuario
        {
            Id = u.Id,
            Nombre = u.Nombre,
            Apellido = u.Apellido,
            Email = u.Email,
            Contraseña = u.Contraseña,
            Permisos = u.Permisos
        };
    }

    public bool EsAdministrador(Usuario u)
    {
        return ListarUsuarios().Min(us => (int?)us.Id).Equals(u.Id);
    }
}