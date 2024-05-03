using UnityEngine;

public class Rotor
{
    public string left;
    public string right;
    public char notch;

    public Rotor(string wiring, char notch)
    {
        left = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        right = wiring;
        this.notch = notch;
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

    public void Rotate(int n = 1, bool forward = true)
    {
        for (int i = 0; i < n; i++)
        {
            if (forward)
            {
                left = left.Substring(1) + left[0];
                right = right.Substring(1) + right[0];
            }
            else
            {
                left = left[25] + left.Substring(0, 25);
                right = right[25] + right.Substring(0, 25);
            }
        }
    }

    public void RotateToLetter(char letter)
    {
        int n = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(letter);
        Rotate(n);
    }

    public void SetRing(int n)
    {
        Rotate(n - 1, false);

        int nNotch = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(notch);
        notch = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[(nNotch - (n - 1) + 26) % 26];
    }
}
