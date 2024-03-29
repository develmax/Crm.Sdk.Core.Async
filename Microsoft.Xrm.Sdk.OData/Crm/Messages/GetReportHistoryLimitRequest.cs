using System;
using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class GetReportHistoryLimitRequest : OrganizationRequest
{
    public Guid ReportId
    {
        get
        {
            if (Parameters.Contains("ReportId"))
                return (Guid)Parameters["ReportId"];
            return default(Guid);
        }
        set { Parameters["ReportId"] = value; }
    }
    public GetReportHistoryLimitRequest()
    {
        this.ResponseType = new GetReportHistoryLimitResponse();
        this.RequestName = "GetReportHistoryLimit";
    }
    internal override string GetRequestBody()
    {
        Parameters["ReportId"] = ReportId;
        return GetSoapBody();
    }
}