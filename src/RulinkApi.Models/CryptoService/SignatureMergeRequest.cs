
using System.Text.Json;

namespace RulinkApi.Models.CryptoService;

public class SignatureMergeRequest : SignatureRequest
{
    public byte[]? SecondSignature { get; set; }
    public SignatureMergeRequest(byte[]? signature, byte[]? secondSignature) : base(signature)
    {
        SecondSignature = secondSignature;
    }
    public SignatureMergeRequest() : base()
    {
        SecondSignature = Array.Empty<byte>();
    }
    
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}