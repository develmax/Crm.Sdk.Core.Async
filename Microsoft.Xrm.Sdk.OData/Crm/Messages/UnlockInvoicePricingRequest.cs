using System;
using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class UnlockInvoicePricingRequest : OrganizationRequest
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
    public UnlockInvoicePricingRequest()
    {
        this.ResponseType = new UnlockInvoicePricingResponse();
        this.RequestName = "UnlockInvoicePricing";
    }
    internal override string GetRequestBody()
    {
        Parameters["InvoiceId"] = InvoiceId;
        return GetSoapBody();
    }
}