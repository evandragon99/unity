using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class HoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI hoverText; //object to be modified
    public string textToShow; //content of the displayed text

    public float modify_x; //add/subtract the x value of the text displayed
    
    public float modify_y; //add/subtract the y value of the text displayed

    public float modify_z; //add/subtract the z value of the text displayed
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Set the text and position it near the Image
        hoverText.text = textToShow;
        hoverText.transform.position = new Vector3(transform.position.x + modify_x, transform.position.y + modify_y, transform.position.z + modify_z);
        hoverText.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Hide the text
        hoverText.gameObject.SetActive(false);
    }
}