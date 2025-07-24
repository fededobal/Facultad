package Parciales.Grafos.Fecha_28_11_2022;

import Practica_5.EJ1.Edge;
import Practica_5.EJ1.Graph;
import Practica_5.EJ1.Vertex;
import Practica_5.EJ1.adjList.AdjListGraph;

import java.util.LinkedList;
import java.util.List;

public class Estadios {
    public List<String> estadios(Graph<Estadio> mapaEstadios, String estadioOrigen, int cantKm) {
        List<String> ret = new LinkedList<>();
        if(mapaEstadios != null && !mapaEstadios.isEmpty()) {
            Vertex<Estadio> primerEstadio = buscarEstadio(mapaEstadios,estadioOrigen);
            boolean[] marcas = new boolean[mapaEstadios.getSize()];
            // por precondición el Estadio seguro existe
            estadios(mapaEstadios,primerEstadio,ret,new LinkedList<>(),marcas,cantKm);
        }
        return ret;
    }

    private void estadios(Graph<Estadio> mapaEstadios, Vertex<Estadio> estadioAct, List<String> caminoMax, LinkedList<String> caminoAct, boolean[] marcas, int cantKm) {
        caminoAct.add(estadioAct.getData().getNombre());
        marcas[estadioAct.getPosition()] = true;

        if(caminoAct.size() > caminoMax.size()) {
            caminoMax.clear();
            caminoMax.addAll(caminoAct);
        }
        for(Edge<Estadio> e : mapaEstadios.getEdges(estadioAct)) {
            if(!marcas[e.getTarget().getPosition()] && cantKm - e.getWeight() > 0)
                estadios(mapaEstadios,e.getTarget(),caminoMax,caminoAct,marcas,cantKm-e.getWeight());
        }

        marcas[estadioAct.getPosition()] = false;
        caminoAct.removeLast();
    }

    private Vertex<Estadio> buscarEstadio(Graph<Estadio> mapaEstadios, String e) {
        for(Vertex<Estadio> v : mapaEstadios.getVertices())
            if(v.getData().getNombre().equals(e))
                return v;
        return null;
    }

    public static void main(String[] args) {
        Graph<Estadio> grafo = new AdjListGraph<>();
        Vertex<Estadio> v1 = grafo.createVertex(new Estadio("Jor", "AL BAYT STADIUM"));
        Vertex<Estadio> v2 = grafo.createVertex(new Estadio("Lusail", "LUSAIL STADIUM"));
        Vertex<Estadio> v3 = grafo.createVertex(new Estadio("Rayán", "EDUCATION CITY STADIUM"));
        Vertex<Estadio> v4 = grafo.createVertex(new Estadio("Rayán", "AL RAYYAN STADIUM"));
        Vertex<Estadio> v5 = grafo.createVertex(new Estadio("Doha", "STADIUM 947"));
        Vertex<Estadio> v6 = grafo.createVertex(new Estadio("Doha", "KHALIFA INTERNATIONAL STADIUM"));
        Vertex<Estadio> v7 = grafo.createVertex(new Estadio("Doha", "AL THUMAMA STADIUM"));
        Vertex<Estadio> v8 = grafo.createVertex(new Estadio("Wakrah", "AL JANOUB STADIUM"));

        grafo.connect(v1, v2, 42);
        grafo.connect(v2, v1, 42);
        grafo.connect(v2, v3, 24);
        grafo.connect(v3, v2, 24);
        grafo.connect(v2, v5, 52);
        grafo.connect(v5, v2, 52);
        grafo.connect(v3, v4, 11);
        grafo.connect(v4, v3, 11);
        grafo.connect(v4, v6, 8);
        grafo.connect(v6, v4, 8);
        grafo.connect(v6, v7, 12);
        grafo.connect(v7, v6, 12);
        grafo.connect(v7, v8, 12);
        grafo.connect(v8, v7, 12);
        grafo.connect(v8, v5, 19);
        grafo.connect(v5, v8, 19);

        Estadios e = new Estadios();

        System.out.println(e.estadios(grafo, "AL BAYT STADIUM", 100));
    }
}
