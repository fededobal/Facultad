using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validators.Evento.Baja;
public class EventoBajaValidadorReservasAsociadas
{
    public bool Validar(int eventoId, IRepositorioReserva repoReservas, out string msg) 
    {
        msg="";
        if (repoReservas.ContarReserva(eventoId)>0)
        {
            msg+= "No puede darse de baja el evento debido a que tiene reservas asociadas.\n";
        }
        return msg=="";
    }
}