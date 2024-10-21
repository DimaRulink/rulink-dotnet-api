using System.Text;

namespace RulinkApi.HttpClient;

public static class Client
{
    /// <summary>
    /// Запрос GET к API
    /// </summary>
    /// <param name="url"></param>
    /// <param name="headers"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<string> GetAsync(Uri url, IDictionary<string,string> headers, CancellationToken cancellationToken)
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
        using var client = new System.Net.Http.HttpClient(clientHandler);
        foreach (var onekey in headers.Keys)
        {
            client.DefaultRequestHeaders.Add(onekey, headers[onekey]);
        }
        var response = await client.GetAsync(url, cancellationToken);
        return await response.Content.ReadAsStringAsync(cancellationToken);
    }
    
    /// <summary>
    /// Запрос GET с ответом в виде byte[]
    /// </summary>
    /// <param name="url"></param>
    /// <param name="apikey"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<byte[]> DownloadAsync(Uri url, string apikey, CancellationToken cancellationToken)
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

        using var client = new System.Net.Http.HttpClient(clientHandler);
        client.DefaultRequestHeaders.Add("Authorization", $"Apikey {apikey}");
        var response = await client.GetAsync(url, cancellationToken);
        return await response.Content.ReadAsByteArrayAsync(cancellationToken);
    }

    /// <summary>
    /// Запрос POST к API
    /// </summary>
    /// <param name="url"></param>
    /// <param name="content"></param>
    /// <param name="headers"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<string> PostAsync(Uri url, string? content, IDictionary<string,string> headers, CancellationToken cancellationToken)
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
        using var client = new System.Net.Http.HttpClient(clientHandler);
        foreach (var onekey in headers.Keys)
        {
            client.DefaultRequestHeaders.Add(onekey, headers[onekey]);
        }
        
        HttpResponseMessage response;
        if (!string.IsNullOrEmpty(content))
        {
            var strcontent = new StringContent(content, Encoding.UTF8, "application/json");
            response = await client.PostAsync(url, strcontent, cancellationToken);
        }
        else
            response = await client.PostAsync(url, null, cancellationToken);
        return await response.Content.ReadAsStringAsync(cancellationToken);
    }
    
    // /// <summary>
    // /// Отправка PUT запроса 
    // /// </summary>
    // /// <param name="url"></param>
    // /// <param name="apikey"></param>
    // /// <param name="content"></param>
    // /// <param name="cancellationToken"></param>
    // /// <returns></returns>
    // public static async Task<string> PutAsync(Uri url, string apikey, string? content, CancellationToken cancellationToken)
    // {
    //     HttpClientHandler clientHandler = new HttpClientHandler();
    //     clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
    //
    //     using var client = new System.Net.Http.HttpClient(clientHandler);
    //     client.DefaultRequestHeaders.Add("Authorization", $"Apikey {apikey}");
    //     HttpResponseMessage response;
    //     if (!string.IsNullOrEmpty(content))
    //     {
    //         var strcontent = new StringContent(content, Encoding.UTF8, "application/json");
    //         response = await client.PutAsync(url, strcontent, cancellationToken);
    //     }
    //     else
    //         response = await client.PutAsync(url, null, cancellationToken);
    //     return await response.Content.ReadAsStringAsync(cancellationToken);
    // }
    
    
    /// <summary>
    /// Запрос PUT API
    /// </summary>
    /// <param name="url"></param>
    /// <param name="content"></param>
    /// <param name="headers"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<string> PutAsync(Uri url, string? content, IDictionary<string,string> headers, CancellationToken cancellationToken)
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
        using var client = new System.Net.Http.HttpClient(clientHandler);
        foreach (var onekey in headers.Keys)
        {
            client.DefaultRequestHeaders.Add(onekey, headers[onekey]);
        }
        
        HttpResponseMessage response;
        if (!string.IsNullOrEmpty(content))
        {
            var strcontent = new StringContent(content, Encoding.UTF8, "application/json");
            response = await client.PutAsync(url, strcontent, cancellationToken);
        }
        else
            response = await client.PutAsync(url, null, cancellationToken);
        return await response.Content.ReadAsStringAsync(cancellationToken);
    }
    
    
    
    
    
    /// <summary>
    /// Загрузка файла через API
    /// </summary>
    /// <param name="url"></param>
    /// <param name="fileData"></param>
    /// <param name="headers"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<string> UploadFileAsync(Uri url, byte[] fileData, IDictionary<string,string> headers, CancellationToken cancellationToken)
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

        using var client = new System.Net.Http.HttpClient(clientHandler);
        foreach (var onekey in headers.Keys)
        {
            client.DefaultRequestHeaders.Add(onekey, headers[onekey]);
        }
        if (fileData.Any())
        {
            var multipartContent = new MultipartFormDataContent($"Upload----{DateTime.Now.Ticks}");
            multipartContent.Add(new StreamContent(new MemoryStream(fileData)), "file1", DateTime.Now.Ticks.ToString());
            HttpResponseMessage response = await client.PostAsync(url, multipartContent, cancellationToken);
            return await response.Content.ReadAsStringAsync(cancellationToken);
        }
        throw new ArgumentNullException($"Request with URL={url} Exception: File content is empty");
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    // /// <summary>
    // /// Загрузка файла через API
    // /// </summary>
    // /// <param name="url"></param>
    // /// <param name="apikey"></param>
    // /// <param name="filename"></param>
    // /// <param name="fileData"></param>
    // /// <param name="cancellationToken"></param>
    // /// <returns></returns>
    // public static async Task<string> UploadFileAsync(Uri url, string apikey, byte[] fileData, CancellationToken cancellationToken)
    // {
    //     HttpClientHandler clientHandler = new HttpClientHandler();
    //     clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
    //
    //     using var client = new System.Net.Http.HttpClient(clientHandler);
    //     client.DefaultRequestHeaders.Add("Authorization", $"Apikey {apikey}");
    //     if (fileData.Any())
    //     {
    //         var multipartContent = new MultipartFormDataContent($"Upload----{DateTime.Now.Ticks}");
    //         multipartContent.Add(new StreamContent(new MemoryStream(fileData)), "file1", DateTime.Now.Ticks.ToString());
    //         HttpResponseMessage response = await client.PostAsync(url, multipartContent, cancellationToken);
    //         return await response.Content.ReadAsStringAsync(cancellationToken);
    //     }
    //     throw new ArgumentNullException($"Request with URL={url} Exception: File content is empty");

    
    /// <summary>
    /// Запрос GET с ответом в виде byte[]. Метод для скачивания контета с внешних сайтов
    /// </summary>
    /// <param name="url"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<byte[]> WildDownloadAsync(Uri url, CancellationToken cancellationToken)
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
        using var client = new System.Net.Http.HttpClient(clientHandler);
        var response = await client.GetAsync(url, cancellationToken);
        return await response.Content.ReadAsByteArrayAsync(cancellationToken);
    }
}