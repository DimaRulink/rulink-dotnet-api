using RulinkApi.CryptoService;
using RulinkApi.CryptoService.Interfaces;
using RulinkApi.Models.CryptoService;

namespace RulinkApi.Test;

public class UnitTestCryptoService
{
    private ICryptoServiceClient _cryptoServiceClient;
    [SetUp]
    public void Setup()
    {
        _cryptoServiceClient = new CryptoServiceClient("https://rulink.io/api/v1/crypto", "your-api-key");
    }

    [Test]
    public void TestPing()
    {
        var result = _cryptoServiceClient.Ping(new CancellationToken()).Result;
        Assert.IsTrue(result.IsSuccess);
    }

    [Test]
    public void TestSignatureVerification()
    {
        var VerificationRequest = new SignatureVerificationRequest
        {
            Data = File.ReadAllBytes("data\\datafile.pdf"),
            Signature= File.ReadAllBytes("data\\datafile.pdf.sig"),
        };
        
        var result = _cryptoServiceClient.VerifySignature(VerificationRequest, "test");
        Assert.IsTrue(result.IsSuccess);
    }

    [Test]
    public void TestMergeSignature()
    {
        var mergeTwoSigFilesRequest = new SignatureMergeRequest()
        {
            Signature= File.ReadAllBytes("data\\datafile.pdf.sig"),
            SecondSignature = File.ReadAllBytes("data\\signatureFile2.sig")
        };
        
        var result = _cryptoServiceClient.MergeSignatures(mergeTwoSigFilesRequest, "test");
        Assert.IsTrue(result.IsSuccess);
    }

    [Test]
    public void TestExcludeSignerFromCmsContainer()
    {
        
        var exludeSignerRequest = new SignatureExcludeRequest()
        {
            Signature= File.ReadAllBytes("data\\SignatureWithManySigners.sig"),
            SerialNumberArray = ["01DA21C85D0D4EE00000000210EF0001"]
        };
        
        var result = _cryptoServiceClient.ExpulseSigners(exludeSignerRequest, "test");
        Assert.IsTrue(result.IsSuccess);
    }
}