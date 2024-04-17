using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagazineSlider : MonoBehaviour
{
    public Slider slider;

    public Weapon player;

    void Start()
    {
        slider = GetComponent<Slider>();
        player = PlayerState.Instance.GetComponent<Weapon>();
        player.shoot.AddListener(UseBullet);
        player.recharge.AddListener(Recharge);

    }

    void UseBullet()
    {
        slider.value -= 0.1f;
    }

    void Recharge()
    {
        slider.value = 1;
    }
}
