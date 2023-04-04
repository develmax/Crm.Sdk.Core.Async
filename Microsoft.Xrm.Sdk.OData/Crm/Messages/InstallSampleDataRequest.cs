using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class InstallSampleDataRequest : OrganizationRequest
{
    public InstallSampleDataRequest()
    {
        base.ResponseType = new InstallSampleDataResponse();
        base.RequestName = "InstallSampleData";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}