using System.Text.Json;


namespace RulinkApi.Models.CryptoService;

public class SignatureVerificationResponse: GeneralResponse
{
    /// <summary>
    /// Результаты проверки подписи
    /// </summary>
    public SignatureVerificationResult? VerificationResult { get; set; }
    public SignatureVerificationResponse(bool success, string message, string traceId, SignatureVerificationResult? verificationResult) : base(success, message, traceId)
    {
        VerificationResult = verificationResult;
    }
    
    public SignatureVerificationResponse() : this(false, "", "", null)
    {
    }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
    
    public static SignatureVerificationResponse FromJson(string data)
    {
        return JsonSerializer.Deserialize<SignatureVerificationResponse>(data, new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true }) ?? 
               new SignatureVerificationResponse(false, $"Ошибка десериализации. Json: {data}", "", null);
    }
}