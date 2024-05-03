using UnityEngine;

public class GenerateCryptoInfo
{
    public static string GenerateCryptographicInformation()
    {
        string cryptoInfo = "SUPPORTED CIPHER SUITE: TLS_AES_256_GCM_SHA384\n";
        cryptoInfo += "VERSION: TLS 1.3\n";
        cryptoInfo += $"CLIENT-GENERATED NUMBER: {Random.Range(1000000000, 9000000000)}";
        return cryptoInfo;
    }
}
