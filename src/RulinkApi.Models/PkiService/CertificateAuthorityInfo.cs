namespace RulinkApi.Models.PkiService;

public class CertificateAuthorityInfo
{
    /// <summary>
    /// Название удостоверяющего центра
    /// </summary>
    /// <example>Федеральная Налоговая Служба</example>
    public string? Title { get; set; }
    /// <summary>
    /// Ссылка на сайт удостоверяющего центра
    /// </summary>
    /// <example>https://www.nalog.ru/rn77/about_fts/uc_fns/</example>
    public string? Url { get; set; }
    /// <summary>
    /// Аккредитованный УЦ (УКЭП)
    /// </summary>
    /// <example>true</example>
    public bool IsAccredited { get; set; }
    /// <summary>
    /// Доверенный УЦ организации (УНЭП)
    /// </summary>
    /// <example>true</example>
    public bool IsTrusted { get; set; }
    /// <summary>
    /// Текущий статус УЦ
    /// </summary>
    /// <example>Действует</example>
    public string? Status { get; set; }
    /// <summary>
    /// Дата последнего обновления статуса
    /// </summary>
    /// <example>2012-08-28T20:00:00</example>
    public DateTime LastStatusUpdate { get; set; }
    /// <summary>
    /// ОГРН удостоверяющего центра
    /// </summary>
    /// <example>1027700071530</example>
    public string? OgrnCode { get; set; }
    /// <summary>
    /// Email удостоверяющего центра
    /// </summary>
    /// <example>uc@nalog.ru</example>
    public string? Email { get; set; }
    
    public override string ToString()
    {
        return $"Title: {this.Title}; Ogrh: {this.OgrnCode}; Status = {this.Status}";
    }
    
    public void Update(CertificateAuthorityInfo? info)
    {
        if (info is null) return; 
        if (string.IsNullOrEmpty(Url))
            this.Url = info.Url;
        if (string.IsNullOrEmpty(Email))
            this.Email = info.Email;
        IsAccredited = info.IsAccredited;
        IsTrusted = info.IsTrusted;
        Status = info.Status;
        LastStatusUpdate = info.LastStatusUpdate;
    }
}