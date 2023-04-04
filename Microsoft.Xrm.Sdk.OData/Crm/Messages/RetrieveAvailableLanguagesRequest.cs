using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveAvailableLanguagesRequest : OrganizationRequest
{
    public RetrieveAvailableLanguagesRequest()
    {
        this.ResponseType = new RetrieveAvailableLanguagesResponse();
        this.RequestName = "RetrieveAvailableLanguages";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}