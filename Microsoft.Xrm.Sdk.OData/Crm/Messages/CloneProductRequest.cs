using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class CloneProductRequest : OrganizationRequest
{
    public EntityReference Source
    {
        get
        {
            if (Parameters.Contains("Source"))
                return (EntityReference)Parameters["Source"];
            return default(EntityReference);
        }
        set { Parameters["Source"] = value; }
    }
    public CloneProductRequest()
    {
        this.ResponseType = new CloneProductResponse();
        this.RequestName = "CloneProduct";
    }
    internal override string GetRequestBody()
    {
        Parameters["Source"] = Source;
        return GetSoapBody();
    }
}