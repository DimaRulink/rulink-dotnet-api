using RulinkApi.Models.CryptoService.Signers;

namespace RulinkApi.Models.CryptoService.SignPackages;

public class SignPackageFile
{
    public string? Id { get; set; }
    public string? FileName { get; set; }
    public string? ContentUrl { get; set; }
    public long Size { get; set; }
    public string? OwnerId { get; set; }
    public DateTime UploadedAt { get; set; }
    public string? OwnerUsername { get; set; }
    
    public bool IsSigned { get; set; }
    
    public List<SignerAssigned?>? AssignedSigners { get; set; }
}
    