using System.Text.Json;

namespace RulinkApi.Models.CryptoService;

/// <summary>
/// Запрос на проверку подписи
/// </summary>
public class SignatureVerificationRequest : SignatureRequest
{
    /// <summary>
    /// Данные для которых необходимо проверить подпись\
    /// Может быть null, в этом случае будет предоставлена информация о подписи, без проверки
    /// </summary>
    public byte[]? Data { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}