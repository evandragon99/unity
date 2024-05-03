using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlugboardManager : MonoBehaviour
{
    [SerializeField] public TMP_InputField plugboardInput;

    public string[] plugboardPairs;

    public Plugboard plugboard;

    public string[] GetPlugboardInput(string input)
    {
        input = input.ToUpper();
        
        //if odd length ignore last character
        if (input.Length % 2 != 0)
        {
            input = input.Substring(0, input.Length - 1);
        }

        List<string> pairsList = new List<string>();

        for (int i = 0; i < input.Length; i += 2)
        {
            string pair = input.Substring(i, 2);
            pairsList.Add(pair);
        }
        plugboardPairs = pairsList.ToArray();
        return plugboardPairs;
    }
}