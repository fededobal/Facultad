using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios.DB;


namespace CentroEventos.Repositorios;

public class RepositorioReserva : IRepositorioReserva
{


    public void AltaReserva(Reserva reserva)
    {
        using var context = new CentroEventosContext();
        context.Add(reserva);
        context.SaveChanges();
    }

    public void BajaReserva(int idBaja)
    {
        var context = new CentroEventosContext();
        var reserva = context.Reservas.SingleOrDefault(r => r.Id == idBaja);
        if (reserva == null) throw new EntidadNotFoundException("Reserva inexistente");
        context.Remove(reserva);
        context.SaveChanges();
    }

    public Reserva ObtenerReserva(int id)
    {
        var context = new CentroEventosContext();
        var reserva = context.Reservas.SingleOrDefault(r => r.Id == id);
        if (reserva == null) throw new EntidadNotFoundException("No existe reserva con esa ID");
        return reserva;
    }


    public List<Reserva> ListarReservas()
    {
        List<Reserva> list = new List<Reserva>();
        using var context = new CentroEventosContext();
        foreach (Reserva r in context.Reservas.ToList())
        {
            list.Add(Copiar(r));
        }
        return list;

    }
    public void ModificarReserva(Reserva unaRes)
    {
        var context = new CentroEventosContext();
        var reserva = context.Reservas.SingleOrDefault(r => r.Id == unaRes.Id);
        if (reserva == null) throw new EntidadNotFoundException("No se encontro la reserva");
        reserva.Id = unaRes.Id;
        reserva.PersonaId = unaRes.PersonaId;
        reserva.EventoDeportivoId = unaRes.EventoDeportivoId;
        reserva.FechaAltaReserva = unaRes.FechaAltaReserva;
        reserva.EstadoAsistencia = unaRes.EstadoAsistencia;
        context.SaveChanges();
    }


    private Reserva Copiar(Reserva reserva)
    {
        Reserva copia = new Reserva();
        copia.Id = reserva.Id;
        copia.PersonaId = reserva.PersonaId;
        copia.EventoDeportivoId = reserva.EventoDeportivoId;
        copia.FechaAltaReserva = reserva.FechaAltaReserva;
        copia.EstadoAsistencia = reserva.EstadoAsistencia;
        return reserva;
    }
     public int ContarReserva(int eventoId) {
        var listaR = ListarReservas();
        int cont= 0;
        foreach (Reserva r in listaR) {
            if (r.EventoDeportivoId == eventoId) cont++;
        }
        return cont;
    }
}