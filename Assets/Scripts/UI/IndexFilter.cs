using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexFilter : MonoBehaviour
{
    public GameObject[] myButtons;

    public bool[] myObj = new bool[12];

    

    public void UpdateButtons()
    {
        foreach (GameObject button in myButtons)
        {
            var buttonData = button.GetComponent<IndexButtonData>().myData;
            switch (buttonData.ObjType)
            {
                case ObjType.Enemy:

                    button.SetActive(myObj[0]);

                    if (myObj[1] || myObj[2])
                    {
                        if (buttonData.EnemyRange == EnemyRange.Melee)
                        {
                            button.SetActive(myObj[1]);
                        }
                        else
                        {
                            button.SetActive(myObj[2]);
                        }
                    }
                    
                    break;
                case ObjType.PowerUp:

                    button.SetActive(myObj[3]);

                    if (myObj[4] || myObj[5] || myObj[6])
                    {
                        if (buttonData.PowerUpEffect == PowerUpEffect.Heal)
                        {
                            button.SetActive(myObj[4]);
                        }
                        else if (buttonData.PowerUpEffect == PowerUpEffect.Invencible)
                        {
                            button.SetActive(myObj[5]);
                        }
                        else
                        {
                            button.SetActive(myObj[6]);
                        }
                    }
                        
                    break;
                case ObjType.Bullet:

                    button.SetActive(myObj[7]);

                    if (myObj[8] || myObj[9] || myObj[10] || myObj[11])
                    {
                        if (buttonData.BulletOwner == BulletOwner.Ally)
                        {
                            button.SetActive(myObj[8]);
                        }
                        else
                        {
                            button.SetActive(myObj[9]);
                        }

                        if (buttonData.BulletDamage == BulletDamage.Weak)
                        {
                            button.SetActive(myObj[10]);
                        }
                        else
                        {
                            button.SetActive(myObj[11]);
                        }
                    }
                        
                    break;
            }
            
        }
        
    }
}
