namespace CentroEventos.Aplicacion.Entities;
public class Persona {
    public int Id { get; set;}
    public string? Dni {get;set;}
    public string? Nombre {get;set;}
    public string? Apellido {get;set;}
    public long Telefono {get;set;}
    public string? Email {get;set;}

    public Persona (){}
    
    public Persona (string unDni, string? unNom, string? unAp,long unTel, string? unEm) 
    {
        Dni = unDni;
        Nombre = unNom;
        Apellido = unAp;
        Telefono = unTel;
        Email = unEm;
    }

    public override string ToString()
    {
        return $"DNI: {Dni} | Nombre: {Nombre} | Apellido: {Apellido} | Telefono: {Telefono} | Correo electrónico: {Email}";
    }
}