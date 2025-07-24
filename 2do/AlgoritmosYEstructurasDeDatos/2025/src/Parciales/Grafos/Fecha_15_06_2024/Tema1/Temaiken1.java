package Parciales.Grafos.Fecha_15_06_2024.Tema1;

import Parciales.Grafos.Fecha_15_06_2024.Recinto;
import Practica_5.EJ1.Edge;
import Practica_5.EJ1.Graph;
import Practica_5.EJ1.Vertex;
import Practica_5.EJ1.adjList.AdjListGraph;

import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;

public class Temaiken1 {
    public int resolver(Graph<Recinto> sitios, int tiempo) {
        // opción con listas -> menos eficiente en memoria
        List<Recinto> sitiosRecorridos = new LinkedList<>();
        if(sitios != null && !sitios.isEmpty()) {
            Vertex<Recinto> v = buscarEntrada(sitios);
            if(v != null && tiempo - v.getData().getTardanza() >= 0) {
                boolean[] marcas = new boolean[sitios.getSize()];
                resolver(sitios,v,sitiosRecorridos,new LinkedList<>(),marcas,tiempo-v.getData().getTardanza());
            }
        }
        return sitiosRecorridos.size();
    }

    private void resolver(Graph<Recinto> sitios, Vertex<Recinto> v, List<Recinto> caminoMax, LinkedList<Recinto> caminoAct, boolean[] marcas, int tiempo) {
        caminoAct.add(v.getData());
        marcas[v.getPosition()] = true;

        if(caminoAct.size() > caminoMax.size()) {
            caminoMax.clear();
            caminoMax.addAll(caminoAct);
        }
        for(Edge<Recinto> e : sitios.getEdges(v))
            if(!marcas[e.getTarget().getPosition()] && tiempo - (e.getWeight() + e.getTarget().getData().getTardanza()) >= 0)
                resolver(sitios,e.getTarget(),caminoMax,caminoAct,marcas,tiempo-e.getWeight());

        marcas[v.getPosition()] = false;
        caminoAct.removeLast();
    }

    public static Vertex<Recinto> buscarEntrada(Graph<Recinto> sitios) {
        boolean encontre = false;
        Vertex<Recinto> aux = null;
        Iterator<Vertex<Recinto>> it = sitios.getVertices().iterator();
        while(!encontre && it.hasNext()) {
            Vertex<Recinto> v = it.next();
            if(v.getData().getNombre().equals("Entrada")) {
                aux = v;
                encontre = true;
            }
        }
        return aux;
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
        grafo.connect(Entrada, Tigres, 10);
        grafo.connect(Tigres, Entrada, 10);
        grafo.connect(Entrada, Murcielagos, 20);
        grafo.connect(Murcielagos, Entrada, 20);
        grafo.connect(Entrada, Flamencos, 25);
        grafo.connect(Flamencos, Entrada, 25);

        grafo.connect(Tigres, Cebras, 8);
        grafo.connect(Cebras, Tigres, 8);
        grafo.connect(Cebras, Tortugas, 10);
        grafo.connect(Tortugas, Cebras, 10);
        grafo.connect(Flamencos, Murcielagos, 25);
        grafo.connect(Murcielagos, Flamencos, 25);
        grafo.connect(Murcielagos, Wallabies, 10);
        grafo.connect(Wallabies, Murcielagos, 10);
        grafo.connect(Wallabies, Tortugas, 10);
        grafo.connect(Tortugas, Wallabies, 10);
        grafo.connect(Tortugas, Pumas, 15);
        grafo.connect(Pumas, Tortugas, 15);

        Temaiken1 p = new Temaiken1();

        System.out.println(p.resolver(grafo, 30));
    }
}
