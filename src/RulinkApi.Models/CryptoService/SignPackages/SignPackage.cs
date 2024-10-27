namespace RulinkApi.Models.CryptoService.SignPackages;

public class SignPackage
{
    public string? Id { get; set; }
    public string? Number { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? CreatorId { get; set; }
    public int Status { get; set; }
    public string? ExternalId { get; set; }
    public string? OrganizationId { get; set; }
    public List<SignPackageFile>? Files { get; set; }
    
    public string? CreatorName { get; set; }
    public string? CreatorUsername { get; set; }
    
    public string GetStatusName()
    {
        return Status switch
        {
            0 => "Черновик",
            1 => "На подписании",
            2 => "Подписан",
            _ => "Неизвестный статус"
        };
    }
}
