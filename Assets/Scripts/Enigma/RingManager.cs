using TMPro;
using UnityEngine;

public class RingManager : MonoBehaviour
{
    [SerializeField] public TMP_InputField ring1Input;
    [SerializeField] public TMP_InputField ring2Input;
    [SerializeField] public TMP_InputField ring3Input;

    private int[] rings; // ring settings for each rotor

    void Start()
    {
        rings = new int[3];
    }

    public int[] GetRingInput(string input, int rotorIndex, TMP_InputField inputField)
    {
        int ringValue;

        if (string.IsNullOrEmpty(input))
        {
            ringValue = 1;
        }
        else
        {
            if (int.TryParse(input, out ringValue))
            {
                ringValue = Mathf.Clamp(ringValue, 1, 26);
            }
            else
            {
                ringValue = 1;
            }
        }

        rings[rotorIndex] = ringValue;
        inputField.text = ringValue.ToString();

        return rings;
    }

    // public void RandomiseRingSettings()
    // {
    //     for (int i = 0; i < rings.Length; i++)
    //     {
    //         rings[i] = Random.Range(1, 27);
    //     }

    //     ring1Input.text = rings[0].ToString();
    //     ring2Input.text = rings[1].ToString();
    //     ring3Input.text = rings[2].ToString();
    // }
}
