using UnityEngine;
using TMPro;

public class SSL_slide_3 : MonoBehaviour
{
    public TextMeshProUGUI serverStatus;
    public TextMeshProUGUI clientStatus;
    public TMP_InputField clientCryptoInformation;

    public void SendCertificateAndKey()
    {
        serverStatus.text = $"RECEIVED KEY + CERT";
        clientStatus.text = "SENDING KEY + CERT...";
        clientCryptoInformation.text = "Certificate\taead8a65510663112396b7da1650230b762ab6e533e133da84fa9dd08be65663\nPublic key\tf6b903ed2d825c82799bc099be25e6a35d5cdcee270d2f985d3f38953f51798a";
    }
}
