namespace Microsoft.Xrm.Sdk.OData.Messages;

public sealed class GetValidManyToManyRequest : OrganizationRequest
{
    public GetValidManyToManyRequest()
    {
        this.ResponseType = new GetValidManyToManyResponse();
        this.RequestName = "GetValidManyToMany";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}