namespace CentroEventos.Repositorios.EventosDeportivos;

public class RepositorioEventoDeportivoId {
    public static int CalcularId ()
    {
        string nombreArch = "../../../../CentroEventos.Repositorios/EventosDeportivos/EventosDeportivosId.txt";
        using StreamReader sr = new StreamReader(nombreArch);
        int id = int.Parse(sr.ReadLine() ?? "0");
        sr.Close();      
        id++;
        using StreamWriter st = new StreamWriter (nombreArch,false);
        st.WriteLine(id);
        return id;
    }
}