using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveApplicationRibbonRequest : OrganizationRequest
{
    public RetrieveApplicationRibbonRequest()
    {
        this.ResponseType = new RetrieveApplicationRibbonResponse();
        this.RequestName = "RetrieveApplicationRibbon";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}