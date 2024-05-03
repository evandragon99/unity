using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using TMPro;
using UnityEditor.VersionControl;
using SecureAnimClient;

public class Login : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;

    public void login(){
        // Debug.Log("Connecting to server...");
        // Client client = new Client();
        // Debug.Log("Connected, logging in...");
        // if (client.Login(username.text, password.text)){
        //     Debug.Log("Logged in successfully!");
        // }
        // else{
        //     Debug.Log("unable to login...");
        // }
    }
}