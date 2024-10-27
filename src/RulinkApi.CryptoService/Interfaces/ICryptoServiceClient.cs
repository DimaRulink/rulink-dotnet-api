using System.Security;
using RulinkApi.Models;
using RulinkApi.Models.CryptoService;
using RulinkApi.Models.CryptoService.SignPackages;

namespace RulinkApi.CryptoService.Interfaces;

/// <summary>
/// Клиент для работы с сервисом электронной подписи
/// Swagger: https://rulink.io/api/v1/crypto/swagger/index.html
/// </summary>
public interface ICryptoServiceClient
{
    /// <summary>
    /// Установка APIKEY
    /// </summary>
    /// <param name="apikey"></param>
    public void SetApikey(string? apikey);
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
    public Task<SignatureUpdateResponse> ExpulseSignersAsync(SignatureExcludeRequest signatureExcludeRequest, string? traceid, CancellationToken cancellationToken);
    
    /// <summary>
    /// Исключение подписантов из контейнера подписи
    /// </summary>
    /// <param name="signatureExcludeRequest">Структура данных: файл подписи и массив Certificate SerialNumber для исключения</param>
    /// <param name="traceid"></param>
    /// <returns></returns>
    public SignatureUpdateResponse ExpulseSigners(SignatureExcludeRequest signatureExcludeRequest, string? traceid);
    
    /// <summary>
    /// Получение списка пакетов подписания
    /// </summary>
    /// <param name="traceid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<SignPackagesResponse> GetSignPackagesAsync(string? traceid, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение списка пакетов подписания
    /// </summary>
    /// <param name="traceid"></param>
    /// <returns></returns>
    public SignPackagesResponse GetSignPackages(string? traceid);

    /// <summary>
    /// Получение пакета подписания
    /// </summary>
    /// <param name="packageid"></param>
    /// <param name="traceid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<SignPackagesResponse> GetSignPackageAsync(string packageid, string? traceid, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение пакета подписания
    /// </summary>
    /// <param name="packageid"></param>
    /// <param name="traceid"></param>
    /// <returns></returns>
    public SignPackagesResponse GetSignPackage(string packageid, string? traceid);
    
    /// <summary>
    /// Создание пакета подписания
    /// </summary>
    /// <param name="description"></param>
    /// <param name="traceid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<SignPackagesResponse> CreateSignPackageAsync(string? traceid, CancellationToken cancellationToken);
    
    /// <summary>
    /// Создание пакета подписания
    /// </summary>
    /// <param name="description"></param>
    /// <param name="traceid"></param>
    /// <returns></returns>
    public SignPackagesResponse CreateSignPackage(string? traceid);
    
    /// <summary>
    /// Удаление пакета подписания
    /// </summary>
    /// <param name="packageid"></param>
    /// <param name="traceid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<GeneralResponse> DeleteSignPackageAsync(string packageid, string? traceid, CancellationToken cancellationToken);
    
    /// <summary>
    /// Удаление пакета подписания
    /// </summary>
    /// <param name="packageid"></param>
    /// <param name="traceid"></param>
    /// <returns></returns>
    public GeneralResponse DeleteSignPackage(string packageid, string? traceid);
    
    /// <summary>
    /// Обновление поля комментарий пакета подписания
    /// </summary>
    /// <param name="packageid"></param>
    /// <param name="description"></param>
    /// <param name="traceid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<GeneralResponse> UpdateSignPackageAsync(string packageid, string? description, string? traceid, CancellationToken cancellationToken);
    
    /// <summary>
    /// Обновление поля комментарий пакета подписания
    /// </summary>
    /// <param name="packageid"></param>
    /// <param name="description"></param>
    /// <param name="traceid"></param>
    /// <returns></returns>
    public GeneralResponse UpdateSignPackage(string packageid, string? description, string? traceid);
}