using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    private Pila _magazine;
    [SerializeField] private int magazineCapacity;
    [SerializeField] private GameObject originalBullet;

    void Start()
    {
        _magazine = new Pila(magazineCapacity);
        Recharge();
    }
    public void Shoot(Vector2 position, float direction)
    {
        if (_magazine.IsEmpty()) return;
        //SONIDITO DE QUE ESTÁ VACIA
        GameObject bullet = _magazine.Pop();
    }

    public void Recharge()
    {
        _magazine.Clear();
        for (int i = 0; i < magazineCapacity; i++)
        {
            _magazine.Push(originalBullet);
        }
        
    }
}
