using Microsoft.Xrm.Sdk.OData;
using Microsoft.Xrm.Sdk.OData.Query;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveUnpublishedRequest : OrganizationRequest
{
    public ColumnSet ColumnSet
    {
        get
        {
            if (Parameters.Contains("ColumnSet"))
                return (ColumnSet)Parameters["ColumnSet"];
            return default(ColumnSet);
        }
        set { Parameters["ColumnSet"] = value; }
    }
    public EntityReference Target
    {
        get
        {
            if (Parameters.Contains("Target"))
                return (EntityReference)Parameters["Target"];
            return default(EntityReference);
        }
        set { Parameters["Target"] = value; }
    }
    public RetrieveUnpublishedRequest()
    {
        this.ResponseType = new RetrieveUnpublishedResponse();
        this.RequestName = "RetrieveUnpublished";
    }
    internal override string GetRequestBody()
    {
        Parameters["ColumnSet"] = ColumnSet;
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}