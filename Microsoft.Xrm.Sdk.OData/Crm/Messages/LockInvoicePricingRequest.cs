using System;
using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class LockInvoicePricingRequest : OrganizationRequest
{
    public Guid InvoiceId
    {
        get
        {
            if (Parameters.Contains("InvoiceId"))
                return (Guid)Parameters["InvoiceId"];
            return default(Guid);
        }
        set { Parameters["InvoiceId"] = value; }
    }
    public LockInvoicePricingRequest()
    {
        this.ResponseType = new LockInvoicePricingResponse();
        this.RequestName = "LockInvoicePricing";
    }
    internal override string GetRequestBody()
    {
        Parameters["InvoiceId"] = InvoiceId;
        return GetSoapBody();
    }
}