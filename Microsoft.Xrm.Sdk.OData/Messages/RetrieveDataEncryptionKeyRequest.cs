﻿namespace Microsoft.Xrm.Sdk.OData.Messages;

public sealed class RetrieveDataEncryptionKeyRequest : OrganizationRequest
{
    public RetrieveDataEncryptionKeyRequest()
    {
        this.ResponseType = new RetrieveDataEncryptionKeyResponse();
        this.RequestName = "RetrieveDataEncryptionKey";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}