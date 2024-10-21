using System.Text.Json;


namespace RulinkApi.Models.CryptoService;

/// <summary>
/// 
/// </summary>
public class SignatureUpdateResponse: GeneralResponse
{
    public byte[] NewSignatures { get; set; }
    public SignatureUpdateResponse()
    {
        NewSignatures = Array.Empty<byte>();
    }
    public SignatureUpdateResponse(bool isSuccess, string message, string traceid, byte[]? newSigByteArray) : base(isSuccess, message, traceid)
    {
        this.NewSignatures = newSigByteArray ?? [];
    }
    
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
    
    public new static SignatureUpdateResponse FromJson(string json)
    {
        return JsonSerializer.Deserialize<SignatureUpdateResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ??
               new SignatureUpdateResponse(false, "Ошибка десериализации", string.Empty, null);
    }
}