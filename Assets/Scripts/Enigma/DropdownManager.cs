using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DropdownManager : MonoBehaviour
{
    [SerializeField] public TMP_Dropdown reflectorDropdown;
    [SerializeField] public TMP_Dropdown rotorDropdown1;
    [SerializeField] public TMP_Dropdown rotorDropdown2;
    [SerializeField] public TMP_Dropdown rotorDropdown3;

    public Reflect selectedReflector;
    public Rotor selectedRotor1;
    public Rotor selectedRotor2;
    public Rotor selectedRotor3;

    public string GetReflectorDropdownValue()
    {
        int index = reflectorDropdown.value;
        string selectedOption = reflectorDropdown.options[index].text;

        switch (selectedOption)
        {
            case "Reflector A":
            case "Reflector B":
            case "Reflector C":
                return ReflectorWiring(selectedOption);
            default:
                Debug.LogError("Invalid selection");
                return null;
        }
    }

    public (string wiring, char notch) GetRotorDropdownValue(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;
        string selectedOption = dropdown.options[index].text;

        switch (selectedOption)
        {
            case "Rotor I":
            case "Rotor II":
            case "Rotor III":
            case "Rotor IV":
            case "Rotor V":
                return RotorWiring(selectedOption);
            default:
                Debug.LogError("Invalid selection");
                return (null, '\0');
        }
    }

    private string ReflectorWiring(string selectedOption)
    {
        switch (selectedOption)
        {
            case "Reflector A":
                return "EJMZALYXVBWFCRQUONTSPIKHGD";
            case "Reflector B":
                return "YRUHQSLDPXNGOKMIEBFZCWVJAT";
            case "Reflector C":
                return "FVPJIAOYEDRZXWGCTKUQSBNMHL";
            default:
                return null;
        }
    }

    private (string wiring, char notch) RotorWiring(string selectedOption)
    {
        switch (selectedOption)
        {
            case "Rotor I":
                return ("EKMFLGDQVZNTOWYHXUSPAIBRCJ", 'Q');
            case "Rotor II":
                return ("AJDKSIRUXBLHWTMCQGZNPYFVOE", 'E');
            case "Rotor III":
                return ("BDFHJLCPRTXVZNYEIWGAKMUSQO", 'V');
            case "Rotor IV":
                return ("ESOVPZJAYQUIRHXLNFTGKDCMWB", 'J');
            case "Rotor V":
                return ("VZBRGITYUPSDNHLXAWMJQOFECK", 'Z');
            default:
                return (null, '\0');
        }
    }
}

