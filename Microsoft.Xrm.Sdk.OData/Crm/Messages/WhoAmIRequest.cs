using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class WhoAmIRequest : OrganizationRequest
{
    public WhoAmIRequest()
    {
        base.ResponseType = new WhoAmIResponse();
        base.RequestName = "WhoAmI";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}