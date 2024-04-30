using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private Cola powerUpGotten;
    private PlayerState _playerState;
    [SerializeField] private GameObject misil;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject invencibleAura;
    [SerializeField] private GameObject healAura;

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
            invencibleAura.SetActive(false);
            healAura.SetActive(false);
        }

    }

    public void UsePowerUp()
    {
        if (time > timer)
        {
            PowerUp powerUp = powerUpGotten.Pop().GetComponent<PowerUp>();
            switch (powerUp.powerUpType)
            {
                case PowerUps.Misil:
                    GameObject newMisil = Instantiate(misil, shootPoint.position, Quaternion.identity);
                    newMisil.transform.localScale = new Vector3(newMisil.transform.localScale.x * transform.localScale.x / Mathf.Abs(transform.localScale.x), newMisil.transform.localScale.y, 1);
                    break;
                case PowerUps.Invencible:
                    _playerState.isInvencible = true;
                    invencibleAura.SetActive(true);
                    break;
                case PowerUps.Heal:
                    healAura.SetActive(true);
                    _playerState.HealDamage(30);
                    break;    
                default: 
                    break;

            }
            PowerUp_UIControl.Instance.UsePowerUp();
            time = timer - powerUp.timer;
            Destroy(powerUp.gameObject);
        }
        

    }

    public void GetNewPowerUp(GameObject newPowerUp)
    {
        powerUpGotten.Push(newPowerUp);
        switch (newPowerUp.GetComponent<PowerUp>().powerUpType)
        {
            case PowerUps.Misil:
                PowerUp_UIControl.Instance.AddPowerUp(2);
                break;
            case PowerUps.Invencible:
                PowerUp_UIControl.Instance.AddPowerUp(1);
                break;
            case PowerUps.Heal:
                PowerUp_UIControl.Instance.AddPowerUp(0);
                break;
            default:
                break;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PowerUp>())
        {
            GetNewPowerUp(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }

}

public enum PowerUps
{
    Misil,
    Invencible,
    Heal
}