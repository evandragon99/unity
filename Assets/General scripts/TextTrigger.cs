using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTrigger : MonoBehaviour
{
   

    public void triggerText(string title, string body, TextMeshProUGUI canvasTitle, TextMeshProUGUI canvasBody)
    {
        canvasTitle.text = title;
        canvasBody.text = body;
    }
}
