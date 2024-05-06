using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPila
{
    public GameObject Pop();
    public void Push(GameObject newItem);
    public void Clear();
    public GameObject LastItem();
    public bool IsEmpty();

}
