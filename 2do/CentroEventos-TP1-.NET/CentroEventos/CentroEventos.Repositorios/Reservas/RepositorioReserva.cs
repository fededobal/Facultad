using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Exceptions;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Repositorios.Reservas;

public class RepositorioReserva : IRepositorioReserva
{
    readonly string _nombreArch = "../../../../CentroEventos.Repositorios/Reservas/Reservas.txt";

    public void AltaReserva(Reserva reserva)
    {
        var idAct = RepositorioIdReserva.NextIdActual();
        reserva.Id = idAct;
        using (var sw = new StreamWriter(_nombreArch, true))
        {
            sw.WriteLine(
                $"{reserva.Id} | {reserva.PersonaId} | {reserva.EventoDeportivoId} | {reserva.FechaAltaReserva:yyyy-MM-dd HH:mm:ss} | {reserva.EstadoAsistencia}");
        }
    }

    public void BajaReserva(int idBaja)
    {
        var reservas = ListarReservas();
        var rBaja = reservas.Find(reserva => reserva.Id == idBaja);
        if (rBaja != null)
        {
            reservas.Remove(rBaja);
            SobreEscribirReservas(reservas);
        } else throw new EntidadNotFoundException("Reserva inexistente.");
    }

    private void SobreEscribirReservas(List<Reserva> lista)
    {
        using var sw = new StreamWriter(_nombreArch, false); 
        foreach (var r in lista)
            sw.WriteLine(
                $"{r.Id} | {r.PersonaId} | {r.EventoDeportivoId} | {r.FechaAltaReserva:yyyy-MM-dd HH:mm:ss} | {r.EstadoAsistencia}");
    }

    public Reserva ObtenerReserva(int id)
    {
        foreach (var r in ListarReservas())
            if (r.Id == id)
                return r;

        throw new EntidadNotFoundException("La reserva buscada no existe.");
    }

    public Reserva ObtenerReserva(int id, out int index)
    {
        index = -1;
        var iAct = index;
        foreach (var r in ListarReservas())
        {
            iAct++;
            if (r.Id == id)
            {
                index = iAct;
                return r;
            }
        }
        throw new EntidadNotFoundException("La reserva buscada no existe.");
    }
    public int ObtenerIdPorIndice(int index)
    {
        Reserva r = ListarReservas()[index];
        if (r == null) throw new EntidadNotFoundException("Selección de reserva inválida.");
        return r.Id;
    }
    public List<Reserva> ListarReservas()
    {
        var listaR = new List<Reserva>();
        if (!File.Exists(_nombreArch))
            return listaR;

        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var reservaNew = new Reserva();
            var st = sr.ReadLine() ?? "";
            var lSplitted = st.Split(" | ");
            reservaNew.Id = int.Parse(lSplitted[0]);
            reservaNew.PersonaId = int.Parse(lSplitted[1]);
            reservaNew.EventoDeportivoId = int.Parse(lSplitted[2]);
            reservaNew.FechaAltaReserva = DateTime.Parse(lSplitted[3]);
            reservaNew.EstadoAsistencia = (Asistencia) Enum.Parse(typeof(Asistencia), lSplitted[4]);
            listaR.Add(reservaNew);
        }
        return listaR;
    }
    public void ModificarReserva(Reserva unaRes)
    {
        try
        {
            ObtenerReserva(unaRes.Id, out var i);
            var lista = ListarReservas();
            lista[i] = unaRes;
            SobreEscribirReservas(lista);
        }
        catch (EntidadNotFoundException e)
        {
            throw new EntidadNotFoundException($"Error al intentar modificar reserva: {e.Message}");
        }
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