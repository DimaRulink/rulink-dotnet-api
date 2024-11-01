using System.Text.Json;

namespace RulinkApi.Models.CryptoService.SignPackages;

public class AttachedFileResponse: GeneralResponse
{
    public SignPackageFile? File { get; set; }
    
    public AttachedFileResponse():base(false, "", "")
    {
        File = null;
    }
    public AttachedFileResponse(bool success, string? message, string? error, SignPackageFile? file):base(success, message, error)
    {
        File = file;
    }
    
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
    
    public new static AttachedFileResponse FromJson(string json)
    {
        return JsonSerializer.Deserialize<AttachedFileResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ??
               new AttachedFileResponse(false, "Ошибка десериализации", string.Empty, null);
    }
}