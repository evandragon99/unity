using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskList : MonoBehaviour
{
    public GameObject taskPrefab;
    public GameObject canvasParent;
    public GameObject taskInput;
    public TextMeshProUGUI taskText;
    public Button deleteButton;

    public HomeCircle hc;

    
    public List<GameObject> objectives = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addNewTask(GameObject inputBox){
        //takes UI input field as arg and instantiates a task prefab with that text
        taskText.text = inputBox.GetComponent<TMP_InputField>().text;
        GameObject task = Instantiate(taskPrefab, canvasParent.transform, false);
        task.SetActive(true);
        objectives.Add(task);
        inputBox.GetComponent<TMP_InputField>().text="";
    }

    public void removeTask(GameObject taskToRemove){
        //takes UI input field as arg and instantiates a task prefab with that text
        objectives.Remove(taskToRemove);
        Destroy(taskToRemove);
        hc.updateFill(canvasParent);
    }


}
