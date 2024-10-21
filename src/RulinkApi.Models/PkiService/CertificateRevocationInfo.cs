namespace RulinkApi.Models.PkiService;

public class CertificateRevocationInfo
{
    /// <summary>
    /// Признак отозванности сертификата
    /// </summary>
    public bool IsRevocated { get; set; } = false;
    /// <summary>
    /// Дата отзыва сертификата
    /// </summary>
    public DateTime? RevocatedDate { get; set; } = null;
    /// <summary>
    /// Причина отзыва сертификата (если есть)
    /// </summary>
    public string? RevocatedDescription { get; set; } = null;
    /// <summary>
    /// Ссылка на CRL, на основании которого был сделан вывод об отзыве сертификата
    /// </summary>
    public string CrlUrl { get; set; } = string.Empty;
    public override string ToString()
    {
        return $"IsRevocated: {IsRevocated}; RevocatedDate: {RevocatedDate}; RevocatedDescription: {RevocatedDescription}; CrlUrl: {CrlUrl}";
    }

    public void Update(CertificateRevocationInfo? info)
    {
        if (info is null) return;
        IsRevocated = info.IsRevocated;
        RevocatedDate = info.RevocatedDate;
        RevocatedDescription = info.RevocatedDescription;
        if (string.IsNullOrEmpty(CrlUrl))
            this.CrlUrl = info.CrlUrl;
    }
}