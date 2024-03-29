using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveAuditPartitionListRequest : OrganizationRequest
{
    public RetrieveAuditPartitionListRequest()
    {
        this.ResponseType = new RetrieveAuditPartitionListResponse();
        this.RequestName = "RetrieveAuditPartitionList";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}