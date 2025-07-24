using CentroEventos.UI.Components;
using CentroEventos.Repositorios.DB;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.UseCases.Usuario;
using CentroEventos.Aplicacion.Services;
using CentroEventos.Aplicacion.Services.ServicioSesion;
using CentroEventos.Aplicacion.Validators.Usuario;
using CentroEventos.UI.Components.Layout;
using CentroEventos.Aplicacion.UseCases.Evento;
using CentroEventos.Aplicacion.UseCases.Persona;
using CentroEventos.Aplicacion.Validators.Evento.Alta;
using CentroEventos.Aplicacion.Validators.Evento.Baja;
using CentroEventos.Aplicacion.Validators.Evento.Modificacion;
using CentroEventos.Aplicacion.Validators.Persona.Alta;
using CentroEventos.Aplicacion.Validators.Persona.Baja;
using CentroEventos.Aplicacion.Validators.Persona.Modificacion;
using CentroEventos.Aplicacion.UseCases.Reserva;
using CentroEventos.Aplicacion.Validators.Reserva.Alta;
using CentroEventos.Aplicacion.Validators.Reserva.Baja;
using CentroEventos.Aplicacion.Validators.Reserva.Modificar;
using CentroEventos.Aplicacion.UseCases.Especiales;

CentroEventosSqlite.Inicializar();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// contenedor DI Transient de Usuarios
builder.Services.AddTransient<ServicioAutorizacion>();
builder.Services.AddTransient<UsuarioAltaUseCase>();
builder.Services.AddTransient<UsuarioBajaUseCase>();
builder.Services.AddTransient<UsuarioModificarUseCase>();
builder.Services.AddTransient<UsuarioListarUseCase>();
builder.Services.AddTransient<UsuarioAltaCampos>();
builder.Services.AddTransient<UsuarioBajaQueNoSeaAdmin>();
builder.Services.AddTransient<ObtenerUsuarioPorEmail>();
builder.Services.AddTransient<InicioSesion>();
builder.Services.AddTransient<CerrarSesion>();
builder.Services.AddTransient<NavMenu>();

// contenedor DI Transient de Eventos Deportivos
builder.Services.AddTransient<EventoAltaUseCase>();
builder.Services.AddTransient<EventoBajaUseCase>();
builder.Services.AddTransient<EventoModificacionUseCase>();
builder.Services.AddTransient<EventoListarUseCase>();
builder.Services.AddTransient<EventoAltaValidadorCupoMaximo>();
builder.Services.AddTransient<EventoAltaValidadorDesc>();
builder.Services.AddTransient<EventoAltaValidadorDuracion>();
builder.Services.AddTransient<EventoAltaValidadorFecha>();
builder.Services.AddTransient<EventoAltaValidadorNombre>();
builder.Services.AddTransient<EventoAltaValidadorResponsable>();
builder.Services.AddTransient<EventoBajaValidadorReservasAsociadas>();
builder.Services.AddTransient<EventoModificadorValidadorCupo>();
builder.Services.AddTransient<EventoModificadorValidadorFecha>();
builder.Services.AddTransient<EventoModificadorValidadorIdResponsable>();
builder.Services.AddTransient<ListarAsistenciaAEventoUseCase>();
builder.Services.AddTransient<ListarEventosConCupoDisponibleUseCase>();

// // contenedor DI Transient de Personas
builder.Services.AddTransient<AltaPersonaUseCase>();
builder.Services.AddTransient<BajaPersonaUseCase>();
builder.Services.AddTransient<ListarPersonasUseCase>();
builder.Services.AddTransient<ModificarPersonaUseCase>();
builder.Services.AddTransient<DniValidador>();
builder.Services.AddTransient<EmailValidador>();
builder.Services.AddTransient<PersonaValidador>();
builder.Services.AddTransient<PersonaBajaValidador>();
builder.Services.AddTransient<PersonaModificacionValidador>();

// contenedor DI Transient de Reservas
builder.Services.AddTransient<ReservaAltaUseCase>();
builder.Services.AddTransient<ReservaBajaUseCase>();
builder.Services.AddTransient<ReservaModificarUseCase>();
builder.Services.AddTransient<ReservaListarUseCase>();
builder.Services.AddTransient<ReservaAltaCupoDisponible>();
builder.Services.AddTransient<ReservaValidadorAltaDuplicado>();
builder.Services.AddTransient<ReservaValidadorAltaExistencias>();
builder.Services.AddTransient<ReservaValidadorBajaExistencia>();
builder.Services.AddTransient<ReservaValidadorModificarExistentes>();

// contenedor DI Scoped de las entidades
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddScoped<IServicioSesion, Sesion>();
builder.Services.AddScoped<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>();
builder.Services.AddScoped<IRepositorioPersona, RepositorioPersona>();
builder.Services.AddScoped<IRepositorioReserva, RepositorioReserva>();
builder.Services.AddScoped<Sesion>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
