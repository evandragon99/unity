using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TextManager : MonoBehaviour
{
    
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI infoText;


    public void displayText(InfoText text)
    {
        nameText.text = text.name;
        infoText.text = text.infotext;
    }


}
