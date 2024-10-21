using System.Text.Json;

namespace RulinkApi.Models;

public class GeneralResponse
{
    /// <summary>
    /// Общий результат выполнения запроса
    /// </summary>
    public bool IsSuccess { get; set; }
    /// <summary>
    /// Сообщение о результате выполнения запроса/Ошибка выполнения
    /// </summary>
    public string Message { get; set; }
    /// <summary>
    /// TraceId запроса
    /// </summary>
    public string TraceId { get; set; }

    public GeneralResponse(): this(false, string.Empty, string.Empty)
    {
    }
    public GeneralResponse(bool isSuccess, string message, string traceId)
    {
        this.IsSuccess = isSuccess;
        this.Message = message;
        this.TraceId = traceId;
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