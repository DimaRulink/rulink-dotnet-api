using System.Text.Json;

namespace RulinkApi.Models.PkiService;

public class CertAuthorityResponse : GeneralResponse
{
    public CertificateAuthorityInfo? CertificateAuthorityInfo { get; set; }
    
    public CertAuthorityResponse(){}
    public CertAuthorityResponse(bool isSuccess, string message, string traceid, CertificateAuthorityInfo certificateAuthorityInfo) : base(isSuccess, message, traceid)
    {
        CertificateAuthorityInfo = certificateAuthorityInfo;
    }
    
    public CertAuthorityResponse(bool isSuccess, string message, string traceid) : base(isSuccess, message, traceid)
    {
        CertificateAuthorityInfo = null;
    }
    
    public new static CertAuthorityResponse FromJson(string json)
    {
        return JsonSerializer.Deserialize<CertAuthorityResponse>(json, new JsonSerializerOptions() {PropertyNameCaseInsensitive = true}) ?? 
               new CertAuthorityResponse(false, $"Ошибка десериализации. Json: {json}", "");
    }
    
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}