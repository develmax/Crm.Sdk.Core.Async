using System;
using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class AutoMapEntityRequest : OrganizationRequest
{
    public Guid EntityMapId
    {
        get
        {
            if (Parameters.Contains("EntityMapId"))
                return (Guid)Parameters["EntityMapId"];
            return default(Guid);
        }
        set { Parameters["EntityMapId"] = value; }
    }
    public AutoMapEntityRequest()
    {
        this.ResponseType = new AutoMapEntityResponse();
        this.RequestName = "AutoMapEntity";
    }
    internal override string GetRequestBody()
    {
        Parameters["EntityMapId"] = EntityMapId;
        return GetSoapBody();
    }
}