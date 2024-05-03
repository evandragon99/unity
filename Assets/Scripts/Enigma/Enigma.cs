using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using JetBrains.Annotations;

public class Enigma
{
    private Reflect reflector;
    private Rotor rotor1;
    private Rotor rotor2;
    private Rotor rotor3;
    private Plugboard plugboard;
    private Keyboard keyboard;
    public int[] encryptionPathArray = new int[11];

    public Enigma(Reflect reflector, Rotor rotor1, Rotor rotor2, Rotor rotor3, Plugboard plugboard, Keyboard keyboard)
    {
        this.reflector = reflector;
        this.rotor1 = rotor1;
        this.rotor2 = rotor2;
        this.rotor3 = rotor3;
        this.plugboard = plugboard;
        this.keyboard = keyboard;
    }

    public void SetRings(int[] rings)
    {
        rotor1.SetRing(rings[0]);
        rotor2.SetRing(rings[1]);
        rotor3.SetRing(rings[2]);
    }

    public void SetKey(char[] key)
    {
        rotor1.RotateToLetter(key[0]);
        rotor2.RotateToLetter(key[1]);
        rotor3.RotateToLetter(key[2]);
    }

    public char Encipher(char letter)
    {
        if (rotor2.left[0] == rotor2.notch && rotor3.left[0] == rotor3.notch)
        {
            rotor1.Rotate();
            rotor2.Rotate();
            rotor3.Rotate();
        }
        // double step anomaly
        else if (rotor2.left[0] == rotor2.notch)
        {
            rotor1.Rotate();
            rotor2.Rotate();
            rotor3.Rotate();
        }
        else if (rotor3.left[0] == rotor3.notch)
        {
            rotor2.Rotate();
            rotor3.Rotate();
        }
        else
        {
            rotor3.Rotate();
        }

        int signal = keyboard.Forward(letter);
        encryptionPathArray[0] = signal;

        signal = plugboard.Forward(signal);
        encryptionPathArray[1] = signal;

        signal = rotor3.Forward(signal);
        encryptionPathArray[2] = signal;

        signal = rotor2.Forward(signal);
        encryptionPathArray[3] = signal;

        signal = rotor1.Forward(signal);
        encryptionPathArray[4] = signal;

        signal = reflector.Reflects(signal);
        encryptionPathArray[5] = signal;

        signal = rotor1.Backward(signal);
        encryptionPathArray[6] = signal;

        signal = rotor2.Backward(signal);
        encryptionPathArray[7] = signal;

        signal = rotor3.Backward(signal);
        encryptionPathArray[8] = signal;

        signal = plugboard.Backward(signal);
        encryptionPathArray[9] = signal;

        letter = keyboard.Backward(signal);
        encryptionPathArray[10] = signal;

        return letter;
    }
    public static string ConvertToLetter(int number)
    {
        if (number >= 0 && number < 26)
        {
            return ((char)('A' + number)).ToString();
        }
        else
        {
            return "X";
        }
    }
}
