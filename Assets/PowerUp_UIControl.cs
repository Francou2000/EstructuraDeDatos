using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp_UIControl : MonoBehaviour
{
    public static PowerUp_UIControl Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    public GameObject[] powerUpShow;
    private int quantity = 0;
    public Sprite[] powerUpSprites;
    public Image selector;

    public void AddPowerUp(int type)
    {
        if (quantity == 0)
        {
            selector.enabled = true;
        }

        quantity++;
        for (int i = quantity - 1; i > 0; i--)
        {
            powerUpShow[i].GetComponent<Image>().sprite = powerUpShow[i - 1].GetComponent<Image>().sprite;
        }
        gameObject.GetComponent<Slider>().value = 0.2f * quantity;
        powerUpShow[0].GetComponent<Image>().sprite = powerUpSprites[type];
        powerUpShow[quantity - 1].SetActive(true);
    }

    public void UsePowerUp()
    {
        quantity--;
        gameObject.GetComponent<Slider>().value = 0.2f * quantity;
        powerUpShow[quantity].SetActive(false);
        if (quantity == 0)
        {
            selector.enabled = false;
        }
    }
}
