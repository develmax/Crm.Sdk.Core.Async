using Microsoft.Xrm.Sdk.OData;
using Microsoft.Xrm.Sdk.OData.Query;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class BackgroundSendEmailRequest : OrganizationRequest
{
    public QueryBase Query
    {
        get
        {
            if (Parameters.Contains("Query"))
                return (QueryBase)Parameters["Query"];
            return default(QueryBase);
        }
        set { Parameters["Query"] = value; }
    }
    public BackgroundSendEmailRequest()
    {
        this.ResponseType = new BackgroundSendEmailResponse();
        this.RequestName = "BackgroundSendEmail";
    }
    internal override string GetRequestBody()
    {
        Parameters["Query"] = Query;
        return GetSoapBody();
    }
}