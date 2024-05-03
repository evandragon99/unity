using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GetanimationText : MonoBehaviour
{
    public UnityEngine.UI.Button anim_button;
    public TextMeshProUGUI button_text;
    public TextMeshProUGUI canvasTitle;
    public TextMeshProUGUI canvasBody;


    // Start is called before the first frame update
    void Start()
    {

        anim_button.onClick.AddListener(AnimTextChangeOnClick);
    }

    void AnimTextChangeOnClick()
    {
        TextTrigger trigger = FindObjectOfType<TextTrigger>();
        AnimationButtons AnimScript = FindObjectOfType<AnimationButtons>();
        List<CipherAnimation> AnimList = AnimScript.Animations;
        foreach (CipherAnimation animation in AnimList)
        {
            if (button_text.text == animation.AName)
            {
                trigger.triggerText(animation.AName, animation.ADesc, canvasTitle, canvasBody);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
