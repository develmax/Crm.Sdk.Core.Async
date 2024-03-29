using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class GetAllTimeZonesWithDisplayNameRequest : OrganizationRequest
{
    public int LocaleId
    {
        get
        {
            if (Parameters.Contains("LocaleId"))
                return (int)Parameters["LocaleId"];
            return default(int);
        }
        set { Parameters["LocaleId"] = value; }
    }
    public GetAllTimeZonesWithDisplayNameRequest()
    {
        this.ResponseType = new GetAllTimeZonesWithDisplayNameResponse();
        this.RequestName = "GetAllTimeZonesWithDisplayName";
    }
    internal override string GetRequestBody()
    {
        Parameters["LocaleId"] = LocaleId;
        return GetSoapBody();
    }
}