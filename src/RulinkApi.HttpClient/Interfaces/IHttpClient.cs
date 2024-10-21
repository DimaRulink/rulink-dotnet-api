namespace RulinkApi.HttpClient.Interfaces;

public interface IHttpClient
{
    /// <summary>
    /// Запрос GET
    /// </summary>
    /// <param name="url"></param>
    /// <param name="apikey"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<string> GetAsync(Uri url, string apikey, CancellationToken cancellationToken);

    /// <summary>
    /// Запрос GET с ответом в виде byte[]
    /// </summary>
    /// <param name="url"></param>
    /// <param name="apikey"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<byte[]> DownloadAsync(Uri url, string apikey, CancellationToken cancellationToken);

    /// <summary>
    /// Отправка POST запроса 
    /// </summary>
    /// <param name="url"></param>
    /// <param name="apikey"></param>
    /// <param name="content"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<string> PostAsync(Uri url, string apikey, string? content, CancellationToken cancellationToken);

    /// <summary>
    /// Отправка PUT запроса 
    /// </summary>
    /// <param name="url"></param>
    /// <param name="apikey"></param>
    /// <param name="content"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<string> PutAsync(Uri url, string apikey, string? content, CancellationToken cancellationToken);

    /// <summary>
    /// Загрузка файла через API
    /// </summary>
    /// <param name="url"></param>
    /// <param name="apikey"></param>
    /// <param name="filename"></param>
    /// <param name="fileData"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<string> UploadFileAsync(Uri url, string apikey, byte[] fileData, CancellationToken cancellationToken);
}