using System;
using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class CalculateTotalTimeIncidentRequest : OrganizationRequest
{
    public Guid IncidentId
    {
        get
        {
            if (Parameters.Contains("IncidentId"))
                return (Guid)Parameters["IncidentId"];
            return default(Guid);
        }
        set { Parameters["IncidentId"] = value; }
    }
    public CalculateTotalTimeIncidentRequest()
    {
        this.ResponseType = new CalculateTotalTimeIncidentResponse();
        this.RequestName = "CalculateTotalTimeIncident";
    }
    internal override string GetRequestBody()
    {
        Parameters["IncidentId"] = IncidentId;
        return GetSoapBody();
    }
}