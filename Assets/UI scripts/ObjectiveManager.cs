using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour
{
    public GameObject objectivePrefab;
    public GameObject canvasParent;
    public TextMeshProUGUI textMeshPro;
    public List<Objective> Objectives = new List<Objective>();
    // Start is called before the first frame update
    void Start()
    {
        Destroy(objectivePrefab);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void addNewObjective(GameObject inputField){
        string objText = inputField.GetComponent<TextMeshProUGUI>().text;
        Objectives.Add(new Objective(objText, false));
        textMeshPro.text = objText;
        GameObject currentButton = Instantiate(objectivePrefab, canvasParent.transform, false);
    }
}
