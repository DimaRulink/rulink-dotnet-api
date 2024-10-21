using System.Security;
using RulinkApi.Models;
using RulinkApi.Models.CryptoService;

namespace RulinkApi.CryptoService.Interfaces;

/// <summary>
/// Клиент для работы с сервисом электронной подписи
/// Swagger: https://rulink.io/api/v1/crypto/swagger/index.html
/// </summary>
public interface ICryptoServiceClient
{
    /// <summary>
    /// Проверка доступности сервиса
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<GeneralResponse> Ping(CancellationToken cancellationToken);

    /// <summary>
    /// Проверка электронной подписи и данных
    /// </summary>
    /// <param name="verificationRequest"></param>
    /// <param name="traceid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<SignatureVerificationResponse> VerifySignatureAsync(SignatureVerificationRequest verificationRequest, string? traceid, CancellationToken cancellationToken);

    /// <summary>
    /// Проверка электронной подписи и данных
    /// </summary>
    /// <param name="verificationRequest"></param>
    /// <param name="traceid"></param>
    /// <returns></returns>
    public SignatureVerificationResponse VerifySignature(SignatureVerificationRequest verificationRequest, string? traceid);
    
    /// <summary>
    /// Объединение подписей в единый sig-файл
    /// </summary>
    /// <param name="signatureUpdateRequest"></param>
    /// <param name="traceid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<SignatureUpdateResponse> MergeSignaturesAsync(SignatureMergeRequest signatureUpdateRequest, string? traceid, CancellationToken cancellationToken);
    
    /// <summary>
    /// Объединение подписей в единый sig-файл
    /// </summary>
    /// <param name="signatureUpdateRequest"></param>
    /// <param name="traceid"></param>
    /// <returns></returns>
    public SignatureUpdateResponse MergeSignatures(SignatureMergeRequest signatureUpdateRequest, string? traceid);
    
    /// <summary>
    /// Исключение подписантов из контейнера подписи
    /// </summary>
    /// <param name="signatureExcludeRequest">Структура данных: файл подписи и массив Certificate SerialNumber для исключения</param>
    /// <param name="traceid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<SignatureUpdateResponse> ExcludeSignersAsync(SignatureExcludeRequest signatureExcludeRequest, string? traceid, CancellationToken cancellationToken);
    
    /// <summary>
    /// Исключение подписантов из контейнера подписи
    /// </summary>
    /// <param name="signatureExcludeRequest">Структура данных: файл подписи и массив Certificate SerialNumber для исключения</param>
    /// <param name="traceid"></param>
    /// <returns></returns>
    public SignatureUpdateResponse ExcludeSigners(SignatureExcludeRequest signatureExcludeRequest, string? traceid);
}