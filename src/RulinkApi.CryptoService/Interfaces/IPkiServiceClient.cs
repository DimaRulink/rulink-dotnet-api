using RulinkApi.Models.PkiService;

namespace RulinkApi.CryptoService.Interfaces;

public interface IPkiServiceClient
{
    /// <summary>
    /// Получение информации об издателе сертификата
    /// </summary>
    /// <param name="request"></param>
    /// <param name="traceid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<CertAuthorityResponse> GetCertAuthorityInfoAsync(CertAuthorityRequest request, string? traceid, CancellationToken cancellationToken);

    /// <summary>
    /// Получение информации из списка отзыва сертификатов
    /// </summary>
    /// <param name="request"></param>
    /// <param name="traceid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<CertRevocationResponse> GetRevocationInfoAsync(CertRevocationRequest request, string? traceid, CancellationToken cancellationToken);
}