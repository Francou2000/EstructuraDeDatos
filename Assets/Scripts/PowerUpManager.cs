using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private Cola powerUpGotten;
    private PlayerState _playerState;
    [SerializeField] private GameObject misil;
    [SerializeField] private Transform shootPoint;

    private float time;
    [SerializeField] private float timer;


    private void Start()
    {
        powerUpGotten = new Cola(5);
        _playerState = PlayerState.Instance;
        time = 0;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > timer)
        {
            _playerState.isInvencible = false;
        }

    }

    public void UsePowerUp()
    {
        PowerUp powerUp = powerUpGotten.Pop().GetComponent<PowerUp>();
        switch (powerUp.powerUpType)
        {
            case PowerUps.Misil:
                GameObject newMisil = Instantiate(misil, shootPoint.position, Quaternion.identity);
                misil.transform.localScale = new Vector3(transform.localScale.x / Mathf.Abs(transform.localScale.x), 1, 1);
                break;
            case PowerUps.Invencible:
                _playerState.isInvencible = true;
                break;
            case PowerUps.Heal:
                _playerState.HealDamage(30);
                break;    
            default: 
                break;

        }
        time = timer - powerUp.timer;

    }

    public void GetNewPowerUp(GameObject newPowerUp)
    {
        powerUpGotten.Push(newPowerUp);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PowerUp>())
        {
            GetNewPowerUp(collision.gameObject);
        }
    }

}

public enum PowerUps
{
    Misil,
    Invencible,
    Heal
}