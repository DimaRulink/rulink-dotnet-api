using RulinkApi.Models.PkiService;

namespace RulinkApi.Models.CryptoService;

/// <summary>
/// Информация о подписи и данные подписанта
/// </summary>
public class SignatureDetails
{
    public string? CompanyName { get; set; }
    public string? Subject { get; set; }
    public string? SubjectEmail { get; set; }
    public string? City { get; set; }
    public string? SerialNumber { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime ValidBefore { get; set; }
    public DateTime SignedDate { get; set; }
    public string? Position { get; set; }
    public string? Algorithm { get; set; }
    public bool IsValidNow { get; set; } 
    public bool IsFileMatch { get; set; }
    public CertificateRevocationInfo? RevocatedDetails { get; set; }
    public CertificateAuthorityInfo? CaDetails { get; set; }
    
    /// <summary>
    /// Summary signature status
    /// </summary>
    /// <returns></returns>
    public KeyValuePair<bool, string> GetSignatureStatus()
    {
        if (!this.IsFileMatch)
            return new KeyValuePair<bool, string>(false, "Подпись не соответствует данным или файл данных был изменен после подписания");
        if (this.RevocatedDetails?.IsRevocated == true)
            return new KeyValuePair<bool, string>(false, "Сертификат электронной подписи отозван. Подпись не действительна");
        if (!this.IsValidNow)
            return new KeyValuePair<bool, string>(false, "Подпись соответствует данным, но строк действия подписи истек");
        if (this.CaDetails?.IsAccredited == false)
        {
            if (this.CaDetails?.IsTrusted == true)
                return new KeyValuePair<bool, string>(false, $"Подпись соответствует данным. Удостоверяющий центр не имеет действующей аккредитации, но некоторые организации ему доверяют. УЦ: {CaDetails?.Title} Статус: {CaDetails?.Status} Ссылка: {CaDetails?.Url}");
            return new KeyValuePair<bool, string>(false, $"Подпись соответствует данным, но удостоверяющий центр не имеет действующей аккредитации. УЦ: {CaDetails?.Title} Статус: {CaDetails?.Status}");
        }
        return new KeyValuePair<bool, string>(true, $"Подпись действующая");
    }
    
    public void UpdateRevocationInfo(CertificateRevocationInfo? revocationInfo)
    {
        if (this.RevocatedDetails == null)
            this.RevocatedDetails = revocationInfo;
        else
            this.RevocatedDetails.Update(revocationInfo);
    }
    
    public void UpdateCertAuthorityInfo(CertificateAuthorityInfo? caDetails)
    {
        if (this.CaDetails == null)
            this.CaDetails = caDetails;
        else
            this.CaDetails.Update(caDetails);
    }
}