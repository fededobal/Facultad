﻿namespace ejercicios_teoria7;

static class Procesador
{
    public static void Alquilar(IAlquilable x, Persona p) => x.SeAlquilaA(p);
    public static void Devolver(IAlquilable x, Persona p) => x.DevueltoPor(p);
    public static void Vender(IVendible x, Persona p) => x.SeVendeA(p);
    public static void Lavar(ILavable x) => x.SeLava();
    public static void Secar(ILavable x) => x.SeSeca();
    public static void Reciclar(IReciclable x) => x.SeRecicla();
    public static void Atender(IAtendible x) => x.SeAtiende();
}