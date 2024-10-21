using RulinkApi.HttpClient;
using RulinkApi.CryptoService.Interfaces;
using RulinkApi.Models;
using RulinkApi.Models.CryptoService;

namespace RulinkApi.CryptoService;

/// <summary>
/// Клиент для работы с сервисом электронной подписи
/// Swagger: https://rulink.io/api/v1/crypto/swagger/index.html
/// </summary>
public class CryptoServiceClient : ICryptoServiceClient
{
    private string BaseUrl { get; }
    public string Apikey { get; set; }
    
    public CryptoServiceClient(string baseUrl)
    {
        BaseUrl = baseUrl;
        Apikey = string.Empty;
    }
    
    public CryptoServiceClient(string baseUrl, string apikey)
    {
        BaseUrl = baseUrl;
        Apikey = apikey;
    }
    
    public void SetApikey(string apikey)
    {
        Apikey = apikey;
    }

    public async Task<GeneralResponse> Ping(CancellationToken cancellationToken)
    {
        var baseUri = new Uri(BaseUrl, UriKind.Absolute);
        var uri = new Uri(baseUri, $"{baseUri.LocalPath}/cms/ping");
        var headers = new Dictionary<string, string>
        {
            {"Authorization", $"Apikey {Apikey}"}
        };
        var jsonResponse = await Client.GetAsync(uri, headers, cancellationToken);
        return GeneralResponse.FromJson(jsonResponse);
    }

    public async Task<SignatureVerificationResponse> VerifySignatureAsync(SignatureVerificationRequest verificationRequest, string? traceid, CancellationToken cancellationToken)
    {
        var baseUri = new Uri(BaseUrl, UriKind.Absolute);
        var uri = new Uri(baseUri, $"{baseUri.LocalPath}/cms/signature/validation");
        var headers = new Dictionary<string, string>
        {
            {"Authorization", $"Apikey {Apikey}"}
        };
        if (!string.IsNullOrEmpty(traceid))
            headers.Add("traceid", traceid);
        var jsonResponse = await Client.PostAsync(uri, verificationRequest.ToString(), headers, cancellationToken);
        return SignatureVerificationResponse.FromJson(jsonResponse);
    }

    public SignatureVerificationResponse VerifySignature(SignatureVerificationRequest verificationRequest, string? traceid)
    {
        return VerifySignatureAsync(verificationRequest, traceid, new CancellationToken()).Result;
    }

    public async Task<SignatureUpdateResponse> MergeSignaturesAsync(SignatureMergeRequest signatureUpdateRequest, string? traceid, CancellationToken cancellationToken)
    {
        var baseUri = new Uri(BaseUrl, UriKind.Absolute);
        var uri = new Uri(baseUri, $"{baseUri.LocalPath}/cms/signature/merge");
        var headers = new Dictionary<string, string>
        {
            {"Authorization", $"Apikey {Apikey}"}
        };
        if (!string.IsNullOrEmpty(traceid))
            headers.Add("traceid", traceid);
        var jsonResponse = await Client.PostAsync(uri, signatureUpdateRequest.ToString(), headers, cancellationToken);
        return SignatureUpdateResponse.FromJson(jsonResponse);
    }

    public SignatureUpdateResponse MergeSignatures(SignatureMergeRequest signatureUpdateRequest, string? traceid)
    {
        return MergeSignaturesAsync(signatureUpdateRequest, traceid, new CancellationToken()).Result;
    }

    public async Task<SignatureUpdateResponse> ExcludeSignersAsync(SignatureExcludeRequest signatureExcludeRequest, string? traceid, CancellationToken cancellationToken)
    {
        var baseUri = new Uri(BaseUrl, UriKind.Absolute);
        var uri = new Uri(baseUri, $"{baseUri.LocalPath}/cms/signature/exclude");
        var headers = new Dictionary<string, string>
        {
            {"Authorization", $"Apikey {Apikey}"}
        };
        if (!string.IsNullOrEmpty(traceid))
            headers.Add("traceid", traceid);
        var jsonResponse = await Client.PostAsync(uri, signatureExcludeRequest.ToString(), headers, cancellationToken);
        return SignatureUpdateResponse.FromJson(jsonResponse);
    }

    public SignatureUpdateResponse ExcludeSigners(SignatureExcludeRequest signatureExcludeRequest, string? traceid)
    {
        return ExcludeSignersAsync(signatureExcludeRequest, traceid, new CancellationToken()).Result;
    }
}