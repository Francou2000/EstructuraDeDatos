using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ConjuntoTDA 
{
    void InicializarConjunto();
    bool ConjuntoVacio();
    void Agregar(int x);
    int Elegir();
    void Sacar(int x);
    bool Pertenece(int x);
}

public class ConjuntoTA : ConjuntoTDA
{
    int[] a;
    int cant;
    
    public void InicializarConjunto()
    {
        a = new int[100];
        cant = 0;
    }
    
    public void Agregar(int x)
    {
        if (!this.Pertenece(x))
        {
            a[cant] = x;
            cant++;
        }
    }

    public bool Pertenece(int x)
    {
        int i = 0;
        while (i < cant && a[i] != x)
        {
            i++;
        }
        return (i < cant);
    }

    public bool ConjuntoVacio()
    {
        return cant == 0;
    }

    public int Elegir()
    {
        return a[cant - 1];
    }

    public void Sacar(int x)
    {
        int i = 0;
        while (i < cant && a[i] != x)
        {
            i++;
        }
        if (i < cant)
        {
            a[i] = a[cant - 1];
            cant--;
        }
    }
}
