using System;
using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RemoveFromQueueRequest : OrganizationRequest
{
    public Guid QueueItemId
    {
        get
        {
            if (Parameters.Contains("QueueItemId"))
                return (Guid)Parameters["QueueItemId"];
            return default(Guid);
        }
        set { Parameters["QueueItemId"] = value; }
    }
    public RemoveFromQueueRequest()
    {
        this.ResponseType = new RemoveFromQueueResponse();
        this.RequestName = "RemoveFromQueue";
    }
    internal override string GetRequestBody()
    {
        Parameters["QueueItemId"] = QueueItemId;
        return GetSoapBody();
    }
}