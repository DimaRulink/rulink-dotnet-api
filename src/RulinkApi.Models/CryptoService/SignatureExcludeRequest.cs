using System.Text.Json;

namespace RulinkApi.Models.CryptoService;

/// <summary>
/// Запрос на исключение подписантов из файла подписи
/// </summary>
public class SignatureExcludeRequest : SignatureRequest
{
    /// <summary>
    /// Серийные номера сертификатов для исключения
    /// </summary>
    public string[] SerialNumberArray { get; set; }

    public SignatureExcludeRequest()
    {
        SerialNumberArray = Array.Empty<string>();
    }
    /// <summary>
    /// Запрос на исключение подписантов из файла подписи.
    /// Единственную подпись в файле ислючить нельзя.
    /// Если несколько одинарных подписей, то исключается одна из них.
    /// </summary>
    /// <param name="signatureFile"></param>
    /// <param name="certificateSNArray">Массив SN сертификатов для исключения</param>
    public SignatureExcludeRequest(byte[]? signatureFile, IEnumerable<string> certificateSNArray):base(signatureFile)
    {
        SerialNumberArray = certificateSNArray.ToArray();
    }


    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}