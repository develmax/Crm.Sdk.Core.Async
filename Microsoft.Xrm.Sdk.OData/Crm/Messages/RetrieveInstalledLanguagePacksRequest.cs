using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveInstalledLanguagePacksRequest : OrganizationRequest
{
    public RetrieveInstalledLanguagePacksRequest()
    {
        this.ResponseType = new RetrieveInstalledLanguagePacksResponse();
        this.RequestName = "RetrieveInstalledLanguagePacks";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}