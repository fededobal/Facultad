using CentroEventos.Aplicacion.Entities;
using Microsoft.EntityFrameworkCore;

namespace CentroEventos.Repositorios.DB;

public class CentroEventosSqlite : DbContext
{
    public static void Inicializar()
    {
        using var context = new CentroEventosContext();
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Se creó base de datos");
        }
        var connection = context.Database.GetDbConnection();
        connection.Open();
        using (var command = connection.CreateCommand())
        {
            command.CommandText = "PRAGMA journal_mode=DELETE;";
            command.ExecuteNonQuery();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>().ToTable("Personas");
        modelBuilder.Entity<EventoDeportivo>().ToTable("Eventos_Deportivos");  
        modelBuilder.Entity<Reserva>().ToTable("Reservas");
        modelBuilder.Entity<Usuario>().ToTable("Usuarios");  
    }
}