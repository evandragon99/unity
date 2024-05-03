using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class QuizButtons : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject canvasParent;
    public TextMeshProUGUI textMeshPro;
    public List<Quiz> Quizzes = new List<Quiz>();
    // Start is called before the first frame update
    void Start()
    {
        Quizzes.Add(new Quiz("test 1", "test desc"));
        Quizzes.Add(new Quiz("test 2", "test desc23"));
        Quizzes.Add(new Quiz("test 3", "test desc23424"));
        foreach (Quiz current_quiz in Quizzes)
        {
            textMeshPro.text = current_quiz.QName;
            GameObject currentButton = Instantiate(buttonPrefab, canvasParent.transform, false);
            //currentButton.GetComponent<Text>() = current_quiz.QName;
            //textMeshPro.text = current_quiz.QName;


        }
        Destroy(buttonPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
