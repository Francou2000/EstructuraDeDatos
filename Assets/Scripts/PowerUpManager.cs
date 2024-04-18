using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private Cola powerUpGotten;

    private float time;
    [SerializeField] private float timer;

    private void Start()
    {
        powerUpGotten = new Cola(5);
        time = 0;
    }

    private void Update()
    {
        time += Time.deltaTime;

    }

    public void UsePowerUp()
    {
        PowerUp powerUp = powerUpGotten.Pop().GetComponent<PowerUp>();
        switch (powerUp.powerUpType)
        {
            case PowerUps.Misil:

                break;
            case PowerUps.Invencible:

                break;
            case PowerUps.Heal:
                PlayerState.Instance.HealDamage(30);
                break;

        }
        time = timer - powerUp.timer;

    }

    public void GetNewPowerUp(GameObject newPowerUp)
    {
        powerUpGotten.Push(newPowerUp);
    }

}

public enum PowerUps
{
    Misil,
    Invencible,
    Heal
}