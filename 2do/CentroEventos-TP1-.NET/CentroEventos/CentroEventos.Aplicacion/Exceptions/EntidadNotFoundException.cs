namespace CentroEventos.Aplicacion.Exceptions;

public class EntidadNotFoundException : Exception {
    public EntidadNotFoundException() {}
    public EntidadNotFoundException(string message) : base(message) {}
    public EntidadNotFoundException(string message, Exception inner) : base(message, inner) {}
}