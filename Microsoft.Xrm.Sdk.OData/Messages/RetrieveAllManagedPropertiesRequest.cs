namespace Microsoft.Xrm.Sdk.OData.Messages;

public sealed class RetrieveAllManagedPropertiesRequest : OrganizationRequest
{
    public RetrieveAllManagedPropertiesRequest()
    {
        this.ResponseType = new RetrieveAllManagedPropertiesResponse();
        this.RequestName = "RetrieveAllManagedProperties";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}