using System.Text.Json;


namespace RulinkApi.Models.CryptoService;

/// <summary>
/// Базовый класс для запросов к сервису криптографии
/// </summary>
public class SignatureRequest(byte[] signature)
{
    public byte[] Signature { get; set; } = signature;

    public SignatureRequest() : this(Array.Empty<byte>())
    {
    }
}