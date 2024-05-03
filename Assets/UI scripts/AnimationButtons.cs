using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AnimationButtons : MonoBehaviour { 
    public GameObject buttonPrefab;
    public GameObject canvasParent;
    public TextMeshProUGUI textMeshPro;
    public List<CipherAnimation> Animations = new List<CipherAnimation>();
    // Start is called before the first frame update
    void Start()
    {
        Animations.Add(new CipherAnimation("Enigma", "The Enigma encryption was a complex cipher machine used primarily by the German military during World War II to encode messages. It consisted of rotating wheels (known as rotors), which substituted letters according to a predetermined configuration."));
        Animations.Add(new CipherAnimation("Electronic code book (ECB)", "ECB (Electronic Codebook) encryption is a basic symmetric encryption mode used to encrypt plaintext into ciphertext."));
        Animations.Add(new CipherAnimation("Message authentication code (MAC)", "MAC (Message Authentication Code) encryption involves generating a tag based on a message and a secret key."));
        foreach (CipherAnimation current_CipherAnimation in Animations)
        {
            textMeshPro.text = current_CipherAnimation.AName;
            GameObject currentButton = Instantiate(buttonPrefab, canvasParent.transform, false);
            //currentButton.GetComponent<Text>() = current_CipherAnimation.QName;
            //textMeshPro.text = current_CipherAnimation.QName;


        }
        Destroy(buttonPrefab);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
