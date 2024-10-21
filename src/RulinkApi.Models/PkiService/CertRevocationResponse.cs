using System.Text.Json;

namespace RulinkApi.Models.PkiService;

public class CertRevocationResponse : GeneralResponse
{
    public CertificateRevocationInfo RevocationInfo { get; set; }

    public CertRevocationResponse(){}
    
    public CertRevocationResponse(bool success, string message, string traceid, CertificateRevocationInfo certRevocInfo) : base(success, message, traceid)
    {
        RevocationInfo = certRevocInfo;
    }
    
    public CertRevocationResponse(bool success, string message, string traceid) : base(success, message, traceid)
    { 
    }
    
    public static CertRevocationResponse FromJson(string json)
    {
        return JsonSerializer.Deserialize<CertRevocationResponse>(json, new JsonSerializerOptions() {PropertyNameCaseInsensitive = true}) ?? 
               new CertRevocationResponse(false, $"Ошибка десериализации. Json: {json}", "");
    }
    
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
    
}