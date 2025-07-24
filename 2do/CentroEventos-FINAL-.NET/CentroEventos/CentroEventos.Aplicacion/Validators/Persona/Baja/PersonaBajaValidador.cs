using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validators.Persona.Baja;
public class PersonaBajaValidador
{
    public bool Validar(int id, IRepositorioEventoDeportivo repoE, IRepositorioReserva repoR, out string msg)
    {
        msg = "";
        foreach (EventoDeportivo e in repoE.ListarEventos())
        {
            if (e.ResponsableId == id)
            {
                msg += "La persona es responsable de un evento\n";
                break;
            }
        }
        foreach (Entities.Reserva r in repoR.ListarReservas())
        {
            if (r.PersonaId == id)
            {
                msg += "La persona es responsable de una reserva\n";
                break;
            }
        }
        return msg ==""; 
    }
}
