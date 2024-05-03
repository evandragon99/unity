using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SearchScript : MonoBehaviour
{
    public GameObject listHolder;
    public GameObject[] elements;
    public GameObject searchBar;
    public int totalElements;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    public void Search()
    {

        //gather number of list items
        totalElements = listHolder.transform.childCount;
        elements = new GameObject[totalElements];
        //copy list elements to list
        for (int i =0; i <totalElements;i++){
            elements[i] = listHolder.transform.GetChild(i).gameObject;
        }
        //get input text & length
        string searchInput = searchBar.GetComponent<TMP_InputField>().text;
        int searchInputLen = searchInput.Length;

        foreach(GameObject e in elements){
            if (e.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Length>=searchInputLen){
                //if search input == text on button
                if (searchInput.ToLower() == e.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Substring(0,searchInputLen).ToLower()){
                    //set active
                    e.SetActive(true);
                }
                else{
                    //set inactive
                    e.SetActive(false);
                }
            }
            
        }
    }
}
