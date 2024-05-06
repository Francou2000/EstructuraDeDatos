using System.Collections;
using UnityEngine;

public class Pila : IPila
{

    public GameObject[] items = null;
    public int index;
    public bool isActive;

    public Pila(int capacity)
    {
        items = new GameObject[capacity];
        isActive = true;
        index = 0;
    }

    public GameObject Pop()
    {
        if(index!= 0)
        {
            index--;
            GameObject popItem = items[index];
            items[index] = null;
            return popItem;
        }
        else
        {
            throw new System.Exception("La pila no existe");
        }
    }

    public void Push(GameObject newItem)
    {
        if (isActive &&  index < items.Length)
        {
            items[index] = newItem;
            index++;
        }
        else
        {
            throw new System.Exception("La pila no existe o esta llena");
        }

    }

    public void Clear()
    {
        for(int i = 0; i < items.Length; i++)
        {
            items[i] = null;
        }
        index = 0;
    }

    public GameObject LastItem()
    {
        if (index != 0)
        {
            return items[index-1];
        }
        else
        {
            throw new System.Exception("La pila no existe");
        }
    }

    public bool IsEmpty()
    {
        if (isActive)
        {
            if (index == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            throw new System.Exception("La pila no existe");
        }
    }
}
