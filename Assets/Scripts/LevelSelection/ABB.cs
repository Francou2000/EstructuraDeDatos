using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ABBTDA
{
    int Raiz();
    NodoABB HijoIzq();
    NodoABB HijoDer();
    bool ArbolVacio();
    void InicializarArbol();
    void AgregarElem(ref NodoABB n, int x);
    void EliminarElem(ref NodoABB n, int x);
}

public class NodoABB
{
    // datos a almacenar, en este caso un entero
    public int info;
    // referencia los nodos izquiero y derecho
    public NodoABB hijoIzq = null;
    public NodoABB hijoDer = null;
}

public class ABB : ABBTDA
{
    public NodoABB raiz;

    public int Raiz()
    {
        return raiz.info;
    }

    public bool ArbolVacio()
    {
        return (raiz == null);
    }

    public void InicializarArbol()
    {
        raiz = null;
    }

    public NodoABB HijoDer()
    {
        return raiz.hijoDer;
    }

    public NodoABB HijoIzq()
    {
        return raiz.hijoIzq;
    }

    public void AgregarElem(ref NodoABB raiz, int x)
    {
        if (raiz == null)
        {
            raiz = new NodoABB();
            raiz.info = x;
        }
        else if (raiz.info > x)
        {
            AgregarElem(ref raiz.hijoIzq, x);
        }
        else if (raiz.info < x)
        {
            AgregarElem(ref raiz.hijoDer, x);
        }
    }

    public void EliminarElem(ref NodoABB raiz, int x)
    {
        if (raiz != null)
        {
            if (raiz.info == x && (raiz.hijoIzq == null) && (raiz.hijoDer == null))
            {
                raiz = null;
            }
            else if (raiz.info == x && raiz.hijoIzq != null)
            {
                raiz.info = this.Mayor(raiz.hijoIzq);
                EliminarElem(ref raiz.hijoIzq, raiz.info);
            }
            else if (raiz.info == x && raiz.hijoIzq == null)
            {
                raiz.info = this.Menor(raiz.hijoDer);
                EliminarElem(ref raiz.hijoDer, raiz.info);
            }
            else if (raiz.info < x)
            {
                EliminarElem(ref raiz.hijoDer, x);
            }
            else
            {
                EliminarElem(ref raiz.hijoIzq, x);
            }
        }
    }

    public int Mayor(NodoABB a)
    {
        if (a.hijoDer == null)
        {
            return a.info;
        }
        else
        {
            return Mayor(a.hijoDer);
        }
    }

    public int Menor(NodoABB a)
    {
        if (a.hijoIzq == null)
        {
            return a.info;
        }
        else
        {
            return Menor(a.hijoIzq);
        }
    }
    
    public List<int> lorder = new List<int>();
    public void InOrder(NodoABB a)
    {
        if (a != null)
        {
            InOrder(a.hijoIzq);
            lorder.Add(a.info);
            InOrder(a.hijoDer);
        }
    }

}