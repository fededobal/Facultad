using System.Security.Cryptography;
using System.Text;
using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.UseCases.Usuario;

namespace CentroEventos.Aplicacion.Services.ServicioSesion;

public class InicioSesion(ObtenerUsuarioPorEmail useCase, IServicioSesion sesion)
{
    public void Ejecutar(Usuario u)
    {
        Usuario? userBuscado = useCase.Ejecutar(u.Email);
        if (userBuscado != null && HashContraseña(u.Contraseña).Equals(userBuscado.Contraseña))
        {
            sesion.IniciarSesion(userBuscado);
        }
        else
            throw new ValidacionException("Email y/o contraseña incorrectos.");
    }
    private String HashContraseña(string contraAct)
    {
        using (SHA256 sha256 = SHA256.Create())   
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraAct));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
                builder.Append(bytes[i].ToString("x2"));
            
            return builder.ToString();
        }
    }
}