using TMPro;
using UnityEngine;

public class KeyboardManager : MonoBehaviour
{
    [SerializeField] public TMP_InputField keyboardInput;
    public TMP_Text outputText;

    public Keyboard keyboard;

    public string GetInputText(string input)
    {
        input = input.Replace(" ", "").ToUpper();        
        return input;
    }

    
}