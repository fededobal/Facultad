using CentroEventos.Aplicacion.Entities;
using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Services;
using CentroEventos.Aplicacion.UseCases.Especiales;
using CentroEventos.Aplicacion.UseCases.Evento;
using CentroEventos.Aplicacion.UseCases.Persona;
using CentroEventos.Aplicacion.UseCases.Reserva;
using CentroEventos.Aplicacion.Validators.Evento.Alta;
using CentroEventos.Aplicacion.Validators.Evento.Baja;
using CentroEventos.Aplicacion.Validators.Evento.Modificacion;
using CentroEventos.Aplicacion.Validators.Persona.Alta;
using CentroEventos.Aplicacion.Validators.Persona.Baja;
using CentroEventos.Aplicacion.Validators.Persona.Modificacion;
using CentroEventos.Aplicacion.Validators.Reserva.Alta;
using CentroEventos.Aplicacion.Validators.Reserva.Baja;
using CentroEventos.Aplicacion.Validators.Reserva.Modificar;
using CentroEventos.Consola;
using CentroEventos.Repositorios.EventosDeportivos;
using CentroEventos.Repositorios.Personas;
using CentroEventos.Repositorios.Reservas;

// Servicio de autorización
var servicioAutorizacion = new ServicioAutorizacionProvisorio();

// Validadores de Reserva
var validadorReservaAlta1 = new ReservaValidadorAltaExistencias();
var validadorReservaAlta2 = new ReservaValidadorAltaDuplicado();
var validadorReservaAlta3 = new ReservaAltaCupoDisponible();
var validadorReservaBaja = new ReservaValidadorBajaExistencia();
var validadorReservaMod = new ReservaValidadorModificarExistentes();

// Validadores de EventoDeportivo
var validadorEventoAlta1 = new EventoAltaValidadorNombre();
var validadorEventoAlta2 = new EventoAltaValidadorCupoMaximo();
var validadorEventoAlta3 = new EventoAltaValidadorDesc();
var validadorEventoAlta4 = new EventoAltaValidadorDuracion();
var validadorEventoAlta5 = new EventoAltaValidadorFecha();
var validadorEventoAlta6 = new EventoAltaValidadorResponsable();
var validadorEventoBaja = new EventoBajaValidadorReservasAsociadas();
var validadorEventoMod1 = new EventoModificadorValidadorFecha();
var validadorEventoMod2 = new EventoModificadorValidadorCupo();
var validadorEventoMod3 = new EventoModificadorValidadorIdResponsable();

// Validadores de Persona
var validadorPersonaAlta1 = new PersonaValidador();
var validadorPersonaAlta2 = new EmailValidador();
var validadorPersonaAlta3 = new DniValidador();
var validadorPersonaBaja = new PersonaBajaValidador();
var validadorPersonaMod = new PersonaModificacionValidador();

// Repositorios para inyectar
IRepositorioPersona repositorioPersona = new RepositorioPersona();
IRepositorioReserva repositorioReserva = new RepositorioReserva();
IRepositorioEventoDeportivo repositorioEventoDeportivo = new RepositorioEventoDeportivo();

// Casos de uso de EventoDeportivo
var altaEventoDeportivo = new EventoAltaUseCase(servicioAutorizacion,repositorioEventoDeportivo,repositorioPersona,validadorEventoAlta1,validadorEventoAlta2,validadorEventoAlta5,validadorEventoAlta6,validadorEventoAlta3,validadorEventoAlta4);
var bajaEventoDeportivo = new EventoBajaUseCase(servicioAutorizacion,repositorioEventoDeportivo,repositorioReserva,validadorEventoBaja);
var modificarEventoDeportivo = new EventoModificacionUseCase(servicioAutorizacion,repositorioEventoDeportivo,repositorioReserva,repositorioPersona,validadorEventoMod1,validadorEventoMod2,validadorEventoMod3);
var listarEventosDeportivos = new EventoListarUseCase(repositorioEventoDeportivo);
var listarEventosCupoDisponible = new ListarEventosConCupoDisponibleUseCase(repositorioEventoDeportivo, repositorioReserva);
var listarAsistenciaEventos = new ListarAsistenciaAEventoUseCase(repositorioReserva, repositorioPersona);

// Casos de uso de Reserva
var altaReserva = new ReservaAltaUseCase(servicioAutorizacion,repositorioReserva,repositorioEventoDeportivo,repositorioPersona,validadorReservaAlta1,validadorReservaAlta2,validadorReservaAlta3);
var bajaReserva = new ReservaBajaUseCase(servicioAutorizacion,repositorioReserva,validadorReservaBaja);
var modificarReserva = new ReservaModificarUseCase(servicioAutorizacion,repositorioReserva,repositorioEventoDeportivo,repositorioPersona,validadorReservaMod);
var listarReservas = new ReservaListarUseCase(repositorioReserva);

//Casos de uso Persona
var altaPersona = new AltaPersonaUseCase(servicioAutorizacion, repositorioPersona, validadorPersonaAlta1, validadorPersonaAlta2, validadorPersonaAlta3);
var bajaPersona = new BajaPersonaUseCase(servicioAutorizacion, repositorioPersona, repositorioEventoDeportivo, repositorioReserva, validadorPersonaBaja);
var modificarPersona = new ModificarPersonaUseCase(servicioAutorizacion, repositorioPersona, validadorPersonaMod);
var listarPersonas = new ListarPersonasUseCase(repositorioPersona);

// Programa principal
try
{
    Selector.OpcionesMain(out var opMain);
    while (opMain != -1)
    {
        Selector.OpcionesEntidad(opMain, out var opEnt);
        switch (opMain, opEnt)
        {
            case (1, 1):
                //Alta de persona
                Console.WriteLine("Ingrese datos nuevos de la persona:");
                Console.Write("DNI: "); string dni = Console.ReadLine() ?? "0";
                Console.Write("Nombre: "); string nom = Console.ReadLine() ?? "";
                Console.Write("Apellido: "); string ap = Console.ReadLine() ?? "";
                Console.Write("Teléfono: "); long tel = long.Parse(Console.ReadLine() ?? "0");
                Console.Write("Correo electrónico: "); string email = Console.ReadLine() ?? "";
                var persona = new Persona(dni,nom,ap,tel,email);
                altaPersona.Ejecutar(persona, 1);
                break;
            case (1, 2):
                // Baja de persona
                Console.WriteLine("Seleccione una persona a eliminar");
                Selector.Personas(repositorioPersona, listarPersonas, out var idPersona);
                var personaBaja = repositorioPersona.ObtenerPersona(idPersona);
                if (personaBaja != null)
                    bajaPersona.Ejecutar(personaBaja.Id, 1);
                break;
            case (1, 3):
                // Modificación de persona
                Console.WriteLine("Seleccione una persona a modificar");
                Selector.Personas(repositorioPersona, listarPersonas, out idPersona);
                var personaModificada = repositorioPersona.ObtenerPersona(idPersona);
                if (personaModificada != null)
                {
                    Console.WriteLine("Ingrese nuevos datos:");
                    Console.Write($"Nombre (actual: '{personaModificada.Nombre}'): "); nom = Console.ReadLine() ?? "";
                    personaModificada.Nombre = nom;
                    Console.Write($"Apellido (actual: '{personaModificada.Apellido}'): "); ap = Console.ReadLine() ?? "";
                    personaModificada.Apellido = ap;
                    modificarPersona.Ejecutar(personaModificada, 1);
                }
                break;
            case (1, 4):
                // Listar personas
                var listaPersonas = listarPersonas.Ejecutar();
                foreach (var p in listaPersonas)
                    Console.WriteLine(p);
                break;
            case (2, 1):
                // Alta de evento deportivo
                Console.WriteLine("Seleccione la persona responsable del nuevo evento deportivo:");
                Selector.Personas(repositorioPersona, listarPersonas, out var idResponsable);
                Console.WriteLine("Ingrese datos del nuevo evento deportivo:");
                Console.Write("Nombre: "); nom = Console.ReadLine() ?? "";
                Console.Write("Descripción: "); string desc = Console.ReadLine() ?? "";
                Console.Write("Fecha (AAAA-MM-DD): "); DateTime fecha = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.AddDays(5).ToString());
                Console.Write("Duración en horas: "); int dur = int.Parse(Console.ReadLine() ?? "1");
                Console.Write("Cupo máximo: "); int cupoMax = int.Parse(Console.ReadLine() ?? "1");
                var evento = new EventoDeportivo(nom, desc, fecha, dur, cupoMax, idResponsable);
                altaEventoDeportivo.Ejecutar(evento, 1);
                break;
            case (2, 2):
                // Baja de evento deportivo
                Console.WriteLine("Seleccione un evento deportivo a eliminar");
                Selector.EventosDeportivos(repositorioEventoDeportivo, listarEventosDeportivos, out var idEvento);
                var eventoBaja = repositorioEventoDeportivo.ObtenerEvento(idEvento);
                if (eventoBaja != null)
                    bajaEventoDeportivo.Ejecutar(eventoBaja.Id, 1);
                break;
            case (2, 3):
                // Modificación de evento deportivo
                Console.WriteLine("Seleccione el evento a modificar:");
                Selector.EventosDeportivos(repositorioEventoDeportivo, listarEventosDeportivos, out var idEventoDeportivo);
                var eventoModificado = repositorioEventoDeportivo.ObtenerEvento(idEventoDeportivo);
                if (eventoModificado != null)
                {
                    Console.WriteLine("Ingrese nuevos datos:");
                    Console.Write($"Nombre (actual: '{eventoModificado.Nombre}'): "); nom = Console.ReadLine() ?? "";
                    eventoModificado.Nombre = nom;
                    Console.Write($"Descripción (actual: '{eventoModificado.Descripcion}'): "); desc = Console.ReadLine() ?? "";
                    eventoModificado.Descripcion = desc;
                    Console.Write($"Cupo máximo (actual: '{eventoModificado.CupoMaximo}'): "); cupoMax = int.Parse(Console.ReadLine() ?? "1");
                    eventoModificado.CupoMaximo = cupoMax;
                    modificarEventoDeportivo.Ejecutar(eventoModificado, 1);
                }
                break;
            case (2, 4):
                // Listar eventos deportivos
                Selector.Generico(out int opListarE, 
                    "Listar todo",
                    "Listar eventos con cupo disponible",
                    "Listar personas que asistieron a determinado evento");
                switch (opListarE)
                {
                    case 1:
                        var listaEventos = listarEventosDeportivos.Ejecutar();
                        foreach (var e in listaEventos)
                            Console.WriteLine(e);
                        break;
                    case 2:
                        var listaEventosCupos = listarEventosCupoDisponible.Ejecutar();
                        foreach (var e in listaEventosCupos)
                            Console.WriteLine(e);
                        break;
                    case 3:
                        Console.WriteLine("Seleccione un evento:");
                        Selector.EventosDeportivos(repositorioEventoDeportivo, listarEventosDeportivos, out idEventoDeportivo);
                        var eventoLista = repositorioEventoDeportivo.ObtenerEvento(idEventoDeportivo);
                        if (eventoLista != null)
                        {
                            foreach(Persona p in listarAsistenciaEventos.Ejecutar(eventoLista))
                                Console.WriteLine(p);
                        }
                        break;
                }
                break;
            case (3, 1):
                // Alta de reserva
                Console.WriteLine("Seleccione la persona a cargo de la reserva:");
                Selector.Personas(repositorioPersona, listarPersonas, out var idPersonaReserva);
                Console.WriteLine("Seleccione el evento deportivo a reservar:");
                Selector.EventosDeportivos(repositorioEventoDeportivo, listarEventosDeportivos, out var idEventoReserva);
                var reserva = new Reserva(idPersonaReserva, idEventoReserva, DateTime.Now, Asistencia.Pendiente);
                altaReserva.Ejecutar(reserva, 1);
                break;
            case (3, 2):
                // Baja de reserva
                Console.WriteLine("Seleccione una reserva a eliminar:");
                Selector.Reservas(repositorioReserva,listarReservas, out var idReserva);
                bajaReserva.Ejecutar(idReserva, 1);
                break;
            case (3, 3):
                // Modificación de reserva
                Console.WriteLine("Seleccione la reserva a modificar:");
                Selector.Reservas(repositorioReserva, listarReservas, out idReserva);
                var reservaModificada = repositorioReserva.ObtenerReserva(idReserva);
                Console.WriteLine("Ingrese nuevos datos:");
                Console.WriteLine($"Asistencia (1-3) (actual: '{reservaModificada.EstadoAsistencia}'): ");
                Console.WriteLine("1) Pendiente\n2) Presente\n3) Ausente");
                int opAsistencia = int.Parse(Console.ReadLine() ?? "");
                Asistencia asistencia = opAsistencia switch {1 => Asistencia.Pendiente, 2 => Asistencia.Presente, 3 => Asistencia.Ausente, _=> Asistencia.Pendiente};
                reservaModificada.EstadoAsistencia = asistencia;
                modificarReserva.Ejecutar(reservaModificada, 1);
                break;
            case (3, 4):
                // Listar reservas
                var listaReservas = listarReservas.Ejecutar();
                foreach (var r in listaReservas)
                    Console.WriteLine(r);
                break;
        }
        Selector.OpcionesMain(out opMain);
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
}

Console.WriteLine("Programa finalizado");
Console.ReadKey();