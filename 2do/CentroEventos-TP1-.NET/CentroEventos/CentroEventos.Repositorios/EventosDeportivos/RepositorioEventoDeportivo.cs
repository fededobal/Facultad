using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Repositorios.EventosDeportivos;

public class RepositorioEventoDeportivo: IRepositorioEventoDeportivo
{
    readonly string _nomArch= "../../../../CentroEventos.Repositorios/EventosDeportivos/EventosDeportivos.txt";
    public void EventoAlta(EventoDeportivo actividad)
    {
        using StreamWriter sw= new StreamWriter (_nomArch,true);
        actividad.Id = RepositorioEventoDeportivoId.CalcularId();
        sw.WriteLine(actividad.Id);
        sw.WriteLine(actividad.Nombre);
        sw.WriteLine(actividad.Descripcion);
        sw.WriteLine(actividad.FechaHoraInicio);
        sw.WriteLine(actividad.DuracionHoras);
        sw.WriteLine(actividad.CupoMaximo);
        sw.WriteLine(actividad.ResponsableId);
    }

    public void EventoBaja(int id)
    {
        var listaEventos= ListarEventos();
        var evento = listaEventos.Find(eventoDeportivo=>eventoDeportivo.Id==id); 
        if (evento!=null)
        {
            listaEventos.Remove(evento);
            SobreEscribirEventos(listaEventos);
        }
        else
            throw new EntidadNotFoundException("Evento deportivo no existente.");
      
    }

    public int ObtenerIdPorIndice(int index)
    {
        EventoDeportivo e = ListarEventos()[index];
        if (e == null) throw new EntidadNotFoundException("Selección de evento deportivo inválido.");
        return e.Id;
    }

    public EventoDeportivo ObtenerEvento(int id) 
    {
        var listaEventos=ListarEventos(); 
        var evento =listaEventos.Find(eventoDeportivo=>eventoDeportivo.Id==id); 
                                                                                
        return evento ?? throw new EntidadNotFoundException("Evento deportivo no existente."); 
    }

    private void SobreEscribirEventos(List<EventoDeportivo> listaEventos)
    {
        using StreamWriter sw= new StreamWriter(_nomArch,false); 
        foreach (EventoDeportivo e in listaEventos)
        {
            sw.WriteLine(e.Id);
            sw.WriteLine(e.Nombre);
            sw.WriteLine(e.Descripcion);
            sw.WriteLine(e.FechaHoraInicio);
            sw.WriteLine(e.DuracionHoras);
            sw.WriteLine(e.CupoMaximo);
            sw.WriteLine(e.ResponsableId);
        }
    }

    public List<EventoDeportivo> ListarEventos()
    {
        using StreamReader sr= new StreamReader(_nomArch);
        List<EventoDeportivo> listaEventos= new List<EventoDeportivo>(); 
        while (!sr.EndOfStream) 
        {
            var evento = new EventoDeportivo(); 
            evento.Id=int.Parse(sr.ReadLine()?? "");
            evento.Nombre=sr.ReadLine()?? "";
            evento.Descripcion=sr.ReadLine() ?? "";
            evento.FechaHoraInicio=DateTime.Parse(sr.ReadLine()?? "");
            evento.DuracionHoras=double.Parse(sr.ReadLine()?? "");
            evento.CupoMaximo=int.Parse(sr.ReadLine()?? "");
            evento.ResponsableId=int.Parse(sr.ReadLine()?? "");
            listaEventos.Add(evento); 
        }
        return listaEventos; 
    }

    public void EventoModificacion(EventoDeportivo actMod)
    {
        List <EventoDeportivo> listaAct = ListarEventos(); 
        foreach (EventoDeportivo act in listaAct)
        { 
            if (act.Id == actMod.Id)
            { 
                act.Nombre = actMod.Nombre;
                act.Descripcion = actMod.Descripcion;
                act.FechaHoraInicio = actMod.FechaHoraInicio;
                act.DuracionHoras = actMod.DuracionHoras;
                act.CupoMaximo = actMod.CupoMaximo;
                act.ResponsableId = actMod.ResponsableId;
                break;
            }
        }
        SobreEscribirEventos(listaAct);
    }


    public List<EventoDeportivo> ListarEventosFuturos()
    {
        List<EventoDeportivo> listaEventos = ListarEventos();
        List<EventoDeportivo> listaEFuturos = new();
        foreach (EventoDeportivo e in listaEventos) {
            if (e.FechaHoraInicio > DateTime.Now) { 
                listaEFuturos.Add(e);
            }
        }
        return listaEFuturos;
    }
}



