﻿namespace Microsoft.Xrm.Sdk.OData.Messages;

public sealed class RetrieveTimestampRequest : OrganizationRequest
{
    public RetrieveTimestampRequest()
    {
        this.ResponseType = new RetrieveTimestampResponse();
        this.RequestName = "RetrieveTimestamp";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}