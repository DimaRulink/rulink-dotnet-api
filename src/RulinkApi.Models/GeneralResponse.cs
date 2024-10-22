using System.Text.Json;

namespace RulinkApi.Models;

public class GeneralResponse(bool isSuccess, string message, string traceId)
{
    /// <summary>
    /// Общий результат выполнения запроса
    /// </summary>
    public bool IsSuccess { get; set; } = isSuccess;

    /// <summary>
    /// Сообщение о результате выполнения запроса/Ошибка выполнения
    /// </summary>
    public string Message { get; set; } = message;

    /// <summary>
    /// TraceId запроса
    /// </summary>
    public string TraceId { get; set; } = traceId;

    public GeneralResponse(): this(false, string.Empty, string.Empty)
    {
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
    
    public static GeneralResponse FromJson(string json)
    {
        return JsonSerializer.Deserialize<GeneralResponse>(json, new JsonSerializerOptions {PropertyNameCaseInsensitive = true}) ??
               new GeneralResponse(false, "Ошибка десериализации", string.Empty);
    }
}