using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMenuButton : MonoBehaviour
{
    public GameObject PanelMenu;

    public void openMenu()
    {
        //Play show/hide animation
        if(PanelMenu != null)
        {
            Animator animator = PanelMenu.GetComponent<Animator>();
            if(animator != null)
            {
                animator.SetBool("show", true);
            }
        }
    }

    public void closeMenu()
    {
        
        if(PanelMenu != null)
        {
            Animator animator = PanelMenu.GetComponent<Animator>();
            if(animator != null)
            {
                animator.SetBool("show", false);
            }
        }
    }
}
