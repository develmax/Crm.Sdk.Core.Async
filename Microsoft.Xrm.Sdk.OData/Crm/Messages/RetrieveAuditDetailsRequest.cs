using System;
using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveAuditDetailsRequest : OrganizationRequest
{
    public Guid AuditId
    {
        get
        {
            if (Parameters.Contains("AuditId"))
                return (Guid)Parameters["AuditId"];
            return default(Guid);
        }
        set { Parameters["AuditId"] = value; }
    }
    public RetrieveAuditDetailsRequest()
    {
        this.ResponseType = new RetrieveAuditDetailsResponse();
        this.RequestName = "RetrieveAuditDetails";
    }
    internal override string GetRequestBody()
    {
        Parameters["AuditId"] = AuditId;
        return GetSoapBody();
    }
}