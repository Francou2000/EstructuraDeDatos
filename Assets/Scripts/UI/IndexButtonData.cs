using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IndexButtonData : MonoBehaviour
{
    public IndexObjectData myData;

    TextMeshProUGUI myText;

    public void SetButtonParameters(IndexObjectData newData)
    {
        myData = newData;
        myText = GetComponentInChildren<TextMeshProUGUI>();
        myText.text = myData.name;
    }

    public void SelectObject()
    {
       GetComponentInParent<IndexFilter>().SelectObject(myData.MySprite);
    }
}
