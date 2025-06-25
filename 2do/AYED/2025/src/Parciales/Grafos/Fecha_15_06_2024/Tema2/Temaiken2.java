package Parciales.Grafos.Fecha_15_06_2024.Tema2;

import Parciales.Grafos.Fecha_15_06_2024.Recinto;
import Practica_5.EJ1.Edge;
import Practica_5.EJ1.Graph;
import Practica_5.EJ1.Vertex;
import Practica_5.EJ1.adjList.AdjListGraph;

import java.util.Iterator;

import static Parciales.Grafos.Fecha_15_06_2024.Tema1.Temaiken1.buscarEntrada;

public class Temaiken2 {
    public String resolver(Graph<Recinto> sitios, int tiempo) {
        if(sitios != null && !sitios.isEmpty()) {
            int cantRecorridos = Integer.MIN_VALUE;
            Vertex<Recinto> entrada = buscarEntrada(sitios);
            if(entrada != null && tiempo - entrada.getData().getTardanza() >= 0) {
                boolean[] marcas = new boolean[sitios.getSize()];
                cantRecorridos = resolver(sitios,entrada,cantRecorridos,0,marcas,tiempo-entrada.getData().getTardanza());
            }
            if(cantRecorridos == sitios.getSize())
                return "Alcanzable";
        }
        return "No alcanzable";
    }

    private int resolver(Graph<Recinto> sitios, Vertex<Recinto> v, int max, int act, boolean[] marcas, int tiempo) {
        act++;
        marcas[v.getPosition()] = true;

        max = Math.max(act,max);
        Iterator<Edge<Recinto>> it = sitios.getEdges(v).iterator();
        while(max < sitios.getSize() && it.hasNext()) {
            Edge<Recinto> e = it.next();
            if(!marcas[e.getTarget().getPosition()] && tiempo - e.getWeight() - e.getTarget().getData().getTardanza() >= 0)
                max = resolver(sitios,e.getTarget(),max,act,marcas,tiempo - e.getWeight() - e.getTarget().getData().getTardanza());
        }

        marcas[v.getPosition()] = false;
        return max;
    }

    public static void main(String[] args) {
        Graph<Recinto> grafo = new AdjListGraph<>();
        Vertex<Recinto> Entrada = grafo.createVertex(new Recinto("Entrada", 15));
        Vertex<Recinto> Cebras = grafo.createVertex(new Recinto("Cebras", 10));
        Vertex<Recinto> Tigres = grafo.createVertex(new Recinto("Tigres", 10));
        Vertex<Recinto> Flamencos = grafo.createVertex(new Recinto("Flamencos", 10));
        Vertex<Recinto> Murcielagos = grafo.createVertex(new Recinto("Murciélagos", 20));
        Vertex<Recinto> Wallabies = grafo.createVertex(new Recinto("Wallabies", 30));
        Vertex<Recinto> Tortugas = grafo.createVertex(new Recinto("Tortugas", 10));
        Vertex<Recinto> Pumas = grafo.createVertex(new Recinto("Pumas", 10));

        grafo.connect(Entrada, Cebras, 10);
        grafo.connect(Cebras, Entrada, 10);
        grafo.connect(Entrada, Tigres, 15);
        grafo.connect(Tigres, Entrada, 15);
        grafo.connect(Entrada, Murcielagos, 20);
        grafo.connect(Murcielagos, Entrada, 20);
        grafo.connect(Entrada, Flamencos, 25);
        grafo.connect(Flamencos, Entrada, 25);

        grafo.connect(Tigres, Cebras, 8);
        grafo.connect(Cebras, Tigres, 8);
        grafo.connect(Cebras, Tortugas, 5);
        grafo.connect(Tortugas, Cebras, 5);
        grafo.connect(Flamencos, Murcielagos, 25);
        grafo.connect(Murcielagos, Flamencos, 25);
        grafo.connect(Murcielagos, Wallabies, 10);
        grafo.connect(Wallabies, Murcielagos, 10);
        grafo.connect(Wallabies, Tortugas, 10);
        grafo.connect(Tortugas, Wallabies, 10);
        grafo.connect(Tortugas, Pumas, 15);
        grafo.connect(Pumas, Tortugas, 15);
        grafo.connect(Pumas, Wallabies, 2);
        grafo.connect(Wallabies, Pumas, 2);

        Temaiken2 t = new Temaiken2();

        System.out.println(t.resolver(grafo, 220)); // Alcanzable
        System.out.println(t.resolver(grafo, 205)); // Alcanzable
        System.out.println(t.resolver(grafo, 195)); // Alcanzable
        System.out.println(t.resolver(grafo, 100)); // No alcanzable
    }
}
