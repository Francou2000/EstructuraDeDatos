using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Pila _magazine;
    [SerializeField] private int magazineCapacity;
    [SerializeField] private GameObject originalBullet;
    [SerializeField] private GameObject strongBullet;
    [SerializeField] private Transform shootPoint;

    private float time;
    [SerializeField] private float timer;

    public UnityEvent shoot;
    public UnityEvent recharge;


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

    public void Shoot(float direction, Animator anim)
    {
        if (time > timer)
        {
            if (_magazine.IsEmpty()) return;
            //SONIDITO DE QUE ESTÁ VACIA
            GameObject bullet = _magazine.Pop();
            bullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);
            bullet.transform.localScale = new Vector3(direction, 1, 1);
            //Instanciente

            anim.SetTrigger("Shoot");

            time = 0;

            shoot.Invoke();
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

        recharge.Invoke();
    }


}
