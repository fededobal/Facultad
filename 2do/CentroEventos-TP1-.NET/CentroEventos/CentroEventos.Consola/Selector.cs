using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.UseCases.Evento;
using CentroEventos.Aplicacion.UseCases.Persona;
using CentroEventos.Aplicacion.UseCases.Reserva;

namespace CentroEventos.Consola;
public static class Selector
{
    public static void Generico(out int op, params string[] opciones)
    {
        for (int i = 0; i < opciones.Length; i++)
            Console.WriteLine($"{i+1}) {opciones[i]}");
        op = int.Parse(Console.ReadLine() ?? "-1");
    }
    public static void OpcionesMain(out int op)
    {
        Console.WriteLine("----- MENÚ PRINCIPAL -----");
        Console.WriteLine("Seleccione con cuál entidad trabajar (1-3) o salir del programa (-1):");
        Console.WriteLine("1) Personas\n2) Eventos deportivos\n3) Reservas\n-1) SALIR ");
        op = int.Parse(Console.ReadLine() ?? "-1");
        do {
            switch (op)
            {
                case 1: 
                    Console.WriteLine("- GESTIÓN DE PERSONAS -");
                    break;
                case 2:
                    Console.WriteLine("- GESTIÓN DE EVENTOS DEPORTIVOS -");
                    break; 
                case 3:
                    Console.WriteLine("- GESTIÓN DE RESERVAS -");
                    break;
                case -1: Console.WriteLine("SALIENDO DEL MENÚ...");
                    Thread.Sleep(2000);
                    break;
                default: 
                    Console.WriteLine("Opción incorrecta.");
                    op = int.Parse(Console.ReadLine() ?? "-1");
                    break;
            }
        } while (op < 1 && op > 3);
    }

    public static void OpcionesEntidad(int opMain, out int opEnt)
    {
        var entidad = opMain switch { 1 => "PERSONA", 2 => "EVENTO DEPORTIVO", 3 => "RESERVA", _ => "" };

        Console.WriteLine($"----- MENÚ DE {entidad} -----");
        Console.WriteLine("Seleccione qué hacer:");
        Console.WriteLine("1) Alta\n2) Baja\n3) Modificar\n4) Listar");
        opEnt = int.Parse(Console.ReadLine() ?? "-1");
        do
        {
            switch (opEnt)
            {
                case 1:
                    Console.WriteLine($"- ALTA DE {entidad} -");
                    break;
                case 2:
                    Console.WriteLine($"- BAJA DE {entidad} -");
                    break;
                case 3:
                    Console.WriteLine($"- MODIFICACIÓN DE {entidad} -");
                    break;
                case 4:
                    Console.WriteLine($"- LISTADO DE {entidad} -");
                    break;
                default:
                    Console.WriteLine("Opción incorrecta.");
                    opEnt = int.Parse(Console.ReadLine() ?? "-1");
                    break;
            }
        } while (opEnt < 1 && opEnt > 4);
    }
    public static void Personas(IRepositorioPersona repositorioPersona, ListarPersonasUseCase listarPersonas, out int id)
    {
        var lista = listarPersonas.Ejecutar();
        if (lista.Count == 0) throw new Exception("No existen personas en el sistema.");
        for(var i = 1; i <= lista.Count; i++) {
            Console.WriteLine($"{i}) {lista[i-1]}");
        }
        var index = int.Parse(Console.ReadLine() ?? "-1") - 1;
        id = repositorioPersona.ObtenerIdPorIndice(index);
    }
    public static void Reservas(IRepositorioReserva repositorioReserva, ReservaListarUseCase listarReservas, out int id)
    {
        var lista = listarReservas.Ejecutar();
        if (lista.Count == 0) throw new Exception("No existen reservas en el sistema.");
        for(var i = 1; i <= lista.Count; i++) {
            Console.WriteLine($"{i}) {lista[i-1]}");
        }
        var index = int.Parse(Console.ReadLine() ?? "-1") - 1;
        id = repositorioReserva.ObtenerIdPorIndice(index);
    }
    public static void EventosDeportivos(IRepositorioEventoDeportivo repositorioEventoDeportivo, EventoListarUseCase listarEventos, out int id)
    {
        var lista = listarEventos.Ejecutar();
        if (lista.Count == 0) throw new Exception("No existen eventos deportivos en el sistema.");
        for(var i = 1; i <= lista.Count; i++) {
            Console.WriteLine($"{i}) {lista[i-1]}");
        }
        var index = int.Parse(Console.ReadLine() ?? "-1") - 1;
        id = repositorioEventoDeportivo.ObtenerIdPorIndice(index);
    }
}