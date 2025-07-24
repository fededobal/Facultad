using CentroEventos.Aplicacion.Entities;
using Microsoft.EntityFrameworkCore;

namespace CentroEventos.Repositorios.DB;

public class CentroEventosContext : DbContext
{
    #nullable disable
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<EventoDeportivo> EventosDeportivos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    #nullable restore
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=CentroEventos.sqlite");
    }
}