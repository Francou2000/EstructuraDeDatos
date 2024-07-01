using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IndexButtonData : MonoBehaviour
{
    public IndexObjectData myData;

    TextMeshProUGUI myText;
    public Image myImage;

    void Start()
    {
        myText = GetComponentInChildren<TextMeshProUGUI>();
        myText.text = myData.name;
    }

    public void SelectObject()
    {
        myImage.sprite = myData.MySprite;
    }
}
