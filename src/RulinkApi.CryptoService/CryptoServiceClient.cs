﻿using RulinkApi.HttpClient;
using RulinkApi.CryptoService.Interfaces;
using RulinkApi.Models;
using RulinkApi.Models.CryptoService;
using RulinkApi.Models.CryptoService.Signers;
using RulinkApi.Models.CryptoService.SignPackages;

namespace RulinkApi.CryptoService;

/// <summary>
/// Клиент для работы с сервисом электронной подписи
/// Swagger: https://rulink.io/api/v1/crypto/swagger/index.html
/// </summary>
public partial class CryptoServiceClient : ICryptoServiceClient
{
    private string BaseUrl { get; }
    public string Apikey { get; set; }
    
    public CryptoServiceClient(string baseUrl)
    {
        BaseUrl = baseUrl;
        Apikey = string.Empty;
    }
    
    public CryptoServiceClient(string baseUrl, string? apikey)
    {
        BaseUrl = baseUrl;
        Apikey = !string.IsNullOrEmpty(apikey) ? apikey : string.Empty;
    }
    
    public void SetApikey(string? apikey)
    {
        if (string.IsNullOrEmpty(apikey)) return;
        Apikey = apikey;
    }

    public async Task<GeneralResponse> Ping(CancellationToken cancellationToken)
    {
        var uri = Client.CreateUri(BaseUrl, "/cms/ping");
        var headers = Client.CreateHeaders(Apikey);
        var jsonResponse = await Client.GetAsync(uri, headers, cancellationToken);
        return GeneralResponse.FromJson(jsonResponse);
    }

    public async Task<SignatureVerificationResponse> VerifySignatureAsync(SignatureVerificationRequest verificationRequest, string? traceid, CancellationToken cancellationToken)
    {
        var uri = Client.CreateUri(BaseUrl, "/cms/signatures/validation");
        var headers = Client.CreateHeaders(Apikey, traceid);
        var jsonResponse = await Client.PostAsync(uri, verificationRequest.ToString(), headers, cancellationToken);
        return SignatureVerificationResponse.FromJson(jsonResponse);
    }

    public SignatureVerificationResponse VerifySignature(SignatureVerificationRequest verificationRequest, string? traceid)
    {
        return VerifySignatureAsync(verificationRequest, traceid, new CancellationToken()).Result;
    }

    public async Task<SignatureUpdateResponse> MergeSignaturesAsync(SignatureMergeRequest signatureUpdateRequest, string? traceid, CancellationToken cancellationToken)
    {
        var uri = Client.CreateUri(BaseUrl, "/cms/signatures/merger");
        var headers = Client.CreateHeaders(Apikey, traceid);
        var jsonResponse = await Client.PostAsync(uri, signatureUpdateRequest.ToString(), headers, cancellationToken);
        return SignatureUpdateResponse.FromJson(jsonResponse);
    }

    public SignatureUpdateResponse MergeSignatures(SignatureMergeRequest signatureUpdateRequest, string? traceid)
    {
        return MergeSignaturesAsync(signatureUpdateRequest, traceid, new CancellationToken()).Result;
    }

    public async Task<SignatureUpdateResponse> ExpulseSignersAsync(SignatureExcludeRequest signatureExcludeRequest, string? traceid, CancellationToken cancellationToken)
    {
        var uri = Client.CreateUri(BaseUrl, "/cms/signatures/expulsion");
        var headers = Client.CreateHeaders(Apikey, traceid);
        var jsonResponse = await Client.PostAsync(uri, signatureExcludeRequest.ToString(), headers, cancellationToken);
        return SignatureUpdateResponse.FromJson(jsonResponse);
    }

    public SignatureUpdateResponse ExpulseSigners(SignatureExcludeRequest signatureExcludeRequest, string? traceid)
    {
        return ExpulseSignersAsync(signatureExcludeRequest, traceid, new CancellationToken()).Result;
    }

    public async Task<SignPackagesResponse> GetSignPackagesAsync(string? traceid, CancellationToken cancellationToken)
    {
        var uri = Client.CreateUri(BaseUrl, "/packages");
        var headers = Client.CreateHeaders(Apikey, traceid);
        var jsonResponse = await Client.GetAsync(uri, headers, cancellationToken);
        return SignPackagesResponse.FromJson(jsonResponse);
    }

    public SignPackagesResponse GetSignPackages(string? traceid)
    {
        return GetSignPackagesAsync(traceid, new CancellationToken()).Result;
    }

    public async Task<SignPackagesResponse> GetSignPackageAsync(string packageid, string? traceid, CancellationToken cancellationToken)
    {
        var uri = Client.CreateUri(BaseUrl, $"/packages/{packageid}");
        var headers = Client.CreateHeaders(Apikey, traceid);
        var jsonResponse = await Client.GetAsync(uri, headers, cancellationToken);
        return SignPackagesResponse.FromJson(jsonResponse);
    }

    public SignPackagesResponse GetSignPackage(string packageid, string? traceid)
    {
        return GetSignPackageAsync(packageid, traceid, new CancellationToken()).Result;
    }

    public async Task<SignPackagesResponse> CreateSignPackageAsync(string? traceid, CancellationToken cancellationToken)
    {
        var uri = Client.CreateUri(BaseUrl, $"/packages");
        var headers = Client.CreateHeaders(Apikey, traceid);
        var jsonResponse = await Client.PostAsync(uri, null, headers, cancellationToken);
        return SignPackagesResponse.FromJson(jsonResponse);
    }

    public SignPackagesResponse CreateSignPackage(string? traceid)
    {
        return CreateSignPackageAsync(traceid, new CancellationToken()).Result;
    }

    public async Task<GeneralResponse> DeleteSignPackageAsync(string packageid, string? traceid, CancellationToken cancellationToken)
    {
        var uri = Client.CreateUri(BaseUrl, $"/packages/{packageid}");
        var headers = Client.CreateHeaders(Apikey, traceid);
        var jsonResponse = await Client.DeleteAsync(uri, headers, cancellationToken);
        return SignPackagesResponse.FromJson(jsonResponse);
    }

    public GeneralResponse DeleteSignPackage(string packageid, string? traceid)
    {
        return DeleteSignPackageAsync(packageid, traceid, new CancellationToken()).Result;
    }
    
    public async Task<GeneralResponse> UpdateSignPackageAsync(string packageid, string? description, string? traceid, CancellationToken cancellationToken)
    {
        var uri = Client.CreateUri(BaseUrl, $"/packages/{packageid}");
        var headers = Client.CreateHeaders(Apikey, traceid);
        var json = $"{{\"description\":\"{description}\"}}";
        var jsonResponse = await Client.PatchAsync(uri, json, headers, cancellationToken);
        return SignPackagesResponse.FromJson(jsonResponse);
    }
    
    public GeneralResponse UpdateSignPackage(string packageid, string? description, string? traceid)
    {
        return UpdateSignPackageAsync(packageid, description, traceid, new CancellationToken()).Result;
    }

    public async Task<AttachedFileResponse> AddFileToSignPackageAsync(string packageid, string filename, string? traceid, CancellationToken cancellationToken)
    {
        var uri = Client.CreateUri(BaseUrl, $"/packages/{packageid}/files");
        var headers = Client.CreateHeaders(Apikey, traceid);
        var json = $"{{\"filename\":\"{filename}\"}}";
        var jsonResponse = await Client.PostAsync(uri, json, headers, cancellationToken);
        return AttachedFileResponse.FromJson(jsonResponse);
    }

    public AttachedFileResponse AddFileToSignPackage(string packageid, string filename, string? traceid)
    {
        return AddFileToSignPackageAsync(packageid, filename, traceid, new CancellationToken()).Result;
    }



    public async Task<GeneralResponse> RemoveFileAsync(string? packageid, string? fileid, string? traceid, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(packageid) || string.IsNullOrEmpty(fileid))
            return new GeneralResponse()
            {
                IsSuccess = false,
                Message = "ContentUrl is empty",
                TraceId = traceid ?? string.Empty
            };
        var uri = Client.CreateUri(BaseUrl, $"/packages/{packageid}/files/{fileid}");
        var headers = Client.CreateHeaders(Apikey, traceid);
        await Client.DeleteAsync(uri, headers, cancellationToken);
        return new GeneralResponse()
        {
            IsSuccess = true,
            Message = "File removed",
            TraceId = traceid ?? string.Empty
        };
        //return GeneralResponse.FromJson(jsonResponse);
    }

    public GeneralResponse RemoveFile(string? packageid, string? fileid, string? traceid)
    {
        return RemoveFileAsync(packageid, fileid, traceid, new CancellationToken()).Result;
    }

    public async Task<AssignedFilesResponse> GetAssignedFilesAsync(string? packageid, string? signerid, string? traceid, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(packageid) || string.IsNullOrEmpty(signerid))
            return new AssignedFilesResponse()
            {
                IsSuccess = false,
                Message = "Не указан идентификатор пакета или подписанта",
                TraceId = traceid ?? string.Empty,
                Files = [],
                Signer = null
            };
        var uri = Client.CreateUri(BaseUrl, $"/packages/{packageid}/signers/{signerid}");
        var headers = Client.CreateHeaders(Apikey, traceid);
        var jsonResponse = await Client.GetAsync(uri, headers, cancellationToken);
        return AssignedFilesResponse.FromJson(jsonResponse);
    }
}