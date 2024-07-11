using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndexFilter : MonoBehaviour
{
    public IndexObjectData[] myObjects;
    public GameObject baseButton;
    public GameObject[] myButtons;
    ABB myTree = new ABB();

    public bool[] myObj = new bool[12];

    public Image myImage;

    private void Start()
    {
        myTree.InicializarArbol();
        foreach (var myObject in myObjects)
        {
            myTree.AgregarElem(ref myTree.raiz, myObject.SortValue);
        }
        
        GenerateButtons();
    }

    private void GenerateButtons()
    {
        myButtons = new GameObject[myObjects.Length];
        myTree.InOrder(myTree.raiz);
        List<int> valuesSorted = myTree.lorder;
        
        for (int i = 0; i < valuesSorted.Count; i++)
        {
            foreach (var myObject in myObjects)
            {
                if (valuesSorted[i] == myObject.SortValue)
                {
                    myButtons[i] = Instantiate(baseButton, this.transform);
                    myButtons[i].GetComponent<IndexButtonData>().SetButtonParameters(myObject);
                }
                
            }
        }
    }

    public void SelectObject(Sprite newImage)
    {
        myImage.sprite = newImage;
        myImage.enabled = true;
    }

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

                    if (buttonData.BulletOwner == BulletOwner.Ally && buttonData.BulletDamage == BulletDamage.Weak)
                    {
                        if ((!myObj[8] && myObj[9]) || (myObj[11] && !myObj[10]))
                        {
                            button.SetActive(false);
                        }
                        else
                        {
                            button.SetActive(true);
                        }
                    }
                    else if (buttonData.BulletOwner == BulletOwner.Enemy && buttonData.BulletDamage == BulletDamage.Weak)
                    {
                        if ((!myObj[9] && myObj[8]) || (myObj[11] && !myObj[10]))
                        {
                            button.SetActive(false);
                        }
                        else
                        {
                            button.SetActive(true);
                        }
                    }
                    else if (buttonData.BulletOwner == BulletOwner.Ally && buttonData.BulletDamage == BulletDamage.Strong)
                    {
                        if ((!myObj[8] && myObj[9]) || (myObj[10] && !myObj[11]))
                        {
                            button.SetActive(false);
                        }
                        else
                        {
                            button.SetActive(true);
                        }
                    }
                    else if (buttonData.BulletOwner == BulletOwner.Enemy && buttonData.BulletDamage == BulletDamage.Strong)
                    {
                        if ((!myObj[9] && myObj[8]) || (myObj[10] && !myObj[11]))
                        {
                            button.SetActive(false);
                        }
                        else
                        {
                            button.SetActive(true);
                        }
                    }
                    

                        
                    break;
            }
            
        }
        
    }
}
