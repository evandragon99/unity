using UnityEngine;
using TMPro;

public class Program : MonoBehaviour
{
    // managers for user input
    private DropdownManager dropdownManager;

    private KeyManager keyManager;
    private RingManager ringManager;
    private PlugboardManager plugboardManager;
    private KeyboardManager keyboardManager;

    private Enigma enigmaMachine;

    private string cipherText;


    //ANIMATION TMP_TEXT
    public TMP_Text inputDisplay;
    public TMP_Text plugboardSwap;
    public TMP_Text rotor3Swap;
    public TMP_Text rotor2Swap;
    public TMP_Text rotor1Swap;
    public TMP_Text reflectorSwap;
    public TMP_Text rotor1SwapReverse;
    public TMP_Text rotor2SwapReverse;
    public TMP_Text rotor3SwapReverse;
    public TMP_Text plugboardSwapReverse;
    public TMP_Text lampboardDisplay;



    private void Start()
    {
        dropdownManager = FindObjectOfType<DropdownManager>();
        keyManager = FindObjectOfType<KeyManager>();
        ringManager = FindObjectOfType<RingManager>();
        plugboardManager = FindObjectOfType<PlugboardManager>();
        keyboardManager = FindObjectOfType<KeyboardManager>();
    }

    public void OnSettingsChanged()
    {
        SetupEnigmaMachine();
    }

    public void SetupEnigmaMachine()
    {
        cipherText = "";

        string reflectorString = dropdownManager.GetReflectorDropdownValue();
        (string rotorWiring, char rotorNotch) rotor1String = dropdownManager.GetRotorDropdownValue(dropdownManager.rotorDropdown1);
        (string rotor2Wiring, char rotor2Notch) rotor2String = dropdownManager.GetRotorDropdownValue(dropdownManager.rotorDropdown2);
        (string rotor3Wiring, char rotor3Notch) rotor3String = dropdownManager.GetRotorDropdownValue(dropdownManager.rotorDropdown3);


        Reflect selectedReflector = new Reflect(reflectorString);
        Rotor selectedRotor1 = new Rotor(rotor1String.rotorWiring, rotor1String.rotorNotch);
        Rotor selectedRotor2 = new Rotor(rotor2String.rotor2Wiring, rotor2String.rotor2Notch);
        Rotor selectedRotor3 = new Rotor(rotor3String.rotor3Wiring, rotor3String.rotor3Notch);
        
        //NOT SURE WHY THIS WORKS BUT IT DOES
        int[] rings = new int[3];
        rings = ringManager.GetRingInput(ringManager.ring1Input.text, 0, ringManager.ring1Input); 
        rings = ringManager.GetRingInput(ringManager.ring2Input.text, 1, ringManager.ring2Input); 
        rings = ringManager.GetRingInput(ringManager.ring3Input.text, 2, ringManager.ring3Input); 
        
        char[] key = keyManager.GetKeyInput(keyManager.keyInput.text);

        string[] plugboardPairs = plugboardManager.GetPlugboardInput(plugboardManager.plugboardInput.text);
        string keyboardInput = keyboardManager.GetInputText(keyboardManager.keyboardInput.text);
        Plugboard plugboard = new Plugboard(plugboardPairs);
        Keyboard keyboard = new Keyboard();

        enigmaMachine = new Enigma(selectedReflector, selectedRotor1, selectedRotor2, selectedRotor3, plugboard, keyboard);

        enigmaMachine.SetRings(rings);
        enigmaMachine.SetKey(key);

        foreach (char letter in keyboardInput)
        {
            cipherText += enigmaMachine.Encipher(letter);
        }
        
        // Debug.Log($"Keyboard Input: {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[0])}\n" +
        //     $"Plugboard Switch: {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[0])} -> {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[1])}\n" +
        //     $"Rotor 3: {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[1])} -> {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[2])}\n" +
        //     $"Rotor 2: {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[2])} -> {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[3])}\n" +
        //     $"Rotor 1: {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[3])} -> {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[4])}\n" +
        //     $"Reflector: {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[4])} -> {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[5])}\n" +
        //     $"Rotor 1 Reverse: {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[5])} -> {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[6])}\n" +
        //     $"Rotor 2 Reverse: {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[6])} -> {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[7])}\n" +
        //     $"Rotor 3 Reverse: {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[7])} -> {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[8])}\n" +
        //     $"Plugboard Reverse: {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[8])} -> {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[9])}\n" +
        //     $"Lampboard: {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[10])}");
            
        if (!string.IsNullOrEmpty(keyboardInput))
        { 
            inputDisplay.SetText(Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[0]));

            //reversed arrows for clarity
            plugboardSwap.SetText($"{Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[1])} <- {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[0])}");
            rotor3Swap.SetText($"{Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[2])} <- {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[1])}");
            rotor2Swap.SetText($"{Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[3])} <- {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[2])} ");
            rotor1Swap.SetText($"{Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[4])} <- {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[3])}");

            reflectorSwap.SetText($"<- {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[4])} {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[5])} ->");

            rotor1SwapReverse.SetText($"{Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[5])} -> {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[6])}");
            rotor2SwapReverse.SetText($"{Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[6])} -> {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[7])}");
            rotor3SwapReverse.SetText($"{Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[7])} -> {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[8])}");

            plugboardSwapReverse.SetText($"{Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[8])} -> {Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[9])}");
            lampboardDisplay.SetText($"{Enigma.ConvertToLetter(enigmaMachine.encryptionPathArray[10])}");
        }
        else
        {
            inputDisplay.SetText("");
            plugboardSwap.SetText("");
            rotor3Swap.SetText("");
            rotor2Swap.SetText("");
            rotor1Swap.SetText("");
            reflectorSwap.SetText("");
            rotor1SwapReverse.SetText("");
            rotor2SwapReverse.SetText("");
            rotor3SwapReverse.SetText("");
            plugboardSwapReverse.SetText("");
            lampboardDisplay.SetText("");
        }


        keyboardManager.outputText.SetText(cipherText);
        
        // Debug.Log($"Enigma Machine Settings:\nReflector: {reflectorString}\nRotor 1: {rotor1String.rotorWiring}, Notch: {rotor1String.rotorNotch}\nRotor 2: {rotor2String.rotor2Wiring}, Notch: {rotor2String.rotor2Notch}\nRotor 3: {rotor3String.rotor3Wiring}, Notch: {rotor3String.rotor3Notch}\nRings: {string.Join(", ", rings)}\nKey: {string.Join(", ", key)}\nPlugboard Pairs: {string.Join(", ", plugboardPairs)}\nKeyboard Input: {keyboardInput}");

    }
}
