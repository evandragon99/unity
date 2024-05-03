using TMPro;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] public TMP_InputField keyInput;
    public char[] key;

    void Start()
    {
        key = new char[3];
    }

    public char[] GetKeyInput(string input)
    {
        input = keyInput.text.ToUpper();

        input = input.Length > 3 ? input.Substring(0, 3) : input.PadRight(3, 'A');

        key = input.ToCharArray();
        keyInput.text = new string(key);

        return key;
    }
}

