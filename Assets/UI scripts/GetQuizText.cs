using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GetQuizText : MonoBehaviour
{
    public UnityEngine.UI.Button this_button;
    public TextMeshProUGUI button_text;
    public TextMeshProUGUI canvasTitle;
    public TextMeshProUGUI canvasBody;


    // Start is called before the first frame update
    void Start()
    {
        
        this_button.onClick.AddListener(ChangeOnClick);
    }

    void ChangeOnClick()
    {
        TextTrigger trigger = FindObjectOfType<TextTrigger>();
        QuizButtons QuizScript = FindObjectOfType<QuizButtons>();
        List<Quiz> QuizList = QuizScript.Quizzes;
        foreach (Quiz quiz in QuizList)
        {
            Console.WriteLine(QuizList.ToString());
            if (button_text.text == quiz.QName)
            {

                trigger.triggerText(quiz.QName, quiz.QDesc, canvasTitle, canvasBody);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
