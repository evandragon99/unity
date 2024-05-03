using UnityEngine;
using TMPro;

public class Keyboard
{
    public int Forward(char letter)
    {
        int signal = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(letter);
        return signal;
    }

    public char Backward(int signal)
    {
        char letter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[signal];
        return letter;
    }
}


