using System.Text.Json;
using RulinkApi.Models.PkiService;

namespace RulinkApi.Models.CryptoService;

/// <summary>
/// Результат проверки подписи
/// </summary>
/// <param name="isFileVerificationSuccess"></param>
/// <param name="signatures"></param>
/// <param name="dataFileLen"></param>
/// <param name="sigFileLen"></param>
public class SignatureVerificationResult (SignatureDetails[] signatures, long dataFileLen, long sigFileLen)
{
    public SignatureVerificationResult() : this([], 0, 0)
    {
    }
    
    /// <summary>
    /// Общий результат проверки файла подписи
    /// </summary>
    public bool IsFileVerificationSuccess {
        get
        {
            if (Signatures.Length == 0)
                return false;
            return Signatures.Any(s => s?.IsFileMatch == true || 
                                       s?.IsValidNow == true || 
                                       s?.RevocatedDetails?.IsRevocated != true || 
                                       s.CaDetails?.IsAccredited == true);
        }}

    /// <summary>
    /// Данные о подписях
    /// </summary>
    public SignatureDetails?[] Signatures { get; set; } = signatures;

    /// <summary>
    /// Размер файла данных
    /// </summary>
    public long DataFileLenght { get; set; } = dataFileLen;

    /// <summary>
    /// Размер файла подписи
    /// </summary>
    public long SignatureFileLenght { get; set; } = sigFileLen;

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
    
    public static SignatureVerificationResult FromJson(string data)
    {
        return JsonSerializer.Deserialize<SignatureVerificationResult>(data, new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true }) ?? 
               new SignatureVerificationResult();
    }
    
    public void UpdateRevocationDetails(CertificateRevocationInfo revocationInfo)
    {
        foreach (var signature in Signatures)
        {
             
        }
    }
}