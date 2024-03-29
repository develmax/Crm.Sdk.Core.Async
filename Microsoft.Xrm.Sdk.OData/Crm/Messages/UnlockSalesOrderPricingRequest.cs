using System;
using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class UnlockSalesOrderPricingRequest : OrganizationRequest
{
    public Guid SalesOrderId
    {
        get
        {
            if (Parameters.Contains("SalesOrderId"))
                return (Guid)Parameters["SalesOrderId"];
            return default(Guid);
        }
        set { Parameters["SalesOrderId"] = value; }
    }
    public UnlockSalesOrderPricingRequest()
    {
        this.ResponseType = new UnlockSalesOrderPricingResponse();
        this.RequestName = "UnlockSalesOrderPricing";
    }
    internal override string GetRequestBody()
    {
        Parameters["SalesOrderId"] = SalesOrderId;
        return GetSoapBody();
    }
}