using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICola
{
    public GameObject Pop();
    public void Push(GameObject newItem);
    public void Clear();
    public GameObject FirstItem();
    public bool IsEmpty();
}
