using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using System;
using System.Security.Cryptography;
using System.IO;
using UnityEngine.UI;

public class CBC : MonoBehaviour
{
    public TMP_InputField clearTextInput;

    public TMP_InputField iv;

    public TMP_InputField key;

    public TMP_Dropdown block_size;
    public TextMeshProUGUI encryptedText;
    public TextMeshProUGUI decryptedText;

    public void Encrypt()
    {
        string plaintext = iv.text;
        // Create a byte array to hold the random key
        byte[] byte_key = new byte[16]; // 128 bits = 16 G
        byte[] byte_iv = new byte[16];

        // Generate random bytes to fill the array
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(byte_key);
        }
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(byte_iv);
        
        }

        iv.text=Convert.ToBase64String(byte_iv);
        key.text=Convert.ToBase64String(byte_key);
        byte[] encryptedBytes = EncryptStringToBytes_CBC(plaintext, byte_key, byte_iv);
        string encryptedString = Convert.ToBase64String(encryptedBytes);
        encryptedText.text = encryptedString;
    }

    static byte[] EncryptStringToBytes_CBC(string plainText, byte[] Key, byte[] IV)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;

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

    static string DecryptStringFromBytes_CBC(byte[] cipherText, byte[] Key, byte[] IV)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;

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
