namespace CentroEventos.Aplicacion.Entities;

public class EventoDeportivo
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaHoraInicio { get; set; }
    public double DuracionHoras { get; set; }
    public int CupoMaximo { get; set; }
    public int ResponsableId { get; set; }

    public EventoDeportivo(String? nombre, string? unaDesc, DateTime unaFecha, double unaDuracion, int cupoMaximo, int respoId)
    {
        Nombre = nombre;
        Descripcion = unaDesc;
        FechaHoraInicio = unaFecha;
        DuracionHoras = unaDuracion;
        CupoMaximo = cupoMaximo;
        ResponsableId = respoId;
    }
    public EventoDeportivo() {}

    public override string ToString()
    {
        return $"Nombre del evento: {Nombre} | Descripcion de evento: {Descripcion} | Fecha de inicio de actividad: {FechaHoraInicio} | Duracion del evento: {DuracionHoras} | Cupo maximo: {CupoMaximo}";
    }
}
