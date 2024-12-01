using System.Text.Json;

namespace RulinkApi.Models.CryptoService.SignPackages;

public class SignPackagesResponse : GeneralResponse
{
    public SignPackage[]? Packages { get; set; }
    
    public SignPackagesResponse():base(false, null, null)
    {
        Packages = [];
    }
    public SignPackagesResponse(bool success, string? message, string? traceid, SignPackage[]? packages):base(success, message, traceid)
    {
        Packages = packages ?? [];
    }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
    
    public new static SignPackagesResponse FromJson(string json)
    {
        return JsonSerializer.Deserialize<SignPackagesResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ??
               new SignPackagesResponse(false, "Ошибка десериализации", string.Empty, null);
    }
}