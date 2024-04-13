using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    private Pila _magazine;
    [SerializeField] private int magazineCapacity;
    [SerializeField] private GameObject originalBullet;
    [SerializeField] private GameObject strongBullet;

    private float time;
    [SerializeField] private float timer;

    void Start()
    {
        _magazine = new Pila(magazineCapacity);
        Recharge();
        time = 0;
    }

    private void Update()
    {
        time += Time.deltaTime;
    }
    public void Shoot(Vector2 position, float direction)
    {
        if (time > timer)
        {
            if (_magazine.IsEmpty()) return;
            //SONIDITO DE QUE ESTÁ VACIA
            GameObject bullet = _magazine.Pop();
            bullet = Instantiate(bullet, position, Quaternion.identity);
            bullet.transform.localScale = new Vector3(direction, 1, 1);
            //Instanciente

            time = 0;
        }
        
    }

    public void Recharge()
    {
        if (_magazine.IsEmpty())
        {
            time = timer - 3;
        }
        else
        {
            time = timer - 2;
        }
        _magazine.Clear();
        _magazine.Push(strongBullet);
        for (int i = 1; i < magazineCapacity; i++)
        {
            _magazine.Push(originalBullet);
        }
        
    }
}
