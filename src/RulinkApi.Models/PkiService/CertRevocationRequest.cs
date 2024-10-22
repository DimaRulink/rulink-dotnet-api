using System.Text.Json;

namespace RulinkApi.Models.PkiService;

public class CertRevocationRequest
{
    public string? SerialNumber { get; set; }
    public string? CrlUrl { get; set; }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}