using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios.DB;


namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo: IRepositorioEventoDeportivo
{
    public void EventoAlta(EventoDeportivo evento)
    {
        using var context = new CentroEventosContext();
        context.Add(evento);
        context.SaveChanges();
    }

    public void EventoBaja(int id)
    {
        using var context = new CentroEventosContext();
        var eventoABorrar = context.EventosDeportivos.Where(e => e.Id == id).SingleOrDefault();
        if (eventoABorrar == null) throw new EntidadNotFoundException("No se encuentra el evento ingresado");
        context.Remove(eventoABorrar);
        context.SaveChanges();
    }

    public void EventoModificacion(EventoDeportivo evento)
    {
        using var context = new CentroEventosContext();
        var eventoAModificar = context.EventosDeportivos.Where(e => e.Id == evento.Id).SingleOrDefault();
        if (eventoAModificar == null) throw new EntidadNotFoundException("No se encuentra el evento a modificar");
        eventoAModificar.Nombre = evento.Nombre;
        eventoAModificar.Descripcion = evento.Descripcion;
        eventoAModificar.FechaHoraInicio = evento.FechaHoraInicio;
        eventoAModificar.DuracionHoras = evento.DuracionHoras;
        eventoAModificar.CupoMaximo = evento.CupoMaximo;
        eventoAModificar.ResponsableId = evento.ResponsableId;
        context.SaveChanges();
    }

    public EventoDeportivo ObtenerEvento(int id)
    {
        using var context = new CentroEventosContext();
        var ev = context.EventosDeportivos.Where(e => e.Id == id).SingleOrDefault();
        if (ev == null) throw new EntidadNotFoundException("No existe un evento con el id recibido");
        else
        {
            return Clonar(ev);    
        }
    }

    public List<EventoDeportivo> ListarEventos()
    {
        using var context = new CentroEventosContext();
        var lista = new List<EventoDeportivo>();
        foreach (var e in context.EventosDeportivos.ToList())
        {
            lista.Add(Clonar(e));
        }
        return lista;

    }

    public List<EventoDeportivo> ListarEventosFuturos()
    {
        using var context = new CentroEventosContext();
        var lista = new List<EventoDeportivo>();
        foreach (var e in context.EventosDeportivos.ToList())
        {
            if (e.FechaHoraInicio > DateTime.Now)
                lista.Add(Clonar(e));
        }
         return lista;
    }

    private EventoDeportivo Clonar(EventoDeportivo evento)
    {
        var e = new EventoDeportivo();
        e.Id = evento.Id;
        e.Nombre = evento.Nombre;
        e.Descripcion = evento.Descripcion;
        e.FechaHoraInicio = evento.FechaHoraInicio;
        e.CupoMaximo = evento.CupoMaximo;
        e.ResponsableId = evento.ResponsableId;
        return e;
    }
}
