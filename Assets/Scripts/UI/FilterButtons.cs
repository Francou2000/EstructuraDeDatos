using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterButtons : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite selectedSprite;
    public Sprite disableSprite;

    private bool isSelected = false;
    public bool IsEnable = true;
    private bool fatherSelected = false;

    private Image myImage;

    public IndexFilter filter;
    public int myObjIndex;

    void Start()
    {
        myImage = GetComponent<Image>();
        EnableButton();
    }

    public void ChangeImage()
    {
        if (isSelected)
        {
            isSelected = false;
            myImage.sprite = normalSprite;
        }
        else
        {
            isSelected = true;
            myImage.sprite = selectedSprite;
        }
    }

    public void EnableButton()
    {
        if (IsEnable)
        {
            IsEnable = false;
            GetComponent<Button>().interactable = false;
            filter.myObj[myObjIndex] = false;
            myImage.sprite = disableSprite;
        }
        else
        {
            IsEnable = true;
            GetComponent<Button>().interactable = true;
            filter.myObj[myObjIndex] = true;
            myImage.sprite = normalSprite;
        }
    }
    
    public void EnableButtonByFather()
    {
        
        if (IsEnable)
        {
            IsEnable = false;
            isSelected = false;
            GetComponent<Button>().interactable = false;
            filter.myObj[myObjIndex] = false;
            myImage.sprite = disableSprite;
        }
        else if (!fatherSelected)
        {
            IsEnable = true;

            GetComponent<Button>().interactable = true;
            filter.myObj[myObjIndex] = true;
            myImage.sprite = normalSprite;
        }
        fatherSelected = !fatherSelected;
    }

    
}