using System;
using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ConvertKitToProductRequest : OrganizationRequest
{
    public Guid KitId
    {
        get
        {
            if (Parameters.Contains("KitId"))
                return (Guid)Parameters["KitId"];
            return default(Guid);
        }
        set { Parameters["KitId"] = value; }
    }
    public ConvertKitToProductRequest()
    {
        this.ResponseType = new ConvertKitToProductResponse();
        this.RequestName = "ConvertKitToProduct";
    }
    internal override string GetRequestBody()
    {
        Parameters["KitId"] = KitId;
        return GetSoapBody();
    }
}