using System;
using Microsoft.Xrm.Sdk.OData;
using Microsoft.Xrm.Sdk.OData.Query;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class GenerateInvoiceFromOpportunityRequest : OrganizationRequest
{
    public Guid OpportunityId
    {
        get
        {
            if (Parameters.Contains("OpportunityId"))
                return (Guid)Parameters["OpportunityId"];
            return default(Guid);
        }
        set { Parameters["OpportunityId"] = value; }
    }
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
    public GenerateInvoiceFromOpportunityRequest()
    {
        this.ResponseType = new GenerateInvoiceFromOpportunityResponse();
        this.RequestName = "GenerateInvoiceFromOpportunity";
    }
    internal override string GetRequestBody()
    {
        Parameters["OpportunityId"] = OpportunityId;
        Parameters["ColumnSet"] = ColumnSet;
        return GetSoapBody();
    }
}