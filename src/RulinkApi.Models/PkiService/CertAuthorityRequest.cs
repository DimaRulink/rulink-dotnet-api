using System.Text.Json;

namespace RulinkApi.Models.PkiService;

public class CertAuthorityRequest
{
    /// <summary>
    /// ОГРН удостоверяющего центра, выдавшего сертификат (для КЭП)
    /// </summary>
    /// <example>1027700071530</example>
    public string Ogrn { get; set; }
    /// <summary>
    /// Название издателя сертификата (для УНЭП)
    /// </summary>
    /// <example>Госуслуги. Неквалифицированная электронная подпись</example>
    public string IssuerCn { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
    
    public static CertAuthorityRequest FromJson(string json)
    {
        return JsonSerializer.Deserialize<CertAuthorityRequest>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}