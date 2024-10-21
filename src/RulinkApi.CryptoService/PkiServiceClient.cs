using RulinkApi.CryptoService.Interfaces;
using RulinkApi.HttpClient;
using RulinkApi.Models.PkiService;

namespace RulinkApi.CryptoService;

public class PkiServiceClient: IPkiServiceClient
{
    private readonly string _baseUrl;
    private string _apikey;

    /// <summary>
    /// </summary>
    /// <param name="baseUrl"></param>
    /// <param name="apikey"></param>
    public PkiServiceClient(string baseUrl, string apikey)
    {
        _baseUrl = baseUrl;
        _apikey = apikey;
    }
    
    public PkiServiceClient(string baseUrl)
    {
        _baseUrl = baseUrl;
        _apikey = string.Empty;
    }
    
    public void SetApikey(string apikey)
    {
        this._apikey = apikey;
    }
    
    public async Task<CertAuthorityResponse> GetCertAuthorityInfoAsync(CertAuthorityRequest request, string? traceid, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(this._apikey)) throw new ArgumentNullException(nameof(_apikey));
        if (string.IsNullOrEmpty(this._baseUrl)) throw new ArgumentNullException(nameof(_baseUrl));
        var baseUri = new Uri(_baseUrl, UriKind.Absolute);
        var uri = new Uri(baseUri, $"{baseUri.LocalPath}/CertAuthority/details");
        var headers = new Dictionary<string, string>
        {
            {"Authorization", $"Apikey {_apikey}"}
        };
        if (!string.IsNullOrEmpty(traceid))
            headers.Add("traceid", traceid);
        var jsonResponse = await Client.PostAsync(uri, request.ToString(), headers, cancellationToken);
        return CertAuthorityResponse.FromJson(jsonResponse);
    }
    
    public async Task<CertRevocationResponse> GetRevocationInfoAsync(CertRevocationRequest request, string? traceid, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(this._apikey)) throw new ArgumentNullException(nameof(_apikey));
        if (string.IsNullOrEmpty(this._baseUrl)) throw new ArgumentNullException(nameof(_baseUrl));
        var baseUri = new Uri(_baseUrl, UriKind.Absolute);
        var uri = new Uri(baseUri, $"{baseUri.LocalPath}/CertRevocation/Certificate");
        var headers = new Dictionary<string, string>
        {
            {"Authorization", $"Apikey {_apikey}"}
        };
        if (!string.IsNullOrEmpty(traceid))
            headers.Add("traceid", traceid);
        var jsonResponse = await Client.PostAsync(uri, request.ToString(), headers, cancellationToken);
        return CertRevocationResponse.FromJson(jsonResponse);
    }

}