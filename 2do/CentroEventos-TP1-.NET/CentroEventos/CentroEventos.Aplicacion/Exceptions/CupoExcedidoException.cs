namespace CentroEventos.Aplicacion.Exceptions;

public class CupoExcedidoException : Exception {
    public CupoExcedidoException()
    {
        throw new Exception();
    }
    public CupoExcedidoException(string message) : base(message)
    {
        throw new Exception(message);
    }
    public CupoExcedidoException(string message, Exception inner) : base(message, inner)
    {
        throw new Exception(message);
    }
}