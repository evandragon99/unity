using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationTrigger : MonoBehaviour
{
    
    public GameObject animatedObject;
    public string triggerName;

    public void TriggerAnimation()
    {
        //Set a trigger for an animation
        if(animatedObject != null)
        {
            Animator animator = animatedObject.GetComponent<Animator>();
            if(animator != null)
            {
                animator.SetTrigger(triggerName);
            }
        }
    }

    

}
