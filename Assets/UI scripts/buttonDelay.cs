using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDelay : MonoBehaviour
{
    //This script just tidies up the login animation so buttons dont show up before they animate themselves in
    public Button Button1;
public Button Button2;
public Button Button3;

//used to determine whether to make buttons interactable or uninteractable after delay
//true == turns interactable, false == turns uninteractable
public bool mode;



public void Button1Clicked()
{
    //button is clicked
    StartCoroutine(delayButton());
}

IEnumerator delayButton()
{
    Debug.Log(Time.time);
    yield return new WaitForSeconds(0.8f);
    Debug.Log(Time.time);

    // Buttons are set interactable after 0.8 second
    if (mode==true){
        Button2.interactable=true;
        Button3.interactable=true;
    }
    else {
        Button2.enabled=false;
        Button3.enabled=false;
    }
}

    
}
