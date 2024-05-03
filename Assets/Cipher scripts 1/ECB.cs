using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using TMPro;

public class ECB : MonoBehaviour
{
    public TMP_InputField clearTextInput;
    public TMP_InputField key;
    public TMP_Dropdown block_size;

    public Toggle gen_new_key;
    public TMP_InputField encryptedText;
    public TextMeshProUGUI decryptedText;

    public void Encrypt()
    {
        string plaintext = clearTextInput.text;
        byte[] byte_key;

        if (block_size.value==0){
            // Create a byte array to hold the random key
            byte_key = new byte[16]; 
        }
        else if (block_size.value==1){
            byte_key = new byte[24];
        }
        else{
            byte_key = new byte[32];
        }
        
        if (gen_new_key.isOn){
            // Generate random bytes to fill the array
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(byte_key);
            }
            Debug.Log("different");
            // Display generated key
            key.text=Convert.ToBase64String(byte_key);
        }
        else{
            byte_key = Encoding.UTF8.GetBytes(key.text);
            Debug.Log("same");
        }
        
        byte[] encryptedBytes = EncryptStringToBytes_ECB(plaintext, byte_key);
        string encryptedString = Convert.ToBase64String(encryptedBytes);
        encryptedText.text = encryptedString;   
    }

    static byte[] EncryptStringToBytes_ECB(string plainText, byte[] Key)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.Mode = CipherMode.ECB; // Set the encryption mode to ECB

            // Create an encryptor to perform the stream transform.
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for encryption.
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                    }
                }
                return msEncrypt.ToArray();
            }
        }
    }

    static string DecryptStringFromBytes_ECB(byte[] cipherText, byte[] Key)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.Mode = CipherMode.ECB; // Set the decryption mode to ECB

            // Create a decryptor to perform the stream transform.
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for decryption.
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}