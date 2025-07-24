namespace CentroEventos.Repositorios.Reservas;

public class RepositorioIdReserva
{
    public static int NextIdActual()
    {
        string nombreArch = "../../../../CentroEventos.Repositorios/Reservas/IDActual_Reserva.txt";
        using StreamReader sr = new StreamReader(nombreArch);
        int id = int.Parse(sr.ReadLine() ?? "0");
        sr.Close();      
        id++;
        using StreamWriter st = new StreamWriter (nombreArch,false);
        st.WriteLine(id);
        return id;
    }
}