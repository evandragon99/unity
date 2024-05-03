using UnityEngine;
using TMPro;

public class SSL_slide_1 : MonoBehaviour
{
    // 1
    public TMP_InputField clientMessage;
    public TextMeshProUGUI serverStatus;
    public TextMeshProUGUI clientStatus;
    public TMP_InputField clientCryptoInformation;
    
    public void ClientHello()
    {
        serverStatus.text = $"SERVER RECEIVED: {clientMessage.text}";
        clientStatus.text = "MESSAGE SENT!";
        clientCryptoInformation.text = GenerateCryptoInfo.GenerateCryptographicInformation();
    }
}
