using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plugboard
{
    private string left;
    private string right;

    public Plugboard(string[] pairs)
    {
        InitializePlugboard();
        SetupPairs(pairs);
    }

    private void InitializePlugboard()
    {
        left = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        right = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    }

    private void SetupPairs(string[] pairs)
    {
        foreach (string pair in pairs)
        {
            char A = pair[0];
            char B = pair[1];
            int pos_A = left.IndexOf(A);
            int pos_B = left.IndexOf(B);
            left = left.Remove(pos_A, 1).Insert(pos_A, B.ToString());
            left = left.Remove(pos_B, 1).Insert(pos_B, A.ToString());
        }
    }

    public int Forward(int signal)
    {
        char letter = right[signal];
        signal = left.IndexOf(letter);
        return signal;
    }

    public int Backward(int signal)
    {
        char letter = left[signal];
        signal = right.IndexOf(letter);
        return signal;
    }

    public void UpdatePlugboardPairs(string[] newPairs)
    {
        SetupPairs(newPairs);
    }
}
