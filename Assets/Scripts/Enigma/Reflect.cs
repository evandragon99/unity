using UnityEngine;

public class Reflect
{
    public string left = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public string right;

    public Reflect(string wiring)
    {
        right = wiring;
    }

    public int Reflects(int signal)
    {
        char letter = right[signal];
        signal = left.IndexOf(letter);
        return signal;
    }
}