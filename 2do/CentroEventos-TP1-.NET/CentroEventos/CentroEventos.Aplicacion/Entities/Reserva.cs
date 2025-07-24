using CentroEventos.Aplicacion.Enums;

namespace CentroEventos.Aplicacion.Entities;
public class Reserva
{
    public int Id { get; set; }
    public int PersonaId { get; set; }
    public int EventoDeportivoId { get; set; }
    public DateTime FechaAltaReserva { get; set; }
    public Asistencia EstadoAsistencia { get; set; }

    public Reserva () {}

    public Reserva(int personaId, int eventoDeportivoId, DateTime fechaAltaReserva, Asistencia estadoAsistencia)
    {
        PersonaId = personaId;
        EventoDeportivoId = eventoDeportivoId;
        FechaAltaReserva = fechaAltaReserva;
        EstadoAsistencia = estadoAsistencia;
    }

    public override string ToString()
    => $"Fecha de reserva: {FechaAltaReserva} | Estado de la asistencia: {EstadoAsistencia}";
}