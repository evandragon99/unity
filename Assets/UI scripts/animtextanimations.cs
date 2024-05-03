using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animtextanimations : MonoBehaviour
{
    public GameObject text;
    

    public void Text_fade(string trigger)
    {
        //Play show/hide animation
        if (text != null)
        {
            Animator animator = text.GetComponent<Animator>();
            if (animator != null)
            {

                animator.SetTrigger(trigger);
               

            }
        }
    }
}
