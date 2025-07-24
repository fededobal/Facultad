package Parciales.Grafos.Fecha_15_06_2024;

public class Recinto {
    private String nombre;
    private int tardanza;

    public String getNombre() {
        return nombre;
    }

    public int getTardanza() {
        return tardanza;
    }

    public Recinto(String nombre, int tardanza) {
        this.nombre = nombre;
        this.tardanza = tardanza;
    }
}
