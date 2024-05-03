using UnityEngine;
using TMPro;

public class SSL_slide_2  : MonoBehaviour
{
    public TMP_InputField clientCryptoInformation;
    public TextMeshProUGUI clientStatus;
    public TextMeshProUGUI serverStatus;
    // 2
    public void ServerHello()
    {
        clientCryptoInformation.text = "USING " + GenerateCryptoInfo.GenerateCryptographicInformation().Split("\n")[0];
        clientCryptoInformation.text +=
            "\nCertificate:\t0569a72a23ea2234562515d477c93056963cd3ccffb7f43e5cfbca61f259748c";
        clientCryptoInformation.text +=
            "\nPublic Key:\tf1cd7669b2e495a46eed6927a4377e7c82140803c600bd3ade7972d8bade49ea";
        clientStatus.text = "VERIFYING... [Select 'Next']";
        serverStatus.text = "MESSAGE SENT!";
    }
}