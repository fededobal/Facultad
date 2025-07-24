namespace CentroEventos.Repositorios.Personas;
public class RepositorioIdPersona
{
    public static int ObtenerId ()
    {
        string nombreArch = "../../../../CentroEventos.Repositorios/Personas/RepositorioIdPersona.txt";
        using StreamReader sr = new StreamReader(nombreArch);
        int id = int.Parse(sr.ReadLine() ?? "0");
        sr.Close();      
        id++;
        using StreamWriter st = new StreamWriter (nombreArch,false);
        st.WriteLine(id);
        return id;
    }
}

