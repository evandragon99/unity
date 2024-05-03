using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using TMPro;
using UnityEditor.VersionControl;

public class HMAC : MonoBehaviour
{
    public TMP_InputField senderMessage; // THIS IS THE TOP LEFT TEXT FIELD THAT IS USED AS INPUT (string plaintext = inputMessage1.text;)
    public TMP_InputField receiverMessage;

    public TMP_InputField receiverMac;
    public TMP_InputField middleMessage;
    public TMP_InputField middleMac;

    public TMP_InputField OGMac;
    public TMP_InputField senderKey;
    public TMP_InputField receiverKey;
    public TMP_Dropdown block_size;
    public Toggle gen_new_key;
    public TextMeshProUGUI validationCheckMessage;
    public TMP_InputField senderOutput; // THIS IS THE OUTPUT TEXT FIELD (encryptedText.text = macHexString;)
    public Toggle changeMessage;

    private string GetMacHexString(byte[] byte_key, string plaintext){
        string macHexString = null;

        switch (block_size.value){
            case 0:
                using (HMACSHA1 hmac = new HMACSHA1(byte_key))
                {
                    // Compute the MAC for the message
                    byte[] macBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(plaintext));
        
                    // Convert the MAC bytes to a hexadecimal string
                    macHexString = BitConverter.ToString(macBytes).Replace("-", "").ToLower();
                }
                break;
            case 1:
                using (HMACSHA256 hmac = new HMACSHA256(byte_key))
                {
                    // Compute the MAC for the message
                    byte[] macBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(plaintext));

                    // Convert the MAC bytes to a hexadecimal string
                    macHexString = BitConverter.ToString(macBytes).Replace("-", "").ToLower();
                }
                break;
            case 2:
                using (HMACSHA512 hmac = new HMACSHA512(byte_key))
                {
                    // Compute the MAC for the message
                    byte[] macBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(plaintext));
        
                    // Convert the MAC bytes to a hexadecimal string
                    macHexString = BitConverter.ToString(macBytes).Replace("-", "").ToLower();
                }
                break;      
        }  
        return macHexString;     
    }
    

    public void GetSenderHash()
    {
        string plaintext = senderMessage.text;

        byte[] byte_key;

        if (block_size.value==0){
            // Create a byte array to hold the random key
            byte_key = new byte[20]; // SHA1
        }
        else if (block_size.value==1){
            byte_key = new byte[32]; // SHA256
        }
        else{
            byte_key = new byte[64]; // SHA512
        }

        if (gen_new_key.isOn){
            // Generate random bytes to fill the array
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(byte_key);
            }
            Debug.Log("different");
            // Display generated key
            senderKey.text=Convert.ToBase64String(byte_key);
        }
        else{
            byte_key = Encoding.UTF8.GetBytes(senderKey.text);
            Debug.Log("same");
        }

        string macHexString = GetMacHexString(byte_key, plaintext);

        senderOutput.text = macHexString;
        receiverKey.text = senderKey.text;

        Copy_values(senderMessage, middleMessage);
        Copy_values(senderOutput, middleMac);
  
        
    }

    public void GetReceiverHash()
    {
        string plaintext = receiverMessage.text;

        byte[] byte_key=Encoding.UTF8.GetBytes(receiverKey.text);

        if (gen_new_key.isOn){
            // Generate random bytes to fill the array
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(byte_key);
            }
            Debug.Log("different");
            // Display generated key
            senderKey.text=Convert.ToBase64String(byte_key);
        }
        else{
            byte_key = Encoding.UTF8.GetBytes(senderKey.text);
            Debug.Log("same");
        }

        string macHexString = GetMacHexString(byte_key, plaintext);

        receiverMac.text = macHexString;

         if (changeMessage.isOn){
            validationCheckMessage.text = "MAC does not match!";
            receiverMessage.text = middleMessage.text + "[ALTERED]";
            receiverMac.text = GetMacHexString(byte_key, plaintext);
        }

        else{
            validationCheckMessage.text = "MAC is valid.";
            receiverMessage.text = middleMessage.text;
            receiverMac.text = middleMac.text;
        }   
    }

    private void Copy_values(TMP_InputField message1, TMP_InputField message2){
        message2.text=message1.text;
    }

    public void SendMessage(){
        
       
        receiverMessage.text = middleMessage.text;
        OGMac.text = middleMac.text;
    }
}