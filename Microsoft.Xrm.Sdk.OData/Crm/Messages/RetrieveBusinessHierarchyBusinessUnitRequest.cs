using System;
using Microsoft.Xrm.Sdk.OData;
using Microsoft.Xrm.Sdk.OData.Query;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveBusinessHierarchyBusinessUnitRequest : OrganizationRequest
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
    public Guid EntityId
    {
        get
        {
            if (Parameters.Contains("EntityId"))
                return (Guid)Parameters["EntityId"];
            return default(Guid);
        }
        set { Parameters["EntityId"] = value; }
    }
    public RetrieveBusinessHierarchyBusinessUnitRequest()
    {
        this.ResponseType = new RetrieveBusinessHierarchyBusinessUnitResponse();
        this.RequestName = "RetrieveBusinessHierarchyBusinessUnit";
    }
    internal override string GetRequestBody()
    {
        Parameters["ColumnSet"] = ColumnSet;
        Parameters["EntityId"] = EntityId;
        return GetSoapBody();
    }
}