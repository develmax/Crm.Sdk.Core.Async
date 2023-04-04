using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class PublishAllXmlRequest : OrganizationRequest
{
    public PublishAllXmlRequest()
    {
        this.ResponseType = new PublishAllXmlResponse();
        this.RequestName = "PublishAllXml";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}