using System.Collections;
using UnityEngine;

public class Cola
{

    public GameObject[] items = null;
    public int index;
    public bool isActive;

    public Cola(int capacity)
    {
        items = new GameObject[capacity];
        isActive = true;
        index = 0;
    }

    public GameObject Pop()
    {
        if (index != 0)
        {
            index--;
            GameObject popItem = items[index];
            items[index] = null;
            return popItem;
        }
        else
        {
            throw new System.Exception("La cola no existe");
        }
    }

    public void Push(GameObject newItem)
    {
        if (isActive && index < items.Length)
        {
            for( int i = 0; i < index; i++)
            {
                items[i + 1] = items[i];
            }
            items[0] = newItem;
            index++;
        }
        else
        {
            throw new System.Exception("La cola no existe o esta llena");
        }

    }

    public void Clear()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = null;
        }
        index = 0;
    }

    public GameObject FirstItem()
    {
        if (index != 0)
        {
            return items[index - 1];
        }
        else
        {
            throw new System.Exception("La cola no existe");
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
            throw new System.Exception("La cola no existe");
        }
    }
}
